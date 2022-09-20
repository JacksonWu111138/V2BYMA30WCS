using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.DB.Object;
using Mirle.Def.U2NMMA30;

namespace Mirle.DB.ClearCmd.Proc
{
    public class clsMoveCmdInHistory_Proc
    {
        private System.Timers.Timer timRead = new System.Timers.Timer();

        public clsMoveCmdInHistory_Proc()
        {
            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = false; timRead.Interval = 1000;
        }

        public void subStart()
        {
            timRead.Enabled = true;
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            try
            {
                if (DB.Proc.clsHost.IsConn)
                {
                    //Tower
                    clsDB_Proc.GetDB_Object().GetMiddleCmd().FunMiddleCmdFinish_Proc(ConveyorDef.DeviceID_Tower);
                    //AGV
                    clsDB_Proc.GetDB_Object().GetMiddleCmd().FunMiddleCmdFinish_Proc(ConveyorDef.DeviceID_AGV);

                    clsDB_Proc.GetDB_Object().GetCmd_Mst().FunMoveFinishCmdToHistory_Proc();
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
