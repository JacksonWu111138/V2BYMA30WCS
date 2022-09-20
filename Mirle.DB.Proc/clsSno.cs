using System;

using Mirle.DataBase;
using Mirle.Def;

namespace Mirle.DB.Proc
{
    public class clsSno
    {
        private clsDbConfig _config = new clsDbConfig();
        private Fun.clsSno SNO = new Fun.clsSno();
        public clsSno(clsDbConfig config)
        {
            _config = config;
        }

        public string FunGetSeqNo(clsEnum.enuSnoType objType)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return SNO.FunGetSeqNo(objType, db);
                    }
                    else
                        return string.Empty;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return string.Empty;
            }
        }
    }
}
