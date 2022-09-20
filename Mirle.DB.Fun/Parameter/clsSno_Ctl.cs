using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsSno_Ctl
    {
        public const string TableName = "SNO_CTL";
        public class Column
        {
            /// <summary>
            /// 類型
            /// </summary>
            public const string Sno_Type = "SnoTyp";
            /// <summary>
            /// 異動月
            /// </summary>
            public const string Trn_Month = "TrnDate";
            /// <summary>
            /// 流水號
            /// </summary>
            public const string Sno = "Sno";
        }
    }
}
