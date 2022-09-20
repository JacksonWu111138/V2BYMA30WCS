using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Object.Table
{
    public class clsUnitMode_Sts
    {
        public static bool FunCheckModeDef(ref DataTable dtTmp) => clsDB_Proc.GetDB_Object().GetUnitModeDef().FunCheckModeDef(ref dtTmp);
        public static bool FunInsSts(string ID, clsEnum.UnitType type, clsEnum.IOPortStatus portStatus) => clsDB_Proc.GetDB_Object().GetUnitStsLog().FunInsSts(ID, type, portStatus);
        public static bool FunUpdateModeDef(string StockerID, string mode) => clsDB_Proc.GetDB_Object().GetUnitModeDef().FunUpdateModeDef(StockerID, mode);
    }
}
