using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Object.Table
{
    public class clsLocMst
    {
        public static int FunGetTeachLoc_Grid(ref DataTable dtTmp) => clsDB_Proc.GetDB_Object().GetLocMst().FunGetTeachLoc_Grid(ref dtTmp);
        public static int CheckIsTeach(string DeviceID, string Loc, ref bool IsTeach) => clsDB_Proc.GetDB_Object().GetLocMst().CheckIsTeach(DeviceID, Loc, ref IsTeach);
        public static bool FunUpdTeachLocSts(string sDeviceID, string sLoc, clsEnum.LocSts sts, string sBoxID)
            => clsDB_Proc.GetDB_Object().GetLocMst().FunUpdTeachLocSts(sDeviceID, sLoc, sts, sBoxID);
        public static bool FunInsTeachLoc(string sDeviceID, string sLoc, clsEnum.LocSts sts, string sBoxID)
            => clsDB_Proc.GetDB_Object().GetLocMst().FunInsTeachLoc(sDeviceID, sLoc, sts, sBoxID);
    }
}
