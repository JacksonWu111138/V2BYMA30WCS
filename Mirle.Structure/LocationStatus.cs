namespace Mirle.Structure.Info
{
    public class LocationStatus
    {
        public string ShelfID { get; set; }
        public string CarrierID { get; set; }//Empty if not occupied
        public VIDEnums.DisabledStatus DisabledStatus { get; set; }
    }
}