using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Linq;
using System.Text;
using Mirle.WriLog;
using System.Windows.Forms;

namespace Mirle.Gird
{
    public class clInitSys
    {
        public static clsLog Log = new clsLog("Mirle.Gird", false);

        public static void GridSysInit(ref DataGridView oGrid)
        {
            try
            {
                //指定 Column 的字體
                oGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                //指定 Row 的字體
                oGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                oGrid.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                oGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                oGrid.ReadOnly = true;                  //不允許修改
                oGrid.AllowUserToAddRows = false;       //不允許使用者從 DataGridView 中增加資料列。
                oGrid.AllowUserToDeleteRows = false;    //不允許使用者從 DataGridView 中刪除資料列。 
                oGrid.AllowUserToResizeRows = true;    //允許調整資料列的大小。
                oGrid.MultiSelect = false;             //不允許多選列
                oGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;        //選擇整Row方式
                //oGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;     //選擇單一Row方式

                oGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //字體對齊位置
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
        }

        public static void SetGridColumnInit(ColumnInfo obj, ref DataGridView oGrid)
        {
            oGrid.Columns[obj.Index].Width = obj.Width; oGrid.Columns[obj.Index].Name = obj.Name;
        }
    }
}
