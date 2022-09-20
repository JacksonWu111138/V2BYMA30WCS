using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsTktMst
    {
        public const string TableName = "Tkt_Mst";
        public class Column
        {
            /// <summary>
            /// 單據下傳日期
            /// </summary>
            public const string Down_Date = "Down_Date";
            /// <summary>
            /// 單據上傳日期
            /// </summary>
            public const string UpLoad_Date = "UpLoad_Date";
            /// <summary>
            /// 異動日期
            /// </summary>
            public const string Trn_Date = "Trn_Date";
            /// <summary>
            /// 異動人員
            /// </summary>
            public const string Trn_User = "Trn_User";
            /// <summary>
            /// 入/出
            /// </summary>
            public const string Tkt_IO = "Tkt_IO";
            /// <summary>
            /// 單據類型
            /// </summary>
            public const string Tkt_Type = "Tkt_Type";
            /// <summary>
            /// 處理狀態
            /// </summary>
            public const string Tkt_Sts = "Tkt_Sts";
            /// <summary>
            /// 板號
            /// </summary>
            public const string Plt_Id = "Plt_Id";
            /// <summary>
            /// 批號
            /// </summary>
            public const string Lot_No = "Lot_No";
            /// <summary>
            /// 已處理量
            /// </summary>
            public const string Proc_Qty = "Proc_Qty";
            /// <summary>
            /// 預約處理量
            /// </summary>
            public const string Act_Qty = "Act_Qty";
            /// <summary>
            /// 計劃量
            /// </summary>
            public const string Plan_Qty = "Plan_Qty";
            /// <summary>
            /// 工單號碼
            /// </summary>
            public const string TktNo = "TktMst01";
            /// <summary>
            /// 訂單項次
            /// </summary>
            public const string Line = "TktMst02";
            /// <summary>
            /// 交貨排程明細碼
            /// </summary>
            public const string Schedule = "TktMst03";
            /// <summary>
            /// 採購單日期
            /// </summary>
            public const string Date = "TktMst04";
            /// <summary>
            /// 保存期限
            /// </summary>
            public const string ShelfLife = "TktMst05";
            /// <summary>
            /// 交貨日期
            /// </summary>
            public const string DeliveryDate = "TktMst06";
            /// <summary>
            /// 料號
            /// </summary>
            public const string ItemNo = "TktMst07";
            /// <summary>
            /// 客戶代碼
            /// </summary>
            public const string ClientNo = "TktMst08";
            /// <summary>
            /// 供應商代碼
            /// </summary>
            public const string SupplierNo = "TktMst10";
            /// <summary>
            /// 供應商名稱
            /// </summary>
            public const string SupplierName = "TktMst11";
            /// <summary>
            /// 整箱
            /// </summary>
            public const string BoxCount = "TktMst12";
            /// <summary>
            /// 單位
            /// </summary>
            public const string Unit = "TktMst13";
            /// <summary>
            /// 送貨地址
            /// </summary>
            public const string Address = "TktMst14";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "TktMst15";
        }
    }
}
