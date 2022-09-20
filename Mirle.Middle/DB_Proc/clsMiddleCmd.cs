using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Structure;
using System.Threading.Tasks;
using Mirle.Def;
using Mirle.DataBase;
using System.Data;
using Mirle.WebAPI.V2BYMA30.ReportInfo;

namespace Mirle.Middle.DB_Proc
{
    public class clsMiddleCmd
    {
        private clsDbConfig _config = new clsDbConfig();
        private clsTool tool;
        private clsEquCmd EquCmd;
        private WebAPI.V2BYMA30.clsHost api = new WebAPI.V2BYMA30.clsHost();
        private static List<ConveyorInfo> Node_All = new List<ConveyorInfo>();
        private string sDeviceID_AGV = "";
        private string sDeviceID_Tower = "";
        private WebApiConfig _agvApi = new WebApiConfig();
        private WebApiConfig _towerApi = new WebApiConfig();
        public clsMiddleCmd(clsDbConfig config, DeviceInfo[] PCBA, DeviceInfo[] Box, List<ConveyorInfo> conveyors,
            string DeviceID_AGV, string DeviceID_Tower, WebApiConfig AgvApi_Config, WebApiConfig TowerApi_Config)
        {
            tool = new clsTool(PCBA, Box);
            EquCmd = new clsEquCmd(config);
            _config = config;
            Node_All = conveyors;
            sDeviceID_AGV = DeviceID_AGV;
            sDeviceID_Tower = DeviceID_Tower;
            _agvApi = AgvApi_Config;
            _towerApi = TowerApi_Config;
        }

        public ConveyorInfo GetCV_ByCmdLoc(MiddleCmd cmd, string Loc, DB db)
        {
            var lst = Node_All.Where(r => r.BufferName == Loc);
            if (lst == null || lst.Count() == 0)
            {
                string sRemark = $"Error: {Loc}不存在在所有節點裡";
                if (sRemark != cmd.Remark)
                {
                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                }

                return new ConveyorInfo();
            }

            ConveyorInfo conveyor = new ConveyorInfo();
            foreach (var cv in lst)
            {
                conveyor = cv;
                break;
            }

            return conveyor;
        }

        public bool FunUpdateCmdSts(MiddleCmd[] cmds, string sCmdSts, string sRemark, DB db)
        {
            try
            {
                string CmdSno_Sql = "";
                for (int i = 0; i < cmds.Length; i++)
                {
                    if (i == 0) CmdSno_Sql = $"'{cmds[i].CommandID}'";
                    else CmdSno_Sql += $",'{cmds[i].CommandID}'";
                }

                string strSql = $"update {Parameter.clsMiddleCmd.TableName} set" +
                    $" {Parameter.clsMiddleCmd.Column.Remark} = N'" + sRemark +
                    $"', {Parameter.clsMiddleCmd.Column.CmdSts} = '{sCmdSts}' ";

                if (sCmdSts == clsConstValue.CmdSts_MiddleCmd.strCmd_Cancel_Wait || sCmdSts == clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait)
                {
                    strSql += $", {Parameter.clsMiddleCmd.Column.EndDate} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                else
                {
                    strSql += $", {Parameter.clsMiddleCmd.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }

                strSql += $" where {Parameter.clsMiddleCmd.Column.CommandID} in ({CmdSno_Sql}) ";

                string strEM = "";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
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

        public bool MiddleCmd_Proc()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                            $"{Parameter.clsMiddleCmd.Column.CmdSts} < '{clsConstValue.CmdSts_MiddleCmd.strCmd_WriteDeviceCmd}' " +
                            $"ORDER BY {Parameter.clsMiddleCmd.Column.Priority}, {Parameter.clsMiddleCmd.Column.Create_Date}, " +
                            $"{Parameter.clsMiddleCmd.Column.CommandID}";
                        string strEM = "";
                        iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                        if (iRet == DBResult.Success)
                        {
                            string sRemark = "";
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                MiddleCmd cmd = tool.GetMiddleCmd(dtTmp.Rows[i]);
                                DeviceInfo device = new DeviceInfo(); clsEnum.AsrsType type = clsEnum.AsrsType.None;
                                if (tool.CheckDeviceMatchCraneDevice(cmd.DeviceID, ref device, ref type))
                                {
                                    if (!EquCmd.funCheckCanInsertEquCmd(cmd.DeviceID, db))
                                    {
                                        sRemark = $"Error: 等候Line{cmd.DeviceID}命令完成";
                                        if (sRemark != cmd.Remark)
                                        {
                                            EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                        }

                                        continue;
                                    }

                                    if(type == clsEnum.AsrsType.Box)
                                    {
                                        bool IsBatch = !string.IsNullOrWhiteSpace(cmd.BatchID);
                                        if (IsBatch)
                                        {
                                            var batch = from myRow in dtTmp.AsEnumerable()
                                                        where myRow.Field<string>(Parameter.clsMiddleCmd.Column.BatchID) == cmd.BatchID
                                                        select myRow;
                                            MiddleCmd[] BatchCmd = new MiddleCmd[2];
                                            int idx = 0;
                                            foreach(var data in batch)
                                            {
                                                if (idx > 1) break;

                                                BatchCmd[idx] = tool.GetMiddleCmd(data);
                                                idx++;
                                            }

                                            if (cmd.CmdSts == clsConstValue.CmdSts_MiddleCmd.strCmd_Initial)
                                            {
                                                switch (cmd.CmdMode)
                                                {
                                                    case clsConstValue.CmdMode.StockIn:
                                                    case clsConstValue.CmdMode.L2L:
                                                        EquCmdInfo equCmd = new EquCmdInfo
                                                        {
                                                            CmdSno = cmd.CommandID,
                                                            CmdMode = cmd.CmdMode,
                                                            CmdSts = clsConstValue.CmdSts.strCmd_Initial,
                                                            CarNo = "1",
                                                            EquNo = cmd.DeviceID,
                                                            LocSize = " ",
                                                            Priority = cmd.Priority.ToString(),
                                                            SpeedLevel = "5"
                                                        };

                                                        if (cmd.CmdMode == clsConstValue.CmdMode.StockIn)
                                                        {
                                                            ConveyorInfo[] conveyors = new ConveyorInfo[2];
                                                            for (int con = 0; con < BatchCmd.Length; con++)
                                                            {
                                                                conveyors[con] = GetCV_ByCmdLoc(BatchCmd[con], BatchCmd[con].Source, db);
                                                            }

                                                            var right = conveyors.Where(r => r.DoubleType == DoubleType.Right);
                                                            foreach (var r in right)
                                                            {
                                                                equCmd.Source = r.StkPortID.ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            for (int con = 0; con < BatchCmd.Length; con++)
                                                            {
                                                                if(tool.GetShelfLocation(BatchCmd[con].Source) == clsEnum.Shelf.OutSide)
                                                                {
                                                                    equCmd.Source = tool.GetEquCmdLoc_BySysCmd(BatchCmd[con].Source);
                                                                    break;
                                                                }
                                                            }
                                                        }

                                                        for (int con = 0; con < BatchCmd.Length; con++)
                                                        {
                                                            if (tool.GetShelfLocation(BatchCmd[con].Destination) == clsEnum.Shelf.OutSide)
                                                            {
                                                                equCmd.Destination = tool.GetEquCmdLoc_BySysCmd(BatchCmd[con].Destination);
                                                                break;
                                                            }
                                                        }

                                                        if (FunWriEquCmd_DoubleProc(BatchCmd, equCmd, db)) return true;
                                                        else continue;

                                                    case clsConstValue.CmdMode.StockOut:
                                                    case clsConstValue.CmdMode.S2S:
                                                        ConveyorInfo[] conveyors_To = new ConveyorInfo[2];
                                                        CVReceiveNewBinCmdInfo[] infos = new CVReceiveNewBinCmdInfo[2];
                                                        for (int con = 0; con < BatchCmd.Length; con++)
                                                        {
                                                            conveyors_To[con] = GetCV_ByCmdLoc(BatchCmd[con], BatchCmd[con].Destination, db);
                                                            if (string.IsNullOrWhiteSpace(conveyors_To[con].BufferName)) return false;

                                                            infos[con] = new CVReceiveNewBinCmdInfo
                                                            {
                                                                bufferId = conveyors_To[con].BufferName,
                                                                jobId = BatchCmd[con].CommandID,
                                                                carrierType = BatchCmd[con].carrierType
                                                            };
                                                        }

                                                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                                        {
                                                            sRemark = "Error: Begin失敗！";
                                                            for (int count = 0; count < BatchCmd.Length; count++)
                                                            {
                                                                if (sRemark != BatchCmd[count].Remark)
                                                                {
                                                                    EquCmd.FunUpdateRemark_MiddleCmd(BatchCmd[count].CommandID, sRemark, db);
                                                                }
                                                            }

                                                            continue;
                                                        }

                                                        bool bCheck = true;
                                                        for (int count = 0; count < BatchCmd.Length; count++)
                                                        {
                                                            sRemark = $"預約{conveyors_To[count].BufferName}";
                                                            if (!EquCmd.FunUpdateCmdSts_MiddleCmd(BatchCmd[count].CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteCV, sRemark, db))
                                                            {
                                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                                bCheck = false;
                                                            }

                                                            if (!bCheck) break;
                                                        }

                                                        if (!bCheck) continue;

                                                        bCheck = true;
                                                        for (int count = 0; count < BatchCmd.Length; count++)
                                                        {
                                                            if (!api.GetCV_ReceiveNewBinCmd().FunReport(infos[count], conveyors_To[count].API.IP))
                                                            {
                                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                                sRemark = $"Error: 預約{conveyors_To[count].BufferName}失敗！";
                                                                if (sRemark != cmd.Remark)
                                                                {
                                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                                }

                                                                bCheck = false;
                                                            }

                                                            if (!bCheck) break;
                                                        }

                                                        if (!bCheck) continue;

                                                        db.TransactionCtrl(TransactionTypes.Commit);
                                                        return true;
                                                    default:
                                                        continue;
                                                }
                                            }
                                            else
                                            {//CmdSts=1 已預約目的站
                                                switch (cmd.CmdMode)
                                                {
                                                    case clsConstValue.CmdMode.L2L:
                                                    case clsConstValue.CmdMode.StockIn:
                                                        if (FunUpdateCmdSts(BatchCmd, clsConstValue.CmdSts_MiddleCmd.strCmd_Initial, "", db)) return true;
                                                        else continue;
                                                }

                                                EquCmdInfo equCmd = new EquCmdInfo
                                                {
                                                    CmdSno = cmd.CommandID,
                                                    CmdMode = cmd.CmdMode,
                                                    CmdSts = clsConstValue.CmdSts.strCmd_Initial,
                                                    CarNo = "1",
                                                    EquNo = cmd.DeviceID,
                                                    LocSize = " ",
                                                    Priority = cmd.Priority.ToString(),
                                                    SpeedLevel = "5"
                                                };

                                                ConveyorInfo[] conveyors_To = new ConveyorInfo[2];
                                                for (int con = 0; con < BatchCmd.Length; con++)
                                                {
                                                    conveyors_To[con] = GetCV_ByCmdLoc(BatchCmd[con], BatchCmd[con].Destination, db);
                                                    if (conveyors_To[con].DoubleType == DoubleType.Left)
                                                    {
                                                        equCmd.Destination = conveyors_To[con].StkPortID.ToString();
                                                        break;
                                                    }
                                                }

                                                if (cmd.CmdMode == clsConstValue.CmdMode.S2S)
                                                {
                                                    ConveyorInfo[] conveyors_From = new ConveyorInfo[2];
                                                    for (int con = 0; con < BatchCmd.Length; con++)
                                                    {
                                                        conveyors_From[con] = GetCV_ByCmdLoc(BatchCmd[con], BatchCmd[con].Source, db);
                                                        if (conveyors_From[con].DoubleType == DoubleType.Right)
                                                        {
                                                            equCmd.Source = conveyors_From[con].StkPortID.ToString();
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    for (int con = 0; con < BatchCmd.Length; con++)
                                                    {
                                                        if (tool.GetShelfLocation(BatchCmd[con].Source) == clsEnum.Shelf.OutSide)
                                                        {
                                                            equCmd.Source = tool.GetEquCmdLoc_BySysCmd(BatchCmd[con].Source);
                                                            break;
                                                        }
                                                    }
                                                }

                                                if (FunWriEquCmd_DoubleProc(BatchCmd, equCmd, db)) return true;
                                                else continue;
                                            }
                                        }
                                        else
                                        {
                                            if (FunSingleAsrsCmdProc(cmd, db)) return true;
                                            else continue;
                                        }
                                    }
                                    else
                                    {
                                        if (FunSingleAsrsCmdProc(cmd, db)) return true;
                                        else continue;
                                    }
                                }
                                else
                                {
                                    if(cmd.DeviceID == sDeviceID_Tower)
                                    {
                                        RetrieveTransferInfo retrieve_info = new RetrieveTransferInfo();
                                        PutawayTransferInfo putaway_info = new PutawayTransferInfo();
                                        if(cmd.CmdMode == clsConstValue.CmdMode.StockIn)
                                        {
                                            putaway_info = new PutawayTransferInfo
                                            {
                                                jobId = cmd.CommandID,
                                                reelId = cmd.CSTID,
                                                toShelfId = cmd.Destination,
                                                lotSize = cmd.lotSize
                                            };
                                        }
                                        else
                                        {
                                            retrieve_info = new RetrieveTransferInfo
                                            {
                                                jobId = cmd.CommandID,
                                                fromShelfId = cmd.Source,
                                                priority = cmd.Priority.ToString(),
                                                reelId = cmd.CSTID,
                                                toPortId = cmd.Destination,
                                                largest = cmd.largest,
                                                rackLocation = cmd.rackLocation
                                            };
                                        }

                                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                        {
                                            sRemark = "Error: Begin失敗！";
                                            if (sRemark != cmd.Remark)
                                            {
                                                EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                            }

                                            continue;
                                        }

                                        sRemark = "下達料塔搬運命令";
                                        if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteDeviceCmd, sRemark, db))
                                        {
                                            db.TransactionCtrl(TransactionTypes.Rollback);
                                            continue;
                                        }

                                        if (cmd.CmdMode == clsConstValue.CmdMode.StockIn)
                                        {
                                            if (!api.GetPutawayTransfer().FunReport(putaway_info, _towerApi.IP))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 下達料塔搬運命令失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            if (!api.GetRetrieveTransfer().FunReport(retrieve_info, _towerApi.IP))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 下達料塔搬運命令失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }
                                        }

                                        db.TransactionCtrl(TransactionTypes.Commit);
                                        return true;
                                    }
                                    else
                                    {
                                        if (cmd.CmdSts == clsConstValue.CmdSts_MiddleCmd.strCmd_Initial)
                                        {
                                            ConveyorInfo conveyor = GetCV_ByCmdLoc(cmd, cmd.Destination, db);
                                            if (string.IsNullOrWhiteSpace(conveyor.BufferName)) continue;

                                            CVReceiveNewBinCmdInfo info = new CVReceiveNewBinCmdInfo
                                            {
                                                bufferId = conveyor.BufferName,
                                                jobId = cmd.CommandID,
                                                carrierType = cmd.carrierType
                                            };

                                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                            {
                                                sRemark = "Error: Begin失敗！";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            sRemark = $"預約{conveyor.BufferName}";
                                            if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteCV, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }

                                            if (!api.GetCV_ReceiveNewBinCmd().FunReport(info, conveyor.API.IP))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = $"Error: 預約{conveyor.BufferName}失敗！";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            db.TransactionCtrl(TransactionTypes.Commit);
                                            return true;
                                        }
                                        else
                                        {
                                            MoveTaskInfo info = new MoveTaskInfo
                                            {
                                                fromLoc = cmd.Source,
                                                jobId = cmd.CommandID,
                                                toLoc = cmd.Destination,
                                                carrierType = cmd.carrierType
                                            };

                                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                            {
                                                sRemark = "Error: Begin失敗！";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            sRemark = "下達AGV搬運命令";
                                            if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteDeviceCmd, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }

                                            if (!api.GetMoveTask().FunReport(info, _agvApi.IP))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 下達AGV搬運命令失敗";
                                                if (sRemark != cmd.Remark)
                                                {
                                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
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
                        else if (iRet == DBResult.Exception) clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                        else { }

                        return false;
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, "資料庫開啟失敗！");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunSingleAsrsCmdProc(MiddleCmd cmd, DB db)
        {
            try
            {
                string sRemark = "";
                if (cmd.CmdSts == clsConstValue.CmdSts_MiddleCmd.strCmd_Initial)
                {
                    switch (cmd.CmdMode)
                    {
                        case clsConstValue.CmdMode.StockIn:
                        case clsConstValue.CmdMode.L2L:
                            EquCmdInfo equCmd = new EquCmdInfo
                            {
                                CmdSno = cmd.CommandID,
                                CmdMode = cmd.CmdMode,
                                CmdSts = clsConstValue.CmdSts.strCmd_Initial,
                                CarNo = "1",
                                EquNo = cmd.DeviceID,
                                LocSize = " ",
                                Priority = cmd.Priority.ToString(),
                                SpeedLevel = "5",
                                Destination = tool.GetEquCmdLoc_BySysCmd(cmd.Destination)
                            };

                            if (cmd.CmdMode == clsConstValue.CmdMode.StockIn)
                            {
                                var obj = Node_All.Where(r => r.BufferName == cmd.Source);
                                if (obj == null || obj.Count() == 0)
                                {
                                    sRemark = "Error: Source站口不存在在所有節點裡";
                                    if (sRemark != cmd.Remark)
                                    {
                                        EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                    }

                                    return false;
                                }

                                foreach (var j in obj)
                                {
                                    equCmd.Source = j.StkPortID.ToString();
                                }
                            }
                            else equCmd.Source = tool.GetEquCmdLoc_BySysCmd(cmd.Source);

                            return FunWriEquCmd_Proc(cmd, equCmd, db);

                        case clsConstValue.CmdMode.StockOut:
                        case clsConstValue.CmdMode.S2S:
                            ConveyorInfo conveyor = GetCV_ByCmdLoc(cmd, cmd.Destination, db);
                            if (string.IsNullOrWhiteSpace(conveyor.BufferName)) return false;

                            CVReceiveNewBinCmdInfo info = new CVReceiveNewBinCmdInfo
                            {
                                bufferId = conveyor.BufferName,
                                jobId = cmd.CommandID,
                                carrierType = cmd.carrierType
                            };

                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                            {
                                sRemark = "Error: Begin失敗！";
                                if (sRemark != cmd.Remark)
                                {
                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                }

                                return false;
                            }

                            sRemark = $"預約{conveyor.BufferName}";
                            if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteCV, sRemark, db))
                            {
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                return false;
                            }

                            if (!api.GetCV_ReceiveNewBinCmd().FunReport(info, conveyor.API.IP))
                            {
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                sRemark = $"Error: 預約{conveyor.BufferName}失敗！";
                                if (sRemark != cmd.Remark)
                                {
                                    EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                                }

                                return false;
                            }

                            db.TransactionCtrl(TransactionTypes.Commit);
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {//CmdSts=1 已預約目的站
                    switch (cmd.CmdMode)
                    {
                        case clsConstValue.CmdMode.L2L:
                        case clsConstValue.CmdMode.StockIn:
                            return EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_Initial, "", db);
                    }

                    ConveyorInfo conveyor_From = new ConveyorInfo();
                    if (cmd.CmdMode == clsConstValue.CmdMode.S2S)
                    {
                        conveyor_From = GetCV_ByCmdLoc(cmd, cmd.Source, db);
                        if (string.IsNullOrWhiteSpace(conveyor_From.BufferName)) return false;
                    }

                    ConveyorInfo conveyor_To = GetCV_ByCmdLoc(cmd, cmd.Destination, db);
                    if (string.IsNullOrWhiteSpace(conveyor_To.BufferName)) return false;

                    EquCmdInfo equCmd = new EquCmdInfo
                    {
                        CmdSno = cmd.CommandID,
                        CmdMode = cmd.CmdMode,
                        CmdSts = clsConstValue.CmdSts.strCmd_Initial,
                        CarNo = "1",
                        EquNo = cmd.DeviceID,
                        LocSize = " ",
                        Priority = cmd.Priority.ToString(),
                        SpeedLevel = "5",
                        Destination = conveyor_To.StkPortID.ToString()
                    };

                    if (cmd.CmdMode == clsConstValue.CmdMode.S2S) equCmd.Source = conveyor_From.StkPortID.ToString();
                    else equCmd.Source = tool.GetEquCmdLoc_BySysCmd(cmd.Source);

                    return FunWriEquCmd_Proc(cmd, equCmd, db);
                }
            }
            catch (Exception ex)
            {
                db.TransactionCtrl(TransactionTypes.Rollback);
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool FunWriEquCmd_Proc(MiddleCmd cmd, EquCmdInfo equCmd, DB db)
        {
            try
            {
                string sRemark = "";
                if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                {
                    sRemark = "Error: Begin失敗！";
                    if (sRemark != cmd.Remark)
                    {
                        EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                    }

                    return false;
                }

                sRemark = "下達EquCmd";
                if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteDeviceCmd, sRemark, db))
                {
                    db.TransactionCtrl(TransactionTypes.Rollback);
                    return false;
                }

                if (!EquCmd.FunInsEquCmd(equCmd, db))
                {
                    db.TransactionCtrl(TransactionTypes.Rollback);
                    sRemark = "Error: 下達EquCmd失敗！";
                    if (sRemark != cmd.Remark)
                    {
                        EquCmd.FunUpdateRemark_MiddleCmd(cmd.CommandID, sRemark, db);
                    }

                    return false;
                }

                db.TransactionCtrl(TransactionTypes.Commit);
                return true;
            }
            catch (Exception ex)
            {
                db.TransactionCtrl(TransactionTypes.Rollback);
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool FunWriEquCmd_DoubleProc(MiddleCmd[] cmd, EquCmdInfo equCmd, DB db)
        {
            try
            {
                string sRemark = "";
                if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                {
                    sRemark = "Error: Begin失敗！";
                    for (int i = 0; i < cmd.Length; i++)
                    {
                        if (sRemark != cmd[i].Remark)
                        {
                            EquCmd.FunUpdateRemark_MiddleCmd(cmd[i].CommandID, sRemark, db);
                        }
                    }

                    return false;
                }

                sRemark = "下達EquCmd";
                for (int i = 0; i < cmd.Length; i++)
                {
                    if (!EquCmd.FunUpdateCmdSts_MiddleCmd(cmd[i].CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_WriteDeviceCmd, sRemark, db))
                    {
                        db.TransactionCtrl(TransactionTypes.Rollback);
                        return false;
                    }
                }

                if (!EquCmd.FunInsEquCmd(equCmd, db))
                {
                    db.TransactionCtrl(TransactionTypes.Rollback);
                    sRemark = "Error: 下達EquCmd失敗！";
                    for (int i = 0; i < cmd.Length; i++)
                    {
                        if (sRemark != cmd[i].Remark)
                        {
                            EquCmd.FunUpdateRemark_MiddleCmd(cmd[i].CommandID, sRemark, db);
                        }
                    }

                    return false;
                }

                db.TransactionCtrl(TransactionTypes.Commit);
                return true;
            }
            catch (Exception ex)
            {
                db.TransactionCtrl(TransactionTypes.Rollback);
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }
    }
}
