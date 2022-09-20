using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotPositionReportInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_POSITION_REPORT";
        public string lotId { get; set; }
        public string location { get; set; }
    }
}
