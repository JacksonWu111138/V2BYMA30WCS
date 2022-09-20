using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Mirle.DataBase;

namespace Mirle.DB.Fun
{
    public class clsL2LCount
    {
        public int FunSelectNeedToTeach(int MaxCount, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsL2LCount.TableName} where " +
                    $"{Parameter.clsL2LCount.Column.Count} >= {MaxCount}";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if(iRet == DBResult.Exception)
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

        public int CheckHasData(string BoxID, ref string strEM, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsL2LCount.TableName} where " +
                    $"{Parameter.clsL2LCount.Column.BoxID} = '{BoxID}' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);

                if (iRet == DBResult.Exception)
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
            finally
            {
                dtTmp = null;
            }
        }

        public bool FunUpdL2LCount(string BoxID, ref string strEM, DataBase.DB db)
        {
            try
            {
                string strSql = $"update {Parameter.clsL2LCount.TableName} set {Parameter.clsL2LCount.Column.Count} = " +
                    $"{Parameter.clsL2LCount.Column.Count} + 1,{Parameter.clsL2LCount.Column.Update_Date} = " +
                    $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}' where {Parameter.clsL2LCount.Column.BoxID} = '{BoxID}' ";
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
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool FunInsL2LCount(string BoxID, ref string strEM, DataBase.DB db)
        {
            try
            {
                string strSql = $"insert into {Parameter.clsL2LCount.TableName} ({Parameter.clsL2LCount.Column.BoxID}," +
                    $"{Parameter.clsL2LCount.Column.Create_Date}) values('{BoxID}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
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
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool FunDelL2LCount(string BoxID, ref string strEM, DataBase.DB db)
        {
            try
            {
                string strSql = $"delete from {Parameter.clsL2LCount.TableName} where " +
                    $"{Parameter.clsL2LCount.Column.BoxID} = '{BoxID}' ";
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
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }
    }
}
