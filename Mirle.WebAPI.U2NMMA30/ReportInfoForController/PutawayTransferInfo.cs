using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class PutawayTransferInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "PUTAWAY_TRANSFER_INFO";
        public string reelId { get; set; }
        public string lotSize { get; set; }
        public string toShelfId { get; set; }
    }
}
