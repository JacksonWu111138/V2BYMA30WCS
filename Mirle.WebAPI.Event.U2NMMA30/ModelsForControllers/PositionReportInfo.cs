using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class PositionReportInfo : BaseInfo
    {
        public string carrierType { get; set; }
        public string id { get; set; }
        public string position { get; set; }
    }
}
