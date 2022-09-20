using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class CommandCompleteInfo : BaseInfo
    {
        public string reelId { get; set; }
        public string cmdMode { get; set; }
        public string cmdSts { get; set; }
        public string emptyRetrieval { get; set; }
        public string portId { get; set; }
        public string carrierId { get; set; }
    }
}
