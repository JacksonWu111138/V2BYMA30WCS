using Mirle.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mirle.Def;
using System.Windows.Forms;

namespace Mirle.MapController.DB_Proc
{
    public class clsProc
    {
        private string[] sDevice = new string[0];
        private List<Location>[] glstPort = new List<Location>[0];

        private clsDbConfig _config = new clsDbConfig();
        public clsProc(clsDbConfig config)
        {
            _config = config;
        }

        public  bool FunMapping_Proc(out List<Location>[] ports, ref DataTable dtRoutDef)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        if (FunGetAllPort(out ports, db))
                        {
                            if (ports.Length <= 0) return false;

                            dtRoutDef = new DataTable();
                            return GetRoutdef(ref dtRoutDef, db);
                        }
                        else
                        {
                            ports = new List<Location>[0];
                            return false;
                        }
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, "資料庫開啟失敗！");
                        ports = new List<Location>[0];
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                ports = new List<Location>[0];
                return false;
            }
        }

        public bool FunDevice(DB db)
        {
            DataTable dtTmp = new DataTable();
            string strEM = "";
            try
            {
                string strSql = $"select DISTINCT {Parameter.clsPortDef.Column.DeviceID} from {Parameter.clsPortDef.TableName}";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    sDevice = new string[dtTmp.Rows.Count];
                    for (int i = 0; i < sDevice.Length; i++)
                    {
                        sDevice[i] = Convert.ToString(dtTmp.Rows[i][0]);
                    }

                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
                    return false;
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

        public List<Location> GetAllPort(string DeviceID, DB db)
        {
            List<Location> lstPorts = new List<Location>();
            Location objPort = null;
            DataTable dtTmp = new DataTable();
            string strEM = "";
            try
            {
                string strSql = $"select * from {Parameter.clsPortDef.TableName} where {Parameter.clsPortDef.Column.DeviceID} = '" + DeviceID + "' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    for (int i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        objPort = new Location(Convert.ToString(dtTmp.Rows[i][Parameter.clsPortDef.Column.DeviceID]),
                                                           Convert.ToString(dtTmp.Rows[i][Parameter.clsPortDef.Column.HostPortID]),
                                                           Location.GetLocationTypesByPortType(Convert.ToInt32(dtTmp.Rows[i][Parameter.clsPortDef.Column.PortType])),
                                                           MapController_2.clsTool.GetDirection(Convert.ToInt32(dtTmp.Rows[i][Parameter.clsPortDef.Column.Direction])));
                        lstPorts.Add(objPort);
                    }

                    return lstPorts;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return new List<Location>();
            }
            finally
            {
                dtTmp = null;
            }
        }

        public bool FunGetAllPort(out List<Location>[] ports, DB db)
        {
            try
            {
                if (FunDevice(db))
                {
                    glstPort = new List<Location>[sDevice.Length];
                    for (int i = 0; i < sDevice.Length; i++)
                    {
                        glstPort[i] = GetAllPort(sDevice[i], db);
                    }

                    ports = glstPort;
                    return true;
                }
                else
                {
                    ports = new List<Location>[0];
                    return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                ports = new List<Location>[0];
                return false;
            }
        }



        public bool GetRoutdef(ref DataTable dtTmp, DB db)
        {
            try
            {
                string strSql = $"select * from {Parameter.clsRoutdef.TableName}";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                    return false;
                }
                else return true;
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
