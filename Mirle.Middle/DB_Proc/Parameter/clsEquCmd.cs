using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Middle.DB_Proc.Parameter
{
    public class clsEquCmd
    {
        public const string TableName = "EquCmd";
        public class Column
        {
            public const string CmdSno = "CmdSno";
            public const string CmdSno_Shuttle = "CmdSno_Shuttle";
            public const string EquNo = "EquNo";
            public const string CmdMode = "CmdMode";
            public const string CmdSts = "CmdSts";
            public const string Source = "Source";
            public const string Destination = "Destination";
            public const string LocSize = "LocSize";
            public const string Priority = "Priority";
            /// <summary>
            /// 命令產生日期
            /// </summary>
            public const string CreateDate = "RCVDT";
            /// <summary>
            /// 最後一次更新日期
            /// </summary>
            public const string ActionDate = "ACTDT";
            public const string EndDate = "ENDDT";
            /// <summary>
            /// 上車時間
            /// </summary>
            public const string CSTPresenceDT = "CSTPresenceDT";
            public const string CompleteCode = "CompleteCode";
            public const string SpeedLevel = "SpeedLevel";
            public const string ReNewFlag = "ReNewFlag";
        }
    }
}
