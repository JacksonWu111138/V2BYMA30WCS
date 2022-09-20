using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class DowntimeStsInfo
    {
        public DateTime createTime { get; set; }
        public string eqpId { get; set; }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DateTime occurTime { get; set; }
        public DateTime releaseTime { get; set; }
        public double downtime { get; set; }
    }
}
