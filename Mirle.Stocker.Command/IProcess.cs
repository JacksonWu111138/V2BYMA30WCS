using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Stocker.Command
{
    public interface IProcess
    {
        void Start();
        void Stop();
    }
}
