using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class TrnLogInfo
    {
        public string LogDate { get; set; }
        public string CmdSno { get; set; }
        public string CmdTxno { get; set; }
        public string CmdSts { get; set; }
        public string CmdAbnormal { get; set; }
        public string Prty { get; set; }
        public string StnNo { get; set; }
        public string CmdMode { get; set; }
        public string IoType { get; set; }
        public string TktIO { get; set; }
        public string TktType { get; set; }
        public string WhId { get; set; }
        public string Loc { get; set; }
        public string NewLoc { get; set; }
        public int MixQty { get; set; }
        public double Avail { get; set; }
        public string ZoneId { get; set; }
        public string LocId { get; set; }
        public string CrtDate { get; set; }
        public string ExpDate { get; set; }
        public string EndDate { get; set; }
        public string TrnUser { get; set; }
        public string HostName { get; set; }
        public string Trace { get; set; }
        public string PltCount { get; set; }
        public string EquNo { get; set; }
        public double PltQty { get; set; }
        public double TrnQty { get; set; }
        public string PltId { get; set; }
        public string LotNo { get; set; }
        public string InDate { get; set; }
        public string CycNo { get; set; }
        public string InTktNo { get; set; }
        public string InTktSeq { get; set; }
        public string TrnTktNo { get; set; }
        public string TrnTktSeq { get; set; }
        public string ValidDate { get; set; }       //保存期限
        public string ItemNo { get; set; }
        public string Factory { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProviderId { get; set; }      //供應商
        public string ProviderName { get; set; }
        public string ItemUnit { get; set; }
        public double BoxQty { get; set; }
        public string StoreCode { get; set; }
        public string ProdDate { get; set; }
        public string Remarks { get; set; }
        public string PrintFlag { get; set; }
    }
}
