using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CarrierShelfRequestInfo
    {
        public string jobId { get; set; } = DateTime.Now.ToString("g");
        public string transactionId { get; set; } = "CARRIER_SHELF_REQUEST";
        public string fromShelfId { get; set; }
        public string toShelfId { get; set; }
        public string disableLocation { get; set; }
    }
}
