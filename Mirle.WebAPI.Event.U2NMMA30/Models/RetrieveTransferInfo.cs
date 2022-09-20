using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class RetrieveTransferInfo : BaseInfo
    {
        public string carrierId { get; set; }
        public string fromShelfId { get; set; }
        public string toPortId { get; set; }
        public string backupPortId { get; set; } = "";
        public string priority { get; set; }
        public string batchId { get; set; } = "";
        public string ticketId { get; set; } = "";
    }
}
