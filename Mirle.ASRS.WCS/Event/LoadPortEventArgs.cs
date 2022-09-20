using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.ASRS.WCS.Event
{
    public class LoadPortEventArgs : EventArgs
    {
        public string PortID { get; }
        public CmdMstInfo Command { get; }

        public LoadPortEventArgs(string portId, CmdMstInfo cmd)
        {
            PortID = portId;
            Command = cmd;
        }
    }
}
