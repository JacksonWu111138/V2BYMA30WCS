using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsCmd_Dtl
    {
        public const string TableName = "Cmd_Dtl";
        public class Column
        {
            /// <summary>
            /// 命令交易編號
            /// </summary>
            public const string Cmd_Txno = "Cmd_Txno";
            /// <summary>
            /// 命令序號
            /// </summary>
            public const string Cmd_Sno = "Cmd_Sno";
            /// <summary>
            /// 棧板量
            /// </summary>
            public const string Plt_Qty = "Plt_Qty";
            /// <summary>
            /// 異動量
            /// </summary>
            public const string Trn_Qty = "Trn_Qty";
            /// <summary>
            /// 儲位編號
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// 板號
            /// </summary>
            public const string Plt_Id = "Plt_Id";
            /// <summary>
            /// 批號
            /// </summary>
            public const string Lot_No = "Lot_No";
            /// <summary>
            /// 入庫日期
            /// </summary>
            public const string IN_Date = "IN_Date";
            /// <summary>
            /// 入庫單據編號
            /// </summary>
            public const string IN_Tkt_No = "IN_Tkt_No";
            /// <summary>
            /// 入庫單據項次
            /// </summary>
            public const string IN_Tkt_Seq = "IN_Tkt_Seq";
            /// <summary>
            /// 交易單據編號
            /// </summary>
            public const string Trn_Tkt_No = "Trn_Tkt_No";
            /// <summary>
            /// 交易單據項次
            /// </summary>
            public const string Trn_Tkt_Seq = "Trn_Tkt_Seq";
            /// <summary>
            /// 入/出庫單
            /// </summary>
            public const string Tkt_IO = "Tkt_IO";
            /// <summary>
            /// 單據類型
            /// </summary>
            public const string Tkt_Type = "Tkt_Type";
            /// <summary>
            /// 盤點單號
            /// </summary>
            public const string Cyc_no = "Cyc_no";

            /// <summary>
            /// 保存期限
            /// </summary>
            public const string ShelfLife = "CmdDtl01";
            /// <summary>
            /// 料號
            /// </summary>
            public const string ItemNo = "CmdDtl02";
            /// <summary>
            /// 工廠
            /// </summary>
            public const string Factory = "CmdDtl03";
            /// <summary>
            /// 客戶代碼
            /// </summary>
            public const string ClientNo = "CmdDtl04";
            /// <summary>
            /// 客戶名稱
            /// </summary>
            public const string ClientName = "CmdDtl05";
            /// <summary>
            /// 供應商代碼
            /// </summary>
            public const string SupplierNo = "CmdDtl06";
            /// <summary>
            /// 供應商名稱
            /// </summary>
            public const string SupplierName = "CmdDtl07";
            /// <summary>
            /// 整箱
            /// </summary>
            public const string BoxCount = "CmdDtl09";
            /// <summary>
            /// 單位
            /// </summary>
            public const string Unit = "CmdDtl08";
            /// <summary>
            /// 倉別
            /// </summary>
            public const string WH_Type = "CmdDtl11";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "CmdDtl10";
            /// <summary>
            /// 製造日期
            /// </summary>
            public const string BeginDate = "CmdDtl12";
        }
    }
}
