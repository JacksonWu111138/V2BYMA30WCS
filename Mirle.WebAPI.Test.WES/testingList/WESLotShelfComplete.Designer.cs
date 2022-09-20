namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotShelfComplete
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
            this.button_LotShelfComplete = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_shelfId = new System.Windows.Forms.Label();
            this.textBox_shelfId = new System.Windows.Forms.TextBox();
            this.label_emptyTransfer = new System.Windows.Forms.Label();
            this.textBox_emptyTransfer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotShelfComplete
            // 
            this.button_LotShelfComplete.Location = new System.Drawing.Point(299, 83);
            this.button_LotShelfComplete.Name = "button_LotShelfComplete";
            this.button_LotShelfComplete.Size = new System.Drawing.Size(128, 109);
            this.button_LotShelfComplete.TabIndex = 0;
            this.button_LotShelfComplete.Text = "send";
            this.button_LotShelfComplete.UseVisualStyleBackColor = true;
            this.button_LotShelfComplete.Click += new System.EventHandler(this.button_LotShelfComplete_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(116, 76);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(181, 73);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(119, 111);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(181, 108);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 2;
            // 
            // label_shelfId
            // 
            this.label_shelfId.AutoSize = true;
            this.label_shelfId.Location = new System.Drawing.Point(103, 146);
            this.label_shelfId.Name = "label_shelfId";
            this.label_shelfId.Size = new System.Drawing.Size(56, 18);
            this.label_shelfId.TabIndex = 1;
            this.label_shelfId.Text = "shelfId";
            // 
            // textBox_shelfId
            // 
            this.textBox_shelfId.Location = new System.Drawing.Point(181, 143);
            this.textBox_shelfId.Name = "textBox_shelfId";
            this.textBox_shelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_shelfId.TabIndex = 2;
            // 
            // label_emptyTransfer
            // 
            this.label_emptyTransfer.AutoSize = true;
            this.label_emptyTransfer.Location = new System.Drawing.Point(50, 181);
            this.label_emptyTransfer.Name = "label_emptyTransfer";
            this.label_emptyTransfer.Size = new System.Drawing.Size(109, 18);
            this.label_emptyTransfer.TabIndex = 1;
            this.label_emptyTransfer.Text = "emptyTransfer";
            // 
            // textBox_emptyTransfer
            // 
            this.textBox_emptyTransfer.Location = new System.Drawing.Point(181, 178);
            this.textBox_emptyTransfer.Name = "textBox_emptyTransfer";
            this.textBox_emptyTransfer.Size = new System.Drawing.Size(100, 29);
            this.textBox_emptyTransfer.TabIndex = 2;
            // 
            // WESLotShelfComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 255);
            this.Controls.Add(this.textBox_emptyTransfer);
            this.Controls.Add(this.label_emptyTransfer);
            this.Controls.Add(this.textBox_shelfId);
            this.Controls.Add(this.label_shelfId);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotShelfComplete);
            this.Name = "WESLotShelfComplete";
            this.Text = "LotShelfComplete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotShelfComplete;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_shelfId;
        private System.Windows.Forms.TextBox textBox_shelfId;
        private System.Windows.Forms.Label label_emptyTransfer;
        private System.Windows.Forms.TextBox textBox_emptyTransfer;
    }
}