using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class AlarmInfo : BaseInfo
    {
        public string deviceId { get; set; }
        public string alarmCode { get; set; }
        public string alarmDef { get; set; }
        public string bufferId { get; set; }
        public string status { get; set; }
        public string happenTime { get; set; }
    }
}
