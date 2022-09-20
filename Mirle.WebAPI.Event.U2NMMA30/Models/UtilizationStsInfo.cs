using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class UtilizationStsInfo
    {
        public string eqpId { get; set; }
        public double upTime { get; set; }
        public double downTime { get; set; }
        public double onlineRate { get; set; }
        public double failureRate { get; set; }
        public double MCBF { get; set; }
        public double MTBF { get; set; }
    }
}
