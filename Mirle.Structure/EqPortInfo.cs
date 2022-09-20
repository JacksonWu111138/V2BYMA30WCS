namespace Mirle.Structure.Info
{
    public class EqPortInfo
    {
        public string PortID { get; set; }
        public VIDEnums.PortTransferState PortTransferState { get; set; }
        public VIDEnums.EqReqStatus EqReqSatus { get; set; }
        public VIDEnums.EqPresenceStatus EqPresenceStatus { get; set; }
    }
}