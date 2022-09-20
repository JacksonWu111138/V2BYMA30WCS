using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsAlarmCVCLog
    {
        public const string TableName = "AlarmCVCLog";
        public class Column
        {
            /// <summary>
            /// 任務ID
            /// </summary>
            public const string CmdSno = "CmdSno";
            /// <summary>
            /// 設備編號
            /// </summary>
            public const string DeviceID = "EquNo";
            /// <summary>
            /// 站口ID
            /// </summary>
            public const string BufferID = "BufferID";
            /// <summary>
            /// 設備模式
            /// </summary>
            public const string EquMode = "EquMode";
            /// <summary>
            /// 異常碼
            /// </summary>
            public const string AlarmCode = "AlarmCode";
            /// <summary>
            /// 異常描述
            /// </summary>
            public const string AlarmDef = "AlarmDef";
            /// <summary>
            /// 狀態
            /// </summary>
            public const string AlarmSts = "AlarmSts";
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
