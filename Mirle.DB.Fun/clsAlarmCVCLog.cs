using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.DB.Fun
{
    public class clsAlarmCVCLog
    {
        public bool FunAlarm_Occur(string sCmdSno, string deviceId, string alarmCode, string alarmDef, string bufferId, 
            string happenTime, DataBase.DB db, ref string strEM)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsAlarmCVCLog.TableName} where " +
                    $"{Parameter.clsAlarmCVCLog.Column.AlarmCode} = '{alarmCode}' ";
                strSql += $" and {Parameter.clsAlarmCVCLog.Column.AlarmSts} = '{Parameter.clsAlarmCVCLog.Status.Occur}' and " +
                    $"{Parameter.clsAlarmCVCLog.Column.DeviceID} = '{deviceId}' and {Parameter.clsAlarmCVCLog.Column.CmdSno} = '{sCmdSno}' ";

                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else if (iRet == DBResult.NoDataSelect)
                {
                    strSql = $"INSERT INTO {Parameter.clsAlarmCVCLog.TableName} ({Parameter.clsAlarmCVCLog.Column.CmdSno}," +
                        $"{Parameter.clsAlarmCVCLog.Column.DeviceID},{Parameter.clsAlarmCVCLog.Column.BufferID}," +
                        $"{Parameter.clsAlarmCVCLog.Column.AlarmCode},{Parameter.clsAlarmCVCLog.Column.AlarmDef}," +
                        $"{Parameter.clsAlarmCVCLog.Column.AlarmSts},{Parameter.clsAlarmCVCLog.Column.Start_Date}" +
                        $") values (";
                    strSql += $"'{sCmdSno}', '{deviceId}', '{bufferId}', '{alarmCode}', '{alarmDef}', "+
                        $"'{Parameter.clsAlarmCVCLog.Status.Occur}', '{happenTime}')";
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
        
        public bool FunAlarm_Solved(string sCmdSno, string deviceId, string alarmCode, string alarmDef, string bufferId,
            string happenTime, DataBase.DB db, ref string strEM)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from {Parameter.clsAlarmCVCLog.TableName} where " +
                    $"{Parameter.clsAlarmCVCLog.Column.AlarmCode} = '{alarmCode}' and {Parameter.clsAlarmCVCLog.Column.AlarmSts} = "+
                    $"'{Parameter.clsAlarmCVCLog.Status.Occur}' and {Parameter.clsAlarmCVCLog.Column.DeviceID} = '{deviceId}' " + 
                    $"and {Parameter.clsAlarmCVCLog.Column.CmdSno} = '{sCmdSno}'";

                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    string aAlarmTime = Convert.ToString(dtTmp.Rows[0][Parameter.clsAlarmCVCLog.Column.Start_Date]);

                    string sDate1 = aAlarmTime;
                    string sClsTime = happenTime;
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

                    strSql = $"update {Parameter.clsAlarmCVCLog.TableName} set {Parameter.clsAlarmCVCLog.Column.AlarmSts}=" +
                        $"'{Parameter.clsAlarmCVCLog.Status.Clear}',{Parameter.clsAlarmCVCLog.Column.Clear_Date}='{sClsTime}'," +
                    $"{Parameter.clsAlarmCVCLog.Column.Total_Secs}= {iTotalSecs} where " +
                    $"{Parameter.clsAlarmCVCLog.Column.AlarmCode} = '{alarmCode}' and {Parameter.clsAlarmCVCLog.Column.AlarmSts} = " +
                    $"'{Parameter.clsAlarmCVCLog.Status.Occur}' and {Parameter.clsAlarmCVCLog.Column.DeviceID} = '{deviceId}' " + 
                    $"{Parameter.clsAlarmCVCLog.Column.CmdSno} = '{sCmdSno}' ";
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
    }
}
