using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class StageEmptyInfo : BaseInfo
    {
        public string stagePosition { get; set; }
        public string isEmpty { get; set; }
    }
}
