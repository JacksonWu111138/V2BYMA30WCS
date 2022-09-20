using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class PutawayTransferInfo : BaseInfo
    {
        public string carrierId { get; set; }
        public string formPortId { get; set; }
        public string toShelfId { get; set; }
        public string priority { get; set; }
        public string destZoneId { get; set; } = "";
        public string manual { get; set; } = "N";
    }
}
