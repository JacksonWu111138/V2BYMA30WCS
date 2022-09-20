using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsMoldUseLog
    {
        public const string TableName = "MoldUseLog";
        public class Column
        {
            /// <summary>
            /// 使用交易序號
            /// </summary>
            public const string MoldUse_Txno = "MoldUse_Txno";
            /// <summary>
            /// 領用工單號
            /// </summary>
            public const string MoldTkt_No = "MoldTkt_No";
            /// <summary>
            /// 模具編碼
            /// </summary>
            public const string MoldCode = "MoldCode";
            /// <summary>
            /// 領用狀態
            /// </summary>
            public const string UsedStatus = "UsedStatus";
            /// <summary>
            /// 模具狀態
            /// </summary>
            public const string MoldStatus = "MoldStatus";
            /// <summary>
            /// 數量
            /// </summary>
            public const string UsedQty = "UsedQty";
            /// <summary>
            /// 領用人
            /// </summary>
            public const string UsedPerson = "UsedPerson";
            /// <summary>
            /// 領用日期
            /// </summary>
            public const string UseDate = "UseDate";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Memo";
            /// <summary>
            /// 客戶編號
            /// </summary>
            public const string ClientNo = "CustNo";
            /// <summary>
            /// 客戶名稱
            /// </summary>
            public const string ClientName = "CustName";
            /// <summary>
            /// 修改人
            /// </summary>
            public const string UpdatedPerson = "UpdatedPerson";
            /// <summary>
            /// 修改日期
            /// </summary>
            public const string UpdatedDate = "UpdatedDate";
            /// <summary>
            /// 創建者
            /// </summary>
            public const string CreatedPerson = "CreatedPerson";
            /// <summary>
            /// 創建日期
            /// </summary>
            public const string CreatedDate = "CreatedDate";
        }
    }
}
