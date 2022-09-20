using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc.Events
{
    public class PositionReportArgs
    {
        public string DeviceID { get; }
        public string Location { get; }
        public string CmdSno { get; }
        public PositionReportArgs(string sDeviceID, string sLocation, string sCmdSno)
        {
            DeviceID = sDeviceID;
            Location = sLocation;
            CmdSno = sCmdSno;
        }

    }
}
