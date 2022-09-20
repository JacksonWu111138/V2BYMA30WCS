using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mirle.Def;

namespace Mirle.Stocker.Command
{
    public interface ICrane
    {
        clsEnum.CmdType.ForkType ForkType { get; }

        int CraneNo { get; }

        IFork GetFork(int forkNo);

        IEnumerable<IFork> GetForks();
    }
}
