using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CarrierPutawayCheckInfo
    {
        public string jobId { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string transactionId { get; set; } = "CARRIER_PUTAWAY_CHECK";
        public string portId { get; set; }
        public string carrierId { get; set; }
        public string storageType { get; set; }
    }
}
