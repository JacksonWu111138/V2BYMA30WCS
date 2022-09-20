using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class WrongEquStockInRequestReply : ReplyCode
    {
        public string reelId { get; set; }
        public string stockerId { get; set; }
        public string locationId { get; set; }
    }
}
