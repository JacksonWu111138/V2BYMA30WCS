using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class CarrierPutawayTransferInfo : BaseInfo
    {
        public string carrierId { get; set; }
        public string carrierType { get; set; }
        public string storageId { get; set; }
        public string fromPortId { get; set; }
        public string toShelfId { get; set; }
        public string priority { get; set; }
    }
}
