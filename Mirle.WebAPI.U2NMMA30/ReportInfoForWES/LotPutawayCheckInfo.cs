using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotPutawayCheckInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_PUTAWAY_CHECK";
        public string portId { get; set; }
        public string lotId { get; set; }
    }
}
