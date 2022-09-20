using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class BlockStatusQueryReply : ReturnMsgInfo
    {
        public string chipSTKCId { get; set; }
        public List<BlockListReply> blockList { get; set; }
    }
}
