using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Events
{
    public class NeedShelfToShelfArgs : EventArgs
    {
        public string Loc { get; }
        public string BoxID { get; }
        public string EquNo { get; }

        public NeedShelfToShelfArgs(string sEquNo, string sLoc, string sBoxID)
        {
            EquNo = sEquNo;
            Loc = sLoc;
            BoxID = sBoxID;
        }
    }
}
