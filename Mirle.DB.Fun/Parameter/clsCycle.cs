using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsCycle
    {
        public const string TableName = "Cycle";
        public class Column
        {
            /// <summary>
            /// 盤點單號
            /// </summary>
            public const string Cyc_No = "Cyc_No";
            /// <summary>
            /// 儲位交易編號
            /// </summary>
            public const string Loc_Txno = "Loc_Txno";
            /// <summary>
            /// 盤點日期
            /// </summary>
            public const string Cycle_Date = "Cycle_Date";
            /// <summary>
            /// 倉儲編號
            /// </summary>
            public const string WH_ID = "WH_ID";
            /// <summary>
            /// 儲位
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// 異動人員
            /// </summary>
            public const string Trn_User = "Trn_User";
            /// <summary>
            /// 異動日期
            /// </summary>
            public const string Trn_Date = "Trn_Date";
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
            /// 盤點量
            /// </summary>
            public const string Cyc_Qty = "Cyc_Qty";
            /// <summary>
            /// 調整狀態
            /// </summary>
            public const string Use_Set = "Use_Set";

            /// <summary>
            /// 工單號碼
            /// </summary>
            public const string TktNo = "Cycle01";
            /// <summary>
            /// 訂單項次
            /// </summary>
            public const string Line = "Cycle02";
            /// <summary>
            /// 保存期限
            /// </summary>
            public const string ShelfLife = "Cycle03";
            /// <summary>
            /// 料號
            /// </summary>
            public const string ItemNo = "Cycle04";
            /// <summary>
            /// 工廠
            /// </summary>
            public const string Factory = "Cycle05";
            /// <summary>
            /// 客戶代碼
            /// </summary>
            public const string ClientNo = "Cycle06";
            /// <summary>
            /// 客戶名稱
            /// </summary>
            public const string ClientName = "Cycle07";
            /// <summary>
            /// 供應商代碼
            /// </summary>
            public const string SupplierNo = "Cycle08";
            /// <summary>
            /// 供應商名稱
            /// </summary>
            public const string SupplierName = "Cycle09";
            /// <summary>
            /// 整箱
            /// </summary>
            public const string BoxCount = "Cycle11";
            /// <summary>
            /// 單位
            /// </summary>
            public const string Unit = "Cycle10";
            /// <summary>
            /// 倉別
            /// </summary>
            public const string WH_Type = "Cycle13";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Cycle12";
            /// <summary>
            /// 製造日期
            /// </summary>
            public const string BeginDate = "Cycle14";
        }
    }
}
