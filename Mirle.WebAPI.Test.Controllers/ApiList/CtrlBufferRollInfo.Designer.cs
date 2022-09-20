namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlBufferRollInfo
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
            this.button_BufferRollInfo = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_bufferId = new System.Windows.Forms.Label();
            this.textBox_bufferId = new System.Windows.Forms.TextBox();
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
            this.comboBox1.Location = new System.Drawing.Point(178, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // button_BufferRollInfo
            // 
            this.button_BufferRollInfo.Location = new System.Drawing.Point(419, 62);
            this.button_BufferRollInfo.Name = "button_BufferRollInfo";
            this.button_BufferRollInfo.Size = new System.Drawing.Size(159, 147);
            this.button_BufferRollInfo.TabIndex = 1;
            this.button_BufferRollInfo.Text = "send";
            this.button_BufferRollInfo.UseVisualStyleBackColor = true;
            this.button_BufferRollInfo.Click += new System.EventHandler(this.button_BufferRollInfo_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(143, 117);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 2;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(211, 114);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(165, 29);
            this.textBox_jobId.TabIndex = 3;
            // 
            // label_bufferId
            // 
            this.label_bufferId.AutoSize = true;
            this.label_bufferId.Location = new System.Drawing.Point(122, 169);
            this.label_bufferId.Name = "label_bufferId";
            this.label_bufferId.Size = new System.Drawing.Size(64, 18);
            this.label_bufferId.TabIndex = 2;
            this.label_bufferId.Text = "bufferId";
            // 
            // textBox_bufferId
            // 
            this.textBox_bufferId.Location = new System.Drawing.Point(211, 166);
            this.textBox_bufferId.Name = "textBox_bufferId";
            this.textBox_bufferId.Size = new System.Drawing.Size(165, 29);
            this.textBox_bufferId.TabIndex = 3;
            // 
            // CtrlBufferRollInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 266);
            this.Controls.Add(this.textBox_bufferId);
            this.Controls.Add(this.label_bufferId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_BufferRollInfo);
            this.Controls.Add(this.comboBox1);
            this.Name = "CtrlBufferRollInfo";
            this.Text = "BufferRollInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_BufferRollInfo;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_bufferId;
        private System.Windows.Forms.TextBox textBox_bufferId;
    }
}