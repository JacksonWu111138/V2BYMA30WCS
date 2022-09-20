using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mirle.Gird;

namespace Mirle.Grid.U2NMMA30
{
    public class ColumnDef
    {
        public class Teach
        {
            public static readonly ColumnInfo DeviceID = new ColumnInfo { Index = 0, Name = "DeviceID", Width = 60 };
            public static readonly ColumnInfo Loc = new ColumnInfo { Index = 1, Name = "Loc", Width = 68 };
            public static readonly ColumnInfo LocSts = new ColumnInfo { Index = 2, Name = "LocSts", Width = 60 };
            public static readonly ColumnInfo BoxId = new ColumnInfo { Index = 3, Name = "CstID", Width = 100 };

            public static void GridSetLocRange(ref DataGridView oGrid)
            {
                oGrid.ColumnCount = 4;
                oGrid.RowCount = 0;
                clInitSys.SetGridColumnInit(DeviceID, ref oGrid);
                clInitSys.SetGridColumnInit(Loc, ref oGrid);
                clInitSys.SetGridColumnInit(BoxId, ref oGrid);
                clInitSys.SetGridColumnInit(LocSts, ref oGrid);
            }
        }

        public class CMD_MST
        {
            public static readonly ColumnInfo CmdSno = new ColumnInfo { Index = 0, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Cmd_Sno, Width = 68 };
            public static readonly ColumnInfo JobID = new ColumnInfo { Index = 1, Name = DB.Fun.Parameter.clsCmd_Mst.Column.JobID, Width = 200 };
            public static readonly ColumnInfo BoxId = new ColumnInfo { Index = 2, Name = DB.Fun.Parameter.clsCmd_Mst.Column.BoxID, Width = 100 };
            public static readonly ColumnInfo CmdSts = new ColumnInfo { Index = 3, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Cmd_Sts, Width = 60 };
            public static readonly ColumnInfo PRT = new ColumnInfo { Index = 4, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Prty, Width = 68 };
            public static readonly ColumnInfo CmdMode = new ColumnInfo { Index = 5, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Cmd_Mode, Width = 60 };
            public static readonly ColumnInfo StnNo = new ColumnInfo { Index = 6, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Stn_No, Width = 200 };
            public static readonly ColumnInfo Loc = new ColumnInfo { Index = 7, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Loc, Width = 68 };
            public static readonly ColumnInfo Remark = new ColumnInfo { Index = 8, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Remark, Width = 250 };
            public static readonly ColumnInfo CurDeviceID = new ColumnInfo { Index = 9, Name = DB.Fun.Parameter.clsCmd_Mst.Column.CurDeviceID, Width = 80 };
            public static readonly ColumnInfo CurLoc = new ColumnInfo { Index = 10, Name = DB.Fun.Parameter.clsCmd_Mst.Column.CurLoc, Width = 80 };
            public static readonly ColumnInfo EquNO = new ColumnInfo { Index = 11, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Equ_No, Width = 60 };
            //public static readonly ColumnInfo BatchID = new ColumnInfo { Index = 12, Name = DB.Fun.Parameter.clsCmd_Mst.Column.BatchID, Width = 200 };
            public static readonly ColumnInfo ZoneID = new ColumnInfo { Index = 12, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Zone, Width = 80 };
            public static readonly ColumnInfo NewLoc = new ColumnInfo { Index = 13, Name = DB.Fun.Parameter.clsCmd_Mst.Column.New_Loc, Width = 68 };
            public static readonly ColumnInfo NeedShelfToShelf = new ColumnInfo { Index = 14, Name = DB.Fun.Parameter.clsCmd_Mst.Column.NeedShelfToShelf, Width = 100 };
            public static readonly ColumnInfo CrtDate = new ColumnInfo { Index = 15, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Create_Date, Width = 100 };
            public static readonly ColumnInfo ExpDate = new ColumnInfo { Index = 16, Name = DB.Fun.Parameter.clsCmd_Mst.Column.Expose_Date, Width = 100 };
            public static readonly ColumnInfo BackupPortId = new ColumnInfo { Index = 17, Name = DB.Fun.Parameter.clsCmd_Mst.Column.backupPortId, Width = 200 };
            //public static readonly ColumnInfo TicketId = new ColumnInfo { Index = 19, Name = "訂單號", Width = 200 };
            //public static readonly ColumnInfo ManualStockIn = new ColumnInfo { Index = 20, Name = "手動入庫", Width = 200 };

            public static void GridSetLocRange(ref DataGridView oGrid)
            {
                oGrid.ColumnCount = 18;
                oGrid.RowCount = 0;
                clInitSys.SetGridColumnInit(CmdSno, ref oGrid);
                clInitSys.SetGridColumnInit(JobID, ref oGrid);
                clInitSys.SetGridColumnInit(BoxId, ref oGrid);
                clInitSys.SetGridColumnInit(CmdSts, ref oGrid);
                clInitSys.SetGridColumnInit(PRT, ref oGrid);
                clInitSys.SetGridColumnInit(CmdMode, ref oGrid);
                clInitSys.SetGridColumnInit(StnNo, ref oGrid);
                clInitSys.SetGridColumnInit(Loc, ref oGrid);
                clInitSys.SetGridColumnInit(Remark, ref oGrid);
                clInitSys.SetGridColumnInit(CurDeviceID, ref oGrid);
                clInitSys.SetGridColumnInit(CurLoc, ref oGrid);
                clInitSys.SetGridColumnInit(EquNO, ref oGrid);
                //clInitSys.SetGridColumnInit(BatchID, ref oGrid);
                clInitSys.SetGridColumnInit(ZoneID, ref oGrid);
                clInitSys.SetGridColumnInit(NewLoc, ref oGrid);
                clInitSys.SetGridColumnInit(NeedShelfToShelf, ref oGrid);
                clInitSys.SetGridColumnInit(CrtDate, ref oGrid);
                clInitSys.SetGridColumnInit(ExpDate, ref oGrid);
                clInitSys.SetGridColumnInit(BackupPortId, ref oGrid);
                //clInitSys.SetGridColumnInit(TicketId, ref oGrid);
                //clInitSys.SetGridColumnInit(ManualStockIn, ref oGrid);
            }
        }

        public class MiddleCmd
        {
            public static readonly ColumnInfo DeviceID = new ColumnInfo { Index = 0, Name = DB.Fun.Parameter.clsMiddleCmd.Column.DeviceID, Width = 100 };
            public static readonly ColumnInfo CmdSno = new ColumnInfo { Index = 1, Name = DB.Fun.Parameter.clsMiddleCmd.Column.CommandID, Width = 68 };
            public static readonly ColumnInfo TaskNo = new ColumnInfo { Index = 2, Name = DB.Fun.Parameter.clsMiddleCmd.Column.TaskNo, Width = 68 };
            public static readonly ColumnInfo BoxId = new ColumnInfo { Index = 3, Name = DB.Fun.Parameter.clsMiddleCmd.Column.CSTID, Width = 100 };
            public static readonly ColumnInfo CmdSts = new ColumnInfo { Index = 4, Name = DB.Fun.Parameter.clsMiddleCmd.Column.CmdSts, Width = 60 };
            public static readonly ColumnInfo PRT = new ColumnInfo { Index = 5, Name = DB.Fun.Parameter.clsMiddleCmd.Column.Priority, Width = 68 };
            public static readonly ColumnInfo CmdMode = new ColumnInfo { Index = 6, Name = DB.Fun.Parameter.clsMiddleCmd.Column.CmdMode, Width = 60 };
            public static readonly ColumnInfo Source = new ColumnInfo { Index = 7, Name = DB.Fun.Parameter.clsMiddleCmd.Column.Source, Width = 68 };
            public static readonly ColumnInfo Destination = new ColumnInfo { Index = 8, Name = DB.Fun.Parameter.clsMiddleCmd.Column.Destination, Width = 68 };
            public static readonly ColumnInfo Remark = new ColumnInfo { Index = 9, Name = DB.Fun.Parameter.clsMiddleCmd.Column.Remark, Width = 250 };
            public static readonly ColumnInfo BatchID = new ColumnInfo { Index = 10, Name = DB.Fun.Parameter.clsMiddleCmd.Column.BatchID, Width = 200 };
            public static readonly ColumnInfo carrierType = new ColumnInfo { Index = 11, Name = DB.Fun.Parameter.clsMiddleCmd.Column.carrierType, Width = 68 };
            public static readonly ColumnInfo CompleteCode = new ColumnInfo { Index = 12, Name = DB.Fun.Parameter.clsMiddleCmd.Column.CompleteCode, Width = 60 };

            public static void GridSetLocRange(ref DataGridView oGrid)
            {
                oGrid.ColumnCount = 13;
                oGrid.RowCount = 0;
                clInitSys.SetGridColumnInit(CmdSno, ref oGrid);
                clInitSys.SetGridColumnInit(DeviceID, ref oGrid);
                clInitSys.SetGridColumnInit(BoxId, ref oGrid);
                clInitSys.SetGridColumnInit(CmdSts, ref oGrid);
                clInitSys.SetGridColumnInit(PRT, ref oGrid);
                clInitSys.SetGridColumnInit(CmdMode, ref oGrid);
                clInitSys.SetGridColumnInit(TaskNo, ref oGrid);
                clInitSys.SetGridColumnInit(Source, ref oGrid);
                clInitSys.SetGridColumnInit(Remark, ref oGrid);
                clInitSys.SetGridColumnInit(Destination, ref oGrid);
                clInitSys.SetGridColumnInit(carrierType, ref oGrid);
                clInitSys.SetGridColumnInit(CompleteCode, ref oGrid);
                clInitSys.SetGridColumnInit(BatchID, ref oGrid);
            }
        }
    }
}
