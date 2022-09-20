using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Def;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class MiddleCmd
    {
        public string DeviceID { get; set; }
        public string CommandID { get; set; }
        public string TaskNo { get; set; }
        public int Priority { get; set; } = 5;
        public string CSTID { get; set; } = "";
        public string CmdSts { get; set; } = clsConstValue.CmdSts.strCmd_Initial;
        public string CmdMode { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Path { get; set; } = 0;
        public string CrtDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string ExpDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string Remark { get; set; } = "";
        public string BatchID { get; set; } = "";
        public string CompleteCode { get; set; } = "";
        public string Iotype { get; set; }
        public string rackLocation { get; set; } = "";
        public string largest { get; set; } = "N";
        public string carrierType { get; set; } = "";
        public string lotSize { get; set; } = "";
    }
}
