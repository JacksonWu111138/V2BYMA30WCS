using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Fun.Parameter
{
    public class clsItmMst
    {
        public const string TableName = "Itm_Mst";
        public class Column
        {
            /// <summary>
            /// 料號
            /// </summary>
            public const string Item_No = "Item_No";
            /// <summary>
            /// 品名
            /// </summary>
            public const string Item_Name = "Item_Name";
            /// <summary>
            /// 規格
            /// </summary>
            public const string Item_Spec = "Item_Spec";
            /// <summary>
            /// 單位(中文)
            /// </summary>
            public const string Item_Unit = "Item_Unit";
            /// <summary>
            /// 單位(英文)
            /// </summary>
            public const string Item_UnitE = "Item_UnitE";
            /// <summary>
            /// 物料類別
            /// </summary>
            public const string Item_Type = "Item_Type";
            /// <summary>
            /// 物料群組
            /// </summary>
            public const string Item_Grp = "Item_Grp";
            /// <summary>
            /// 每箱包裝量
            /// </summary>
            public const string Qty_Box = "Qty_Box";
            /// <summary>
            /// 每一棧板箱數
            /// </summary>
            public const string Box_Plt = "Box_Plt";
            /// <summary>
            /// 整板數量
            /// </summary>
            public const string Qty_Plt = "Qty_Plt";
            /// <summary>
            /// 最高安全存量
            /// </summary>
            public const string Safe_Height = "Safe_Height";
            /// <summary>
            /// 最低安全存量
            /// </summary>
            public const string Safe_Low = "Safe_Low";
            /// <summary>
            /// 最小計量單位重(淨重)
            /// </summary>
            public const string Unit_WG = "Unit_WG";
            /// <summary>
            /// 保存期限
            /// </summary>
            public const string Valid_Days = "Valid_Days";
            /// <summary>
            /// 備註
            /// </summary>
            public const string Remark = "Remark";
            /// <summary>
            /// 創建人
            /// </summary>
            public const string Created_User = "Created_User";
            /// <summary>
            /// 創建日期
            /// </summary>
            public const string Created_Date = "Created_Date";
            /// <summary>
            /// 異動日期
            /// </summary>
            public const string Trn_Date = "Trn_Date";
            /// <summary>
            /// 異動人員
            /// </summary>
            public const string Trn_User = "Trn_User";
        }
    }
}
