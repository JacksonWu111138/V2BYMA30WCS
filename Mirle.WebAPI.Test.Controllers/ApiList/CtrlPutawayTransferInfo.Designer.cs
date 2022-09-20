namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlPutawayTransferInfo
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
            this.button_PutawayTransferInfo = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_reelId = new System.Windows.Forms.Label();
            this.textBox_reelId = new System.Windows.Forms.TextBox();
            this.label_lotSize = new System.Windows.Forms.Label();
            this.textBox_lotSize = new System.Windows.Forms.TextBox();
            this.label_toShelfId = new System.Windows.Forms.Label();
            this.textBox_toShelfId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_PutawayTransferInfo
            // 
            this.button_PutawayTransferInfo.Location = new System.Drawing.Point(305, 66);
            this.button_PutawayTransferInfo.Name = "button_PutawayTransferInfo";
            this.button_PutawayTransferInfo.Size = new System.Drawing.Size(129, 120);
            this.button_PutawayTransferInfo.TabIndex = 0;
            this.button_PutawayTransferInfo.Text = "send";
            this.button_PutawayTransferInfo.UseVisualStyleBackColor = true;
            this.button_PutawayTransferInfo.Click += new System.EventHandler(this.button_PutawayTransferInfo_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(54, 65);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(133, 62);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(140, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_reelId
            // 
            this.label_reelId.AutoSize = true;
            this.label_reelId.Location = new System.Drawing.Point(48, 100);
            this.label_reelId.Name = "label_reelId";
            this.label_reelId.Size = new System.Drawing.Size(49, 18);
            this.label_reelId.TabIndex = 1;
            this.label_reelId.Text = "reelId";
            // 
            // textBox_reelId
            // 
            this.textBox_reelId.Location = new System.Drawing.Point(133, 97);
            this.textBox_reelId.Name = "textBox_reelId";
            this.textBox_reelId.Size = new System.Drawing.Size(140, 29);
            this.textBox_reelId.TabIndex = 2;
            // 
            // label_lotSize
            // 
            this.label_lotSize.AutoSize = true;
            this.label_lotSize.Location = new System.Drawing.Point(41, 135);
            this.label_lotSize.Name = "label_lotSize";
            this.label_lotSize.Size = new System.Drawing.Size(56, 18);
            this.label_lotSize.TabIndex = 1;
            this.label_lotSize.Text = "lotSize";
            // 
            // textBox_lotSize
            // 
            this.textBox_lotSize.Location = new System.Drawing.Point(133, 132);
            this.textBox_lotSize.Name = "textBox_lotSize";
            this.textBox_lotSize.Size = new System.Drawing.Size(140, 29);
            this.textBox_lotSize.TabIndex = 2;
            // 
            // label_toShelfId
            // 
            this.label_toShelfId.AutoSize = true;
            this.label_toShelfId.Location = new System.Drawing.Point(26, 170);
            this.label_toShelfId.Name = "label_toShelfId";
            this.label_toShelfId.Size = new System.Drawing.Size(71, 18);
            this.label_toShelfId.TabIndex = 1;
            this.label_toShelfId.Text = "toShelfId";
            // 
            // textBox_toShelfId
            // 
            this.textBox_toShelfId.Location = new System.Drawing.Point(133, 167);
            this.textBox_toShelfId.Name = "textBox_toShelfId";
            this.textBox_toShelfId.Size = new System.Drawing.Size(140, 29);
            this.textBox_toShelfId.TabIndex = 2;
            // 
            // CtrlPutawayTransferInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 259);
            this.Controls.Add(this.textBox_toShelfId);
            this.Controls.Add(this.label_toShelfId);
            this.Controls.Add(this.textBox_lotSize);
            this.Controls.Add(this.label_lotSize);
            this.Controls.Add(this.textBox_reelId);
            this.Controls.Add(this.label_reelId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_PutawayTransferInfo);
            this.Name = "CtrlPutawayTransferInfo";
            this.Text = "PutawayTransferInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_PutawayTransferInfo;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_reelId;
        private System.Windows.Forms.TextBox textBox_reelId;
        private System.Windows.Forms.Label label_lotSize;
        private System.Windows.Forms.TextBox textBox_lotSize;
        private System.Windows.Forms.Label label_toShelfId;
        private System.Windows.Forms.TextBox textBox_toShelfId;
    }
}