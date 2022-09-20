using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotRenewRequestInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_RENEW_REQUEST";
        public string lotId { get; set; }
        public int qty { get; set; }
    }
}
