using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class BinEmptyLeaveInfo : BaseInfo
    {
        public string binId { get; set; }
        public string position { get; set; }
    }
}
