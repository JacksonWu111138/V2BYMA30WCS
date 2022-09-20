using System;
using System.Data;
using Mirle.DataBase;
using Mirle.Def;

namespace Mirle.DB.Proc
{
    public class clsEQ_Alarm
    {
        private Fun.clsEQ_Alarm eq_Alarm = new Fun.clsEQ_Alarm();
        private clsDbConfig _config = new clsDbConfig();
        public clsEQ_Alarm(clsDbConfig config)
        {
            _config = config;
        }

        public bool FunInsSts(int cvBuffer, string alarm, clsEnum.AlarmSts alarmSts)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        eq_Alarm.FunInsEQ_Alarm(cvBuffer, alarm, alarmSts, db);
                        return true;
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

        public bool FunUpdSts(int cvBuffer, string alarm, clsEnum.AlarmSts alarmSts)
        {

            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        eq_Alarm.FunUpdEQ_Alarm(cvBuffer, alarm, alarmSts, db);
                        return true;
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
