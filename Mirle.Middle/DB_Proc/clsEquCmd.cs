using Mirle.DataBase;
using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Middle.DB_Proc
{
    public class clsEquCmd
    {
        private clsDbConfig _config = new clsDbConfig();
        private clsTool tool = new clsTool();
        public clsEquCmd(clsDbConfig config)
        {
            _config = config;
        }

        public int GetMiddleCmd(string sCmdSno, ref MiddleCmd middleCmd, DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                            $"{Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) middleCmd = tool.GetMiddleCmd(dtTmp.Rows[0]);
                else { }

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
                dtTmp.Dispose();
            }
        }

        public int GetMiddleCmd_byBatchID(string sBatchID, ref MiddleCmd[] cmds, DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsMiddleCmd.TableName} where " +
                            $"{Parameter.clsMiddleCmd.Column.BatchID} = '{sBatchID}' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    cmds = new MiddleCmd[dtTmp.Rows.Count];
                    for (int i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        cmds[i] = tool.GetMiddleCmd(dtTmp.Rows[i]);
                    }
                }
                else { }

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
                dtTmp.Dispose();
            }
        }

        public bool funCheckCanInsertEquCmd(string EquNo, DB db)
        {
            DataTable objDataTable = new DataTable();
            try
            {
                string strSQL = $"SELECT COUNT (*) AS ICOUNT FROM {Parameter.clsEquCmd.TableName} WHERE " +
                    $"{Parameter.clsEquCmd.Column.EquNo}='" + EquNo + "' ";

                objDataTable = new DataTable();
                if (db.GetDataTable(strSQL, ref objDataTable) == DBResult.Success)
                {
                    int intCraneNo = int.Parse(objDataTable.Rows[0]["ICOUNT"].ToString());
                    return intCraneNo == 0 ? true : false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }

        public bool FunUpdEquCmdSts(EquCmdInfo equCmd, string sNewSts, string sNewCompleteCode, DB db)
        {
            try
            {
                string strSql = $"UPDATE {Parameter.clsEquCmd.TableName} SET " +
                    $"{Parameter.clsEquCmd.Column.CmdSts} = '{sNewSts}'" +
                    $", {Parameter.clsEquCmd.Column.CompleteCode} = '{sNewCompleteCode}' where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '{equCmd.CmdSno}' and {Parameter.clsEquCmd.Column.EquNo} = '{equCmd.EquNo}'";
                string strEM = "";
                if(db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
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

        public bool FunUpdEquCmdSts(EquCmdInfo equCmd, string sNewSts, string sNewMode, string sNewCompleteCode, DB db)
        {
            try
            {
                string strSql = $"UPDATE {Parameter.clsEquCmd.TableName} SET " +
                    $"{Parameter.clsEquCmd.Column.CmdSts} = '{sNewSts}'" +
                    $", {Parameter.clsEquCmd.Column.CompleteCode} = '{sNewCompleteCode}'" +
                    $", {Parameter.clsEquCmd.Column.CmdMode} = '{sNewMode}' where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '{equCmd.CmdSno}' and {Parameter.clsEquCmd.Column.EquNo} = '{equCmd.EquNo}'";
                string strEM = "";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
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

        public bool FunUpdateRemark_MiddleCmd(string sCmdSno, string sRemark, DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsMiddleCmd.TableName} set " +
                    $"{Parameter.clsMiddleCmd.Column.Remark} = N'" + sRemark +
                    $"' where {Parameter.clsMiddleCmd.Column.CommandID} = '{sCmdSno}'";

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

        public bool FunUpdateCmdSts_MiddleCmd(string sCmdSno, string sCmdSts, string sRemark, DB db)
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

        public bool FunUpdateCmdSts_MiddleCmd(string sCmdSno, string sCmdSts, string sCompleteCode, string sRemark, DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsMiddleCmd.TableName} set" +
                    $" {Parameter.clsMiddleCmd.Column.Remark} = N'" + sRemark +
                    $"', {Parameter.clsMiddleCmd.Column.CmdSts} = '{sCmdSts}'" +
                    $", {Parameter.clsMiddleCmd.Column.CompleteCode} = '{sCompleteCode}'";

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

        public bool FunUpdateCmdSts_MiddleCmd(MiddleCmd[] cmds, string sCmdSts, string sCompleteCode, string sRemark, DB db)
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
                    $"', {Parameter.clsMiddleCmd.Column.CmdSts} = '{sCmdSts}' " +
                    $", {Parameter.clsMiddleCmd.Column.CompleteCode} = '{sCompleteCode}'";

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

        public bool FunInsEquCmd(EquCmdInfo cmd, DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsEquCmd.TableName}({Parameter.clsEquCmd.Column.CmdSno}," +
                    $"{Parameter.clsEquCmd.Column.EquNo},{Parameter.clsEquCmd.Column.CmdMode},{Parameter.clsEquCmd.Column.CmdSts}," +
                    $"{Parameter.clsEquCmd.Column.Source},{Parameter.clsEquCmd.Column.Destination},{Parameter.clsEquCmd.Column.LocSize}," +
                    $"{Parameter.clsEquCmd.Column.Priority},{Parameter.clsEquCmd.Column.CreateDate},{Parameter.clsEquCmd.Column.ReNewFlag}," +
                    $"{Parameter.clsEquCmd.Column.SpeedLevel}) values (";
                SQL += $"'{cmd.CmdSno}', '{cmd.EquNo}', '{cmd.CmdMode}', '{clsConstValue.CmdSts.strCmd_Initial}', ";
                SQL += $"'{cmd.Source}', '{cmd.Destination}', '{cmd.LocSize}', '{cmd.Priority}', " +
                    $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{cmd.ReNewFlag}', '{cmd.SpeedLevel}')";
                string strEM = "";
                int iRet = db.ExecuteSQL(SQL, ref strEM);
                if (iRet == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, SQL);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{SQL} => {strEM}");
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

        public bool FunDelEquCmd(EquCmdInfo cmd, DB db)
        {
            try
            {
                string SQL = $"delete from {Parameter.clsEquCmd.TableName} WHERE " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '{cmd.CmdSno}' and {Parameter.clsEquCmd.Column.EquNo} = '{cmd.EquNo}'";
                string strEM = "";
                int iRet = db.ExecuteSQL(SQL, ref strEM);
                if (iRet == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, SQL);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{SQL} => {strEM}");
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

        public bool FunInsertEquCmd_His(EquCmdInfo cmd, DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsEquCmdHis.TableName} ";
                SQL += $" SELECT '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', * FROM {Parameter.clsEquCmd.TableName} ";
                SQL += $" WHERE {Parameter.clsEquCmd.Column.CmdSno} = '{cmd.CmdSno}' and {Parameter.clsEquCmd.Column.EquNo} = '{cmd.EquNo}'";

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

        public bool FunEquCmdFinish_Proc()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        string strSql = $"select * from {Parameter.clsEquCmd.TableName} where " +
                            $"{Parameter.clsEquCmd.Column.CmdSts} in ('{clsConstValue.CmdSts.strCmd_Cancel_Wait}', '{clsConstValue.CmdSts.strCmd_Finished}')";
                        string strEM = "";
                        iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                        switch(iRet)
                        {
                            case DBResult.Success:
                                for (int i = 0; i < dtTmp.Rows.Count; i++)
                                {
                                    EquCmdInfo equCmd = tool.GetEquCmd(dtTmp.Rows[i]);
                                    MiddleCmd middleCmd = new MiddleCmd();
                                    if(GetMiddleCmd(equCmd.CmdSno, ref middleCmd, db) != DBResult.Success)
                                    {
                                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, "NG: 取得MiddleCmd資料失敗 => " +
                                            $"<{Parameter.clsMiddleCmd.Column.CommandID}>{equCmd.CmdSno}");
                                        continue;
                                    }

                                    if (equCmd.CompleteCode.Substring(0, 1) == "W")
                                    {
                                        if (FunUpdEquCmdSts(equCmd, clsConstValue.CmdSts.strCmd_Initial, "", db)) return true;
                                        else continue;
                                    }
                                    else if (
                                               (equCmd.CmdMode == clsConstValue.CmdMode.StockOut || equCmd.CmdMode == clsConstValue.CmdMode.S2S)
                                               && equCmd.CompleteCode == clsConstValue.CompleteCode.DoubleStorage
                                             )
                                    {
                                        if (FunUpdEquCmdSts(equCmd, clsConstValue.CmdSts.strCmd_Initial, clsConstValue.CmdMode.Deposit, "", db)) return true;
                                        else continue;
                                    }
                                    else
                                    {
                                        string sRemark = "";
                                        if (string.IsNullOrWhiteSpace(middleCmd.BatchID))
                                        {
                                            #region 單板命令
                                            if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                            {
                                                sRemark = "Error: Begin失敗！";
                                                if (sRemark != middleCmd.Remark)
                                                {
                                                    FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            sRemark = "Crane命令完成";
                                            if (!FunUpdateCmdSts_MiddleCmd(middleCmd.CommandID, clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait,
                                                equCmd.CompleteCode, sRemark, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                continue;
                                            }

                                            if (!FunInsertEquCmd_His(equCmd, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: Insert EquCmdHis失敗";
                                                if (sRemark != middleCmd.Remark)
                                                {
                                                    FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            if (!FunDelEquCmd(equCmd, db))
                                            {
                                                db.TransactionCtrl(TransactionTypes.Rollback);
                                                sRemark = "Error: 刪除EquCmd失敗";
                                                if (sRemark != middleCmd.Remark)
                                                {
                                                    FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                }

                                                continue;
                                            }

                                            db.TransactionCtrl(TransactionTypes.Commit);
                                            return true;
                                            #endregion 單板命令
                                        }
                                        else
                                        {
                                            #region 雙板命令
                                            MiddleCmd[] middleCmds = new MiddleCmd[2];
                                            if (GetMiddleCmd_byBatchID(middleCmd.BatchID, ref middleCmds, db) == DBResult.Success)
                                            {
                                                if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success)
                                                {
                                                    sRemark = "Error: Begin失敗！";
                                                    if (sRemark != middleCmd.Remark)
                                                    {
                                                        FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                    }

                                                    continue;
                                                }

                                                sRemark = "Crane命令完成";
                                                if (!FunUpdateCmdSts_MiddleCmd(middleCmds, clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait,
                                                    equCmd.CompleteCode, sRemark, db))
                                                {
                                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                                    continue;
                                                }

                                                if (!FunInsertEquCmd_His(equCmd, db))
                                                {
                                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                                    sRemark = "Error: Insert EquCmdHis失敗";
                                                    if (sRemark != middleCmd.Remark)
                                                    {
                                                        FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                    }

                                                    continue;
                                                }

                                                if (!FunDelEquCmd(equCmd, db))
                                                {
                                                    db.TransactionCtrl(TransactionTypes.Rollback);
                                                    sRemark = "Error: 刪除EquCmd失敗";
                                                    if (sRemark != middleCmd.Remark)
                                                    {
                                                        FunUpdateRemark_MiddleCmd(middleCmd.CommandID, sRemark, db);
                                                    }

                                                    continue;
                                                }

                                                db.TransactionCtrl(TransactionTypes.Commit);
                                                return true;
                                            }
                                            else
                                            {
                                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, "NG: 取得MiddleCmd雙板資料失敗 => " +
                                                                          $"<{Parameter.clsMiddleCmd.Column.BatchID}>{middleCmd.BatchID}");
                                                continue;
                                            }
                                            #endregion 雙板命令
                                        }
                                    }
                                }

                                return false;
                            case DBResult.NoDataSelect:
                                return true;
                            default:
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                                return false;
                        }
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
    }
}
