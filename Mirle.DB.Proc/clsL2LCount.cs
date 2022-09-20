using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc
{
    public class clsL2LCount
    {
        private Fun.clsL2LCount L2LCount = new Fun.clsL2LCount();
        private clsDbConfig _config = new clsDbConfig();
        public clsL2LCount(clsDbConfig config)
        {
            _config = config;
        }

        public int FunSelectNeedToTeach(int MaxCount, ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return L2LCount.FunSelectNeedToTeach(MaxCount, ref dtTmp, db);
                    }

                    return iRet;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }
    }
}
