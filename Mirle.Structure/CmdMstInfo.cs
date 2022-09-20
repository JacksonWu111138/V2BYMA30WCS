using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class CmdMstInfo
    {
        public string Cmd_Sno { get; set; }
        public string Cmd_Sts { get; set; }
        public string Cmd_Abnormal { get; set; }
        public string Prty { get; set; }
        public string Stn_No { get; set; }
        public string Cmd_Mode { get; set; }
        public string IO_Type { get; set; }
        public string WH_ID { get; set; }
        public string Loc { get; set; }
        public string New_Loc { get; set; }
        public int Mix_Qty { get; set; }
        public double Avail { get; set; }
        /// <summary>
        /// 命令產生時間
        /// </summary>
        public string Crt_Date { get; set; }
        /// <summary>
        /// 命令送出時間
        /// </summary>
        public string EXP_Date { get; set; }
        public string End_Date { get; set; }
        public string Trn_User { get; set; }
        public string Host_Name { get; set; }
        public string Trace { get; set; }
        public string Plt_Count { get; set; }
        /// <summary>
        /// 棧板ID
        /// </summary>
        public string BoxID { get; set; }
        public string Equ_No { get; set; }
        /// <summary>
        /// 當前位置
        /// </summary>
        public string CurLoc { get; set; }
        public string CurDeviceID { get; set; }
        public string JobID { get; set; }
        public string BatchID { get; set; }
        public string Zone_ID { get; set; }
        public string Remark { get; set; }
        public string NeedShelfToShelf { get; set; }
        public string backupPortId { get; set; }
        public string rackLocation { get; set; } = "";
        public string largest { get; set; } = "N";
        public string carrierType { get; set; } = "";
        public string lotSize { get; set; } = "";
    }
}
