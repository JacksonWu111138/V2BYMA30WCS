using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class EquCmdInfo
    {
        public string CmdSno { get; set; }
        public string EquNo { get; set; }
        public string Remark { get; set; }
        public string CmdMode { get; set; }
        public string CmdSts { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string LocSize { get; set; }
        public string Priority { get; set; }
        public string RCVDT { get; set; }
        public string ACTDT { get; set; }
        public string CSTPresenceDT { get; set; }
        public string ENDDT { get; set; }
        public string CompleteCode { get; set; }
        public string CompleteIndex { get; set; }
        public string CarNo { get; set; }
        public string ReNewFlag { get; set; } = "Y";
        public string SpeedLevel { get; set; }
    }
}
