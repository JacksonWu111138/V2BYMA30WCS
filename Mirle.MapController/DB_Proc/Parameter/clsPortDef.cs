using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.MapController.DB_Proc.Parameter
{
    public class clsPortDef
    {
        public const string TableName = "PortDef";
        public class Column
        {
            /// <summary>
            /// 設備編號
            /// </summary>
            public const string DeviceID = "DeviceID";
            /// <summary>
            /// 可視化PortID
            /// </summary>
            public const string HostPortID = "HostPortID";
            /// <summary>
            /// Port類型
            /// </summary>
            public const string PortType = "PortType";
            /// <summary>
            /// 順序
            /// </summary>
            public const string PortTypeIndex = "PortTypeIndex";
            /// <summary>
            /// For PLC看的PortID
            /// </summary>
            public const string PLCPortID = "PLCPortID";
            /// <summary>
            /// 流向
            /// </summary>
            public const string Direction = "Direction";
        }
    }
}
