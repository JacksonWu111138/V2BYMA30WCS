using System;
using System.Data;
using Mirle.DataBase;
using Mirle.Def;

namespace Mirle.DB.Proc
{
    public class clsUnitStsLog
    {
        private Fun.clsUnitStsLog unitStsLog = new Fun.clsUnitStsLog();
        private clsDbConfig _config = new clsDbConfig();
        public clsUnitStsLog(clsDbConfig config)
        {
            _config = config;
        }

        public bool FunCheckAllRMSts(ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return unitStsLog.FunCheckAllRMSts(ref dtTmp, db);
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

        public bool FunInsSts(string ID, clsEnum.UnitType type, clsEnum.IOPortStatus portStatus)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        unitStsLog.FunUpdUnitStsLog(ID, type, db);
                        unitStsLog.FunInsUnitStsLog(ID, type, portStatus, db);
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

        public bool FunGetCVDowntimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        unitStsLog.FunGetCVDowntimeStsLog(startTime, endTime, eqpId, ref dtTmp, db);
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

        public bool FunGetDowntimeSts(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        unitStsLog.FunGetDowntimeStsLog(startTime, endTime, eqpId,ref dtTmp, db);
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

        public bool FunGetUptimeSts(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        unitStsLog.FunGetUptimeStsLog(startTime, endTime, eqpId, ref dtTmp, db);
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
