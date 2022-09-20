using Mirle.DataBase;
using Mirle.Def;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc
{
    public class clsLotRetrieveNG
    {
        private Fun.clsLotRetrieveNG LotRetrieveNG = new Fun.clsLotRetrieveNG();
        private clsDbConfig _config = new clsDbConfig();
        private WebAPI.V2BYMA30.clsHost api = new WebAPI.V2BYMA30.clsHost();
        private WebApiConfig wesApiConfig = new WebApiConfig();
        public clsLotRetrieveNG(clsDbConfig config, WebApiConfig WesApiConfig)
        {
            _config = config;
            wesApiConfig = WesApiConfig;
        }

        public bool FunRetrieveNG_Occur(string sCmdSno, string jobId, string lotId, ref string strEM)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return LotRetrieveNG.FunLotRetrieveNG_Occur(sCmdSno, jobId, lotId, db, ref strEM);
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
        
        public bool FunLotRetrieveFailCancel_Proc()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        if (LotRetrieveNG.FunGetOccurCommand(ref dtTmp, db) == DBResult.Success)
                        {
                            string strEM = "";
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                string sCmdSno = Convert.ToString(dtTmp.Rows[i]["CmdSno"]);
                                string slotId = Convert.ToString(dtTmp.Rows[i]["lotId"]);

                                WCSCancelInfo info = new WCSCancelInfo
                                {
                                    lotIdCarrierId = slotId,
                                    cancelType = clsConstValue.WesApi.CancelType.Lot_Retrieve
                                };

                                if(!api.GetWCSCancel().FunReport(info, wesApiConfig.IP))
                                {
                                    var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                                    clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, 
                                        $"Error: WCS Cancel Fail, lotId = {slotId}, CancelType = {info.cancelType}.");
                                    continue;
                                }

                                if(!LotRetrieveNG.FunLotRetrieveNG_Solved(sCmdSno, slotId, db, ref strEM))
                                {
                                    var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                                    clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, strEM);
                                    continue;
                                }
                                
                            }

                            return true;
                        }
                        else return false;
                    }
                    else return false;
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
                dtTmp = null;
            }
        }

        public bool FunDelLotRetrieveNGSolved(double dblDay)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return LotRetrieveNG.FunDelLotRetrieveNGSolved(dblDay, db);
                    }
                    else return false;
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
