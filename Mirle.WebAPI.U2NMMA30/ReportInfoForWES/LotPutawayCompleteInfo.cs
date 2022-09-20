using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotPutawayCompleteInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_PUTAWAY_COMPLETE";
        public string shelfId { get; set; }
        public string lotId { get; set; }
        public string isComplete { get; set; }
    }
}
