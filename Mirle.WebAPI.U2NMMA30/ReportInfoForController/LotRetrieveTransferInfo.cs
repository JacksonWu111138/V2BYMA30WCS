using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotRetrieveTransferInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string transactionId { get; set; } = "LOT_RETRIEVE_TRANSFER";

        public string priority { get; set; }
        public List<LotListInfo> lotList { get; set; }
    }
}
