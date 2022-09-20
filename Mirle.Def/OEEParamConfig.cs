using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Def
{
    public class OEEParamConfig
    {
        public string CountBy { get; set; } = "lot";
        public int PlanTime { get; set; } = 0;

        public int[] PlanCount { get; set; } = new int[4];
    }
}