using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mirle.Def;

namespace Mirle.Stocker.Command
{
    public interface IFork
    {
        clsEnum.CmdType.LocType LocType { get; }

        int ForkNo { get; }
        IProcess GetProcess();
    }
}
