using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsL2LCount
    {
        public const string TableName = "L2LCount";
        public class Column
        {
            /// <summary>
            /// 棧板ID
            /// </summary>
            public const string BoxID = "BoxID";
            /// <summary>
            /// 累計次數
            /// </summary>
            public const string Count = "DoCount";
            /// <summary>
            /// 新增時間
            /// </summary>
            public const string Create_Date = "CrtDate";
            /// <summary>
            /// 更新時間
            /// </summary>
            public const string Update_Date = "UpdDate";
        }
    }
}
