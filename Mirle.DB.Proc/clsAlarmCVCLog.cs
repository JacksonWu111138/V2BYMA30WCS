using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc
{
    public class clsAlarmCVCLog
    {
        private Fun.clsAlarmCVCLog alarmCVCLog = new Fun.clsAlarmCVCLog();
        private clsDbConfig _config = new clsDbConfig();
        public clsAlarmCVCLog(clsDbConfig config)
        {
            _config = config;
        }
        public bool FunAlarm_Occur(string sCmdSno, string deviceId, string alarmCode, string alarmDef, string bufferId,
            string happenTime, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return alarmCVCLog.FunAlarm_Occur(sCmdSno, deviceId, alarmCode, alarmDef, bufferId, happenTime, db, ref strEM);
                    }

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
        public bool FunAlarm_Solved(string sCmdSno, string deviceId, string alarmCode, string alarmDef, string bufferId,
            string happenTime, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return alarmCVCLog.FunAlarm_Solved(sCmdSno, deviceId, alarmCode, alarmDef, bufferId, happenTime, db, ref strEM);
                    }

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
