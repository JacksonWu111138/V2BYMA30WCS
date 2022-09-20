using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class WCSCancelInfo
    {
        public string jobId { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string transactionId { get; set; } = "WCS_CANCEL";
        public string lotIdCarrierId { get; set; }
        public string cancelType { get; set; }
    }
}
