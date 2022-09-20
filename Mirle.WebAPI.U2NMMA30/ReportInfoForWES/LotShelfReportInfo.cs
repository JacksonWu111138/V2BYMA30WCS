using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotShelfReportInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_SHELF_REPORT";
        public string shelfId { get; set; }
        public string shelfStatus { get; set; }
        public string lotId { get; set; }
        public string disableLocation { get; set; }
    }
}
