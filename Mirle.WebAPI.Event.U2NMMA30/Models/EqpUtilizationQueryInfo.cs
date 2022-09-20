using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class EqpUtilizationQueryInfo : BaseInfo
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
