namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlLotTransferCancel
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
            this.button_LotTransferCancel = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotTransferCancel
            // 
            this.button_LotTransferCancel.Location = new System.Drawing.Point(304, 53);
            this.button_LotTransferCancel.Name = "button_LotTransferCancel";
            this.button_LotTransferCancel.Size = new System.Drawing.Size(117, 103);
            this.button_LotTransferCancel.TabIndex = 0;
            this.button_LotTransferCancel.Text = "send";
            this.button_LotTransferCancel.UseVisualStyleBackColor = true;
            this.button_LotTransferCancel.Click += new System.EventHandler(this.button_LotTransferCancel_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(46, 67);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(130, 64);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(151, 29);
            this.textBox_jobId.TabIndex = 2;
            this.textBox_jobId.TextChanged += new System.EventHandler(this.textBox_jobId_TextChanged);
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(49, 115);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            this.label_lotId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(130, 112);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(151, 29);
            this.textBox_lotId.TabIndex = 2;
            this.textBox_lotId.TextChanged += new System.EventHandler(this.textBox_jobId_TextChanged);
            // 
            // CtrlLotTransferCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 211);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotTransferCancel);
            this.Name = "CtrlLotTransferCancel";
            this.Text = "LotTransferCancel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotTransferCancel;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
    }
}