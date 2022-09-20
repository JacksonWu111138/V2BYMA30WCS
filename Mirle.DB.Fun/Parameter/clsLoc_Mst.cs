using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsLoc_Mst
    {
        public const string TableName = "Loc_Mst";
        public class Column
        {
            /// <summary>
            /// 倉儲編號
            /// </summary>
            public const string WH_ID = "WH_ID";
            /// <summary>
            /// 儲位
            /// </summary>
            public const string Loc = "Loc";
            /// <summary>
            /// 儲位狀態
            /// </summary>
            public const string Loc_Sts = "Loc_Sts";
            /// <summary>
            /// 上次儲位狀態
            /// </summary>
            public const string Old_Sts = "Old_Sts";
            /// <summary>
            /// 混載數
            /// </summary>
            public const string Mix_Qty = "Mix_Qty";
            /// <summary>
            /// 使用率
            /// </summary>
            public const string Avail = "Avail";
            /// <summary>
            /// 列
            /// </summary>
            public const string Row_X = "Row_X";
            /// <summary>
            /// 行
            /// </summary>
            public const string Bay_Y = "Bay_Y";
            /// <summary>
            /// 層
            /// </summary>
            public const string Lvl_Z = "Lvl_Z";
            /// <summary>
            /// BOXID/PALLETID
            /// </summary>
            public const string Loc_ID = "Loc_ID";
            /// <summary>
            /// 儲位Size
            /// </summary>
            public const string Loc_Size = "Loc_Size";
            /// <summary>
            /// 儲存區
            /// </summary>
            public const string Zone_ID = "Zone_ID";
            /// <summary>
            /// 最後盤點日期
            /// </summary>
            public const string Cycle_Date = "Cycle_Date";
            /// <summary>
            /// 最後異動日期
            /// </summary>
            public const string Trn_Date = "Trn_Date";
            /// <summary>
            /// 儲位對照 
            /// </summary>
            public const string Loc_DD = "Loc_DD";
            /// <summary>
            /// 儲位類型
            /// </summary>
            public const string Storage_Type = "Storage_Type";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Remark";
            /// <summary>
            /// 建立者
            /// </summary>
            public const string Created_By = "Created_By";
            /// <summary>
            /// 禁用者
            /// </summary>
            public const string Inhibit_By = "Inhibit_By";
            /// <summary>
            /// 修改者
            /// </summary>
            public const string Trn_User = "Trn_User";
            /// <summary>
            /// 存取機ID
            /// </summary>
            public const string Equ_No = "Equ_No";
            /// <summary>
            /// 存取機的左右編號
            /// </summary>
            public const string Equ_RowNo = "Equ_RowNo";
            /// <summary>
            /// 空棧板數量
            /// </summary>
            public const string Plt_Count = "Plt_Count";
        }
    }
}
