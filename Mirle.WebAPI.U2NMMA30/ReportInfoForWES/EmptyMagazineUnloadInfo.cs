using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class EmptyMagazineUnloadInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "EMPTY_MAGAZINE_UNLOAD";
        public string carrierId { get; set; }
        public string location { get; set; }
    }
}
