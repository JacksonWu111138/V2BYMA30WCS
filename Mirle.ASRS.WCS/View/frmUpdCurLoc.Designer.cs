
namespace Mirle.ASRS.WCS.View
{
    partial class frmUpdCurLoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdCurLoc));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.butSave = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.txtCurLoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurDeviceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCmdSno = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.butSave, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.butClear, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCurLoc, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCurDeviceID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCmdSno, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 321);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.butSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(315, 258);
            this.butSave.Margin = new System.Windows.Forms.Padding(4);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(99, 59);
            this.butSave.TabIndex = 71;
            this.butSave.Text = "儲存";
            this.butSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butClear
            // 
            this.butClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.butClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butClear.Image = ((System.Drawing.Image)(resources.GetObject("butClear.Image")));
            this.butClear.Location = new System.Drawing.Point(50, 258);
            this.butClear.Margin = new System.Windows.Forms.Padding(4);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(150, 59);
            this.butClear.TabIndex = 70;
            this.butClear.Text = "清除";
            this.butClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butClear.UseVisualStyleBackColor = false;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // txtCurLoc
            // 
            this.txtCurLoc.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCurLoc, 2);
            this.txtCurLoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurLoc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurLoc.Location = new System.Drawing.Point(208, 132);
            this.txtCurLoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurLoc.MaxLength = 5;
            this.txtCurLoc.Name = "txtCurLoc";
            this.txtCurLoc.Size = new System.Drawing.Size(206, 39);
            this.txtCurLoc.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 64);
            this.label2.TabIndex = 60;
            this.label2.Text = "CurLoc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurDeviceID
            // 
            this.txtCurDeviceID.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCurDeviceID, 2);
            this.txtCurDeviceID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurDeviceID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurDeviceID.Location = new System.Drawing.Point(208, 68);
            this.txtCurDeviceID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurDeviceID.MaxLength = 5;
            this.txtCurDeviceID.Name = "txtCurDeviceID";
            this.txtCurDeviceID.Size = new System.Drawing.Size(206, 39);
            this.txtCurDeviceID.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 64);
            this.label1.TabIndex = 58;
            this.label1.Text = "CurDeviceID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCmdSno
            // 
            this.txtCmdSno.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCmdSno, 2);
            this.txtCmdSno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCmdSno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCmdSno.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmdSno.Location = new System.Drawing.Point(208, 4);
            this.txtCmdSno.Margin = new System.Windows.Forms.Padding(4);
            this.txtCmdSno.MaxLength = 5;
            this.txtCmdSno.Name = "txtCmdSno";
            this.txtCmdSno.ReadOnly = true;
            this.txtCmdSno.Size = new System.Drawing.Size(206, 39);
            this.txtCmdSno.TabIndex = 57;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(50, 0);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(105, 64);
            this.Label3.TabIndex = 56;
            this.Label3.Text = "命令序號";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUpdCurLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmUpdCurLoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Current Location";
            this.Load += new System.EventHandler(this.frmUpdCurLoc_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtCmdSno;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCurDeviceID;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtCurLoc;
        internal System.Windows.Forms.Button butClear;
        internal System.Windows.Forms.Button butSave;
    }
}