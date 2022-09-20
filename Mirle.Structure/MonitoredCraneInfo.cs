using System.Collections.Generic;

namespace Mirle.Structure.Info
{
    public class MonitoredCraneInfo
    {
        public string StockerCraneID { get; set; }
        public int CraneCurrentPosition { get; set; }
        public int CraneTotalDistance { get; set; }
    }
}