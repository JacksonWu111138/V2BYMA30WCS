using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class PortStatusUpdateInfo
    {
        public string jobId { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string transactionId { get; set; } = "PORT_STATUS_UPDATE";
        public string portId { get; set; }
        public string portStatus { get; set; }
    }
}
