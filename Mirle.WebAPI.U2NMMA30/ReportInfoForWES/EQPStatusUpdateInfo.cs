using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class EQPStatusUpdateInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "EQP_STATUS_UPDATE";
        public string craneId { get; set; }
        public string craneStatus { get; set; }
        public string portId { get; set; }
        public string portStatus { get; set; }
    }
}
