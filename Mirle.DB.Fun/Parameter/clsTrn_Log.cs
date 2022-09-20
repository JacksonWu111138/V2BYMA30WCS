using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsTrn_Log
    {
        public const string TableName = "Trn_Log";
        public class Column
        {
            /// <summary>
            /// 紀錄日期
            /// </summary>
            public const string Log_Date = "Log_Date";
            /// <summary>
            /// 命令序號
            /// </summary>
            public const string Cmd_Sno = "Cmd_Sno";
            /// <summary>
            /// 命令交易編號
            /// </summary>
            public const string Cmd_Txno = "Cmd_Txno";
            /// <summary>
            /// 命令狀態
            /// </summary>
            public const string Cmd_Sts = "Cmd_Sts";
            /// <summary>
            /// 命令不正常狀態
            /// </summary>
            public const string Cmd_Abnormal = "Cmd_Abnormal";
            /// <summary>
            /// 優先順位
            /// </summary>
            public const string Prty = "Prty";
            /// <summary>
            /// 站號
            /// </summary>
            public const string Stn_No = "Stn_No";
            /// <summary>
            /// 命令模式
            /// </summary>
            public const string Cmd_Mode = "Cmd_Mode";
            /// <summary>
            /// 作業類別
            /// </summary>
            public const string IO_Type = "IO_Type";
            /// <summary>
            /// 入/出庫單
            /// </summary>
            public const string Tkt_IO = "Tkt_IO";
            /// <summary>
            /// 單據類型
            /// </summary>
            public const string Tkt_Type = "Tkt_Type";
            /// <summary>
            /// 倉儲編號
            /// </summary>
            public const string WH_ID = "WH_ID";
            /// <summary>
            /// 儲位
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// (TO)新儲位/站號
            /// </summary>
            public const string New_Loc = "New_Loc";
            /// <summary>
            /// 混載數
            /// </summary>
            public const string Mix_Qty = "Mix_Qty";
            /// <summary>
            /// 使用率
            /// </summary>
            public const string Avail = "Avail";
            /// <summary>
            /// 儲存區
            /// </summary>
            public const string Zone = "Zone_ID";
            /// <summary>
            /// BOXID/PALLETID
            /// </summary>
            public const string BoxID = "Loc_ID";
            /// <summary>
            /// 命令建立時間
            /// </summary>
            public const string Create_Date = "Crt_Date";
            /// <summary>
            /// 命令送出時間
            /// </summary>
            public const string Expose_Date = "EXP_Date";
            /// <summary>
            /// 命令完成時間
            /// </summary>
            public const string End_Date = "End_Date";
            /// <summary>
            /// 使用者編號
            /// </summary>
            public const string Trn_User = "Trn_User";
            /// <summary>
            /// 電腦名稱
            /// </summary>
            public const string Host_Name = "Host_Name";
            /// <summary>
            /// 時序
            /// </summary>
            public const string Trace = "Trace";
            /// <summary>
            /// 空棧板數量
            /// </summary>
            public const string Pallet_Count = "Plt_Count";
            /// <summary>
            /// CRANE編號
            /// </summary>
            public const string Equ_No = "Equ_No";
            /// <summary>
            /// 棧板量
            /// </summary>
            public const string Plt_Qty = "Plt_Qty";
            /// <summary>
            /// 異動量
            /// </summary>
            public const string Trn_Qty = "Trn_Qty";
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
            /// 盤點單號
            /// </summary>
            public const string Cyc_No = "Cyc_No";
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
            /// <summary>
            /// 列印Flag
            /// </summary>
            public const string Print_Flag = "Print_Flag";
        }
    }
}
