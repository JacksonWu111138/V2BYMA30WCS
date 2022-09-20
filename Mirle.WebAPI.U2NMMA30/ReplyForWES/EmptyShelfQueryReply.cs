using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class EmptyShelfQueryReply : ReturnMsgInfo
    {
        public string lotIdCarrierId { get; set; }
        public string shelfId { get; set; }
    }
}
