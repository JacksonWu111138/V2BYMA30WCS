using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsMiddleCmd
    {
        public const string TableName = "MiddleCmd";
        public class Column
        {
            public const string DeviceID = "DeviceID";
            public const string CommandID = "CommandID";
            public const string TaskNo = "TaskNo";
            public const string Priority = "Priority";
            public const string CSTID = "CSTID";
            public const string CmdSts = "CmdSts";
            public const string CmdMode = "CmdMode";
            public const string Source = "Source";
            public const string Destination = "Destination";
            public const string Path = "Path";
            public const string Create_Date = "CrtDate";
            public const string Expose_Date = "ExpDate";
            public const string EndDate = "EndDate";
            public const string Remark = "Remark";
            public const string BatchID = "BatchID";
            public const string CompleteCode = "CompleteCode";
            public const string IoType = "Iotype";
            /// <summary>
            /// 料架的位置
            /// </summary>
            public const string rackLocation = "rackLocation";
            /// <summary>
            /// 是否為最大捲
            /// </summary>
            public const string largest = "largest";
            public const string carrierType = "carrierType";
            public const string lotSize = "lotSize";

        }
    }
}
