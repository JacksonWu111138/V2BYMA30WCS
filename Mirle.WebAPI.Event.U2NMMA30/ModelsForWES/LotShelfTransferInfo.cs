using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class LotShelfTransferInfo : BaseInfo
    {
        public string lotId { get; set; }
        public string fromShelfId { get; set; }
        public string toShelfId { get; set; }
        public string priority { get; set; }
    }
}
