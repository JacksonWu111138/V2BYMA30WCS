using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CarrierShelfCompleteInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "CARRIER_SHELF_COMPLETE";
        public string shelfId { get; set; }
        public string carrierId { get; set; }
        public string emptyTransfer { get; set; }
    }
}
