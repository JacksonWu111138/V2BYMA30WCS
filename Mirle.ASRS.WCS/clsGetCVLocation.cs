using Mirle.ASRS.WCS.View;
using Mirle.MapController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.ASRS.WCS
{
    public class clsGetCVLocation
    {
        private System.Timers.Timer timRead = new System.Timers.Timer();
        public MapHost router;
        public clsGetCVLocation(MapHost Router)
        {
            router = Router;

            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = true; timRead.Interval = 100;
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            try
            {
                if (router.Done)
                {
                    string DeviceID;
                    for (int i = 0; i < MainForm.PCBA.Length; i++)
                    {
                        DeviceID = MainForm.PCBA[i].DeviceID;
                        foreach (var floor in MainForm.PCBA[i].Floors)
                        {
                            foreach(var gin in floor.Group_IN)
                            {
                                gin.bufferLocation = router.GetLocation(DeviceID, gin.BufferName);
                            }

                            foreach (var gout in floor.Group_OUT)
                            {
                                gout.bufferLocation = router.GetLocation(DeviceID, gout.BufferName);
                            }
                        }
                    }

                    for (int i = 0; i < MainForm.Box.Length; i++)
                    {
                        DeviceID = MainForm.Box[i].DeviceID;
                        foreach (var floor in MainForm.Box[i].Floors)
                        {
                            foreach (var gin in floor.Group_IN)
                            {
                                gin.bufferLocation = router.GetLocation(DeviceID, gin.BufferName);
                            }

                            foreach (var gout in floor.Group_OUT)
                            {
                                gout.bufferLocation = router.GetLocation(DeviceID, gout.BufferName);
                            }
                        }
                    }

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
        }
    }
}
