using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class ForkStatusReportInfo : BaseInfo
    {
        public string chipSTKCId { get; set; }
        public List<ForkStatusList> forkStatusList { get; set; }
    }
}
