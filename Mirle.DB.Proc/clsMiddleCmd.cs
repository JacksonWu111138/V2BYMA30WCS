using Mirle.DataBase;
using Mirle.DB.Proc.Events;
using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mirle.Structure.Info.VIDEnums;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Mirle.DB.Proc
{
    public class clsMiddleCmd
    {
        public delegate void PostionReportEventHandler(object sender, PositionReportArgs e);
        public event PostionReportEventHandler OnPostionReportEvent;
        private bool reportedFlag = false;
        protected readonly object _Lock = new object();
        private Fun.clsMiddleCmd MiddleCmd = new Fun.clsMiddleCmd();
        private Fun.clsCmd_Mst cmd_Mst = new Fun.clsCmd_Mst();
        private Fun.clsRoutdef routdef = new Fun.clsRoutdef();
        private Fun.clsTool tool = new Fun.clsTool();
        private clsDbConfig _config = new clsDbConfig();
        public clsMiddleCmd(clsDbConfig config)
        {
            _config = config;
        }

        public int FunGetMiddleCmd_Grid(ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return MiddleCmd.FunGetMiddleCmd_Grid(ref dtTmp, db);
                    }
                    else return iRet;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public bool FunMiddleCmdFinish_Proc(string DeviceID)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        if(MiddleCmd.GetFinishCommand(DeviceID, ref dtTmp, db) == DBResult.Success)
                        {
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                string sCmdSno = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.CommandID]);
                                CmdMstInfo cmd = new CmdMstInfo();
                                if(cmd_Mst.FunGetCommand(sCmdSno, ref cmd, ref iRet, db))
                                {
                                    string sCmdSts = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.CmdSts]);
                                    string sCmdMode = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.CmdMode]);
                                    string sCompleteCode = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.CompleteCode]);
                                    if (sCompleteCode == clsConstValue.CompleteCode.DoubleStorage ||
                                        sCompleteCode == clsConstValue.CompleteCode.EmptyRetrieval)
                                        continue; //二重格或空出庫，外部流程自行處理

                                    string sLocation = "";
                                    if (sCmdSts == clsConstValue.CmdSts.strCmd_Cancel_Wait)
                                    {
                                        sLocation = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.Source]);
                                    }
                                    else
                                    {
                                       sLocation = Convert.ToString(dtTmp.Rows[i][Fun.Parameter.clsMiddleCmd.Column.Destination]);
                                    }

                                    string sCurLoc = routdef.GetLocaionByCmdMode(sCmdMode, sCmdSts, DeviceID, sLocation, db);
                                    string sRemark = "";
                                    if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                    {
                                        sRemark = "Error: Begin失敗！";
                                        if (sRemark != cmd.Remark)
                                        {
                                            cmd_Mst.FunUpdateRemark(sCmdSno, sRemark, db);
                                        }

                                        continue;
                                    }

                                    if (!cmd_Mst.FunUpdateCurLoc(sCmdSno, DeviceID, sCurLoc, db))
                                    {
                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                        continue;
                                    }

                                    if (!MiddleCmd.FunInsertHisMiddleCmd(sCmdSno, db))
                                    {
                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                        continue;
                                    }

                                    if (!MiddleCmd.FunDelMiddleCmd(sCmdSno, db))
                                    {
                                        db.TransactionCtrl(TransactionTypes.Rollback);
                                        continue;
                                    }

                                    db.TransactionCtrl(TransactionTypes.Commit);

                                    lock (_Lock)
                                    {
                                        if (!reportedFlag)
                                        {
                                            reportedFlag = true;
                                            OnPostionReportEvent?.Invoke(this, new PositionReportArgs(DeviceID, sCurLoc, sCmdSno));
                                            reportedFlag = false;
                                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, $"觸發Position回報Event => " +
                                                $"<Device>{DeviceID} <Location>{sCurLoc} <{Fun.Parameter.clsCmd_Mst.Column.Cmd_Sno}>{sCmdSno}");
                                        }
                                    }

                                    return true;
                                }
                                else
                                {
                                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"<{Fun.Parameter.clsCmd_Mst.Column.Cmd_Sno}>{sCmdSno} => 取得命令資料失敗");
                                    continue;
                                }
                            }
                        }

                        return false;
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

        public bool FunMiddleCmdUpdateFinishByCommanId(string sCmdSno, ref string strEM)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        string strSql = $"select * from {Fun.Parameter.clsMiddleCmd.TableName} where " +
                            $"{Fun.Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}' ";
                        iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);

                        if (iRet == DBResult.Success)
                        {
                            MiddleCmd cmd = tool.GetMiddleCmd(dtTmp.Rows[0]);
                            string sRemark = "";

                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                            {
                                sRemark = "Error: Begin失敗！";
                                if (sRemark != cmd.Remark)
                                {
                                    FunMiddleCmdUpdateRemark(sCmdSno, sRemark, dtTmp, ref strEM);
                                }
                                return false;
                            }

                            sRemark = "命令完成";
                            if (!FunMiddleCmdUpdateCmdSts(sCmdSno, clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait, sRemark))
                            {
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                return false;
                            }

                            db.TransactionCtrl(TransactionTypes.Commit);
                            return true;
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

        public bool FunMiddleCmdUpdateRemark(string sCmdSno, string sRemark, DataTable dtTmp, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                      return MiddleCmd.FunMiddleCmdUpdateRemark(sCmdSno, sRemark, db, ref strEM);
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }
        
        public bool FunMiddleCmdUpdateCmdSts(string sCmdSno, string sCmdSts, string sRemark)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return MiddleCmd.FunMiddleCmdUpdateCmdSts(sCmdSno, sCmdSts, sRemark, db);
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool CheckHasMiddleCmdbyCmdSno(string sCmdSno)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = MiddleCmd.CheckHasMiddleCmdByCmdSno(sCmdSno, db);
                        if (iRet == DBResult.Success)
                            return true;
                        else return false;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool CheckHasMiddleCmdbyCSTID(string CSTID)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = MiddleCmd.CheckHasMiddleCmdByCSTID(CSTID, db);
                        if (iRet == DBResult.Success)
                            return true;
                        else return false;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunGetMiddleCmdbyCommandID(string CmdSno, ref MiddleCmd middleCmd)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return MiddleCmd.FunGetMiddleCmdbyCommandID(CmdSno, ref middleCmd, ref dtTmp, db);
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunInsMiddleCmd(MiddleCmd middleCmd)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return MiddleCmd.FunInsMiddleCmd(middleCmd, db);
                    }
                    else
                        return false;
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
