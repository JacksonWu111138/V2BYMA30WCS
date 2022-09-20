using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class EQPOEEListInfo
    {
        public string eqpId { get; set; }
        public string Availability { get; set; }
        public string Performance { get; set; }
        public string OEE1 { get; set; }
        public string OEE2 { get; set; }
        public string totalAlarm { get; set; }
        public string MTBA { get; set; }
        public string MTBF { get; set; }
        public string MTTR { get; set; }
        public TimeSpan runTime { get; set; }
        public TimeSpan idleTime { get; set; }
        public TimeSpan upTime { get; set; }
        public TimeSpan downTime { get; set; }
    }
}
