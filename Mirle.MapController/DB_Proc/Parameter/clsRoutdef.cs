using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.MapController.DB_Proc.Parameter
{
    public class clsRoutdef
    {
        public const string TableName = "Routdef";
        public class Column
        {
            public const string DeviceID = "DeviceID";
            public const string HostPortID = "HostPortID";
            public const string NextDeviceID = "NextDeviceID";
            public const string NextHostPortID = "NextHostPortID";
        }
    }
}
