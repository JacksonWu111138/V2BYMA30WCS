using System;
using Mirle.Def;
using System.Data;
using Mirle.Structure;
using Mirle.DataBase;
using Mirle.EccsSignal;

namespace Mirle.DB.Fun
{
    public class clsCmd_Mst
    {
        private clsTool tool = new clsTool();
        public bool CheckCraneStatus(CmdMstInfo cmd, DeviceInfo Device, SignalHost CrnSignal, DataBase.DB db)
        {
            string sRemark = "";
            bool bCraneSts;
            if (CrnSignal.CrnMode != clsConstValue.Crane.Mode.Computer)
            {
                bCraneSts = false;
                sRemark = $"Error: Line{Device.DeviceID}並非電腦模式";
            }
            else if (CrnSignal.CrnSts == clsConstValue.Crane.Status.Alarm ||
                CrnSignal.CrnSts == clsConstValue.Crane.Status.ComputerOffLine ||
                CrnSignal.CrnSts == clsConstValue.Crane.Status.Error)
            {
                bCraneSts = false;
                sRemark = $"Error: Line{Device.DeviceID}異常中";
            }
            else if (CrnSignal.CrnSts == clsConstValue.Crane.Status.Busy)
            {
                bCraneSts = false;
                sRemark = $"Line{Device.DeviceID}動作中";
            }
            else bCraneSts = true;

            if (!bCraneSts)
            {
                if (sRemark != cmd.Remark)
                {
                    FunUpdateRemark(cmd.Cmd_Sno, sRemark, db);
                }
            }

            return bCraneSts;
        }

        public int FunGetNormalCommand(string sAsrsStockInLocation_Sql, string sAsrsEquNo_Sql, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} where " +
                    $"({Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{clsConstValue.CmdSts.strCmd_Running}' and " +
                    $"{Parameter.clsCmd_Mst.Column.CurLoc} not in ({sAsrsStockInLocation_Sql})) or " +
                    $"({Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{clsConstValue.CmdSts.strCmd_Initial}' and " +
                    $"({Parameter.clsCmd_Mst.Column.Cmd_Mode} in ('{clsConstValue.CmdMode.S2S}', '{clsConstValue.CmdMode.StockIn}') or " +
                    $"({Parameter.clsCmd_Mst.Column.Cmd_Mode} in ('{clsConstValue.CmdMode.StockOut}', '{clsConstValue.CmdMode.L2L}') and " +
                    $"{Parameter.clsCmd_Mst.Column.Equ_No} not in ({sAsrsEquNo_Sql}))" +
                    $"))";
                strSql += $" ORDER BY {Parameter.clsCmd_Mst.Column.Prty}," +
                  $" {Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.Cmd_Sno}";
                dtTmp = new DataTable();
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Exception) clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return DBResult.Exception;
            }
        }

        public int FunGetR2RCommand(string EquNo, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} where {Parameter.clsCmd_Mst.Column.Equ_No} = '{EquNo}' and " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Mode} = '{clsConstValue.CmdMode.L2L}' and " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{clsConstValue.CmdSts.strCmd_Initial}' ";
                strSql += $" ORDER BY {Parameter.clsCmd_Mst.Column.Prty}," +
                  $" {Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.Cmd_Sno}";
                dtTmp = new DataTable();
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Exception) clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return DBResult.Exception;
            }
        }

        public int FunGetCommand(string EquNo, string StockInLoc_Sql, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} where (";
                strSql += $"{Parameter.clsCmd_Mst.Column.Equ_No} = '{EquNo}' and ";
                strSql += $"{Parameter.clsCmd_Mst.Column.Cmd_Mode} in ('{clsConstValue.CmdMode.StockOut}'," +
                    $"'{clsConstValue.CmdMode.L2L}') and {Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{clsConstValue.CmdSts.strCmd_Initial}') ";
                strSql += $"or ({Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{clsConstValue.CmdSts.strCmd_Running}' and " +
                    $"{Parameter.clsCmd_Mst.Column.CurDeviceID} = '{EquNo}' and " +
                    $"{Parameter.clsCmd_Mst.Column.CurLoc} in ({StockInLoc_Sql}))";
                strSql += $" ORDER BY {Parameter.clsCmd_Mst.Column.Prty}," +
                   $" {Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.Cmd_Sno}";
                dtTmp = new DataTable();
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Exception) clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return DBResult.Exception;
            }
        }

        public bool FunGetCommand(string sCmdSno, ref CmdMstInfo cmd, ref int iRet, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} " +
                    $"where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '" + sCmdSno + "' ";
                iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmd = new CmdMstInfo();
                    cmd = tool.GetCommand(dtTmp.Rows[0]);
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
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public bool FunGetCommandByJobID(string JobID, ref CmdMstInfo cmd, ref int iRet, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} " +
                    $"where {Parameter.clsCmd_Mst.Column.JobID} = '" + JobID + "' ";
                iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmd = new CmdMstInfo();
                    cmd = tool.GetCommand(dtTmp.Rows[0]);
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
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public int FunGetCommand_byBoxID(string sBoxID, ref CmdMstInfo cmd, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName} " +
                    $"where {Parameter.clsCmd_Mst.Column.BoxID} = '" + sBoxID + "' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmd = tool.GetCommand(dtTmp.Rows[0]);
                }
                else
                {
                    if (iRet != DBResult.NoDataSelect)
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
                }

                return iRet;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public bool FunGetCmdMst(Location loc, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}";
                strSql += $" where {Parameter.clsCmd_Mst.Column.CurDeviceID} = '{loc.DeviceId}'" +
                    $" and {Parameter.clsCmd_Mst.Column.CurLoc} = '{loc.LocationId}' ";
                if (db.GetDataTable(strSql, ref dtTmp, ref strEM) == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
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

        public int FunGetCmdMst_Grid_AutoUpFile(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.Cmd_Sts} in ('{clsConstValue.CmdSts.strCmd_Cancel_Wait}'," +
                    $" '{clsConstValue.CmdSts.strCmd_Finish_Wait}')";
                strSql += $" ORDER BY {Parameter.clsCmd_Mst.Column.Prty}," +
                    $" {Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.Cmd_Sno}";
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

        public int FunGetCmdMst_Grid(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select {Parameter.clsCmd_Mst.Column.Cmd_Sno},{Parameter.clsCmd_Mst.Column.JobID}," +
                    $"{Parameter.clsCmd_Mst.Column.BoxID},{Parameter.clsCmd_Mst.Column.Cmd_Sts}," +
                    $"{Parameter.clsCmd_Mst.Column.Prty},{Parameter.clsCmd_Mst.Column.Cmd_Mode}," +
                    $"{Parameter.clsCmd_Mst.Column.Stn_No},{Parameter.clsCmd_Mst.Column.Loc}," +
                    $"{Parameter.clsCmd_Mst.Column.Remark},{Parameter.clsCmd_Mst.Column.CurDeviceID}," +
                    $"{Parameter.clsCmd_Mst.Column.CurLoc},{Parameter.clsCmd_Mst.Column.Equ_No}," +
                    $"{Parameter.clsCmd_Mst.Column.Zone},{Parameter.clsCmd_Mst.Column.New_Loc}," +
                    $"{Parameter.clsCmd_Mst.Column.NeedShelfToShelf},{Parameter.clsCmd_Mst.Column.Create_Date}," +
                    $"{Parameter.clsCmd_Mst.Column.Expose_Date},{Parameter.clsCmd_Mst.Column.backupPortId} from " +
                    $"{Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.Cmd_Sts} in ('{clsConstValue.CmdSts.strCmd_Initial}'," +
                    $" '{clsConstValue.CmdSts.strCmd_Running}')";
                strSql += $" ORDER BY {Parameter.clsCmd_Mst.Column.Prty}," +
                    $" {Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.Cmd_Sno}";
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

        public int FunGetFinishCommand(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.Cmd_Sts} in ('{clsConstValue.CmdSts.strCmd_Finish_Wait}', '{clsConstValue.CmdSts.strCmd_Cancel_Wait}')";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return DBResult.Exception;
            }
        }

        public int FunCheckHasCommand_ByBoxID(string BoxId, ref CmdMstInfo cmd, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.BoxID} = '{BoxId}'";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmd = tool.GetCommand(dtTmp.Rows[0]);
                }
                else
                {
                    if (iRet != DBResult.NoDataSelect)
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                    }
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
                dtTmp = null;
            }
        }

        public int FunCheckHasCommand(string sLoc, ref CmdMstInfo cmd, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.Loc} = '{sLoc}' or {Parameter.clsCmd_Mst.Column.New_Loc} = '{sLoc}' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmd = tool.GetCommand(dtTmp.Rows[0]);
                }
                else
                {
                    if (iRet != DBResult.NoDataSelect)
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                    }
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
                dtTmp = null;
            }
        }

        public int FunCheckHasCommand(string sLoc, string sCmdSts, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where ({Parameter.clsCmd_Mst.Column.Loc} = '{sLoc}' or {Parameter.clsCmd_Mst.Column.New_Loc} = '{sLoc}' )";
                strSql += $" and {Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{sCmdSts}' ";
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

        public int FunCheckHasCommand(int iStockerID, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsCmd_Mst.TableName}" +
                    $" where {Parameter.clsCmd_Mst.Column.CurDeviceID} = '{iStockerID}' or" +
                    $" {Parameter.clsCmd_Mst.Column.Equ_No} = '{iStockerID}' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Exception)
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

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
                dtTmp = null;
            }
        }

        public bool FunUpdateRemark(string sCmdSno, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.Remark} = N'" + sRemark + 
                    $"' where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}'";

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

        public bool FunUpdateStnNo(string sCmdSno, string sStnNo, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.Stn_No} = '" + sStnNo + 
                    $"', {Parameter.clsCmd_Mst.Column.Remark} = N'{sRemark}' ";
                strSql += $", {Parameter.clsCmd_Mst.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                strSql += $" where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";

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

        public bool FunUpdatePry(string sBoxID, string Pry, ref string strEM, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set {Parameter.clsCmd_Mst.Column.Prty} = '" + Pry + "' ";
                strSql += $" where {Parameter.clsCmd_Mst.Column.BoxID} = '{sBoxID}' ";

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

        public bool FunUpdateCmdSts(string sCmdSno, string sCmdSts, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set" +
                    $" {Parameter.clsCmd_Mst.Column.Remark} = N'" + sRemark + 
                    $"', {Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{sCmdSts}' ";

                if(sCmdSts == clsConstValue.CmdSts.strCmd_Initial)
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.CurLoc} = '', {Parameter.clsCmd_Mst.Column.CurDeviceID} = '' ";
                }

                if (sCmdSts == clsConstValue.CmdSts.strCmd_Cancel_Wait || sCmdSts == clsConstValue.CmdSts.strCmd_Finish_Wait ||
                    sCmdSts == clsConstValue.CmdSts.strCmd_Finished || sCmdSts == clsConstValue.CmdSts.strCmd_Cancelled )
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.End_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                else
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }

                strSql += $" where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";

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

        public bool FunUpdateCmdSts(string sCmdSno, string sCmdSts, string sStnNo, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.Remark} = N'" + sRemark + 
                    $"', {Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{sCmdSts}', {Parameter.clsCmd_Mst.Column.Stn_No} = '{sStnNo}' ";

                if (sCmdSts == clsConstValue.CmdSts.strCmd_Initial)
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.CurLoc} = '', {Parameter.clsCmd_Mst.Column.CurDeviceID} = '' ";
                }

                if (sCmdSts == clsConstValue.CmdSts.strCmd_Cancel_Wait || sCmdSts == clsConstValue.CmdSts.strCmd_Finish_Wait ||
                    sCmdSts == clsConstValue.CmdSts.strCmd_Finished || sCmdSts == clsConstValue.CmdSts.strCmd_Cancelled)
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.End_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                else
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }

                strSql += $" where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";

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

        public bool FunUpdateCmdSts(string sCmdSno, string sCmdSts, clsEnum.Cmd_Abnormal abnormal, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.Remark} = N'" + sRemark + $"', {Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{sCmdSts}' ";
                strSql += $", {Parameter.clsCmd_Mst.Column.Cmd_Abnormal} = '{abnormal.ToString()}' ";

                if (sCmdSts == clsConstValue.CmdSts.strCmd_Initial)
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.CurLoc} = '', {Parameter.clsCmd_Mst.Column.CurDeviceID} = '' ";
                }

                if (sCmdSts == clsConstValue.CmdSts.strCmd_Cancel_Wait || sCmdSts == clsConstValue.CmdSts.strCmd_Finish_Wait ||
                    sCmdSts == clsConstValue.CmdSts.strCmd_Finished || sCmdSts == clsConstValue.CmdSts.strCmd_Cancelled)
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.End_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }
                else
                {
                    strSql += $", {Parameter.clsCmd_Mst.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                }

                strSql += $" where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";

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

        public bool FunUpdateNewLocForL2L(string sCmdSno, string sNewLoc, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.New_Loc} = '{sNewLoc}' where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";
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

        public bool FunUpdateLoc(string sCmdSno, string sLoc, string EquNO, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.Loc} = '{sLoc}', {Parameter.clsCmd_Mst.Column.Equ_No} = '{EquNO}' " +
                    $"where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";
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

        public bool FunUpdateCurLoc(string sCmdSno, string sCurDeviceID, string sCurLoc, DataBase.DB db)
        {
            try
            {
                string sCmdSts = string.IsNullOrWhiteSpace(sCurLoc) ? clsConstValue.CmdSts.strCmd_Initial : clsConstValue.CmdSts.strCmd_Running;

                string strSql = $"update {Parameter.clsCmd_Mst.TableName} set " +
                    $"{Parameter.clsCmd_Mst.Column.CurDeviceID} = '" + sCurDeviceID + 
                    $"', {Parameter.clsCmd_Mst.Column.CurLoc} = '{sCurLoc}', " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Sts} = '{sCmdSts}' ";

                strSql += $", {Parameter.clsCmd_Mst.Column.Expose_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

                strSql += $" where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '{sCmdSno}' ";

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

        public bool FunInsCmdMst(CmdMstInfo stuCmdMst, ref string strErrMsg, DataBase.DB db)
        {
            string sSQL = "";
            try
            {
                sSQL = $"INSERT INTO {Parameter.clsCmd_Mst.TableName} ({Parameter.clsCmd_Mst.Column.Cmd_Sno}, " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Sts}, {Parameter.clsCmd_Mst.Column.Prty}, " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Abnormal}, {Parameter.clsCmd_Mst.Column.Stn_No}, " +
                    $"{Parameter.clsCmd_Mst.Column.Cmd_Mode}, {Parameter.clsCmd_Mst.Column.IO_Type}, " +
                    $"{Parameter.clsCmd_Mst.Column.Loc}, {Parameter.clsCmd_Mst.Column.New_Loc},";
                sSQL += $"{Parameter.clsCmd_Mst.Column.Create_Date}, {Parameter.clsCmd_Mst.Column.JobID}," +
                    $"{Parameter.clsCmd_Mst.Column.Expose_Date}, {Parameter.clsCmd_Mst.Column.End_Date}, {Parameter.clsCmd_Mst.Column.Trn_User}, " +
                    $"{Parameter.clsCmd_Mst.Column.BoxID}, {Parameter.clsCmd_Mst.Column.BatchID}," +
                    $"{Parameter.clsCmd_Mst.Column.Equ_No}, {Parameter.clsCmd_Mst.Column.CurLoc}, " +
                    $"{Parameter.clsCmd_Mst.Column.CurDeviceID}, {Parameter.clsCmd_Mst.Column.Zone}, {Parameter.clsCmd_Mst.Column.Remark}," +
                    $"{Parameter.clsCmd_Mst.Column.rackLocation}, {Parameter.clsCmd_Mst.Column.largest}, {Parameter.clsCmd_Mst.Column.carrierType}," +
                    $"{Parameter.clsCmd_Mst.Column.lotSize}) values(";
                sSQL += "'" + stuCmdMst.Cmd_Sno + "', ";
                sSQL += "'" + clsConstValue.CmdSts.strCmd_Initial + "', ";
                sSQL += "" + stuCmdMst.Prty + ", 'NA', ";
                sSQL += "'" + stuCmdMst.Stn_No + "', ";
                sSQL += "'" + stuCmdMst.Cmd_Mode + "', ";
                sSQL += "'" + stuCmdMst.IO_Type + "', ";
                //sSQL += $"'{stuCmdMst.WH_ID}', ";
                sSQL += "'" + stuCmdMst.Loc + "', ";
                sSQL += "'" + stuCmdMst.New_Loc + "', ";
                //sSQL += $"{stuCmdMst.Mix_Qty}, {stuCmdMst.Avail}, ";
                sSQL += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + $"','{stuCmdMst.JobID}', '', '', " +
                    $"'{stuCmdMst.Trn_User}', ";
                sSQL += "'" + stuCmdMst.BoxID + $"',";
                sSQL += $"'{stuCmdMst.BatchID}',";
                sSQL += "'" + stuCmdMst.Equ_No + "', ";
                sSQL += $"'{stuCmdMst.CurLoc}', ";
                sSQL += "'" + stuCmdMst.CurDeviceID + "',";
                sSQL += "'" + stuCmdMst.Zone_ID + "'," +
                    $"'{stuCmdMst.Remark}','{stuCmdMst.rackLocation}','{stuCmdMst.largest}','{stuCmdMst.carrierType}','{stuCmdMst.lotSize}')";

                if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, sSQL + " => " + strErrMsg);
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

        public bool FunDelCmdMst(string CommandID, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSQL = $"delete from {Parameter.clsCmd_Mst.TableName} where {Parameter.clsCmd_Mst.Column.Cmd_Sno} = '" + CommandID + "' ";
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

        public bool FunInsertCMD_MST_His(string sCmdSno, DataBase.DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsCMD_MST_His.TableName} ";
                SQL += $" SELECT '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', * FROM {Parameter.clsCmd_Mst.TableName} ";
                SQL += $" WHERE {Parameter.clsCmd_Mst.Column.Cmd_Sno}='{sCmdSno}'";

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

        public bool FunDelCMD_MST_His(double dblDay, DataBase.DB db)
        {
            try
            {
                string strDelDay = DateTime.Today.Date.AddDays(dblDay * (-1)).ToString("yyyy-MM-dd");
                string strSql = $"delete from {Parameter.clsCMD_MST_His.TableName} where {Parameter.clsCMD_MST_His.Column.HisDT} <= '" + strDelDay + "' ";

                int iRet = db.ExecuteSQL(strSql);
                if (iRet == DBResult.Success)
                {
                    strSql = $"delete from {Parameter.clsCmd_Dtl_His.TableName} where {Parameter.clsCmd_Dtl_His.Column.HisDT} <= '" + strDelDay + "' ";
                    iRet = db.ExecuteSQL(strSql);
                    if (iRet == DBResult.Success)
                        return true;
                    else return false;
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
    }
}
