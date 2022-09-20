namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlCVReceiveNewBinCmd
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_bufferId = new System.Windows.Forms.Label();
            this.textBox_bufferId = new System.Windows.Forms.TextBox();
            this.label_carrierType = new System.Windows.Forms.Label();
            this.textBox_carrierType = new System.Windows.Forms.TextBox();
            this.button_CVReceiveNewBinCmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "E800C",
            "SMTC",
            "LIFT4C",
            "LIFT5C",
            "B800C",
            "M800C",
            "OSMTC"});
            this.comboBox1.Location = new System.Drawing.Point(142, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(127, 110);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 2;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(203, 107);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(147, 29);
            this.textBox_jobId.TabIndex = 3;
            // 
            // label_bufferId
            // 
            this.label_bufferId.AutoSize = true;
            this.label_bufferId.Location = new System.Drawing.Point(106, 145);
            this.label_bufferId.Name = "label_bufferId";
            this.label_bufferId.Size = new System.Drawing.Size(64, 18);
            this.label_bufferId.TabIndex = 2;
            this.label_bufferId.Text = "bufferId";
            // 
            // textBox_bufferId
            // 
            this.textBox_bufferId.Location = new System.Drawing.Point(203, 142);
            this.textBox_bufferId.Name = "textBox_bufferId";
            this.textBox_bufferId.Size = new System.Drawing.Size(147, 29);
            this.textBox_bufferId.TabIndex = 3;
            // 
            // label_carrierType
            // 
            this.label_carrierType.AutoSize = true;
            this.label_carrierType.Location = new System.Drawing.Point(81, 180);
            this.label_carrierType.Name = "label_carrierType";
            this.label_carrierType.Size = new System.Drawing.Size(89, 18);
            this.label_carrierType.TabIndex = 2;
            this.label_carrierType.Text = "carrierType";
            // 
            // textBox_carrierType
            // 
            this.textBox_carrierType.Location = new System.Drawing.Point(203, 177);
            this.textBox_carrierType.Name = "textBox_carrierType";
            this.textBox_carrierType.Size = new System.Drawing.Size(147, 29);
            this.textBox_carrierType.TabIndex = 3;
            // 
            // button_CVReceiveNewBinCmd
            // 
            this.button_CVReceiveNewBinCmd.Location = new System.Drawing.Point(378, 62);
            this.button_CVReceiveNewBinCmd.Name = "button_CVReceiveNewBinCmd";
            this.button_CVReceiveNewBinCmd.Size = new System.Drawing.Size(149, 143);
            this.button_CVReceiveNewBinCmd.TabIndex = 4;
            this.button_CVReceiveNewBinCmd.Text = "send";
            this.button_CVReceiveNewBinCmd.UseVisualStyleBackColor = true;
            this.button_CVReceiveNewBinCmd.Click += new System.EventHandler(this.button_CVReceiveNewBinCmd_Click);
            // 
            // CtrlCVReceiveNewBinCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 278);
            this.Controls.Add(this.button_CVReceiveNewBinCmd);
            this.Controls.Add(this.textBox_carrierType);
            this.Controls.Add(this.label_carrierType);
            this.Controls.Add(this.textBox_bufferId);
            this.Controls.Add(this.label_bufferId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.comboBox1);
            this.Name = "CtrlCVReceiveNewBinCmd";
            this.Text = "CVReceiveNewBinCmd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_bufferId;
        private System.Windows.Forms.TextBox textBox_bufferId;
        private System.Windows.Forms.Label label_carrierType;
        private System.Windows.Forms.TextBox textBox_carrierType;
        private System.Windows.Forms.Button button_CVReceiveNewBinCmd;
    }
}