using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotShelfRequestInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_SHELF_REQUEST";
        public string fromShelfId { get; set; }
        public string toShelfId { get; set; }
    }
}
