namespace Mirle.Structure.Info
{
    public class TransferCommand
    {
        public string CommandID { get; set; }
        public string CmdMode { get; set; }
        public int Priority { get; set; }
        public string CarrierID { get; set; }
        public string Loc { get; set; } = "";
        public string NewLoc { get; set; } = "";
        public string Remark { get; set; }
        public string StnNo { get; set; }
        public string BackupPortID { get; set; }
        public string TicketId { get; set; } = "";
    }
}
