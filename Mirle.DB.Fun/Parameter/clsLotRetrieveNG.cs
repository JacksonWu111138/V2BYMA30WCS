using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsLotRetrieveNG
    {
        public const string TableName = "LotRetrieveNG";
        public class Column
        {
            /// <summary>
            /// WCS任務序號
            /// </summary>
            public const string CmdSno = "CmdSno";
            /// <summary>
            /// WES任務ID
            /// </summary>
            public const string JobID = "JobID";
            /// <summary>
            /// Lot ID
            /// </summary>
            public const string lotId = "lotId";
            /// <summary>
            /// 狀態
            /// </summary>
            public const string CmdSts = "CmdSts";
            /// <summary>
            /// 發生日期時間
            /// </summary>
            public const string Start_Date = "STRDT";
            /// <summary>
            /// 排除日期時間
            /// </summary>
            public const string Clear_Date = "CLRDT";
            /// <summary>
            /// 持續秒數
            /// </summary>
            public const string Total_Secs = "TotalSecs";
        }

        public class Status
        {
            /// <summary>
            /// 發生中
            /// </summary>
            public const string Occur = "O";
            /// <summary>
            /// 已清除
            /// </summary>
            public const string Clear = "S";
        }
    }
}
