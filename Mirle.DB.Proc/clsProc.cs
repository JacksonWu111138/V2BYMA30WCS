using Mirle.DataBase;
using Mirle.Def;
using Mirle.Def.U2NMMA30;
using Mirle.EccsSignal;
using Mirle.MapController;
using Mirle.Middle;
using Mirle.Structure;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Mirle.DB.Proc
{
    public class clsProc
    {
        private Fun.clsCmd_Mst Cmd_Mst = new Fun.clsCmd_Mst();
        private Fun.clsLocMst LocMst = new Fun.clsLocMst();
        private Fun.clsTool tool = new Fun.clsTool();
        private Fun.clsRoutdef Routdef = new Fun.clsRoutdef();
        private Fun.clsMiddleCmd MiddleCmd = new Fun.clsMiddleCmd();
        private Fun.clsEquCmd EquCmd = new Fun.clsEquCmd();
        private clsDbConfig _config = new clsDbConfig();
        private WebAPI.V2BYMA30.clsHost api = new WebAPI.V2BYMA30.clsHost();
        private WebApiConfig _wmsApi = new WebApiConfig();
        private WebApiConfig _towerApi = new WebApiConfig();
        public clsProc(clsDbConfig config, WebApiConfig WmsApi_Config, WebApiConfig TowerApi_Config)
        {
            _config = config;
            _wmsApi = WmsApi_Config;
            _towerApi = TowerApi_Config;
        }

        public Fun.clsRoutdef GetFun_Routdef() => Routdef;

        public bool FunNormalCmd_Proc(string sAsrsStockInLocation_Sql, string sAsrsEquNo_Sql, MapHost Router, MidHost middle)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = Cmd_Mst.FunGetNormalCommand(sAsrsStockInLocation_Sql, sAsrsEquNo_Sql, ref dtTmp, db);
                        if (iRet == DBResult.Success)
                        {
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                CmdMstInfo cmd = tool.GetCommand(dtTmp.Rows[i]);
                                string sRemark = "";
                                Location Start = null; Location End = null;
                                if (!Routdef.FunGetLocation(cmd, Router, ref Start, ref End, db)) continue;
                                if (Start != End)
                                {
                                    Location sLoc_Start = null; Location sLoc_End = null;
                                    bool bCheck = Router.GetPath(Start, End, ref sLoc_Start, ref sLoc_End);
                                    if (bCheck == false)
                                    {
                                        sRemark = "Error: Route給出的路徑為Null，WCS給的Location => Start: <Device>" + Start.DeviceId + " <Location>" + Start.LocationId +
                                           "，End: <Device>" + End.DeviceId + " <Location>" + End.LocationId;
                                        if (sRemark != cmd.Remark)
                                        {
                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                        }

                                        continue;
                                    }
                                    else
                                    {
                                        if(sLoc_Start.DeviceId == sLoc_End.DeviceId)
                                        {//是電子料塔或AGV的命令
                                            string sDeviceID = "";
                                            if (!tool.IsAGV(sLoc_Start.DeviceId, ref sDeviceID))
                                            {
                                                sDeviceID = ConveyorDef.DeviceID_Tower;
                                            }

                                            ConveyorInfo conveyor = new ConveyorInfo();
                                            if(sLoc_Start.LocationTypes == LocationTypes.Conveyor)
                                            {
                                                conveyor = ConveyorDef.GetBuffer(sLoc_Start.LocationId);
                                            }

                                            ConveyorInfo conveyor_To = new ConveyorInfo();
                                            if (sLoc_End.LocationTypes == LocationTypes.Conveyor)
                                            {
                                                conveyor_To = ConveyorDef.GetBuffer(sLoc_End.LocationId);
                                            }

                                            if (!Routdef.CheckSourceIsOK_NonASRS(cmd, sLoc_Start, middle, conveyor, db)) continue;
                                            if (!Routdef.CheckDestinationIsOK_NonASRS(cmd, sLoc_End, middle, conveyor_To, db)) continue;
                                            MiddleCmd middleCmd = new MiddleCmd();
                                            if (!MiddleCmd.FunGetMiddleCmd_NonASRS(cmd, sLoc_Start, sLoc_End, ref middleCmd, sDeviceID, db)) continue;

                                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                            {
                                                sRemark = "Error: Begin失敗！";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            sRemark = $"下達Middle層命令 => <{Fun.Parameter.clsMiddleCmd.Column.DeviceID}>{sDeviceID}";
                                            if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }

                                            if (!MiddleCmd.FunInsMiddleCmd(middleCmd, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 下達Middle層命令失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            db.TransactionCtrl(TransactionTypes.Commit);
                                            return true;
                                        }
                                        else
                                        {
                                            if(cmd.Cmd_Sts == clsConstValue.CmdSts.strCmd_Initial)
                                            {
                                                var con = ConveyorDef.GetBuffer(sLoc_Start.LocationId);
                                                string sCmdSno_CV = "";
                                                if (!middle.CheckIsInReady(con, ref sCmdSno_CV))
                                                {
                                                    sRemark = $"Error: {con.BufferName}並非入庫Ready";
                                                    if (sRemark != cmd.Remark)
                                                    {
                                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                    }

                                                    continue;
                                                }
                                                else if (!string.IsNullOrWhiteSpace(sCmdSno_CV) && sCmdSno_CV != cmd.Cmd_Sno)
                                                {
                                                    sRemark = $"Error: {con.BufferName}已被其他任務預約 => {sCmdSno_CV}";
                                                    if (sRemark != cmd.Remark)
                                                    {
                                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                    }

                                                    continue;
                                                }
                                                else
                                                {
                                                    PositionReportInfo info = new PositionReportInfo
                                                    {
                                                        carrierId = cmd.BoxID,
                                                        inStock = clsConstValue.YesNo.No,
                                                        jobId = cmd.JobID,
                                                        location = sLoc_Start.LocationId
                                                    };

                                                    CVReceiveNewBinCmdInfo info_cv = new CVReceiveNewBinCmdInfo
                                                    {
                                                        bufferId = con.BufferName,
                                                        carrierType = cmd.carrierType,
                                                        jobId = cmd.Cmd_Sno
                                                    };

                                                    if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                                    {
                                                        sRemark = "Error: Begin失敗！";
                                                        if (sRemark != cmd.Remark)
                                                        {
                                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                        }

                                                        continue;
                                                    }

                                                    sRemark = $"預約{con.BufferName}";
                                                    if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                                    {
                                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                                        continue;
                                                    }

                                                    if (!api.GetCV_ReceiveNewBinCmd().FunReport(info_cv, con.API.IP))
                                                    {
                                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                                        sRemark = $"Error: 預約{con.BufferName}失敗";
                                                        if (sRemark != cmd.Remark)
                                                        {
                                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                        }

                                                        continue;
                                                    }

                                                    if (!api.GetPositionReport().FunReport(info, _wmsApi.IP))
                                                    {
                                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                                        sRemark = "Error: 上報Position Report失敗";
                                                        if (sRemark != cmd.Remark)
                                                        {
                                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                        }

                                                        continue;
                                                    }

                                                    db.TransactionCtrl(TransactionTypes.Commit);
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            return false;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunAsrsCmd_Proc(DeviceInfo Device, string StockInLoc_Sql, MapHost Router, 
            WMS.Proc.clsHost wms, MidHost middle, SignalHost CrnSignal)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = Cmd_Mst.FunGetCommand(Device.DeviceID, StockInLoc_Sql, ref dtTmp, db);
                        if (iRet == DBResult.Success)
                        {
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                CmdMstInfo cmd = tool.GetCommand(dtTmp.Rows[i]);
                                if (!Cmd_Mst.CheckCraneStatus(cmd, Device, CrnSignal, db)) continue;

                                string sRemark = "";
                                Location Start = null; Location End = null;
                                if (!Routdef.FunGetLocation(cmd, Router, ref Start, ref End, db)) continue;
                                if (Start != End)
                                {
                                    Location sLoc_Start = null; Location sLoc_End = null;
                                    bool bCheck = Router.GetPath(Start, End, ref sLoc_Start, ref sLoc_End);
                                    if (bCheck == false)
                                    {
                                        sRemark = "Error: Route給出的路徑為Null，WCS給的Location => Start: <Device>" + Start.DeviceId + " <Location>" + Start.LocationId +
                                           "，End: <Device>" + End.DeviceId + " <Location>" + End.LocationId;
                                        if (sRemark != cmd.Remark)
                                        {
                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                        }

                                        continue;
                                    }
                                    else
                                    {
                                        #region 判斷狀態
                                        if (!Routdef.CheckSourceIsOK(cmd, sLoc_Start, middle, Device, wms, db)) continue;
                                        if (!Routdef.CheckDestinationIsOK(cmd, sLoc_End, middle, Device, wms, db)) continue;
                                        iRet = MiddleCmd.CheckHasMiddleCmd(Device.DeviceID, db);
                                        if (iRet == DBResult.Success)
                                        {
                                            sRemark = $"Error: 等候Stocker{Device.DeviceID}的Fork命令淨空";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }
                                        else if (iRet == DBResult.Exception)
                                        {
                                            sRemark = $"Error: 取得Stocker{Device.DeviceID}的Fork命令失敗！";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }
                                        else { }
                                        #endregion 判斷狀態
                                        MiddleCmd middleCmd = new MiddleCmd();
                                        if (!MiddleCmd.FunGetMiddleCmd(cmd, sLoc_Start, sLoc_End, ref middleCmd, db)) continue;

                                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                        {
                                            sRemark = "Error: Begin失敗！";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }

                                        sRemark = $"下達Middle層命令 => <{Fun.Parameter.clsMiddleCmd.Column.DeviceID}>{sLoc_Start.DeviceId}";
                                        if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                        {
                                            db.TransactionCtrl(TransactionTypes.Rollback);
                                            continue;
                                        }

                                        if (!MiddleCmd.FunInsMiddleCmd(middleCmd, db))
                                        {
                                            db.TransactionCtrl(TransactionTypes.Rollback);
                                            sRemark = "Error: 下達Middle層命令失敗";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }

                                        db.TransactionCtrl(TransactionTypes.Commit);
                                        return true;
                                    }
                                }
                                else continue;
                            }

                            return false;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunAsrsCmd_DoubleCV_Proc(DeviceInfo Device, string StockInLoc_Sql, MapHost Router,
            WMS.Proc.clsHost wms, MidHost middle, SignalHost CrnSignal)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = Cmd_Mst.FunGetCommand(Device.DeviceID, StockInLoc_Sql, ref dtTmp, db);
                        if (iRet == DBResult.Success)
                        {
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                CmdMstInfo cmd = tool.GetCommand(dtTmp.Rows[i]);
                                if (!Cmd_Mst.CheckCraneStatus(cmd, Device, CrnSignal, db)) continue;

                                string sRemark = "";
                                Location Start = null; Location End = null;
                                if (!Routdef.FunGetLocation(cmd, Router, ref Start, ref End, db)) continue;
                                if (Start != End)
                                {
                                    Location sLoc_Start = null; Location sLoc_End = null;
                                    bool bCheck = Router.GetPath(Start, End, ref sLoc_Start, ref sLoc_End);
                                    if (bCheck == false)
                                    {
                                        sRemark = "Error: Route給出的路徑為Null，WCS給的Location => Start: <Device>" + Start.DeviceId + " <Location>" + Start.LocationId +
                                           "，End: <Device>" + End.DeviceId + " <Location>" + End.LocationId;
                                        if (sRemark != cmd.Remark)
                                        {
                                            Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                        }

                                        continue;
                                    }
                                    else
                                    {
                                        bool IsDoubleCmd = false; CmdMstInfo cmd_DD = new CmdMstInfo();
                                        string[] sCmdSno_CV = new string[2];
                                        #region 判斷狀態
                                        if (!Routdef.CheckSourceIsOK(cmd, sLoc_Start, middle, Device, wms, ref IsDoubleCmd, ref cmd_DD,
                                            ref sCmdSno_CV, db))
                                            continue;

                                        if(IsDoubleCmd)
                                        {
                                            if (!sCmdSno_CV.Where(r => r == cmd.Cmd_Sno).Any())
                                            {
                                                sRemark = $"Error: 此序號跟Buffer的序號不一樣 => <Left>{sCmdSno_CV[0]} <Right>{sCmdSno_CV[1]}";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            if (!sCmdSno_CV.Where(r => r == cmd_DD.Cmd_Sno).Any())
                                            {
                                                sRemark = $"Error: 此序號跟Buffer的序號不一樣 => <Left>{sCmdSno_CV[0]} <Right>{sCmdSno_CV[1]}";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd_DD.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            if (!sCmdSno_CV.Where(r => r == cmd.Cmd_Sno).Any())
                                            {
                                                sRemark = $"Error: 此序號跟Buffer的序號{sCmdSno_CV[0]}不一樣";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }
                                        }

                                        if (!Routdef.CheckDestinationIsOK(cmd, sLoc_End, middle, Device, wms, IsDoubleCmd, db)) continue;


                                        iRet = MiddleCmd.CheckHasMiddleCmd(Device.DeviceID, db);
                                        if (iRet == DBResult.Success)
                                        {
                                            sRemark = $"Error: 等候Stocker{Device.DeviceID}的Fork命令淨空";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }
                                        else if (iRet == DBResult.Exception)
                                        {
                                            sRemark = $"Error: 取得Stocker{Device.DeviceID}的Fork命令失敗！";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }
                                        else { }
                                        #endregion 判斷狀態
                                        MiddleCmd middleCmd = new MiddleCmd();
                                        MiddleCmd middleCmd_DD = new MiddleCmd();
                                        if (!MiddleCmd.FunGetMiddleCmd(cmd, sLoc_Start, sLoc_End, ref middleCmd, ref middleCmd_DD, IsDoubleCmd, cmd_DD, Router, db))
                                            continue;
                                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                        {
                                            sRemark = "Error: Begin失敗！";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }

                                        sRemark = $"下達Middle層命令 => <{Fun.Parameter.clsMiddleCmd.Column.DeviceID}>{sLoc_Start.DeviceId}";
                                        if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                        {
                                            db.TransactionCtrl(TransactionTypes.Rollback);
                                            continue;
                                        }

                                        if(IsDoubleCmd)
                                        {
                                            if (!Cmd_Mst.FunUpdateCmdSts(cmd_DD.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }
                                        }

                                        if (!MiddleCmd.FunInsMiddleCmd(middleCmd, db))
                                        {
                                            db.TransactionCtrl(TransactionTypes.Rollback);
                                            sRemark = "Error: 下達Middle層命令失敗";
                                            if (sRemark != cmd.Remark)
                                            {
                                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                            }

                                            continue;
                                        }

                                        if (IsDoubleCmd)
                                        {
                                            if (!MiddleCmd.FunInsMiddleCmd(middleCmd_DD, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 下達Middle層命令失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd_DD.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }
                                        }

                                        db.TransactionCtrl(TransactionTypes.Commit);
                                        return true;
                                    }
                                }
                                else continue;
                            }

                            return false;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }
        /// <summary>
        /// 處理空出/二重格的情況
        /// </summary>
        /// <returns></returns>
        public bool FunAsrsCmd_AbnormalFinish_Proc()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        switch(MiddleCmd.GetAbnormalFinishCommand(ref dtTmp, db))
                        {
                            case DBResult.Success:
                                for (int i = 0; i < dtTmp.Rows.Count; i++)
                                {
                                    string sRemark = ""; string strEM = "";
                                    MiddleCmd middleCmd = tool.GetMiddleCmd(dtTmp.Rows[i]);
                                    CmdMstInfo cmd = new CmdMstInfo();
                                    if (Cmd_Mst.FunGetCommand(middleCmd.CommandID, ref cmd, ref iRet, db))
                                    {
                                        if (middleCmd.CompleteCode == clsConstValue.CompleteCode.EmptyRetrieval)
                                        {
                                            #region 空出庫流程
                                            CarrierShelfCompleteInfo shelfCompleteInfo = new CarrierShelfCompleteInfo();
                                            CarrierRetrieveCompleteInfo retrieveCompleteInfo = new CarrierRetrieveCompleteInfo();
                                            if (cmd.Cmd_Mode == clsConstValue.CmdMode.StockOut)
                                            {
                                                retrieveCompleteInfo = new CarrierRetrieveCompleteInfo
                                                {
                                                    carrierId = cmd.BoxID,
                                                    emptyTransfer = clsEnum.WmsApi.EmptyRetrieval.Y.ToString(),
                                                    isComplete = clsConstValue.YesNo.Yes,
                                                    jobId = cmd.JobID,
                                                    location = "",
                                                    portId = ""
                                                };
                                            }
                                            else
                                            {
                                                shelfCompleteInfo = new CarrierShelfCompleteInfo
                                                {
                                                    carrierId = cmd.BoxID,
                                                    emptyTransfer = clsEnum.WmsApi.EmptyRetrieval.Y.ToString(),
                                                    jobId = cmd.JobID,
                                                    shelfId = ""
                                                };
                                            }

                                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                            {
                                                sRemark = "Error: Begin失敗！";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            sRemark = "Error: 儲位空出庫";
                                            if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Finish_Wait, clsEnum.Cmd_Abnormal.E2, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }

                                            if (!MiddleCmd.FunInsertHisMiddleCmd(cmd.Cmd_Sno, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: insert MiddleCmd_His失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            if (!MiddleCmd.FunDelMiddleCmd(cmd.Cmd_Sno, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 刪除MiddleCmd失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                }

                                                continue;
                                            }

                                            if (cmd.Cmd_Mode == clsConstValue.CmdMode.StockOut)
                                            {
                                                if (!api.GetCarrierRetrieveComplete().FunReport(retrieveCompleteInfo, _wmsApi.IP))
                                                {
                                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                                    sRemark = "Error: 上報RetrieveComplete失敗";
                                                    if (sRemark != cmd.Remark)
                                                    {
                                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                    }

                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                if (!api.GetCarrierShelfComplete().FunReport(shelfCompleteInfo, _wmsApi.IP))
                                                {
                                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                                    sRemark = "Error: 上報ShelfComplete失敗";
                                                    if (sRemark != cmd.Remark)
                                                    {
                                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                                    }

                                                    continue;
                                                }
                                            }

                                            db.TransactionCtrl(TransactionTypes.Commit);
                                            return true;
                                            #endregion 空出庫流程
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {
                                        sRemark = $"Error: 找不到系統命令";
                                        if(sRemark != middleCmd.Remark)
                                        {
                                            MiddleCmd.FunMiddleCmdUpdateRemark(middleCmd.CommandID, sRemark, db, ref strEM);
                                        }
                                    }
                                }

                                return false;
                            case DBResult.NoDataSelect:
                                return true;
                            default:
                                return false;
                        }
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool subCraneWrR2R(DeviceInfo Device, SignalHost CrnSignal)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = Cmd_Mst.FunGetR2RCommand(Device.DeviceID, ref dtTmp, db);
                        if (iRet == DBResult.Success)
                        {
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                CmdMstInfo cmd = tool.GetCommand(dtTmp.Rows[i]);
                                int iEquNo_To = tool.funGetEquNoByLoc(cmd.New_Loc);
                                if (int.Parse(cmd.Equ_No) != iEquNo_To) continue;
                                if (!Cmd_Mst.CheckCraneStatus(cmd, Device, CrnSignal, db)) continue;
                                string sRemark = "";
                                iRet = MiddleCmd.CheckHasMiddleCmd(Device.DeviceID, db);
                                if (iRet == DBResult.Success)
                                {
                                    sRemark = $"Error: 等候Stocker{Device.DeviceID}的Fork命令淨空";
                                    if (sRemark != cmd.Remark)
                                    {
                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                    }

                                    continue;
                                }
                                else if (iRet == DBResult.Exception)
                                {
                                    sRemark = $"Error: 取得Stocker{Device.DeviceID}的Fork命令失敗！";
                                    if (sRemark != cmd.Remark)
                                    {
                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                    }

                                    continue;
                                }
                                else { }

                                MiddleCmd middleCmd = new MiddleCmd();
                                if (!MiddleCmd.FunGetMiddleCmd_R2R(cmd, ref middleCmd, db)) continue;

                                if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                {
                                    sRemark = "Error: Begin失敗！";
                                    if (sRemark != cmd.Remark)
                                    {
                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                    }

                                    continue;
                                }

                                sRemark = $"下達Middle層命令 => <{Fun.Parameter.clsMiddleCmd.Column.DeviceID}>{Device.DeviceID}";
                                if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Running, sRemark, db))
                                {
                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                    continue;
                                }

                                if (!MiddleCmd.FunInsMiddleCmd(middleCmd, db))
                                {
                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                    sRemark = "Error: 下達Middle層命令失敗";
                                    if (sRemark != cmd.Remark)
                                    {
                                        Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                    }

                                    continue;
                                }

                                db.TransactionCtrl(TransactionTypes.Commit);
                                return true;
                            }

                            return false;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunAGVTaskCancel(string sCmdSno, ref string strEM, string IP)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        string sRemark = "";
                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                        {
                            sRemark = "Error: Begin失敗！";
                            Cmd_Mst.FunUpdateRemark(sCmdSno, sRemark, db);
                            return false;
                        }

                        sRemark = "";
                        if(!Cmd_Mst.FunUpdateCmdSts(sCmdSno, clsConstValue.CmdSts.strCmd_Cancel_Wait,sRemark, db))
                        {
                            db.TransactionCtrl(TransactionTypes.Rollback);
                            return false;
                        }

                        if (!MiddleCmd.FunMiddleCmdUpdateCmdSts(sCmdSno, clsConstValue.CmdSts.strCmd_Cancel_Wait, sRemark, db))
                        {
                            db.TransactionCtrl(TransactionTypes.Rollback);
                            return false;
                        }

                        //call api
                        TaskCancelInfo info = new TaskCancelInfo
                        {
                            jobId = sCmdSno
                        };

                        if (!api.GetTaskCancel().FunReport(info, IP))
                        {
                            MessageBox.Show($"取消命令失敗, jobId:{info.jobId}.", "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.TransactionCtrl(TransactionTypes.Rollback);
                            return false;
                        }
                        else
                        {
                            MessageBox.Show($"取消命令成功, jobId:{info.jobId}.", "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        db.TransactionCtrl(TransactionTypes.Commit);
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunCarrierTransferCancel(string sCmdSno, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        CmdMstInfo cmd = new CmdMstInfo();
                        if(Cmd_Mst.FunGetCommandByJobID(sCmdSno, ref cmd, ref iRet, db))
                        {
                            if (cmd.Cmd_Sts == clsConstValue.CmdSts.strCmd_Running)
                            {
                                strEM = "Error: 命令已開始執行，無法取消！";
                                return false;
                            }

                            int iRet_Middle = MiddleCmd.CheckHasMiddleCmdByCmdSno(cmd.Cmd_Sno, db);
                            if (iRet_Middle == DBResult.Exception)
                            {
                                strEM = "取得Middle命令失敗！";
                                return false;
                            }

                            int iRet_Equ = EquCmd.CheckHasEquCmdByCmdSno(cmd.Cmd_Sno, db);
                            if(iRet_Equ == DBResult.Exception)
                            {
                                strEM = "取得Equ命令失敗！";
                                return false;
                            }
                            if (iRet_Middle == DBResult.Success)
                                MiddleCmd.FunInsertHisMiddleCmd(cmd.Cmd_Sno, db);

                            string sRemark = ""; 
                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                            {
                                sRemark = "Error: Begin失敗！";
                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                return false;
                            }

                            sRemark = "WES命令取消";
                            if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Cancel_Wait, sRemark, db))
                            {
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                return false;
                            }

                            if (iRet_Middle == DBResult.Success)
                            {
                                if (!MiddleCmd.FunDelMiddleCmd(cmd.Cmd_Sno, db))
                                {
                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                    return false;
                                }

                            }

                            if (iRet_Equ == DBResult.Success)
                            {
                                if (!EquCmd.FunDelEquCmd(cmd.Cmd_Sno, db))
                                {
                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                    return false;
                                }
                            }

                            db.TransactionCtrl(TransactionTypes.Commit);
                            return true;
                        }
                        else
                        {
                            strEM = $"<JobID> {sCmdSno} => 取得命令資料失敗！";
                            return false;
                        }
                    }
                    else
                    {
                        strEM = "Error: 開啟DB失敗！";
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strEM);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunLotTransferCancel(string sCmdSno, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        CmdMstInfo cmd = new CmdMstInfo();
                        if (Cmd_Mst.FunGetCommand(sCmdSno, ref cmd, ref iRet, db))
                        {
                            if (cmd.Cmd_Sts == clsConstValue.CmdSts.strCmd_Running)
                            {
                                strEM = "Error: 命令已開始執行，無法取消！";
                                return false;
                            }

                            string sRemark = "";
                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                            {
                                sRemark = "Error: Begin失敗！";
                                Cmd_Mst.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                                return false;
                            }

                            sRemark = "WES命令取消";
                            if (!Cmd_Mst.FunUpdateCmdSts(cmd.Cmd_Sno, clsConstValue.CmdSts.strCmd_Cancel_Wait, sRemark, db))
                            {
                                strEM = "Error: 更新CmdMst.CmdSts失敗";
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                return false;
                            }

                            //對E800C下達LotCancel
                            LotTransferCancelInfo lotcancel_info = new LotTransferCancelInfo
                            {
                                jobId = cmd.Cmd_Sno,
                                lotId = cmd.BoxID
                            };
                            if(!api.GetLotTransferCancel().FunReport(lotcancel_info, _towerApi.IP))
                            {
                                strEM = "Error: 下達LotCancel命令給E800C失敗";
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                return false;
                            }

                            db.TransactionCtrl(TransactionTypes.Commit);
                            return true;
                        }
                        else
                        {
                            strEM = $"<JobID> {sCmdSno} => 取得命令資料失敗！";
                            return false;
                        }
                    }
                    else
                    {
                        strEM = "Error: 開啟DB失敗！";
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strEM);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }
    }
}
