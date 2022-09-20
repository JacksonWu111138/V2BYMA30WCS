using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class LotList
    {
        public string lotId { get; set; }
        public string fromShelfId { get; set; }
        public string toPortId { get; set; }
        public string rackLocation { get; set; }
        public string largest { get; set; }
    }
}
