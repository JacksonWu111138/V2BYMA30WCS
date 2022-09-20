using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class CarrierPutawayCheckReply : ReturnMsgInfo
    {
        public string carrierId { get; set; }
        public string portId { get; set; }
        public string suggestCrane { get; set; }
    }
}
