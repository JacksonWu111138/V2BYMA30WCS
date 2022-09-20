using Mirle.Def;
using Mirle.Stocker.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Structure;
using System.Threading.Tasks;
using Mirle.MapController;
using Mirle.Middle;
using Mirle.EccsSignal;
using Mirle.DB.Proc;

namespace Mirle.ASRS.DBCommand.DoubleDeep.SingleCrane.SingleFork
{
    public class Process : IProcess
    {
        private System.Timers.Timer timRead = new System.Timers.Timer();
        private DeviceInfo device;
        private MapHost router;
        private MidHost middle;
        private SignalHost signal;
        private clsHost _wcs;
        private DB.WMS.Proc.clsHost _wms;
        public Process(clsHost wcs, DB.WMS.Proc.clsHost wms, DeviceInfo Device, MapHost Router, MidHost Middle, SignalHost CrnSignal)
        {
            _wcs = wcs; _wms = wms;
            device = Device; router = Router; middle = Middle; signal = CrnSignal;
            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = false; timRead.Interval = 500;
        }

        public void Start() => timRead.Enabled = true;
        public void Stop() => timRead.Enabled = false;

        private bool bOnline = true;
        public bool Online
        {
            get { return bOnline; }
            set { bOnline = value; }
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            try
            {
                if (bOnline)
                {
                    _wcs.GetProc().FunAsrsCmd_Proc(device, clsTool.GetSqlLocation_ForIn(device),
                           router, _wms, middle, signal);

                    if (clsHost.IsConn)
                    {
                        _wcs.GetProc().subCraneWrR2R(device, signal);

                        if (clsHost.IsConn)
                            _wcs.GetMiddleCmd().FunMiddleCmdFinish_Proc(device.DeviceID);
                    }
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                timRead.Enabled = true;
            }
        }
    }
}
