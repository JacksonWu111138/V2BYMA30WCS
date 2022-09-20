using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mirle.Def;

namespace Mirle.Stocker.Command
{
    public interface IStocker
    {
        int Id { get; }
        clsEnum.CmdType.CraneType CraneType { get; }

        IEnumerable<ICrane> GetCranes();

        ICrane GetCrane(int craneNo);
    }
}
