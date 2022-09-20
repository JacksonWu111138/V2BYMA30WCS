using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class RetrieveTransferInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "RETRIEVE_TRANSFER_INFO";
        public string reelId { get; set; }
        public string fromShelfId { get; set; }
        public string toPortId { get; set; }
        public string rackLocation { get; set; }
        public string largest { get; set; }
        public string priority { get; set; }
    }
}
