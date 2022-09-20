using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class CmdDoubleStorageInfo : BaseInfo
    {
        public string reelId { get; set; }
        public string cmdMode { get; set; }
        public string locationId { get; set; }
        public string doubleStorage { get; set; }
    }
}
