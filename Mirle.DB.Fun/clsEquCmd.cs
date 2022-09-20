using Mirle.DataBase;
using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun
{
    public class clsEquCmd
    {
        public int FunGetInitialEquCmd(string sEquNo, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = $"select * from {Parameter.clsEquCmd.TableName}" +
                    $" where {Parameter.clsEquCmd.Column.EquNo} = '{sEquNo}' and " +
                    $"{Parameter.clsEquCmd.Column.CmdSts} = '{clsConstValue.CmdSts.strCmd_Initial}' ORDER BY ";
                strSql += $"{Parameter.clsEquCmd.Column.Priority}, {Parameter.clsEquCmd.Column.Create_Date}, " +
                    $"{Parameter.clsEquCmd.Column.CmdSno}, {Parameter.clsEquCmd.Column.EquNo}";
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

        public bool FunUpdateCmdSts(string sCmdSno, string sEquNo, string sCmdSts, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsEquCmd.TableName} set {Parameter.clsEquCmd.Column.ReNewFlag}='Y'" +
                    $", {Parameter.clsEquCmd.Column.Action_Date} = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}'" +
                    $", {Parameter.clsEquCmd.Column.CmdSts} = '{sCmdSts}'" +
                    $" where {Parameter.clsEquCmd.Column.CmdSno} = '{sCmdSno}' and " +
                    $"{Parameter.clsEquCmd.Column.EquNo} = '{sEquNo}'";
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

        public bool FunUpdateCmdSts(string sCmdSno, string sEquNo, string sCmdSts, string CompleteCode, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsEquCmd.TableName} set {Parameter.clsEquCmd.Column.ReNewFlag}='Y'" +
                    $", {Parameter.clsEquCmd.Column.End_Date} = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}'" +
                    $", {Parameter.clsEquCmd.Column.CmdSts} = '{sCmdSts}'" +
                    $", {Parameter.clsEquCmd.Column.CompleteCode} = '{CompleteCode}'" +
                    $", {Parameter.clsEquCmd.Column.Remark} = N'{sRemark}'" +
                    $" where {Parameter.clsEquCmd.Column.CmdSno} = '{sCmdSno}' and " +
                    $"{Parameter.clsEquCmd.Column.EquNo} = '{sEquNo}'";
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

        public bool FunUpdateRemark(string sCmdSno, string sEquNo, string sRemark, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsEquCmd.TableName} set " +
                    $"{Parameter.clsEquCmd.Column.Remark} = N'" + sRemark + $"' where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '{sCmdSno}' and {Parameter.clsEquCmd.Column.EquNo} = '{sEquNo}'";
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

        public bool FunInsEquCmd(EquCmdInfo cmd, DataBase.DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsEquCmd.TableName}({Parameter.clsEquCmd.Column.CmdSno}," +
                    $"{Parameter.clsEquCmd.Column.EquNo},{Parameter.clsEquCmd.Column.CmdMode}," +
                    $"{Parameter.clsEquCmd.Column.CmdSts},{Parameter.clsEquCmd.Column.Source}," +
                    $"{Parameter.clsEquCmd.Column.Destination},{Parameter.clsEquCmd.Column.LocSize}," +
                    $"{Parameter.clsEquCmd.Column.Priority},{Parameter.clsEquCmd.Column.Create_Date}," +
                    $"{Parameter.clsEquCmd.Column.ReNewFlag},{Parameter.clsEquCmd.Column.SpeedLevel}) values (";
                SQL += $"'{cmd.CmdSno}', '{cmd.EquNo}', '{cmd.CmdMode}', '{clsConstValue.CmdSts.strCmd_Initial}', ";
                SQL += $"'{cmd.Source}', '{cmd.Destination}', '{cmd.LocSize}', '{cmd.Priority}', " +
                    $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{cmd.ReNewFlag}', '{cmd.SpeedLevel}')";
                string strEM = "";
                int iRet = db.ExecuteSQL(SQL, ref strEM);
                if (iRet == DBResult.Success) return true;
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

        public bool FunDelEquCmd(string sCmdSno, string sEquNo, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSQL = $"delete from {Parameter.clsEquCmd.TableName} where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '" + sCmdSno + 
                    $"' and {Parameter.clsEquCmd.Column.EquNo} = '{sEquNo}' ";
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
        public bool FunDelEquCmd(string sCmdSno, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSQL = $"delete from {Parameter.clsEquCmd.TableName} where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '" + sCmdSno + "'";
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

        public int CheckHasEquCmdByCmdSno(string sCmdSno, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsEquCmd.TableName} where " +
                    $"{Parameter.clsEquCmd.Column.CmdSno} = '{sCmdSno}'";
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
    }
}
