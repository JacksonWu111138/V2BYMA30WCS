using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class CarrierRetrieveTransferInfo : BaseInfo
    {
        public string carrierId { get; set; }
        public string carrierType { get; set; }
        public string storageId { get; set; }
        public string fromShelfId { get; set; }
        public string toLocation { get; set; }
        public string orderNo { get; set; }
        public string priority { get; set; }
    }
}
