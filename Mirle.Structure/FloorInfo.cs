using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class FloorInfo
    {
        public List<ConveyorInfo> Group_IN { get; set; }
        public List<ConveyorInfo> Group_OUT { get; set; }
    }
}
