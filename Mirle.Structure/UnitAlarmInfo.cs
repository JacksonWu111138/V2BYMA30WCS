namespace Mirle.Structure.Info
{
    public class UnitAlarmInfo
    {
        public string EqpName { get; set; }
        public string StockerUnitID { get; set; }
        public int AlarmID { get; set; }
        public string AlarmText { get; set; }
        public VIDEnums.MainteState MainteState { get; set; }
    }
}