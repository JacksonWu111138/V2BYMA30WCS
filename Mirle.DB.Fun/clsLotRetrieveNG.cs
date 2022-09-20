using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun
{
    public class clsLotRetrieveNG
    {
        public bool FunLotRetrieveNG_Occur(string sCmdSno, string jobId, string lotId, DataBase.DB db, ref string strEM)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsLotRetrieveNG.TableName} where " +
                    $"{Parameter.clsLotRetrieveNG.Column.CmdSno} = '{sCmdSno}' ";
                strSql += $" and {Parameter.clsLotRetrieveNG.Column.CmdSts} = '{Parameter.clsLotRetrieveNG.Status.Occur}' and " +
                    $"{Parameter.clsLotRetrieveNG.Column.lotId} = '{lotId}' and {Parameter.clsLotRetrieveNG.Column.JobID} = '{jobId}' ";

                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else if (iRet == DBResult.NoDataSelect)
                {
                    strSql = $"insert into {Parameter.clsLotRetrieveNG.TableName}({Parameter.clsLotRetrieveNG.Column.CmdSno}," +
                        $"{Parameter.clsLotRetrieveNG.Column.JobID},{Parameter.clsLotRetrieveNG.Column.lotId}," +
                        $"{Parameter.clsLotRetrieveNG.Column.CmdSts},{Parameter.clsLotRetrieveNG.Column.Start_Date}" +
                        $") values(";
                    strSql += $"'{sCmdSno}', '{jobId}', '{lotId}', '{Parameter.clsLotRetrieveNG.Status.Occur}', '" +
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success) return true;
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                        return false;
                    }
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
            finally
            {
                dtTmp.Dispose();
            }
        }
        public int FunGetOccurCommand(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsLotRetrieveNG.TableName}" +
                    $" where {Parameter.clsLotRetrieveNG.Column.CmdSts} = '{Parameter.clsLotRetrieveNG.Status.Occur}'";
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
        public bool FunLotRetrieveNG_Solved (string sCmdSno, string lotId, DataBase.DB db, ref string strEM)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsLotRetrieveNG.TableName} where " +
                    $"{Parameter.clsLotRetrieveNG.Column.CmdSno} = '{sCmdSno}' ";
                strSql += $" and {Parameter.clsLotRetrieveNG.Column.CmdSts} = '{Parameter.clsLotRetrieveNG.Status.Occur}' and " +
                    $"{Parameter.clsLotRetrieveNG.Column.lotId} = '{lotId}'";

                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    string aAlarmTime = Convert.ToString(dtTmp.Rows[0][Parameter.clsLotRetrieveNG.Column.Start_Date]);

                    string sDate1 = aAlarmTime;
                    string sClsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    TimeSpan ts1 = new TimeSpan(DateTime.ParseExact(sDate1,
                                           "yyyy-MM-dd HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture
                                           ).Ticks);
                    TimeSpan ts2 = new TimeSpan(DateTime.ParseExact(sClsTime,
                                           "yyyy-MM-dd HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture
                                           ).Ticks);
                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                    double iTotalSecs = 0;
                    iTotalSecs = ts.TotalSeconds;

                    strSql = $"update {Parameter.clsLotRetrieveNG.TableName} set {Parameter.clsLotRetrieveNG.Column.CmdSts}=" +
                        $"'{Parameter.clsLotRetrieveNG.Status.Clear}',{Parameter.clsLotRetrieveNG.Column.Clear_Date}='{sClsTime}'," +
                    $"{Parameter.clsLotRetrieveNG.Column.Total_Secs}= {iTotalSecs} where " +
                    $"{Parameter.clsLotRetrieveNG.Column.CmdSno} = '{sCmdSno}' and {Parameter.clsLotRetrieveNG.Column.CmdSts} = " +
                    $"'{Parameter.clsLotRetrieveNG.Status.Occur}' and {Parameter.clsLotRetrieveNG.Column.lotId} = '{lotId}' ";
                    if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success) return true;
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                        return false;
                    }
                }
                else if (iRet == DBResult.NoDataSelect) return true;
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
            finally
            {
                dtTmp.Dispose();
            }
        }
        public bool FunDelLotRetrieveNGSolved(double dblDay, DataBase.DB db)
        {
            try
            {
                string strDelDay = DateTime.Today.Date.AddDays(dblDay * (-1)).ToString("yyyy-MM-dd");
                string strSql = $"delete from {Parameter.clsLotRetrieveNG.TableName} where {Parameter.clsLotRetrieveNG.Column.Clear_Date} <= '" + strDelDay + "' ";

                int iRet = db.ExecuteSQL(strSql);
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
    }
}
