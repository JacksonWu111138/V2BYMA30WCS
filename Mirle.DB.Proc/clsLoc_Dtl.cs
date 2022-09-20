using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc
{
    public class clsLoc_Dtl
    {
        private clsDbConfig _config = new clsDbConfig();
        private Fun.clsLocDtl LocDtl = new Fun.clsLocDtl();
        public clsLoc_Dtl(clsDbConfig config)
        {
            _config = config;
        }

        public bool FunDelLocDtlLog(double dblDay)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return LocDtl.FunDelLocDtlLog(dblDay, db);
                    }
                    else return false;
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
