using Mirle.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotRetrieveCompleteInfo
    {
        public string jobId { get; set; }
        public string transactionId { get; set; } = "LOT_RETRIEVE_COMPLETE";
        public string portId { get; set; }
        public string lotId { get; set; }
        public string carrierId { get; set; }
        public string isComplete { get; set; }
        public string emptyTransfer { get; set; } = clsEnum.WmsApi.EmptyTransfer.N.ToString();
        public string disableLocation { get; set; }
    }
}
