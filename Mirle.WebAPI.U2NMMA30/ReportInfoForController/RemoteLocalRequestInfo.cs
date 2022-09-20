using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class RemoteLocalRequestInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "REMOTE_LOCAL_REQUEST";
        public string chipSTKCId { get; set; }
        public string controlQuery { get; set; }
    }
}
