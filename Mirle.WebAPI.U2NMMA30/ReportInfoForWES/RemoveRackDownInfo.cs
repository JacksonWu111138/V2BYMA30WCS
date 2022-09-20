using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class RemoveRackDownInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "REMOVE_RACK_DOWN";
        public string carrierId { get; set; }
        public string location { get; set; }
    }
}
