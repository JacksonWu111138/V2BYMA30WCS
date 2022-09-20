using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CVReceiveNewBinCmdInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "CV_RECEIVE_NEW_BIN_CMD";
        public string bufferId { get; set; }
        public string carrierType { get; set; }
    }
}
