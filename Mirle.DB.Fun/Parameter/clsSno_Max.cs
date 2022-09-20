using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsSno_Max
    {
        public const string TableName = "Sno_Max";
        public class Column
        {
            /// <summary>
            /// 類型
            /// </summary>
            public const string Sno_Type = "Sno_Type";
            /// <summary>
            /// 是否為月異動
            /// </summary>
            public const string Month_Flag = "Month_Flag";
            /// <summary>
            /// 起始值
            /// </summary>
            public const string Init_Sno = "Init_Sno";
            /// <summary>
            /// 最大流水號
            /// </summary>
            public const string Max_Sno = "Max_Sno";
            /// <summary>
            /// 序號長度
            /// </summary>
            public const string Sno_Len = "Sno_Len";
        }
    }
}
