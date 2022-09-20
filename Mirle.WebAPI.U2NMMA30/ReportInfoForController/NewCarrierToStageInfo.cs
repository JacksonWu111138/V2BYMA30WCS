using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class NewCarrierToStageInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "NEW_CARRIER_TO_STAGE";
        public string carrierId { get; set; }
        public string stagePosition { get; set; }
    }
}
