using Mirle.DataBase;
using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.EccsSignal.DB_Proc
{
    public class clsProc
    {
        private clsDbConfig _config = new clsDbConfig();
        public clsProc(clsDbConfig config)
        {
            _config = config;
        }

        public int FunGetCrane(string iCrn, ref DataTable dtTmp, ref DataTable dtMode, ref DataTable dtSts, ref string strEM)
        {
            int iRet = DBResult.Initial;
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    string strSql = "select * from EquPlcData where EquNo='" + iCrn + "' ";
                    iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);

                        if (iRet == DBResult.Success)
                        {
                            strSql = "SELECT * FROM EQUMODELOG WHERE EQUNO='" + iCrn + "' ";
                            strSql += " and ENDDT IN ('',' ')";
                            iRet = db.GetDataTable(strSql, ref dtMode, ref strEM);
                            if (iRet == DBResult.Success)
                            {
                                strSql = "SELECT * FROM EQUSTSLOG WHERE EQUNO='" + iCrn + "' ";
                                strSql += " and ENDDT IN ('',' ')";

                                iRet = db.GetDataTable(strSql, ref dtSts, ref strEM);
                            }
                        }
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
