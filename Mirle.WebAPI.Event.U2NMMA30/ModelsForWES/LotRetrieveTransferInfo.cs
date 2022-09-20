using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class LotRetrieveTransferInfo : BaseInfo
    {
        public string priority { get; set; }
        public List<LotList> lotList { get; set; }
    }
}
