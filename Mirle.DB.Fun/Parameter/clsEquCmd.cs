using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsEquCmd
    {
        public const string TableName = "EquCmd";
        public class Column
        {
            /// <summary>
            /// 命令序號
            /// </summary>
            public const string CmdSno = "CmdSno";
            /// <summary>
            /// 設備編號
            /// </summary>
            public const string EquNo = "EquNo";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Remark";
            /// <summary>
            /// 命令模式
            /// </summary>
            public const string CmdMode = "CmdMode";
            /// <summary>
            /// 命令狀態
            /// </summary>
            public const string CmdSts = "CmdSts";
            /// <summary>
            /// 來源
            /// </summary>
            public const string Source = "Source";
            /// <summary>
            /// 目的
            /// </summary>
            public const string Destination = "Destination";
            /// <summary>
            /// 貨物/儲位大小
            /// </summary>
            public const string LocSize = "LocSize";
            /// <summary>
            /// 優先級
            /// </summary>
            public const string Priority = "Priority";
            /// <summary>
            /// 命令產生時間
            /// </summary>
            public const string Create_Date = "RCVDT";
            /// <summary>
            /// 動作時間
            /// </summary>
            public const string Action_Date = "ACTDT";
            /// <summary>
            /// 荷有時間
            /// </summary>
            public const string Load_Date = "CSTPresenceDT";
            /// <summary>
            /// 命令結束時間
            /// </summary>
            public const string End_Date = "ENDDT";
            /// <summary>
            /// 完成碼
            /// </summary>
            public const string CompleteCode = "CompleteCode";
            /// <summary>
            /// 命令完成 Index
            /// </summary>
            public const string CompleteIndex = "CompleteIndex";
            /// <summary>
            /// 台車編號 
            /// </summary>
            public const string CarNo = "CarNo";
            /// <summary>
            /// 該資料是否更新 
            /// </summary>
            public const string ReNewFlag = "ReNewFlag";
            /// <summary>
            /// 速度等級
            /// </summary>
            public const string SpeedLevel = "SpeedLevel";
        }
    }
}
