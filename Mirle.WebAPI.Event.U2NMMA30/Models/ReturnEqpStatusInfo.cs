using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class ReturnEqpStatusInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; }
        public string returnCode { get; set; }
        public string returnComment { get; set; }
        public List<CraneStsInfo> craneList { get; set; }
        public List<PortStsInfo> portList { get; set; }
        public List<CvStsInfo> cvList { get; set; }
    }
}
