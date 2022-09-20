namespace Mirle.ASRS.WCS.View
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpMainSts = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.picMirle = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDBConn_WMS = new System.Windows.Forms.Label();
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.lblDBConn_WCS = new System.Windows.Forms.Label();
            this.spcView = new System.Windows.Forms.SplitContainer();
            this.spcMainView = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkIgnoreTkt = new System.Windows.Forms.CheckBox();
            this.btnCrandSpeedMaintain = new System.Windows.Forms.Button();
            this.btnCmdMaintain = new System.Windows.Forms.Button();
            this.btnStockerModeMaintain = new System.Windows.Forms.Button();
            this.btnTeachMaintain = new System.Windows.Forms.Button();
            this.btnTransferToTeachLoc = new System.Windows.Forms.Button();
            this.chkCycleRun = new System.Windows.Forms.CheckBox();
            this.btnOEEParameterMaintain = new System.Windows.Forms.Button();
            this.AGVTaskCancelButten = new System.Windows.Forms.Button();
            this.tbcCmdInfo = new System.Windows.Forms.TabControl();
            this.tbpCmdMst = new System.Windows.Forms.TabPage();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.tbpMiddleCmd = new System.Windows.Forms.TabPage();
            this.Grid_MiddleCmd = new System.Windows.Forms.DataGridView();
            this.mnuTransferCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTransferCmdComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransferCmdCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateCurLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMiddleCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMiddleComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMiddleCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertMiddleCmd = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpMainSts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMirle)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcView)).BeginInit();
            this.spcView.Panel1.SuspendLayout();
            this.spcView.Panel2.SuspendLayout();
            this.spcView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMainView)).BeginInit();
            this.spcMainView.Panel2.SuspendLayout();
            this.spcMainView.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcCmdInfo.SuspendLayout();
            this.tbpCmdMst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.tbpMiddleCmd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_MiddleCmd)).BeginInit();
            this.mnuTransferCmd.SuspendLayout();
            this.mnuMiddleCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpMainSts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.spcView);
            this.splitContainer1.Size = new System.Drawing.Size(1756, 898);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // tlpMainSts
            // 
            this.tlpMainSts.ColumnCount = 4;
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpMainSts.Controls.Add(this.lblTimer, 0, 0);
            this.tlpMainSts.Controls.Add(this.picMirle, 0, 0);
            this.tlpMainSts.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tlpMainSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainSts.Location = new System.Drawing.Point(0, 0);
            this.tlpMainSts.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMainSts.Name = "tlpMainSts";
            this.tlpMainSts.RowCount = 1;
            this.tlpMainSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainSts.Size = new System.Drawing.Size(1756, 118);
            this.tlpMainSts.TabIndex = 0;
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Location = new System.Drawing.Point(249, 0);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(237, 118);
            this.lblTimer.TabIndex = 268;
            this.lblTimer.Text = "yyyy/MM/dd hh:mm:ss";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMirle
            // 
            this.picMirle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMirle.Image = ((System.Drawing.Image)(resources.GetObject("picMirle.Image")));
            this.picMirle.Location = new System.Drawing.Point(4, 4);
            this.picMirle.Margin = new System.Windows.Forms.Padding(4);
            this.picMirle.Name = "picMirle";
            this.picMirle.Size = new System.Drawing.Size(237, 110);
            this.picMirle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMirle.TabIndex = 267;
            this.picMirle.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblDBConn_WMS, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkOnline, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDBConn_WCS, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1512, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 110);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblDBConn_WMS
            // 
            this.lblDBConn_WMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDBConn_WMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBConn_WMS.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDBConn_WMS.Location = new System.Drawing.Point(4, 35);
            this.lblDBConn_WMS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDBConn_WMS.Name = "lblDBConn_WMS";
            this.lblDBConn_WMS.Size = new System.Drawing.Size(232, 35);
            this.lblDBConn_WMS.TabIndex = 3;
            this.lblDBConn_WMS.Text = "WMS DB Sts";
            this.lblDBConn_WMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkOnline
            // 
            this.chkOnline.AutoSize = true;
            this.chkOnline.Checked = true;
            this.chkOnline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOnline.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOnline.Location = new System.Drawing.Point(4, 74);
            this.chkOnline.Margin = new System.Windows.Forms.Padding(4);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(232, 32);
            this.chkOnline.TabIndex = 2;
            this.chkOnline.Text = "OnLine";
            this.chkOnline.UseVisualStyleBackColor = true;
            this.chkOnline.Visible = false;
            this.chkOnline.CheckedChanged += new System.EventHandler(this.chkOnline_CheckedChanged);
            // 
            // lblDBConn_WCS
            // 
            this.lblDBConn_WCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDBConn_WCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBConn_WCS.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDBConn_WCS.Location = new System.Drawing.Point(4, 0);
            this.lblDBConn_WCS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDBConn_WCS.Name = "lblDBConn_WCS";
            this.lblDBConn_WCS.Size = new System.Drawing.Size(232, 35);
            this.lblDBConn_WCS.TabIndex = 1;
            this.lblDBConn_WCS.Text = "WCS DB Sts";
            this.lblDBConn_WCS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spcView
            // 
            this.spcView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcView.Location = new System.Drawing.Point(0, 0);
            this.spcView.Margin = new System.Windows.Forms.Padding(4);
            this.spcView.Name = "spcView";
            this.spcView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcView.Panel1
            // 
            this.spcView.Panel1.Controls.Add(this.spcMainView);
            // 
            // spcView.Panel2
            // 
            this.spcView.Panel2.Controls.Add(this.tbcCmdInfo);
            this.spcView.Size = new System.Drawing.Size(1756, 774);
            this.spcView.SplitterDistance = 567;
            this.spcView.SplitterWidth = 6;
            this.spcView.TabIndex = 0;
            // 
            // spcMainView
            // 
            this.spcMainView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMainView.Location = new System.Drawing.Point(0, 0);
            this.spcMainView.Margin = new System.Windows.Forms.Padding(4);
            this.spcMainView.Name = "spcMainView";
            // 
            // spcMainView.Panel2
            // 
            this.spcMainView.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.spcMainView.Size = new System.Drawing.Size(1756, 567);
            this.spcMainView.SplitterDistance = 1571;
            this.spcMainView.SplitterWidth = 6;
            this.spcMainView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkIgnoreTkt, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCrandSpeedMaintain, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCmdMaintain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStockerModeMaintain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTeachMaintain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTransferToTeachLoc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCycleRun, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnOEEParameterMaintain, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.AGVTaskCancelButten, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(177, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkIgnoreTkt
            // 
            this.chkIgnoreTkt.AutoSize = true;
            this.chkIgnoreTkt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIgnoreTkt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkIgnoreTkt.Location = new System.Drawing.Point(4, 442);
            this.chkIgnoreTkt.Margin = new System.Windows.Forms.Padding(4);
            this.chkIgnoreTkt.Name = "chkIgnoreTkt";
            this.chkIgnoreTkt.Size = new System.Drawing.Size(169, 36);
            this.chkIgnoreTkt.TabIndex = 10;
            this.chkIgnoreTkt.Text = "Ignore Ticket";
            this.chkIgnoreTkt.UseVisualStyleBackColor = true;
            this.chkIgnoreTkt.Visible = false;
            this.chkIgnoreTkt.CheckedChanged += new System.EventHandler(this.chkIgnoreTkt_CheckedChanged);
            // 
            // btnCrandSpeedMaintain
            // 
            this.btnCrandSpeedMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCrandSpeedMaintain.Location = new System.Drawing.Point(4, 268);
            this.btnCrandSpeedMaintain.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrandSpeedMaintain.Name = "btnCrandSpeedMaintain";
            this.btnCrandSpeedMaintain.Size = new System.Drawing.Size(169, 58);
            this.btnCrandSpeedMaintain.TabIndex = 6;
            this.btnCrandSpeedMaintain.Text = "Stocker Speed Maintain";
            this.btnCrandSpeedMaintain.UseVisualStyleBackColor = true;
            // 
            // btnCmdMaintain
            // 
            this.btnCmdMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCmdMaintain.Location = new System.Drawing.Point(4, 70);
            this.btnCmdMaintain.Margin = new System.Windows.Forms.Padding(4);
            this.btnCmdMaintain.Name = "btnCmdMaintain";
            this.btnCmdMaintain.Size = new System.Drawing.Size(169, 58);
            this.btnCmdMaintain.TabIndex = 4;
            this.btnCmdMaintain.Text = "Command Maintain";
            this.btnCmdMaintain.UseVisualStyleBackColor = true;
            // 
            // btnStockerModeMaintain
            // 
            this.btnStockerModeMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStockerModeMaintain.Location = new System.Drawing.Point(4, 4);
            this.btnStockerModeMaintain.Margin = new System.Windows.Forms.Padding(4);
            this.btnStockerModeMaintain.Name = "btnStockerModeMaintain";
            this.btnStockerModeMaintain.Size = new System.Drawing.Size(169, 58);
            this.btnStockerModeMaintain.TabIndex = 0;
            this.btnStockerModeMaintain.Text = "Stocker Mode Maintain";
            this.btnStockerModeMaintain.UseVisualStyleBackColor = true;
            // 
            // btnTeachMaintain
            // 
            this.btnTeachMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTeachMaintain.Location = new System.Drawing.Point(4, 136);
            this.btnTeachMaintain.Margin = new System.Windows.Forms.Padding(4);
            this.btnTeachMaintain.Name = "btnTeachMaintain";
            this.btnTeachMaintain.Size = new System.Drawing.Size(169, 58);
            this.btnTeachMaintain.TabIndex = 5;
            this.btnTeachMaintain.Text = "TeachLoc Maintain";
            this.btnTeachMaintain.UseVisualStyleBackColor = true;
            this.btnTeachMaintain.Visible = false;
            // 
            // btnTransferToTeachLoc
            // 
            this.btnTransferToTeachLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTransferToTeachLoc.Location = new System.Drawing.Point(3, 202);
            this.btnTransferToTeachLoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTransferToTeachLoc.Name = "btnTransferToTeachLoc";
            this.btnTransferToTeachLoc.Size = new System.Drawing.Size(171, 58);
            this.btnTransferToTeachLoc.TabIndex = 8;
            this.btnTransferToTeachLoc.Text = "Transfer To TeachLoc";
            this.btnTransferToTeachLoc.UseVisualStyleBackColor = true;
            // 
            // chkCycleRun
            // 
            this.chkCycleRun.AutoSize = true;
            this.chkCycleRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCycleRun.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkCycleRun.Location = new System.Drawing.Point(4, 388);
            this.chkCycleRun.Margin = new System.Windows.Forms.Padding(4);
            this.chkCycleRun.Name = "chkCycleRun";
            this.chkCycleRun.Size = new System.Drawing.Size(169, 46);
            this.chkCycleRun.TabIndex = 7;
            this.chkCycleRun.Text = "Cycle Run";
            this.chkCycleRun.UseVisualStyleBackColor = true;
            this.chkCycleRun.Visible = false;
            this.chkCycleRun.CheckedChanged += new System.EventHandler(this.chkCycleRun_CheckedChanged);
            // 
            // btnOEEParameterMaintain
            // 
            this.btnOEEParameterMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOEEParameterMaintain.Location = new System.Drawing.Point(4, 335);
            this.btnOEEParameterMaintain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOEEParameterMaintain.Name = "btnOEEParameterMaintain";
            this.btnOEEParameterMaintain.Size = new System.Drawing.Size(169, 44);
            this.btnOEEParameterMaintain.TabIndex = 9;
            this.btnOEEParameterMaintain.Text = "OEE Parameter";
            this.btnOEEParameterMaintain.UseVisualStyleBackColor = true;
            // 
            // AGVTaskCancelButten
            // 
            this.AGVTaskCancelButten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AGVTaskCancelButten.Location = new System.Drawing.Point(4, 487);
            this.AGVTaskCancelButten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AGVTaskCancelButten.Name = "AGVTaskCancelButten";
            this.AGVTaskCancelButten.Size = new System.Drawing.Size(169, 44);
            this.AGVTaskCancelButten.TabIndex = 11;
            this.AGVTaskCancelButten.Text = "WES API Testing";
            this.AGVTaskCancelButten.UseVisualStyleBackColor = true;
            this.AGVTaskCancelButten.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbcCmdInfo
            // 
            this.tbcCmdInfo.Controls.Add(this.tbpCmdMst);
            this.tbcCmdInfo.Controls.Add(this.tbpMiddleCmd);
            this.tbcCmdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCmdInfo.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbcCmdInfo.Location = new System.Drawing.Point(0, 0);
            this.tbcCmdInfo.Name = "tbcCmdInfo";
            this.tbcCmdInfo.SelectedIndex = 0;
            this.tbcCmdInfo.Size = new System.Drawing.Size(1756, 201);
            this.tbcCmdInfo.TabIndex = 0;
            // 
            // tbpCmdMst
            // 
            this.tbpCmdMst.Controls.Add(this.Grid1);
            this.tbpCmdMst.Location = new System.Drawing.Point(4, 34);
            this.tbpCmdMst.Name = "tbpCmdMst";
            this.tbpCmdMst.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCmdMst.Size = new System.Drawing.Size(1748, 163);
            this.tbpCmdMst.TabIndex = 0;
            this.tbpCmdMst.Text = "System Command";
            this.tbpCmdMst.UseVisualStyleBackColor = true;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(3, 3);
            this.Grid1.Margin = new System.Windows.Forms.Padding(4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 62;
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(1742, 157);
            this.Grid1.TabIndex = 1;
            // 
            // tbpMiddleCmd
            // 
            this.tbpMiddleCmd.Controls.Add(this.Grid_MiddleCmd);
            this.tbpMiddleCmd.Location = new System.Drawing.Point(4, 34);
            this.tbpMiddleCmd.Name = "tbpMiddleCmd";
            this.tbpMiddleCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMiddleCmd.Size = new System.Drawing.Size(1748, 163);
            this.tbpMiddleCmd.TabIndex = 1;
            this.tbpMiddleCmd.Text = "Middle Command";
            this.tbpMiddleCmd.UseVisualStyleBackColor = true;
            // 
            // Grid_MiddleCmd
            // 
            this.Grid_MiddleCmd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_MiddleCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_MiddleCmd.Location = new System.Drawing.Point(3, 3);
            this.Grid_MiddleCmd.Margin = new System.Windows.Forms.Padding(4);
            this.Grid_MiddleCmd.Name = "Grid_MiddleCmd";
            this.Grid_MiddleCmd.RowHeadersWidth = 62;
            this.Grid_MiddleCmd.RowTemplate.Height = 24;
            this.Grid_MiddleCmd.Size = new System.Drawing.Size(1742, 157);
            this.Grid_MiddleCmd.TabIndex = 2;
            // 
            // mnuTransferCmd
            // 
            this.mnuTransferCmd.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuTransferCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransferCmdComplete,
            this.mnuTransferCmdCancel,
            this.mnuInsertCmd,
            this.mnuUpdateCurLoc});
            this.mnuTransferCmd.Name = "mnuFun";
            this.mnuTransferCmd.Size = new System.Drawing.Size(215, 132);
            // 
            // mnuTransferCmdComplete
            // 
            this.mnuTransferCmdComplete.Name = "mnuTransferCmdComplete";
            this.mnuTransferCmdComplete.Size = new System.Drawing.Size(214, 32);
            this.mnuTransferCmdComplete.Text = "Complete";
            this.mnuTransferCmdComplete.Click += new System.EventHandler(this.mnuTransferCmdComplete_Click);
            // 
            // mnuTransferCmdCancel
            // 
            this.mnuTransferCmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("mnuTransferCmdCancel.Image")));
            this.mnuTransferCmdCancel.Name = "mnuTransferCmdCancel";
            this.mnuTransferCmdCancel.Size = new System.Drawing.Size(214, 32);
            this.mnuTransferCmdCancel.Text = "Cancel";
            this.mnuTransferCmdCancel.Click += new System.EventHandler(this.mnuTransferCmdCancel_Click);
            // 
            // mnuInsertCmd
            // 
            this.mnuInsertCmd.Name = "mnuInsertCmd";
            this.mnuInsertCmd.Size = new System.Drawing.Size(214, 32);
            this.mnuInsertCmd.Text = "Insert";
            this.mnuInsertCmd.Click += new System.EventHandler(this.mnuInsertCmd_Click);
            // 
            // mnuUpdateCurLoc
            // 
            this.mnuUpdateCurLoc.Name = "mnuUpdateCurLoc";
            this.mnuUpdateCurLoc.Size = new System.Drawing.Size(214, 32);
            this.mnuUpdateCurLoc.Text = "Update CurLoc";
            this.mnuUpdateCurLoc.Click += new System.EventHandler(this.mnuUpdateCurLoc_Click);
            // 
            // mnuMiddleCmd
            // 
            this.mnuMiddleCmd.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMiddleCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMiddleComplete,
            this.mnuMiddleCancel,
            this.mnuInsertMiddleCmd});
            this.mnuMiddleCmd.Name = "mnuFun";
            this.mnuMiddleCmd.Size = new System.Drawing.Size(249, 133);
            // 
            // mnuMiddleComplete
            // 
            this.mnuMiddleComplete.Name = "mnuMiddleComplete";
            this.mnuMiddleComplete.Size = new System.Drawing.Size(248, 32);
            this.mnuMiddleComplete.Text = "Complete";
            this.mnuMiddleComplete.Click += new System.EventHandler(this.mnuMiddleComplete_Click);
            // 
            // mnuMiddleCancel
            // 
            this.mnuMiddleCancel.Image = ((System.Drawing.Image)(resources.GetObject("mnuMiddleCancel.Image")));
            this.mnuMiddleCancel.Name = "mnuMiddleCancel";
            this.mnuMiddleCancel.Size = new System.Drawing.Size(248, 32);
            this.mnuMiddleCancel.Text = "Cancel";
            this.mnuMiddleCancel.Click += new System.EventHandler(this.mnuMiddleCancel_Click);
            // 
            // mnuInsertMiddleCmd
            // 
            this.mnuInsertMiddleCmd.Name = "mnuInsertMiddleCmd";
            this.mnuInsertMiddleCmd.Size = new System.Drawing.Size(248, 32);
            this.mnuInsertMiddleCmd.Text = "Insert";
            this.mnuInsertMiddleCmd.Click += new System.EventHandler(this.mnuInsertMiddleCmd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1756, 898);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpMainSts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMirle)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.spcView.Panel1.ResumeLayout(false);
            this.spcView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcView)).EndInit();
            this.spcView.ResumeLayout(false);
            this.spcMainView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMainView)).EndInit();
            this.spcMainView.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbcCmdInfo.ResumeLayout(false);
            this.tbpCmdMst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.tbpMiddleCmd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_MiddleCmd)).EndInit();
            this.mnuTransferCmd.ResumeLayout(false);
            this.mnuMiddleCmd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblDBConn_WCS;
        private System.Windows.Forms.SplitContainer spcView;
        private System.Windows.Forms.CheckBox chkOnline;
        private System.Windows.Forms.SplitContainer spcMainView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStockerModeMaintain;
        private System.Windows.Forms.TableLayoutPanel tlpMainSts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox picMirle;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnCmdMaintain;
        private System.Windows.Forms.Button btnTeachMaintain;
        private System.Windows.Forms.Button btnCrandSpeedMaintain;
        private System.Windows.Forms.CheckBox chkCycleRun;
        private System.Windows.Forms.Button btnTransferToTeachLoc;
        private System.Windows.Forms.Button btnOEEParameterMaintain;
        private System.Windows.Forms.CheckBox chkIgnoreTkt;
        private System.Windows.Forms.Label lblDBConn_WMS;
        private System.Windows.Forms.Button AGVTaskCancelButten;
        private System.Windows.Forms.TabControl tbcCmdInfo;
        private System.Windows.Forms.TabPage tbpCmdMst;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TabPage tbpMiddleCmd;
        private System.Windows.Forms.ContextMenuStrip mnuTransferCmd;
        private System.Windows.Forms.ToolStripMenuItem mnuTransferCmdComplete;
        private System.Windows.Forms.ToolStripMenuItem mnuTransferCmdCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertCmd;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateCurLoc;
        private System.Windows.Forms.ContextMenuStrip mnuMiddleCmd;
        private System.Windows.Forms.ToolStripMenuItem mnuMiddleComplete;
        private System.Windows.Forms.ToolStripMenuItem mnuMiddleCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertMiddleCmd;
        private System.Windows.Forms.DataGridView Grid_MiddleCmd;
    }
}

