using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class LocDtlInfo
    {
        public string LocTxno { get; set; }
        public string Loc { get; set; }
        public string WhId { get; set; }
        public string InDate { get; set; }
        public string PltId
        {
            get; set;
        }
        public string LotNo
        {
            get; set;
        }
        public double PltQty { get; set; }
        public double AloQty
        {
            get; set;
        }
        public string TktIO
        {
            get; set;
        }
        public string TktType
        {
            get; set;
        }
        public string CycNo
        {
            get; set;
        }

        /// <summary>
        /// LocDtl01 工單號碼/採購單號
        /// </summary>
        public string TktNo { get; set; }

        /// <summary>
        /// LocDtl02 採購單號項目
        /// </summary>
        public string TktSeq { get; set; }

        /// <summary>
        /// LocDtl03 保存期限
        /// </summary>
        public string ValidDate { get; set; }

        /// <summary>
        /// LocDtl04 料號
        /// </summary>
        public string ItemNo { get; set; }

        /// <summary>
        /// LocDtl05 工廠
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// LocDtl06 客戶代碼/訂貨客戶代碼
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// LocDtl07 客戶名稱/訂貨客戶名稱
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// LocDtl08 供應商代碼
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// LocDtl09 供應商名稱
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// LocDtl10 單位
        /// </summary>
        public string ItemUnit { get; set; }

        /// <summary>
        /// LocDtl11 整箱
        /// </summary>
        public double BoxQty { get; set; }

        /// <summary>
        /// LocDtl12 備註
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// LocDtl13 倉別
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// LocDtl14 製造日期
        /// </summary>
        public string ProdDate { get; set; }

        /// <summary>
        /// 出貨單號
        /// </summary>
        public string TrnTktNo { get; set; }

        /// <summary>
        /// 出貨單項目
        /// </summary>
        public string TrnTktSeq { get; set; }

        //public string IN_TKT;       //記錄入庫的單號
        //public string TRN_TKT;      //記錄上次出庫的單號
        //public string TRAN_TYPE;    //單據類別

        //v1.04
        /// <summary>
        /// UsedStatus 模具領用狀態
        /// </summary>
        public string UsedStatus { get; set; }    // 0:庫存  1: 生產  2:保養   3:維修  4:報廢  B:Booking  A: 待上架
    }
}
