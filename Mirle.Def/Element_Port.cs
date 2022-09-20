using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Def
{
    public class Element_Port
    {
        public string DeviceID { get; set; }
        public string HostPortID { get; set; }
        public int PortType { get; set; }
        public int PortTypeIndex { get; set; }
        public int PLCPortID { get; set; }
        public clsEnum.IOPortDirection Direction { get; set; }

        public Element_Port(string DeviceID, string HostPortID, int PortType, int PortTypeIndex, int PLCPortID, clsEnum.IOPortDirection direction)
        {
            this.DeviceID = DeviceID;
            this.HostPortID = HostPortID;
            this.PLCPortID = PLCPortID;
            this.PortType = PortType;
            this.PortTypeIndex = PortTypeIndex;
            Direction = direction;
        }
    }
}
