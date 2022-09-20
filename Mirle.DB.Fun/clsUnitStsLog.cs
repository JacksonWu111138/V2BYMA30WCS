using System;
using System.Collections.Generic;
using System.Data;
using Mirle.DataBase;
using Mirle.Def;

namespace Mirle.DB.Fun
{
    public class clsUnitStsLog
    {
        public bool FunCheckAllRMSts(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = "SELECT a.StockerID, a.Status, b.In_enable FROM UnitStsLog as a LEFT JOIN UnitModeDef as b " +
                    "ON a.StockerID = b.StockerID WHERE a.ENDDT is null AND a.UnitID = 'C1' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
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

        public bool FunUpdUnitStsLog(string ID, clsEnum.UnitType type, DataBase.DB db)
        {
            try
            {
                var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var update = $"UPDATE UnitStsLog SET ENDDT='{now}', TotalSecs=datediff(SECOND,STRDT, '{now}') " +
                    $"WHERE StockerID = '{ID}' AND UnitID = '{(int)type}' AND ENDDT is null";
                string strEM = "";
                if (db.ExecuteSQL(update, ref strEM) == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{update} => {strEM}");
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

        public bool FunInsUnitStsLog(string ID, clsEnum.UnitType type, clsEnum.IOPortStatus portStatus, DataBase.DB db)
        {
            try
            {
                var sql = $"insert into UnitStsLog(StockerID,UnitID,STRDT,Status) values ('{ID}', '{(int)type}', " +
                    $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', {(int)portStatus})";
                string strEM = "";
                if (db.ExecuteSQL(sql, ref strEM) == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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

        public bool FunGetCVDowntimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}') or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status = '{(int)clsEnum.IOPortStatus.ERROR}'";
                if (eqpId != "")
                {
                    sql += $" and StockerID = '{eqpId}'";
                }
                else
                {
                    sql += $" and StockerID LIKE 'CV%'";
                }    
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else if (iRet == DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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

        public bool FunGetDowntimeStsLog(DateTime startTime, DateTime endTime,string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}') or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status not in ('{(int)clsEnum.CraneSts.Idle}','{(int)clsEnum.CraneSts.Busy}')";
                sql += $" and StockerID = '{eqpId}'";          
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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

        public bool FunGetUptimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                    $" or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status in ('{(int)clsEnum.CraneSts.Idle}','{(int)clsEnum.CraneSts.Busy}')" +
                    $" and StockerID = '{eqpId}'";
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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
        public bool FunGetRuntimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                    $" or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status = '{(int)clsEnum.CraneSts.Busy}'" +
                    $" and StockerID = '{eqpId}'";
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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
        public bool FunGetRepairtimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                    $" or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status in ('{(int)clsEnum.CraneSts.Stop}','{(int)clsEnum.CraneSts.Maintain}','{(int)clsEnum.CraneSts.StopAndOffline}','{(int)clsEnum.CraneSts.DownAndDoorOpen}')" +
                    $" and StockerID = '{eqpId}'";
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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
        public bool FunGetPortUptimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                    $" or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status = '{(int)clsEnum.PortSts.Run}'" +
                    $" and StockerID = '{eqpId}'";
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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
        public bool FunGetPortDowntimeStsLog(DateTime startTime, DateTime endTime, string eqpId, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                var sql = $"select * from UnitStsLog where ((STRDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                    $" or (ENDDT between '{startTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and '{endTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}'))" +
                    $" and Status = '{(int)clsEnum.PortSts.Down}'" +
                    $" and StockerID = {eqpId}" +
                    $" order by StockerID, STRDT";
                string strEM = "";
                int iRet = db.GetDataTable(sql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) return true;
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sql} => {strEM}");
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
