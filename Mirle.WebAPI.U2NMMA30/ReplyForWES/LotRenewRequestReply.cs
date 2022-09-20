using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30.ReportInfo
{
    public class LotRenewRequestReply : LotReply
    {
        public string newLotId { get; set; }
        public string newLabel { get; set; }
        public string portNo { get; set; }
        public string MSL { get; set; }
        public string keeper { get; set; }
        public string custPart { get; set; }
        public string dateCode { get; set; }
        public string lotNumber { get; set; }
        public string version { get; set; }
        public string cavityNo { get; set; }
        public string safeNo { get; set; }
        public string vendorCode { get; set; }
        public string bin { get; set; }
        public string spec { get; set; }
        public string special { get; set; }
        public string barcodeNo { get; set; }
    }
}
