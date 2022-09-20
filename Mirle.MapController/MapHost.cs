using System;
using System.Collections.Generic;
using Mirle.MapController.DB_Proc;
using System.Data;
using System.Linq;
using Mirle.DRCS;
using Mirle.Def;

namespace Mirle.MapController
{
    public class MapHost
    {
        private RouteService routeService = new RouteService();
        private System.Timers.Timer timRead = new System.Timers.Timer();
        private readonly clsHost db;
        public MapHost(clsDbConfig config)
        {
            db = new clsHost(config);
            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = true; timRead.Interval = 100;
        }

        private List<Location>[] Nodes = new List<Location>[0];
        public bool Done = false;
        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            DataTable dtTmp = new DataTable();
            try
            {
                if (db.GetProc().FunMapping_Proc(out Nodes, ref dtTmp))
                {
                    for (int i = 0; i < Nodes.Length; i++)
                    {
                        foreach(var loc1 in Nodes[i])
                        {
                            foreach(var loc2 in Nodes[i])
                            {
                                if(loc1 != loc2)
                                {
                                    switch(loc1.Direction)
                                    {
                                        case clsEnum.IOPortDirection.Both:
                                        case clsEnum.IOPortDirection.InMode:
                                            switch(loc2.Direction)
                                            {
                                                case clsEnum.IOPortDirection.Both:
                                                case clsEnum.IOPortDirection.OutMode:
                                                    routeService.AddPath(loc1, loc2);
                                                    break;
                                            }

                                            break;
                                    }
                                }
                            }
                        }
                    }

                    if (dtTmp != null && dtTmp.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtTmp.Rows.Count; i++)
                        {
                            string DeviceID = Convert.ToString(dtTmp.Rows[i][DB_Proc.Parameter.clsRoutdef.Column.DeviceID]);
                            string HostPortID = Convert.ToString(dtTmp.Rows[i][DB_Proc.Parameter.clsRoutdef.Column.HostPortID]);
                            var n1 = GetLocation(DeviceID, HostPortID);
                            if (n1 == null)
                            {
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error,
                                    $"Router找不到此Location => <DeviceID>{DeviceID} <HostPortID>{HostPortID}");
                                continue;
                            }

                            DeviceID = Convert.ToString(dtTmp.Rows[i][DB_Proc.Parameter.clsRoutdef.Column.NextDeviceID]);
                            HostPortID = Convert.ToString(dtTmp.Rows[i][DB_Proc.Parameter.clsRoutdef.Column.NextHostPortID]);
                            var n2 = GetLocation(DeviceID, HostPortID);
                            if (n2 == null)
                            {
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error,
                                    $"Router找不到此Location => <DeviceID>{DeviceID} <HostPortID>{HostPortID}");
                                continue;
                            }

                            if (n1.DeviceId == n2.DeviceId) continue;
                            else routeService.AddDevicePath(n1, n2);
                        }
                    }

                    Done = true;
                    timRead.Enabled = false;
                }
                else timRead.Enabled = true;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                timRead.Enabled = true;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public Location GetLocation(string DeviceID, string HostPortID)
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                if(Nodes[i].Any(r => r.DeviceId == DeviceID && r.LocationId == HostPortID))
                {
                    var node = Nodes[i].Where(r => r.DeviceId == DeviceID && r.LocationId == HostPortID);
                    foreach (var s in node)
                    {
                        return s;
                    }
                }
            }

            return null;
        }

        public bool GetPath(Location Start, Location End, ref Location Now_Start, ref Location Now_End)
        {
            try
            {
                var path = routeService.GetPath(Start, End);
                if (!path.Any())
                {
                    return false;
                }

                int iRow_Path = 0;
                foreach (Location p in path)
                {
                    if (iRow_Path > 1) break;
                    if (iRow_Path == 0)
                    {
                        Now_Start = p;
                    }
                    else
                    {
                        Now_End = p;
                    }

                    iRow_Path++;
                }

                return true;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool EnablePath(Location Start, Location End, bool Enable)
        {
            try
            {
                routeService.EnalePath(Start, End, Enable);
                return true;
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }

        public bool EnableNode(Location Node, bool Enable)
        {
            try
            {
                routeService.EnalePath(Node, Enable);
                return true;
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
