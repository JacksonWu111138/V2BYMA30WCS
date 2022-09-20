﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class TransferCommandRequestInfo
    {
        /// <summary>
        /// 命令序號
        /// </summary>
        public string jobId { get; set; } = "";
        public string transactionId { get; set; } = "TRANSFER_COMMAND_REQUEST";
        public string binId { get; set; }
        public string carrierType { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
    }
}
