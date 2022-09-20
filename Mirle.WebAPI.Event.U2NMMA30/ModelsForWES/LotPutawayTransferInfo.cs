using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class LotPutawayTransferInfo : BaseInfo
    {
        public string lotId { get; set; }
        public string fromPortId { get; set; }
        public string toShelfId { get; set; }
        public string lotSize { get; set; }
        public string priority { get; set; }
    }
}
