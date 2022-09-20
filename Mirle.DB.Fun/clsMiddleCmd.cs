using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Structure;
using System.Threading.Tasks;
using Mirle.Def;
using Mirle.DataBase;
using System.Data;
using Mirle.Def.U2NMMA30;
using Mirle.MapController;

namespace Mirle.DB.Fun
{
    public class clsMiddleCmd
    {
        private readonly clsSno SNO = new clsSno();
        private readonly clsCmd_Mst CMD_MST = new clsCmd_Mst();
        private readonly clsTool tool = new clsTool();
        private readonly clsRoutdef routdef = new clsRoutdef();
        public int GetFinishCommand(string DeviceID, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where {Parameter.clsMiddleCmd.Column.DeviceID} = '{DeviceID}' and " +
                    $"{Parameter.clsMiddleCmd.Column.CmdSts} in ('{clsConstValue.CmdSts.strCmd_Cancel_Wait}','{clsConstValue.CmdSts.strCmd_Finish_Wait}')";
                dtTmp = new DataTable();
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public int GetAbnormalFinishCommand(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.CmdSts} in ('{clsConstValue.CmdSts.strCmd_Cancel_Wait}','{clsConstValue.CmdSts.strCmd_Finish_Wait}') and " +
                    $"{Parameter.clsMiddleCmd.Column.CompleteCode} in ('{clsConstValue.CompleteCode.DoubleStorage}','{clsConstValue.CompleteCode.EmptyRetrieval}')";
                dtTmp = new DataTable();
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public bool FunGetMiddleCmd_R2R(CmdMstInfo cmd, ref MiddleCmd middleCmd, DataBase.DB db)
        {
            try
            {
                middleCmd = new MiddleCmd();
                middleCmd.TaskNo = SNO.FunGetSeqNo(clsEnum.enuSnoType.CMDSUO, db);
                if (string.IsNullOrWhiteSpace(middleCmd.TaskNo))
                {
                    string sRemark = "Error: 取得TaskNo失敗！";
                    if (sRemark != cmd.Remark)
                    {
                        CMD_MST.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                    }

                    return false;
                }

                middleCmd.CommandID = cmd.Cmd_Sno;
                middleCmd.DeviceID = cmd.Equ_No;
                middleCmd.CSTID = cmd.BoxID;
                middleCmd.CmdMode = clsConstValue.CmdMode.L2L;
                middleCmd.Source = cmd.Loc;
                middleCmd.Destination = cmd.New_Loc;
                middleCmd.Priority = Convert.ToInt32(cmd.Prty);
                middleCmd.Path = 0;
                middleCmd.BatchID = "";
                middleCmd.Iotype = cmd.IO_Type;
                middleCmd.carrierType = cmd.carrierType;
                middleCmd.largest = cmd.largest;
                middleCmd.rackLocation = cmd.rackLocation;
                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunGetMiddleCmd(CmdMstInfo cmd, Location sLoc_Start, Location sLoc_End, ref MiddleCmd middleCmd, DataBase.DB db, string BatchID = "")
        {
            try
            {
                middleCmd = new MiddleCmd();
                middleCmd.TaskNo = SNO.FunGetSeqNo(clsEnum.enuSnoType.CMDSUO, db);
                if (string.IsNullOrWhiteSpace(middleCmd.TaskNo))
                {
                    string sRemark = "Error: 取得TaskNo失敗！";
                    if (sRemark != cmd.Remark)
                    {
                        CMD_MST.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                    }

                    return false;
                }

                middleCmd.CommandID = cmd.Cmd_Sno;
                middleCmd.DeviceID = sLoc_Start.DeviceId;
                middleCmd.CSTID = cmd.BoxID;
                string ToLoc = cmd.Cmd_Mode == clsConstValue.CmdMode.L2L ? cmd.New_Loc : cmd.Loc;
                middleCmd.Source = tool.GetLocation(cmd.Loc, sLoc_Start);
                middleCmd.Destination = tool.GetLocation(ToLoc, sLoc_End);
                middleCmd.lotSize = cmd.lotSize;
                string sCmdMode = "";
                if (sLoc_Start.LocationTypes == LocationTypes.Shelf)
                {
                    switch (sLoc_End.LocationTypes)
                    {
                        case LocationTypes.Shelf:
                            sCmdMode = clsConstValue.CmdMode.L2L;
                            break;
                        default:
                            sCmdMode = clsConstValue.CmdMode.StockOut;
                            break;
                    }
                }
                else
                {
                    switch (sLoc_End.LocationTypes)
                    {
                        case LocationTypes.Shelf:
                            sCmdMode = clsConstValue.CmdMode.StockIn;
                            break;
                        default:
                            sCmdMode = clsConstValue.CmdMode.S2S;
                            break;
                    }
                }

                middleCmd.CmdMode = sCmdMode;
                middleCmd.Priority = Convert.ToInt32(cmd.Prty);

                string sStnNo = cmd.Cmd_Mode == clsConstValue.CmdMode.S2S ? cmd.New_Loc : cmd.Stn_No;
                middleCmd.Path = ConveyorDef.GetPathByStn(sStnNo);
                middleCmd.BatchID = BatchID;
                middleCmd.Iotype = cmd.IO_Type;
                middleCmd.carrierType = cmd.carrierType;
                middleCmd.largest = cmd.largest;
                middleCmd.rackLocation = cmd.rackLocation;
                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunGetMiddleCmd_NonASRS(CmdMstInfo cmd, Location sLoc_Start, Location sLoc_End, ref MiddleCmd middleCmd, string sDeviceID, DataBase.DB db, string BatchID = "")
        {
            try
            {
                middleCmd = new MiddleCmd();
                middleCmd.TaskNo = SNO.FunGetSeqNo(clsEnum.enuSnoType.CMDSUO, db);
                if (string.IsNullOrWhiteSpace(middleCmd.TaskNo))
                {
                    string sRemark = "Error: 取得TaskNo失敗！";
                    if (sRemark != cmd.Remark)
                    {
                        CMD_MST.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                    }

                    return false;
                }

                middleCmd.CommandID = cmd.Cmd_Sno;
                middleCmd.DeviceID = sDeviceID;
                middleCmd.CSTID = cmd.BoxID;
                string ToLoc = cmd.Cmd_Mode == clsConstValue.CmdMode.L2L ? cmd.New_Loc : cmd.Loc;
                middleCmd.Source = tool.GetLocation(cmd.Loc, sLoc_Start);
                middleCmd.Destination = tool.GetLocation(ToLoc, sLoc_End);
                string sCmdMode = "";
                if (sLoc_Start.LocationTypes == LocationTypes.Shelf)
                {
                    switch (sLoc_End.LocationTypes)
                    {
                        case LocationTypes.Shelf:
                            sCmdMode = clsConstValue.CmdMode.L2L;
                            break;
                        default:
                            sCmdMode = clsConstValue.CmdMode.StockOut;
                            break;
                    }
                }
                else
                {
                    switch (sLoc_End.LocationTypes)
                    {
                        case LocationTypes.Shelf:
                            sCmdMode = clsConstValue.CmdMode.StockIn;
                            break;
                        default:
                            sCmdMode = clsConstValue.CmdMode.S2S;
                            break;
                    }
                }

                middleCmd.CmdMode = sCmdMode;
                middleCmd.Priority = Convert.ToInt32(cmd.Prty);

                string sStnNo = cmd.Cmd_Mode == clsConstValue.CmdMode.S2S ? cmd.New_Loc : cmd.Stn_No;
                middleCmd.Path = 0;
                middleCmd.BatchID = BatchID;
                middleCmd.Iotype = cmd.IO_Type;
                middleCmd.carrierType = cmd.carrierType;
                middleCmd.largest = cmd.largest;
                middleCmd.rackLocation = cmd.rackLocation;
                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunGetMiddleCmd(CmdMstInfo cmd, Location sLoc_Start, Location sLoc_End, ref MiddleCmd middleCmd, ref MiddleCmd middleCmd_DD,
            bool IsDoubleCmd, CmdMstInfo cmd_DD, MapHost Router, DataBase.DB db)
        {
            try
            {
                middleCmd = new MiddleCmd();
                middleCmd_DD = new MiddleCmd();
                string sRemark = "";
                if (IsDoubleCmd)
                {
                    string sBatchID = SNO.FunGetSeqNo(clsEnum.enuSnoType.BATCH, db);
                    if (string.IsNullOrWhiteSpace(sBatchID))
                    {
                        sRemark = $"Error: 取得{Parameter.clsMiddleCmd.Column.BatchID}失敗！";
                        if (sRemark != cmd.Remark)
                        {
                            CMD_MST.FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                        }

                        return false;
                    }

                    if (FunGetMiddleCmd(cmd, sLoc_Start, sLoc_End, ref middleCmd, db, sBatchID))
                    {
                        Location sLoc_Start_DD = null; Location sLoc_End_DD = null;
                        if (routdef.FunGetLocation(cmd_DD, Router, ref sLoc_Start_DD, ref sLoc_End_DD, db))
                        {
                            return FunGetMiddleCmd(cmd_DD, sLoc_Start_DD, sLoc_End_DD, ref middleCmd_DD, db, sBatchID);
                        }
                        else return false;
                    }
                    else return false;
                }
                else
                {
                    return FunGetMiddleCmd(cmd, sLoc_Start, sLoc_End, ref middleCmd, db);
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunGetMiddleCmdbyCommandID(string CmdSno, ref MiddleCmd middleCmd, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.CommandID} == '" + CmdSno + "'";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                    return false;
                }
                else
                {
                    middleCmd = new MiddleCmd();
                    middleCmd = tool.GetMiddleCmd(dtTmp.Rows[0]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public int FunGetMiddleCmd_Grid(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select {Parameter.clsMiddleCmd.Column.DeviceID},{Parameter.clsMiddleCmd.Column.CommandID}," +
                    $"{Parameter.clsMiddleCmd.Column.TaskNo},{Parameter.clsMiddleCmd.Column.CSTID}," +
                    $"{Parameter.clsMiddleCmd.Column.CmdSts},{Parameter.clsMiddleCmd.Column.Priority}," +
                    $"{Parameter.clsMiddleCmd.Column.CmdMode},{Parameter.clsMiddleCmd.Column.Source}," +
                    $"{Parameter.clsMiddleCmd.Column.Destination},{Parameter.clsMiddleCmd.Column.Remark}," +
                    $"{Parameter.clsMiddleCmd.Column.BatchID},{Parameter.clsMiddleCmd.Column.carrierType}," +
                    $"{Parameter.clsMiddleCmd.Column.CompleteCode} from " +
                    $"{Parameter.clsMiddleCmd.TableName}" +
                    $" where {Parameter.clsMiddleCmd.Column.CmdSts} < '{clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait}' ";
                strSql += $" ORDER BY {Parameter.clsMiddleCmd.Column.Priority}," +
                    $" {Parameter.clsMiddleCmd.Column.Create_Date}, {Parameter.clsMiddleCmd.Column.CommandID}";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public int CheckHasMiddleCmd(string DeviceID, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.DeviceID} = '{DeviceID}'";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public int CheckHasMiddleCmdByCmdSno(string sCmdSno, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}' and {Parameter.clsMiddleCmd.Column.CmdSts} not in " +
                    $"('{clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait}', '{clsConstValue.CmdSts_MiddleCmd.strCmd_Cancel_Wait}')";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public int CheckHasMiddleCmdByCSTID(string CSTID, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.CSTID} = '{CSTID}' and {Parameter.clsMiddleCmd.Column.CmdSts} not in " +
                    $"('{clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait}', '{clsConstValue.CmdSts_MiddleCmd.strCmd_Cancel_Wait}')";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunInsMiddleCmd(MiddleCmd middleCmd, DataBase.DB db)
        {
            try
            {
                string strSql = $"insert into {Parameter.clsMiddleCmd.TableName}({Parameter.clsMiddleCmd.Column.CmdMode}," +
                    $"{Parameter.clsMiddleCmd.Column.CmdSts},{Parameter.clsMiddleCmd.Column.CommandID}," +
                    $"{Parameter.clsMiddleCmd.Column.Create_Date},{Parameter.clsMiddleCmd.Column.CSTID}," +
                    $"{Parameter.clsMiddleCmd.Column.Destination},{Parameter.clsMiddleCmd.Column.DeviceID}," +
                    $"{Parameter.clsMiddleCmd.Column.EndDate},{Parameter.clsMiddleCmd.Column.Expose_Date},{Parameter.clsMiddleCmd.Column.CompleteCode}," +
                    $"{Parameter.clsMiddleCmd.Column.Path},{Parameter.clsMiddleCmd.Column.Priority},{Parameter.clsMiddleCmd.Column.Remark}," +
                    $"{Parameter.clsMiddleCmd.Column.Source},{Parameter.clsMiddleCmd.Column.TaskNo},{Parameter.clsMiddleCmd.Column.BatchID}," +
                    $"{Parameter.clsMiddleCmd.Column.largest},{Parameter.clsMiddleCmd.Column.rackLocation},{Parameter.clsMiddleCmd.Column.IoType}," +
                    $"{Parameter.clsMiddleCmd.Column.carrierType},{Parameter.clsMiddleCmd.Column.lotSize}) values (" +
                    $"'{middleCmd.CmdMode}','{middleCmd.CmdSts}','{middleCmd.CommandID}','{middleCmd.CrtDate}'," +
                    $"'{middleCmd.CSTID}','{middleCmd.Destination}','{middleCmd.DeviceID}','{middleCmd.EndDate}'," +
                    $"'{middleCmd.ExpDate}','{middleCmd.CompleteCode}',{middleCmd.Path},{middleCmd.Priority}," +
                    $"'{middleCmd.Remark}','{middleCmd.Source}','{middleCmd.TaskNo}','{middleCmd.BatchID}'," +
                    $"'{middleCmd.largest}','{middleCmd.rackLocation}','{middleCmd.Iotype}','{middleCmd.carrierType}','{middleCmd.lotSize}')";
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

        public bool FunInsertHisMiddleCmd(string sCmdSno, DataBase.DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsMiddleCmd_His.TableName} ";
                SQL += $" SELECT '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', * FROM {Parameter.clsMiddleCmd.TableName} ";
                SQL += $" WHERE {Parameter.clsMiddleCmd.Column.CommandID}='{sCmdSno}'";

                int iRet = db.ExecuteSQL(SQL);
                if (iRet == DBResult.Success)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunDelMiddleCmd(string CommandID, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSQL = $"delete from {Parameter.clsMiddleCmd.TableName} where " +
                    $"{Parameter.clsMiddleCmd.Column.CommandID} = '" + CommandID + "' ";
                int Ret = db.ExecuteSQL(strSQL, ref strEM);
                if (Ret == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSQL); return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSQL + " => " + strEM); return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunMiddleCmdUpdateRemark(string sCmdSno, string sRemark, DataBase.DB db, ref string strEM)
        {
            try
            {
                string strSql = $"update {Parameter.clsMiddleCmd.TableName} set " +
                    $"{Parameter.clsMiddleCmd.Column.Remark} = N'" + sRemark +
                    $"' where {Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}'";

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

        public bool FunMiddleCmdUpdateCmdSts(string sCmdSno, string sCmdSts, string sRemark, DataBase.DB db)
        {
            try
            {
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

                strSql += $" where {Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}' ";

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
    }
}
