using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class ReturnEqpUtilizationQueryInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; }
        public string returnCode { get; set; }
        public string returnComment { get; set; } = "";
        public List<UtilizationStsInfo> eqpList { get; set; }
    }
}
