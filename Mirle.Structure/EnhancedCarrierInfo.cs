using System;

namespace Mirle.Structure.Info
{
    public class EnhancedCarrierInfo
    {
        public string CarrierID { get; set; }
        public string CarrierLoc { get; set; }
        public string ZoneName { get; set; }//CarrierZoneName can be zero length string if carrier is on a port
        public DateTime InstallTime { get; set; }
        public VIDEnums.CarrierState CarrierState { get; set; }
    }
}