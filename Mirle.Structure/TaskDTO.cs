using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mirle.Def;

namespace Mirle.Structure
{
    public class TaskDTO
    {
        public string StockerID { get; set; }
        public string CommandID { get; set; }
        public string TaskNo { get; set; }
        public int CraneNo { get; set; } = 1;
        public int ForkNo { get; set; } = 1;
        public string CSTID { get; set; }
        public clsEnum.TaskState TaskState { get; set; }
        public string CompleteCode { get; set; }
        public clsEnum.TaskCmdState CMDState { get; set; }
        public clsEnum.TaskMode TransferMode { get; set; }
        public string TransferModeType { get; set; }
        public string Source { get; set; }
        public int SourceBay { get; set; }
        public string Destination { get; set; }
        public int DestinationBay { get; set; }
        public string AtSourceDT { get; set; }
        public string AtDestinationDT { get; set; }
        public int TravelAxisSpeed { get; set; }
        public int LifterAxisSpeed { get; set; }
        public int RotateAxisSpeed { get; set; }
        public int ForkAxisSpeed { get; set; }
        public string CMDInfo { get; set; }
        public string UserID { get; set; }
        public string LotID { get; set; }
        public string EmptyCST { get; set; }
        public string CSTType { get; set; }
        public string BCRReadFlag { get; set; }
        public string BCRReadDT { get; set; }
        public string BCRReplyCSTID { get; set; }
        public clsEnum.BCRReadStatus BCRReadStatus { get; set; }
        public int Priority { get; set; }
        public string QueueDT { get; set; }
        public string InitialDT { get; set; }
        public string WaitingDT { get; set; }
        public string ActiveDT { get; set; }
        public string FinishDT { get; set; }
        public string FinishLocation { get; set; }
        public string C1StartDT { get; set; }
        public string CSTOnDT { get; set; }
        public string CSTTakeOffDT { get; set; }
        public string C2StartDT { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int T3 { get; set; }
        public int T4 { get; set; }
        public string F1StartDT { get; set; }
        public string F2StartDT { get; set; }
        public string RenewFlag { get; set; }
        public string AccStep { get; set; }
        public string UpdateDT { get; set; }
        public int TravelDistance { get; set; }
        public string ReplyCstId { get; set; }
        public int NextDest { get; set; }
        public string Remark { get; set; }
    }
}
