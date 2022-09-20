namespace Mirle.Structure.Info
{
    public class EnhancedDisabledLoc
    {
        public string CarrierLoc { get; set; }
        public string CarrierID { get; set; }//Empty if not occupied
        public VIDEnums.ShelfState ShelfState { get; set; }
    }
}