using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsCmd_Mst
    {
        public const string TableName = "Cmd_Mst";
        public class Column
        {
            /// <summary>
            /// 命令序號
            /// </summary>
            public const string Cmd_Sno = "CmdSno";
            /// <summary>
            /// 命令狀態
            /// </summary>
            public const string Cmd_Sts = "CmdSts";
            /// <summary>
            /// 命令不正常狀態
            /// </summary>
            public const string Cmd_Abnormal = "Cmd_Abnormal";
            /// <summary>
            /// 優先順位
            /// </summary>
            public const string Prty = "PRT";
            /// <summary>
            /// 站號
            /// </summary>
            public const string Stn_No = "StnNo";
            /// <summary>
            /// 命令模式
            /// </summary>
            public const string Cmd_Mode = "CmdMode";
            /// <summary>
            /// 作業類別
            /// </summary>
            public const string IO_Type = "Iotype";
            /// <summary>
            /// 倉儲編號
            /// </summary>
            //public const string WH_ID = "WH_ID";
            /// <summary>
            /// 儲位
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// (TO)新儲位/站號
            /// </summary>
            public const string New_Loc = "NewLoc";
            /// <summary>
            /// 混載數
            /// </summary>
            //public const string Mix_Qty = "Mix_Qty";
            /// <summary>
            /// 使用率
            /// </summary>
            //public const string Avail = "Avail";
            /// <summary>
            /// 儲存區
            /// </summary>
            public const string Zone = "ZoneID";
            /// <summary>
            /// BOXID/PALLETID
            /// </summary>
            public const string BoxID = "BoxId";
            /// <summary>
            /// 命令建立時間
            /// </summary>
            public const string Create_Date = "CrtDate";
            /// <summary>
            /// 命令送出時間
            /// </summary>
            public const string Expose_Date = "ExpDate";
            /// <summary>
            /// 命令完成時間
            /// </summary>
            public const string End_Date = "EndDate";
            /// <summary>
            /// 使用者編號
            /// </summary>
            public const string Trn_User = "UserID";
            /// <summary>
            /// 電腦名稱
            /// </summary>
            //public const string Host_Name = "Host_Name";
            /// <summary>
            /// 時序
            /// </summary>
            //public const string Trace = "Trace";
            /// <summary>
            /// 空棧板數量
            /// </summary>
            //public const string Pallet_Count = "Plt_Count";
            /// <summary>
            /// CRANE編號
            /// </summary>
            public const string Equ_No = "EquNO";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Remark";
            /// <summary>
            /// 當下位置
            /// </summary>
            public const string CurLoc = "CurLoc";
            /// <summary>
            /// 當下設備
            /// </summary>
            public const string CurDeviceID = "CurDeviceID";
            /// <summary>
            /// WMS JobID
            /// </summary>
            public const string JobID = "JobID";
            /// <summary>
            /// WMS BatchID
            /// </summary>
            public const string BatchID = "BatchID";
            /// <summary>
            /// 是否需要內儲位庫對庫
            /// </summary>
            public const string NeedShelfToShelf = "NeedShelfToShelf";
            /// <summary>
            /// WMS備用出庫Port
            /// </summary>
            public const string backupPortId = "backupPortId";
            /// <summary>
            /// 料架的位置
            /// </summary>
            public const string rackLocation = "rackLocation";
            /// <summary>
            /// 是否為最大捲
            /// </summary>
            public const string largest = "largest";
            public const string carrierType = "carrierType";
            public const string lotSize = "lotSize";
        }
    }
}
