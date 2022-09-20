using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Object.Table
{
    public class clsEQ_Alarm
    {
        public static bool FunInsSts(int cvBuffer, string alarm, clsEnum.AlarmSts alarmSts) => clsDB_Proc.GetDB_Object().GetEQ_Alarm().FunInsSts(cvBuffer, alarm, alarmSts);
        public static bool FunUpdSts(int cvBuffer, string alarm, clsEnum.AlarmSts alarmSts) => clsDB_Proc.GetDB_Object().GetEQ_Alarm().FunUpdSts(cvBuffer, alarm, alarmSts);
    }
}
