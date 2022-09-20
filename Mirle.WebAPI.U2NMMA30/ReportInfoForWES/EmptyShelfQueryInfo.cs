using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class EmptyShelfQueryInfo
    {
        public string jobId { get; set; } = DateTime.Now.ToString("g");
        public string transactionId { get; set; } = "EMPTY_SHELF_QUERY";
        public string lotIdCarrierId { get; set; }
        public string craneId { get; set; }
    }
}
