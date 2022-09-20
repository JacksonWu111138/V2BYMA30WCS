namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotRenewRequest
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
            this.button_LotRenewRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_qty = new System.Windows.Forms.Label();
            this.textBox_qty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotRenewRequest
            // 
            this.button_LotRenewRequest.Location = new System.Drawing.Point(263, 68);
            this.button_LotRenewRequest.Name = "button_LotRenewRequest";
            this.button_LotRenewRequest.Size = new System.Drawing.Size(119, 109);
            this.button_LotRenewRequest.TabIndex = 0;
            this.button_LotRenewRequest.Text = "send";
            this.button_LotRenewRequest.UseVisualStyleBackColor = true;
            this.button_LotRenewRequest.Click += new System.EventHandler(this.button_LotRenewRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(47, 76);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(118, 75);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(47, 122);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(118, 119);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 2;
            // 
            // label_qty
            // 
            this.label_qty.AutoSize = true;
            this.label_qty.Location = new System.Drawing.Point(61, 159);
            this.label_qty.Name = "label_qty";
            this.label_qty.Size = new System.Drawing.Size(29, 18);
            this.label_qty.TabIndex = 1;
            this.label_qty.Text = "qty";
            // 
            // textBox_qty
            // 
            this.textBox_qty.Location = new System.Drawing.Point(118, 154);
            this.textBox_qty.Name = "textBox_qty";
            this.textBox_qty.Size = new System.Drawing.Size(100, 29);
            this.textBox_qty.TabIndex = 2;
            // 
            // WESLotRenewRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 231);
            this.Controls.Add(this.textBox_qty);
            this.Controls.Add(this.label_qty);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotRenewRequest);
            this.Name = "WESLotRenewRequest";
            this.Text = "LotRenewRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotRenewRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_qty;
        private System.Windows.Forms.TextBox textBox_qty;
    }
}