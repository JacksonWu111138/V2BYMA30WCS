using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CarrierRetrieveCompleteInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "CARRIER_RETRIEVE_COMPLETE";
        public string carrierId { get; set; }
        public string portId { get; set; }
        public string location { get; set; }
        public string isComplete { get; set; }
        public string emptyTransfer { get; set; }
    }
}
