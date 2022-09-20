namespace Mirle.Structure.Info
{
    public class Transfer
    {
        public Transfer(string commandID, int priority, string carrierID, string source, string dest)
        {
            this.CommandID = commandID;
            this.Priority = priority;
            this.CarrierID = carrierID;
            this.Source = source;
            this.Dest = dest;
        }

        public string CommandID { get; internal set; }
        public int Priority { get; internal set; }
        public string CarrierID { get; internal set; }
        public string Source { get; internal set; }
        public string Dest { get; internal set; }
    }
}
