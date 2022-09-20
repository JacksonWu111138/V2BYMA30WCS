using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class LocCheckInfo
    {
        public string Loc { get; set; } = "";
        public bool IsOutside { get; set; } = false;
        public string LocDD { get; set; } = "";
        public bool IsEmpty_DD { get; set; } = true;
        public string BoxID_DD { get; set; } = "";
        public string CmdSno_Outside { get; set; } = "";
    }
}
