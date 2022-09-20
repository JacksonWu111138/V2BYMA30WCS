using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Def;
using System.Threading.Tasks;

namespace Mirle.MapController_2
{
    public class clsTool
    {
        public static clsEnum.IOPortDirection GetDirection(int direction)
        {
            switch(direction)
            {
                case 1:
                    return clsEnum.IOPortDirection.InMode;
                case 2:
                    return clsEnum.IOPortDirection.OutMode;
                default:
                    return clsEnum.IOPortDirection.Both;
            }
        }
    }
}
