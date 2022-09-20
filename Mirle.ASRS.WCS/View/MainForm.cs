using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using Mirle.Grid.U2NMMA30;
using System.Collections.Generic;
using Mirle.Def;
using Mirle.Def.U2NMMA30;
using Mirle.Structure.Info;
using Mirle.DB.Object;
using Mirle.DataBase;
using Mirle.WebAPI.Event;
using Unity;
using Mirle.Logger;
using Mirle.ASRS.Close.Program;
using System.Threading;
using Mirle.MapController;
using Mirle.Structure;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.ASRS.DBCommand;
using Mirle.Middle;
using Mirle.EccsSignal;
using Mirle.WebAPI.Test.AGVTaskCancel;
using Mirle.WebAPI.Test.WES;
using Mirle.WebAPI.Test.Controllers;

namespace Mirle.ASRS.WCS.View
{
    public partial class MainForm : Form
    {
        private DB.ClearCmd.Proc.clsHost clearCmd;
        private WebAPI.V2BYMA30.clsHost api = new WebAPI.V2BYMA30.clsHost();
        private WebApiHost _webApiHost;
        private UnityContainer _unityContainer;
        private clsGetCVLocation CVLocation;
        private static System.Timers.Timer timRead = new System.Timers.Timer();
        private MapHost router;
        public static DeviceInfo[] PCBA = new DeviceInfo[2];
        public static DeviceInfo[] Box = new DeviceInfo[3];
        //public static DeviceInfo[] AGV = new DeviceInfo[4];
        private ASRSProcess[] AsrsCommand = new ASRSProcess[5];
        private SignalHost[] CraneSignals = new SignalHost[5];
        private MidHost middle;
        private string sAsrsStockIn_Sql = "";
        private string sAsrsEquNo_Sql = "";
        private DB.Fun.clsTool tool;
        public MainForm()
        {
            InitializeComponent();

            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = false; timRead.Interval = 500;
        }

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            ChkAppIsAlreadyRunning();
            this.Text = this.Text + "  v " + ProductVersion;
            //CraneBuffer_Initial();
            //AGVBuffer_Initial();
            clInitSys.FunLoadIniSys();
            FunInit();
            FunEventInit();
            GridInit();

            sAsrsStockIn_Sql = DBCommand.clsTool.GetAllSqlLocation_ForIn(PCBA);
            sAsrsStockIn_Sql = sAsrsStockIn_Sql + "," + DBCommand.clsTool.GetAllSqlLocation_ForIn(Box);

            sAsrsEquNo_Sql = DBCommand.clsTool.GetAllSqlEquNo(PCBA);
            sAsrsEquNo_Sql = sAsrsEquNo_Sql + "," + DBCommand.clsTool.GetAllSqlEquNo(Box);

            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "WCS程式已開啟");
            timRead.Enabled = true;
            timer1.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCloseProgram objCloseProgram;
            try
            {
                e.Cancel = true;

                objCloseProgram = new frmCloseProgram();

                if (objCloseProgram.ShowDialog() == DialogResult.OK)
                {
                    chkOnline.Checked = false;
                    SpinWait.SpinUntil(() => false, 1000);
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "WCS程式已關閉！");
                    throw new Exception();
                }
            }
            catch
            {
                Environment.Exit(0);
            }
            finally
            {
                objCloseProgram = null;
            }
        }

        private void MainForm_OnNeedShelfToShelfEvent(object sender, DB.Fun.Events.NeedShelfToShelfArgs e)
        {
            clsEnum.AsrsType type = clsEnum.AsrsType.None;
            if (tool.CheckWhId_ASRS(e.EquNo, ref type))
            {
                CmdMstInfo cmd = new CmdMstInfo();
                int iRet = clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCommand_byBoxID(e.BoxID, ref cmd);
                if(iRet == DBResult.NoDataSelect)
                {
                    if(type == clsEnum.AsrsType.PCBA)
                    {
                        EmptyShelfQueryInfo info = new EmptyShelfQueryInfo
                        {
                            craneId = e.EquNo,
                            lotIdCarrierId = e.BoxID
                        };

                        EmptyShelfQueryReply reply = new EmptyShelfQueryReply();
                        if (api.GetEmptyShelfQuery().FunReport(info, ref reply, clInitSys.WmsApi_Config.IP))
                        {
                            CarrierShelfRequestInfo shelfRequestInfo = new CarrierShelfRequestInfo
                            {
                                disableLocation = clsConstValue.YesNo.No,
                                fromShelfId = e.Loc,
                                toShelfId = reply.shelfId
                            };

                            api.GetCarrierShelfRequest().FunReport(shelfRequestInfo, clInitSys.WmsApi_Config.IP);
                        }
                    }
                    else
                    {
                        string sNewLoc = clsDB_Proc.GetWmsDB_Object().GetLocMst().funSearchEmptyLoc_Abnormal_Proc(e.EquNo, e.Loc);
                        if (string.IsNullOrWhiteSpace(sNewLoc))
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 庫對庫找不到空儲位 => <Source>{e.Loc} " +
                                $"<{DB.Fun.Parameter.clsCmd_Mst.Column.Equ_No}>{e.EquNo} <{DB.Fun.Parameter.clsCmd_Mst.Column.BoxID}>{e.BoxID}");
                        }
                        else
                        {
                            CarrierShelfRequestInfo shelfRequestInfo = new CarrierShelfRequestInfo
                            {
                                disableLocation = clsConstValue.YesNo.No,
                                fromShelfId = e.Loc,
                                toShelfId = sNewLoc
                            };

                            api.GetCarrierShelfRequest().FunReport(shelfRequestInfo, clInitSys.WmsApi_Config.IP);
                        }
                    }
                }
            }
            else clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 確認ASRS倉別失敗 => <{DB.Fun.Parameter.clsCmd_Mst.Column.Equ_No}>{e.EquNo}");
        }

        private void MainForm_OnPostionReportEvent_ASRS(object sender, DB.Proc.Events.PositionReportArgs e)
        {
            CmdMstInfo cmd = new CmdMstInfo();
            if (clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCommand(e.CmdSno, ref cmd))
            {
                PositionReportInfo info = new PositionReportInfo
                {
                    carrierId = cmd.BoxID,
                    jobId = cmd.JobID,
                    location = e.Location,
                    inStock = e.Location == Def.Location.LocationID.Shelf.ToString() ? clsConstValue.YesNo.Yes : clsConstValue.YesNo.No
                };

                api.GetPositionReport().FunReport(info, clInitSys.WmsApi_Config.IP);
            }
        }

        private void chkOnline_CheckedChanged(object sender, EventArgs e)
        {
            middle.Online = chkOnline.Checked;

            if (chkOnline.Checked)
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, "WCS OnLine.");
            else
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, "WCS OffLine.");
        }

        private void chkCycleRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCycleRun.Checked)
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "周邊CycleRun啟動！");
            else
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "周邊CycleRun關閉！");
        }

        private void chkIgnoreTkt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgnoreTkt.Checked)
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "啟動IgnoreTicket功能！");
            else
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, "關閉IgnoreTicket功能！");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl + L
            if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                Def.clsTool.FunVisbleChange(ref btnTeachMaintain);
                Def.clsTool.FunVisbleChange(ref chkCycleRun);
                Def.clsTool.FunVisbleChange(ref chkIgnoreTkt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //APITestAGVTaskCancel form = new APITestAGVTaskCancel(clInitSys.AgvApi_Config);
            WESAPITest form_1 = new WESAPITest();
            //ControllersAPITest form_2 = new ControllersAPITest();
            form_1.Show();
            //form_2.Show();
        }

        private DataGridViewRow dgrTransferCmdLastSelect = null;
        private void Grid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Grid1.SelectedRows.Count > 0)
                {
                    mnuTransferCmdCancel.Visible = true;
                    mnuTransferCmdComplete.Visible = true;
                    mnuUpdateCurLoc.Visible = true;

                    if (dgrTransferCmdLastSelect != null)
                    {
                        if (!Grid1.SelectedRows.Contains(dgrTransferCmdLastSelect))
                        {
                            Grid1.SelectedRows[0].ContextMenuStrip = mnuTransferCmd;
                            dgrTransferCmdLastSelect.ContextMenuStrip = null;
                            dgrTransferCmdLastSelect = Grid1.SelectedRows[0];
                        }
                        else if (dgrTransferCmdLastSelect.Index == e.RowIndex)
                            Grid1.SelectedRows[0].ContextMenuStrip = mnuTransferCmd;
                        else
                        {
                            dgrTransferCmdLastSelect.ContextMenuStrip = null;
                            dgrTransferCmdLastSelect = Grid1.SelectedRows[0];
                        }
                    }
                    else
                    {
                        Grid1.SelectedRows[0].ContextMenuStrip = mnuTransferCmd;
                        dgrTransferCmdLastSelect = Grid1.SelectedRows[0];
                    }
                }
                else
                {
                    mnuTransferCmdCancel.Visible = false;
                    mnuTransferCmdComplete.Visible = false;
                    mnuUpdateCurLoc.Visible = false;

                    Grid1.ContextMenuStrip = mnuTransferCmd;
                }
            }
        }

        private DataGridViewRow dgrMiddleCmdLastSelect = null;
        private void Grid_MiddleCmd_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Grid_MiddleCmd.SelectedRows.Count > 0)
                {
                    mnuMiddleCancel.Visible = true;
                    mnuMiddleComplete.Visible = true;

                    if (dgrMiddleCmdLastSelect != null)
                    {
                        if (!Grid_MiddleCmd.SelectedRows.Contains(dgrMiddleCmdLastSelect))
                        {
                            Grid_MiddleCmd.SelectedRows[0].ContextMenuStrip = mnuMiddleCmd;
                            dgrMiddleCmdLastSelect.ContextMenuStrip = null;
                            dgrMiddleCmdLastSelect = Grid_MiddleCmd.SelectedRows[0];
                        }
                        else if (dgrMiddleCmdLastSelect.Index == e.RowIndex)
                            Grid_MiddleCmd.SelectedRows[0].ContextMenuStrip = mnuMiddleCmd;
                        else
                        {
                            dgrMiddleCmdLastSelect.ContextMenuStrip = null;
                            dgrMiddleCmdLastSelect = Grid_MiddleCmd.SelectedRows[0];
                        }
                    }
                    else
                    {
                        Grid_MiddleCmd.SelectedRows[0].ContextMenuStrip = mnuMiddleCmd;
                        dgrMiddleCmdLastSelect = Grid_MiddleCmd.SelectedRows[0];
                    }
                }
                else
                {
                    mnuMiddleCancel.Visible = false;
                    mnuMiddleComplete.Visible = false;

                    Grid_MiddleCmd.ContextMenuStrip = mnuMiddleCmd;
                }
            }
        }

        private void mnuMiddleComplete_Click(object sender, EventArgs e)
        {
            if (funMiddleCmd_Validation(clsEnum.CmdMaintence.Complete))
            {
                string sCmdSno = Convert.ToString(dgrMiddleCmdLastSelect.Cells[ColumnDef.MiddleCmd.CmdSno.Index].Value);
                string sRemark = "手動完成命令";
                if (clsDB_Proc.GetDB_Object().GetMiddleCmd().FunMiddleCmdUpdateCmdSts(sCmdSno, clsConstValue.CmdSts_MiddleCmd.strCmd_Finish_Wait, sRemark))
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, $"手動完成Middle命令成功 => <CommandID> {sCmdSno}");
                    MessageBox.Show("Finish Complete.");
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動完成Middle命令失敗 => <CommandID> {sCmdSno}");
                    MessageBox.Show("Complete Fail.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuMiddleCancel_Click(object sender, EventArgs e)
        {
            if (funMiddleCmd_Validation(clsEnum.CmdMaintence.Cancel))
            {
                string sCmdSno = Convert.ToString(dgrMiddleCmdLastSelect.Cells[ColumnDef.MiddleCmd.CmdSno.Index].Value);
                string sRemark = "手動取消命令";
                if (clsDB_Proc.GetDB_Object().GetMiddleCmd().FunMiddleCmdUpdateCmdSts(sCmdSno, 
                    clsConstValue.CmdSts_MiddleCmd.strCmd_Cancel_Wait, sRemark))
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, $"手動取消Middle命令成功 => <CommandID> {sCmdSno}");
                    MessageBox.Show("Cancel Complete.");
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動取消Middle命令失敗 => <CommandID> {sCmdSno}");
                    MessageBox.Show("Cancel Fail.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private frmInsertCmd_MiddleCmd insertCmd_MiddleCmd;
        private void mnuInsertMiddleCmd_Click(object sender, EventArgs e)
        {
            if (insertCmd_MiddleCmd == null)
            {
                insertCmd_MiddleCmd = new frmInsertCmd_MiddleCmd();
                insertCmd_MiddleCmd.TopMost = true;
                insertCmd_MiddleCmd.FormClosed += new FormClosedEventHandler(funMiddleCmdMaintain_FormClosed);
                insertCmd_MiddleCmd.Show();
            }
            else
            {
                insertCmd_MiddleCmd.BringToFront();
            }
        }

        private void funMiddleCmdMaintain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (insertCmd_MiddleCmd != null)
                insertCmd_MiddleCmd = null;
        }

        private bool funMiddleCmd_Validation(clsEnum.CmdMaintence type)
        {
            if (Grid_MiddleCmd.SelectedRows.Count == 0) return false;
            if (dgrMiddleCmdLastSelect == null) return false;

            DialogResult DlgResult;
            if (type == clsEnum.CmdMaintence.Cancel)
                DlgResult = MessageBox.Show("Are you sure cancel MiddleCmd？", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                DlgResult = MessageBox.Show("Are you sure complete MiddleCmd？", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DlgResult == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private bool funTransferCmd_Validation(clsEnum.CmdMaintence type)
        {
            if (Grid1.SelectedRows.Count == 0) return false;
            if (dgrTransferCmdLastSelect == null) return false;

            DialogResult DlgResult;
            if (type == clsEnum.CmdMaintence.Cancel)
                DlgResult = MessageBox.Show("Are you sure cancel command？", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                DlgResult = MessageBox.Show("Are you sure complete command？", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DlgResult == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void mnuTransferCmdComplete_Click(object sender, EventArgs e)
        {
            if (funTransferCmd_Validation(clsEnum.CmdMaintence.Complete))
            {
                string sCmdSno = Convert.ToString(dgrTransferCmdLastSelect.Cells[ColumnDef.CMD_MST.CmdSno.Index].Value);
                string sRemark = "手動完成命令";
                if (clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateCmdSts(sCmdSno, clsConstValue.CmdSts.strCmd_Finish_Wait, 
                    clsEnum.Cmd_Abnormal.CF, sRemark))
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, $"手動完成命令成功 => <CmdSno> {sCmdSno}");
                    MessageBox.Show("Finish Complete.");
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動完成命令失敗 => <CmdSno> {sCmdSno}");
                    MessageBox.Show("Complete Fail.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuTransferCmdCancel_Click(object sender, EventArgs e)
        {
            if (funTransferCmd_Validation(clsEnum.CmdMaintence.Cancel))
            {
                string sCmdSno = Convert.ToString(dgrTransferCmdLastSelect.Cells[ColumnDef.CMD_MST.CmdSno.Index].Value);
                string sRemark = "手動取消命令";
                if (clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateCmdSts(sCmdSno, clsConstValue.CmdSts.strCmd_Cancel_Wait, 
                    clsEnum.Cmd_Abnormal.CC, sRemark))
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, $"手動取消命令成功 => <CmdSno> {sCmdSno}");
                    MessageBox.Show("Cancel Complete.");
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動取消命令失敗 => <CmdSno> {sCmdSno}");
                    MessageBox.Show("Cancel Fail.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private frmInsertCmd_CmdMst insertCmd_CmdMst;
        private void mnuInsertCmd_Click(object sender, EventArgs e)
        {
            if (insertCmd_CmdMst == null)
            {
                insertCmd_CmdMst = new frmInsertCmd_CmdMst();
                insertCmd_CmdMst.TopMost = true;
                insertCmd_CmdMst.FormClosed += new FormClosedEventHandler(funCmdMaintain_FormClosed);
                insertCmd_CmdMst.Show();
            }
            else
            {
                insertCmd_CmdMst.BringToFront();
            }
        }

        private void funCmdMaintain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (insertCmd_CmdMst != null)
                insertCmd_CmdMst = null;
        }

        private frmUpdCurLoc updCurLoc;
        private void mnuUpdateCurLoc_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRows.Count == 0) return;

            string sCmdSno = Convert.ToString(dgrTransferCmdLastSelect.Cells[ColumnDef.CMD_MST.CmdSno.Index].Value);
            string sCurLoc = Convert.ToString(dgrTransferCmdLastSelect.Cells[ColumnDef.CMD_MST.CurLoc.Index].Value);
            string sCurDeviceID = Convert.ToString(dgrTransferCmdLastSelect.Cells[ColumnDef.CMD_MST.CurDeviceID.Index].Value);
            if (updCurLoc == null)
            {
                updCurLoc = new frmUpdCurLoc(sCmdSno, sCurDeviceID, sCurLoc);
                updCurLoc.TopMost = true;
                updCurLoc.FormClosed += new FormClosedEventHandler(funCmdMaintain_CurLoc_FormClosed);
                updCurLoc.Show();
            }
            else
            {
                updCurLoc.BringToFront();
            }
        }

        private void funCmdMaintain_CurLoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (updCurLoc != null)
                updCurLoc = null;
        }
        #endregion Event
        #region Timer
        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            try
            {
                clsDB_Proc.GetDB_Object().GetProc().FunNormalCmd_Proc(sAsrsStockIn_Sql, sAsrsEquNo_Sql, router, middle);
                if(DB.Proc.clsHost.IsConn)
                {
                    clsDB_Proc.GetDB_Object().GetProc().FunAsrsCmd_AbnormalFinish_Proc();
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                timRead.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                lblDBConn_WCS.BackColor = clsDB_Proc.DBConn ? Color.Blue : Color.Red;
                lblTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (tbcCmdInfo.SelectedTab == tbpCmdMst)
                    SubShowCmdtoGrid(ref Grid1);
                else if (tbcCmdInfo.SelectedTab == tbpMiddleCmd)
                    SubShowMiddleCmdtoGrid(ref Grid_MiddleCmd);
                else { }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                timer1.Enabled = true;
            }
        } 
        #endregion Timer
        //public static void AGVBuffer_Initial()
        //{
        //    #region 3F
        //    AGV[0] = new DeviceInfo
        //    {
        //        Floors = new List<FloorInfo>()
        //    };

        //    var floor = new FloorInfo
        //    {
        //        Group_IN = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A1_04,
        //            ConveyorDef.AGV.A1_08,
        //            ConveyorDef.AGV.A1_12,
        //            ConveyorDef.AGV.LO4_04
        //        },
        //        Group_OUT = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A1_01,
        //            ConveyorDef.AGV.A1_05,
        //            ConveyorDef.AGV.A1_09,
        //            ConveyorDef.AGV.LO4_01
        //        }
        //    };
        //    AGV[0].Floors.Add(floor);
        //    #endregion 3F
        //    #region 5F
        //    AGV[1] = new DeviceInfo
        //    {
        //        Floors = new List<FloorInfo>()
        //    };

        //    floor = new FloorInfo
        //    {
        //        Group_IN = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A2_04,
        //            ConveyorDef.AGV.A2_08,
        //            ConveyorDef.AGV.A2_12,
        //            ConveyorDef.AGV.A2_16,
        //            ConveyorDef.AGV.A2_20,
        //            ConveyorDef.AGV.LO5_04
        //        },
        //        Group_OUT = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A2_01,
        //            ConveyorDef.AGV.A2_05,
        //            ConveyorDef.AGV.A2_09,
        //            ConveyorDef.AGV.A2_13,
        //            ConveyorDef.AGV.A2_17,
        //            ConveyorDef.AGV.LO5_01
        //        }
        //    };
        //    AGV[1].Floors.Add(floor);
        //    #endregion 5F
        //    #region 6F
        //    AGV[2] = new DeviceInfo
        //    {
        //        Floors = new List<FloorInfo>()
        //    };

        //    floor = new FloorInfo
        //    {
        //        Group_IN = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A3_04,
        //            ConveyorDef.AGV.A3_08,
        //            ConveyorDef.AGV.A3_12,
        //            ConveyorDef.AGV.A3_16,
        //            ConveyorDef.AGV.A3_20,
        //            ConveyorDef.AGV.LO6_04
        //        },
        //        Group_OUT = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.A3_01,
        //            ConveyorDef.AGV.A3_05,
        //            ConveyorDef.AGV.A3_09,
        //            ConveyorDef.AGV.A3_13,
        //            ConveyorDef.AGV.A3_17,
        //            ConveyorDef.AGV.LO6_01
        //        }
        //    };
        //    AGV[2].Floors.Add(floor);
        //    #endregion 6F
        //    #region 8F
        //    AGV[3] = new DeviceInfo
        //    {
        //        Floors = new List<FloorInfo>()
        //    };

        //    floor = new FloorInfo
        //    {
        //        Group_IN = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.M1_05,
        //            ConveyorDef.AGV.M1_15,
        //            ConveyorDef.AGV.A4_04,
        //            ConveyorDef.AGV.A4_08,
        //            ConveyorDef.AGV.A4_12,
        //            ConveyorDef.AGV.A4_16,
        //            ConveyorDef.AGV.A4_20,
        //            ConveyorDef.AGV.E1_08,
        //            ConveyorDef.AGV.E2_35,
        //            ConveyorDef.AGV.E2_36,
        //            ConveyorDef.AGV.E2_37,
        //            ConveyorDef.AGV.E2_38,
        //            ConveyorDef.AGV.E2_39,
        //            ConveyorDef.AGV.E2_44,
        //            ConveyorDef.AGV.B1_070,
        //            ConveyorDef.AGV.B1_074,
        //            ConveyorDef.AGV.B1_078,
        //            ConveyorDef.AGV.LO2_04,
        //            ConveyorDef.AGV.LO3_01,
        //            ConveyorDef.AGV.S1_49,
        //            ConveyorDef.AGV.S1_50,
        //            ConveyorDef.AGV.S1_01,
        //            ConveyorDef.AGV.S1_07,
        //            ConveyorDef.AGV.S1_13,
        //            ConveyorDef.AGV.S1_25,
        //            ConveyorDef.AGV.S1_31,
        //            ConveyorDef.AGV.S1_40,
        //            ConveyorDef.AGV.S1_44,
        //            ConveyorDef.AGV.S1_48,
        //            //ConveyorDef.AGV.S1_52,
        //            //ConveyorDef.AGV.S1_56,
        //            //ConveyorDef.AGV.S1_60,
        //            //ConveyorDef.AGV.S1_64,
        //            ConveyorDef.AGV.S2_49,
        //            ConveyorDef.AGV.S2_01,
        //            ConveyorDef.AGV.S2_07,
        //            ConveyorDef.AGV.S2_13,
        //            ConveyorDef.AGV.S2_25,
        //            ConveyorDef.AGV.S2_31,
        //            ConveyorDef.AGV.S3_49,
        //            ConveyorDef.AGV.S3_01,
        //            ConveyorDef.AGV.S3_07,
        //            ConveyorDef.AGV.S3_13,
        //            ConveyorDef.AGV.S3_19,
        //            ConveyorDef.AGV.S3_25,
        //            ConveyorDef.AGV.S3_31,
        //            ConveyorDef.AGV.S3_40,
        //            ConveyorDef.AGV.S3_44,
        //            ConveyorDef.AGV.S3_48,
        //            ConveyorDef.AGV.S4_49,
        //            ConveyorDef.AGV.S4_50,
        //            ConveyorDef.AGV.S4_01,
        //            ConveyorDef.AGV.S4_07,
        //            ConveyorDef.AGV.S4_13,
        //            ConveyorDef.AGV.S4_19,
        //            ConveyorDef.AGV.S4_25,
        //            ConveyorDef.AGV.S5_49,
        //            ConveyorDef.AGV.S5_01,
        //            ConveyorDef.AGV.S5_07,
        //            ConveyorDef.AGV.S5_40,
        //            ConveyorDef.AGV.S6_01,
        //            ConveyorDef.AGV.S6_07
        //        },
        //        Group_OUT = new List<ConveyorInfo>
        //        {
        //            ConveyorDef.AGV.M1_10,
        //            ConveyorDef.AGV.M1_20,
        //            ConveyorDef.AGV.A4_01,
        //            ConveyorDef.AGV.A4_05,
        //            ConveyorDef.AGV.A4_09,
        //            ConveyorDef.AGV.A4_13,
        //            ConveyorDef.AGV.A4_17,
        //            ConveyorDef.AGV.E1_01,
        //            ConveyorDef.AGV.E2_35,
        //            ConveyorDef.AGV.E2_36,
        //            ConveyorDef.AGV.E2_37,
        //            ConveyorDef.AGV.E2_38,
        //            ConveyorDef.AGV.E2_39,
        //            ConveyorDef.AGV.E2_44,
        //            ConveyorDef.AGV.B1_071,
        //            ConveyorDef.AGV.B1_075,
        //            ConveyorDef.AGV.B1_079,
        //            ConveyorDef.AGV.LO2_01,
        //            ConveyorDef.AGV.LO3_04,
        //            ConveyorDef.AGV.S1_49,
        //            ConveyorDef.AGV.S1_50,
        //            ConveyorDef.AGV.S1_01,
        //            ConveyorDef.AGV.S1_07,
        //            ConveyorDef.AGV.S1_13,
        //            ConveyorDef.AGV.S1_25,
        //            ConveyorDef.AGV.S1_31,
        //            ConveyorDef.AGV.S1_37,
        //            ConveyorDef.AGV.S1_41,
        //            ConveyorDef.AGV.S1_45,
        //            ConveyorDef.AGV.S2_49,
        //            ConveyorDef.AGV.S2_01,
        //            ConveyorDef.AGV.S2_07,
        //            ConveyorDef.AGV.S2_13,
        //            ConveyorDef.AGV.S2_25,
        //            ConveyorDef.AGV.S2_31,
        //            ConveyorDef.AGV.S3_49,
        //            ConveyorDef.AGV.S3_01,
        //            ConveyorDef.AGV.S3_07,
        //            ConveyorDef.AGV.S3_13,
        //            ConveyorDef.AGV.S3_19,
        //            ConveyorDef.AGV.S3_25,
        //            ConveyorDef.AGV.S3_31,
        //            ConveyorDef.AGV.S3_37,
        //            ConveyorDef.AGV.S3_45,
        //            ConveyorDef.AGV.S4_49,
        //            ConveyorDef.AGV.S4_50,
        //            ConveyorDef.AGV.S4_01,
        //            ConveyorDef.AGV.S4_07,
        //            ConveyorDef.AGV.S4_13,
        //            ConveyorDef.AGV.S4_19,
        //            ConveyorDef.AGV.S4_25,
        //            ConveyorDef.AGV.S5_49,
        //            ConveyorDef.AGV.S5_01,
        //            ConveyorDef.AGV.S5_07,
        //            ConveyorDef.AGV.S5_37,
        //            ConveyorDef.AGV.S6_01,
        //            ConveyorDef.AGV.S6_07
        //        }
        //    };
        //    AGV[3].Floors.Add(floor); 
        //    #endregion 8F
        //}

        public static void CraneBuffer_Initial()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int f = 1; f <= 2; f++)
                {
                    if (i < 2 && f == 2) continue;

                    FloorInfo floor = new FloorInfo();
                    floor.Group_IN = new List<ConveyorInfo>();
                    floor.Group_OUT = new List<ConveyorInfo>();
                    switch(i)
                    {
                        #region PCBA
                        case 0:
                            floor.Group_IN.Add(ConveyorDef.PCBA.M1_06);
                            floor.Group_OUT.Add(ConveyorDef.PCBA.M1_01);

                            PCBA[i] = new DeviceInfo();
                            PCBA[i].Floors = new List<FloorInfo>();
                            PCBA[i].Floors.Add(floor);
                            break;
                        case 1:
                            floor.Group_IN.Add(ConveyorDef.PCBA.M1_16);
                            floor.Group_OUT.Add(ConveyorDef.PCBA.M1_11);

                            PCBA[i] = new DeviceInfo();
                            PCBA[i].Floors = new List<FloorInfo>();
                            PCBA[i].Floors.Add(floor);
                            break;
                        #endregion PCBA
                        #region 箱式倉
                        case 2:
                            if (f == 1)
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_007);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_010);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_001);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_004);
                            }
                            else
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_087);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_090);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_081);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_084);
                            }
                            Box[i - 2] = new DeviceInfo();
                            Box[i - 2].Floors = new List<FloorInfo>();
                            Box[i - 2].Floors.Add(floor);
                            break;
                        case 3:
                            if (f == 1)
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_019);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_022);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_013);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_016);
                            }
                            else
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_099);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_102);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_093);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_096);
                            }
                            Box[i - 2] = new DeviceInfo();
                            Box[i - 2].Floors = new List<FloorInfo>();
                            Box[i - 2].Floors.Add(floor);
                            break;
                        default:
                            if (f == 1)
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_031);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_034);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_025);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_028);
                            }
                            else
                            {
                                floor.Group_IN.Add(ConveyorDef.Box.B1_111);
                                floor.Group_IN.Add(ConveyorDef.Box.B1_114);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_105);
                                floor.Group_OUT.Add(ConveyorDef.Box.B1_108);
                            }
                            Box[i - 2] = new DeviceInfo();
                            Box[i - 2].Floors = new List<FloorInfo>();
                            Box[i - 2].Floors.Add(floor);
                            break;
                            #endregion 箱式倉
                    }
                }
            }
        }

        private void FunInit()
        {
            var archive = new AutoArchive();
            archive.Start();
            clsDB_Proc.Initial(clInitSys.DbConfig, clInitSys.DbConfig_WMS, clInitSys.WmsApi_Config, clInitSys.TowerApi_Config);
            clsMiddle.Initial(ConveyorDef.GetAllNode(), clInitSys.AgvApi_Config, PCBA, Box,
                ConveyorDef.DeviceID_AGV, ConveyorDef.DeviceID_Tower, clInitSys.DbConfig, clInitSys.AgvApi_Config, clInitSys.TowerApi_Config);
            clsAPI.Initial(clInitSys.WmsApi_Config, clInitSys.AgvApi_Config, clInitSys.TowerApi_Config, clInitSys.BoxApi_Config,
                clInitSys.PcbaApi_Config, clInitSys.SmtcApi_Config, clInitSys.OsmtcApi_Config, clInitSys.E04Api_Config, clInitSys.E05Api_Config);
            router = new MapHost(clInitSys.DbConfig);
            CVLocation = new clsGetCVLocation(router);
            ConveyorDef.FunNodeListAddInit();
            ConveyorDef.FunStnListAddInit();
            FunAsrsCmdInit();
            tool = new DB.Fun.clsTool(PCBA, Box);
            middle = new MidHost(ConveyorDef.GetAllNode(), clInitSys.AgvApi_Config, PCBA, Box, 
                ConveyorDef.DeviceID_AGV, ConveyorDef.DeviceID_Tower, clInitSys.DbConfig, clInitSys.AgvApi_Config, clInitSys.TowerApi_Config);
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterInstance(new WCSController());
            _webApiHost = new WebApiHost(new Startup(_unityContainer), clInitSys.WcsApi_Config.IP);
            clearCmd = new DB.ClearCmd.Proc.clsHost();
        }

        private void FunEventInit()
        {
            Grid1.CellMouseDown += new DataGridViewCellMouseEventHandler(Grid1_CellMouseDown);
            Grid_MiddleCmd.CellMouseDown += new DataGridViewCellMouseEventHandler(Grid_MiddleCmd_CellMouseDown);
            for (int i = 0; i < AsrsCommand.Length; i++)
            {
                AsrsCommand[i].GetWCS().GetProc().GetFun_Routdef().OnNeedShelfToShelfEvent += MainForm_OnNeedShelfToShelfEvent;
                AsrsCommand[i].GetWCS().GetMiddleCmd().OnPostionReportEvent += MainForm_OnPostionReportEvent_ASRS;
            }
        }

        private void FunAsrsCmdInit()
        {
            for (int i = 0; i < AsrsCommand.Length; i++)
            {
                clsPlcConfig plcConfig = new clsPlcConfig();
                plcConfig.CraneType = clsEnum.CmdType.CraneType.Single;
                plcConfig.ForkType = clsEnum.CmdType.ForkType.SingleFork;
                plcConfig.LocType = clsEnum.CmdType.LocType.DoubleDeep;

                if (i < 2)
                {
                    CraneSignals[i] = new SignalHost(clInitSys.DbConfig, PCBA[i].DeviceID);
                    plcConfig.CV_Type = clsEnum.CmdType.CV_Type.Single;
                    AsrsCommand[i] = new ASRSProcess(clInitSys.DbConfig, clInitSys.DbConfig_WMS, plcConfig, PCBA[i], router, middle, CraneSignals[i]);
                }
                else
                {
                    CraneSignals[i] = new SignalHost(clInitSys.DbConfig, Box[i - 2].DeviceID);
                    plcConfig.CV_Type = clsEnum.CmdType.CV_Type.Double;
                    AsrsCommand[i] = new ASRSProcess(clInitSys.DbConfig, clInitSys.DbConfig_WMS, plcConfig, Box[i - 2], router, middle, CraneSignals[i]);
                }
            }
        }

        #region Grid顯示
        private void GridInit()
        {
            Gird.clInitSys.GridSysInit(ref Grid1);
            Gird.clInitSys.GridSysInit(ref Grid_MiddleCmd);
            ColumnDef.CMD_MST.GridSetLocRange(ref Grid1);
            ColumnDef.MiddleCmd.GridSetLocRange(ref Grid_MiddleCmd);
        }

        delegate void degShowCmdtoGrid(ref DataGridView oGrid);
        private void SubShowCmdtoGrid(ref DataGridView oGrid)
        {
            degShowCmdtoGrid obj;
            DataTable dtTmp = new DataTable();
            try
            {
                if (InvokeRequired)
                {
                    obj = new degShowCmdtoGrid(SubShowCmdtoGrid);
                    Invoke(obj, oGrid);
                }
                else
                {
                    int iRet = clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCmdMst_Grid(ref dtTmp);
                    if (iRet == DBResult.Success)
                    {
                        if (oGrid.Columns.Count == 0)
                            return;

                        int intSelectRowIndex = (oGrid.SelectedRows.Count == 0 ? -1 : oGrid.SelectedRows[0].Index);
                        oGrid.SuspendLayout();
                        if (oGrid.Rows.Count > dtTmp.Rows.Count)
                        {
                            for (int intRow = oGrid.Rows.Count; intRow > dtTmp.Rows.Count; intRow--)
                                oGrid.Rows.Remove(oGrid.Rows[intRow - 1]);
                        }
                        else if (oGrid.Rows.Count < dtTmp.Rows.Count)
                        {
                            for (int intRow = oGrid.Rows.Count; intRow < dtTmp.Rows.Count; intRow++)
                            {
                                oGrid.Rows.Add();
                                oGrid.Rows[intRow].HeaderCell.Value = (intRow + 1).ToString();
                            }
                        }
                        else
                        {
                            for (int intRow = 0; intRow < oGrid.Rows.Count; intRow++)
                                oGrid.Rows[intRow].HeaderCell.Value = (intRow + 1).ToString();
                        }

                        string strField = string.Empty;
                        string strSortField = string.Empty;
                        SortOrder sortOrder = SortOrder.Ascending;
                        object sync1 = new object();
                        object sync2 = new object();

                        if (oGrid.SortedColumn != null)
                        {
                            strSortField = oGrid.SortedColumn.Name;
                            sortOrder = oGrid.SortOrder;
                            dtTmp.DefaultView.Sort = strSortField + (sortOrder == SortOrder.Ascending ? " ASC" : " DESC");
                            dtTmp = dtTmp.DefaultView.ToTable();
                        }

                        for (int intRow = 0; intRow < oGrid.Rows.Count; intRow++)
                        {
                            for (int intCol = 0; intCol < dtTmp.Columns.Count; intCol++)
                            {
                                //dataGridView.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.None;
                                strField = oGrid.Columns[intCol].Name;
                                if (oGrid.Columns.Contains(strField))
                                {
                                    if (Convert.ToString(oGrid.Rows[intRow].Cells[intCol].Value) != Convert.ToString(dtTmp.Rows[intRow][strField]))
                                        oGrid.Rows[intRow].Cells[intCol].Value = Convert.ToString(dtTmp.Rows[intRow][strField]);
                                }
                            }
                        }

                        if (intSelectRowIndex >= 0)
                        {
                            if (oGrid.Rows.Count > intSelectRowIndex)
                                oGrid.Rows[intSelectRowIndex].Selected = true;
                            else
                                oGrid.Rows[oGrid.Rows.Count - 1].Selected = true;
                        }
                        else
                            oGrid.ClearSelection();

                        oGrid.ResumeLayout();
                    }
                    else
                    {
                        oGrid.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                dtTmp = null;
            }
        }

        delegate void degShowMiddleCmdtoGrid(ref DataGridView oGrid);
        private void SubShowMiddleCmdtoGrid(ref DataGridView oGrid)
        {
            degShowMiddleCmdtoGrid obj;
            DataTable dtTmp = new DataTable();
            try
            {
                if (InvokeRequired)
                {
                    obj = new degShowMiddleCmdtoGrid(SubShowMiddleCmdtoGrid);
                    Invoke(obj, oGrid);
                }
                else
                {
                    int iRet = clsDB_Proc.GetDB_Object().GetMiddleCmd().FunGetMiddleCmd_Grid(ref dtTmp);
                    if (iRet == DBResult.Success)
                    {
                        if (oGrid.Columns.Count == 0)
                            return;

                        int intSelectRowIndex = (oGrid.SelectedRows.Count == 0 ? -1 : oGrid.SelectedRows[0].Index);
                        oGrid.SuspendLayout();
                        if (oGrid.Rows.Count > dtTmp.Rows.Count)
                        {
                            for (int intRow = oGrid.Rows.Count; intRow > dtTmp.Rows.Count; intRow--)
                                oGrid.Rows.Remove(oGrid.Rows[intRow - 1]);
                        }
                        else if (oGrid.Rows.Count < dtTmp.Rows.Count)
                        {
                            for (int intRow = oGrid.Rows.Count; intRow < dtTmp.Rows.Count; intRow++)
                            {
                                oGrid.Rows.Add();
                                oGrid.Rows[intRow].HeaderCell.Value = (intRow + 1).ToString();
                            }
                        }
                        else
                        {
                            for (int intRow = 0; intRow < oGrid.Rows.Count; intRow++)
                                oGrid.Rows[intRow].HeaderCell.Value = (intRow + 1).ToString();
                        }

                        string strField = string.Empty;
                        string strSortField = string.Empty;
                        SortOrder sortOrder = SortOrder.Ascending;
                        object sync1 = new object();
                        object sync2 = new object();

                        if (oGrid.SortedColumn != null)
                        {
                            strSortField = oGrid.SortedColumn.Name;
                            sortOrder = oGrid.SortOrder;
                            dtTmp.DefaultView.Sort = strSortField + (sortOrder == SortOrder.Ascending ? " ASC" : " DESC");
                            dtTmp = dtTmp.DefaultView.ToTable();
                        }

                        for (int intRow = 0; intRow < oGrid.Rows.Count; intRow++)
                        {
                            for (int intCol = 0; intCol < dtTmp.Columns.Count; intCol++)
                            {
                                //dataGridView.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.None;
                                strField = oGrid.Columns[intCol].Name;
                                if (oGrid.Columns.Contains(strField))
                                {
                                    if (Convert.ToString(oGrid.Rows[intRow].Cells[intCol].Value) != Convert.ToString(dtTmp.Rows[intRow][strField]))
                                        oGrid.Rows[intRow].Cells[intCol].Value = Convert.ToString(dtTmp.Rows[intRow][strField]);
                                }
                            }
                        }

                        if (intSelectRowIndex >= 0)
                        {
                            if (oGrid.Rows.Count > intSelectRowIndex)
                                oGrid.Rows[intSelectRowIndex].Selected = true;
                            else
                                oGrid.Rows[oGrid.Rows.Count - 1].Selected = true;
                        }
                        else
                            oGrid.ClearSelection();

                        oGrid.ResumeLayout();
                    }
                    else
                    {
                        oGrid.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                dtTmp = null;
            }
        }
        #endregion Grid顯示

        /// <summary>
        /// 檢查程式是否重複開啟
        /// </summary>
        private void ChkAppIsAlreadyRunning()
        {
            try
            {
                string aFormName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
                string aProcName = System.IO.Path.GetFileNameWithoutExtension(aFormName);
                if (System.Diagnostics.Process.GetProcessesByName(aProcName).Length > 1)
                {
                    MessageBox.Show("程式已開啟", "Communication System", MessageBoxButtons.OK);
                    //Application.Exit();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                Environment.Exit(0);
            }
        }

        private void ChangeSubForm(Form subForm)
        {
            try
            {
                var children = spcMainView.Panel1.Controls;
                foreach (Control c in children)
                {
                    if (c is Form)
                    {
                        var thisChild = c as Form;
                        //thisChild.Hide();
                        spcMainView.Panel1.Controls.Remove(thisChild);
                        thisChild.Width = 0;
                    }
                }

                if (subForm != null)
                {
                    subForm.TopLevel = false;
                    subForm.Dock = DockStyle.Fill;//適應窗體大小
                    subForm.FormBorderStyle = FormBorderStyle.None;//隱藏右上角的按鈕
                    subForm.Parent = spcMainView.Panel1;
                    spcMainView.Panel1.Controls.Add(subForm);
                    subForm.Show();
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
        }
    }
}
