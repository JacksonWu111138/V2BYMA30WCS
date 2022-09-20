using System.Collections.Generic;

namespace Mirle.Structure.Info
{
    public class ZoneData2
    {
        public string ZoneName { get; set; }
        public int ZoneCapacity { get; set; }
        public int ZoneTotalSize { get; set; }
        public VIDEnums.ZoneType ZoneType { get; set; }
        public List<EnhancedDisabledLoc> EnhancedDisabledLocations { get; set; } = new List<EnhancedDisabledLoc>();
    }
}