﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class MagazineLoadRequestInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "MAGAZINE_LOAD_REQUEST";
        public string location { get; set; }
    }
}
