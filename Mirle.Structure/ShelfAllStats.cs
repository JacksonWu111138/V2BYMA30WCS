namespace Mirle.Structure.Info
{
    public class ShelfAllStats
    {
        //ShelfAddress in 5 digits
        //Bank : 1 digit / Bay : 2 digits/ Level : 2 digits
        public string ShelfAddress { get; set; }
        public string ZoneName { get; set; }
        public VIDEnums.ShelfState ShelfState { get; set; }
        public string CarrierID { get; set; }
    }
}