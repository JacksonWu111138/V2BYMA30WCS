using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsLoc_Dtl_Log
    {
        public const string TableName = "Loc_Dtl_Log";
        public class Column
        {
            /// <summary>
            /// 儲位交易編號
            /// </summary>
            public const string Loc_Txno = "Loc_Txno";
            /// <summary>
            /// 倉儲編號
            /// </summary>
            public const string WH_ID = "WH_ID";
            /// <summary>
            /// 儲位
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// 入庫日期
            /// </summary>
            public const string IN_Date = "IN_Date";
            /// <summary>
            /// 板號
            /// </summary>
            public const string Plt_Id = "Plt_Id";
            /// <summary>
            /// 批號
            /// </summary>
            public const string Lot_No = "Lot_No";
            /// <summary>
            /// 庫存量
            /// </summary>
            public const string Plt_Qty = "Plt_Qty";
            /// <summary>
            /// 預約量
            /// </summary>
            public const string Alo_Qty = "Alo_Qty";
            /// <summary>
            /// 單據類型
            /// </summary>
            public const string Tkt_Type = "Tkt_Type";
            /// <summary>
            /// 併板狀態
            /// </summary>
            public const string Merge_Sts = "Merge_Sts";

            /// <summary>
            /// 工單號碼
            /// </summary>
            public const string TktNo = "LocDtl01";
            /// <summary>
            /// 訂單項次
            /// </summary>
            public const string Line = "LocDtl02";
            /// <summary>
            /// 保存期限
            /// </summary>
            public const string ShelfLife = "LocDtl03";
            /// <summary>
            /// 料號
            /// </summary>
            public const string ItemNo = "LocDtl04";
            /// <summary>
            /// 工廠
            /// </summary>
            public const string Factory = "LocDtl05";
            /// <summary>
            /// 客戶代碼
            /// </summary>
            public const string ClientNo = "LocDtl06";
            /// <summary>
            /// 客戶名稱
            /// </summary>
            public const string ClientName = "LocDtl07";
            /// <summary>
            /// 供應商代碼
            /// </summary>
            public const string SupplierNo = "LocDtl08";
            /// <summary>
            /// 供應商名稱
            /// </summary>
            public const string SupplierName = "LocDtl09";
            /// <summary>
            /// 整箱
            /// </summary>
            public const string BoxCount = "LocDtl11";
            /// <summary>
            /// 單位
            /// </summary>
            public const string Unit = "LocDtl10";
            /// <summary>
            /// 倉別
            /// </summary>
            public const string WH_Type = "LocDtl13";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "LocDtl12";
            /// <summary>
            /// 製造日期
            /// </summary>
            public const string BeginDate = "LocDtl14";
        }
    }
}
