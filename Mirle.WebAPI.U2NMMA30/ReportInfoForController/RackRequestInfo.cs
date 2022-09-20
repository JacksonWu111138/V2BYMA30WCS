using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class RackRequestInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string transactionId { get; set; } = "RACK_REQUEST";
        public string location { get; set; }
    }
}
