using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.DB.Object;
using Mirle.Def.U2NMMA30;

namespace Mirle.DB.ClearCmd.Proc
{
    public class clsLotRetrieveFailCancel_Proc
    {
        private System.Timers.Timer timRead = new System.Timers.Timer();
        private string strLastExportTime = string.Empty;

        public clsLotRetrieveFailCancel_Proc()
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
                    clsDB_Proc.GetDB_Object().GetLotRetrieveNG().FunLotRetrieveFailCancel_Proc();
                }

                string strExportTime = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00";
                string strNowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                if (strNowTime == strExportTime && strNowTime != strLastExportTime)
                {
                    if (DB.Proc.clsHost.IsConn)
                    {
                        if (clsDB_Proc.GetDB_Object().GetLotRetrieveNG().FunDelLotRetrieveNGSolved(180))
                        {
                            strLastExportTime = strNowTime;
                        }
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
