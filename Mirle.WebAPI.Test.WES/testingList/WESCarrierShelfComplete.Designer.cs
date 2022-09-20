namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESCarrierShelfComplete
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
            this.button_CarrierShelfComplete = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_carrierId = new System.Windows.Forms.Label();
            this.textBox_carrierId = new System.Windows.Forms.TextBox();
            this.label_shelfId = new System.Windows.Forms.Label();
            this.textBox_shelfId = new System.Windows.Forms.TextBox();
            this.label_emptyTransfer = new System.Windows.Forms.Label();
            this.textBox_emptyTransfer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_CarrierShelfComplete
            // 
            this.button_CarrierShelfComplete.Location = new System.Drawing.Point(246, 76);
            this.button_CarrierShelfComplete.Name = "button_CarrierShelfComplete";
            this.button_CarrierShelfComplete.Size = new System.Drawing.Size(138, 103);
            this.button_CarrierShelfComplete.TabIndex = 0;
            this.button_CarrierShelfComplete.Text = "send";
            this.button_CarrierShelfComplete.UseVisualStyleBackColor = true;
            this.button_CarrierShelfComplete.Click += new System.EventHandler(this.button_CarrierShelfComplete_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(91, 57);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(140, 54);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_carrierId
            // 
            this.label_carrierId.AutoSize = true;
            this.label_carrierId.Location = new System.Drawing.Point(65, 91);
            this.label_carrierId.Name = "label_carrierId";
            this.label_carrierId.Size = new System.Drawing.Size(69, 18);
            this.label_carrierId.TabIndex = 1;
            this.label_carrierId.Text = "carrierId";
            this.label_carrierId.Click += new System.EventHandler(this.label_carrierId_Click);
            // 
            // textBox_carrierId
            // 
            this.textBox_carrierId.Location = new System.Drawing.Point(140, 89);
            this.textBox_carrierId.Name = "textBox_carrierId";
            this.textBox_carrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_carrierId.TabIndex = 2;
            // 
            // label_shelfId
            // 
            this.label_shelfId.AutoSize = true;
            this.label_shelfId.Location = new System.Drawing.Point(78, 126);
            this.label_shelfId.Name = "label_shelfId";
            this.label_shelfId.Size = new System.Drawing.Size(56, 18);
            this.label_shelfId.TabIndex = 1;
            this.label_shelfId.Text = "shelfId";
            this.label_shelfId.Click += new System.EventHandler(this.label_carrierId_Click);
            // 
            // textBox_shelfId
            // 
            this.textBox_shelfId.Location = new System.Drawing.Point(140, 123);
            this.textBox_shelfId.Name = "textBox_shelfId";
            this.textBox_shelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_shelfId.TabIndex = 2;
            // 
            // label_emptyTransfer
            // 
            this.label_emptyTransfer.AutoSize = true;
            this.label_emptyTransfer.Location = new System.Drawing.Point(25, 161);
            this.label_emptyTransfer.Name = "label_emptyTransfer";
            this.label_emptyTransfer.Size = new System.Drawing.Size(109, 18);
            this.label_emptyTransfer.TabIndex = 1;
            this.label_emptyTransfer.Text = "emptyTransfer";
            this.label_emptyTransfer.Click += new System.EventHandler(this.label_carrierId_Click);
            // 
            // textBox_emptyTransfer
            // 
            this.textBox_emptyTransfer.Location = new System.Drawing.Point(140, 158);
            this.textBox_emptyTransfer.Name = "textBox_emptyTransfer";
            this.textBox_emptyTransfer.Size = new System.Drawing.Size(100, 29);
            this.textBox_emptyTransfer.TabIndex = 2;
            // 
            // WESCarrierShelfComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 227);
            this.Controls.Add(this.textBox_emptyTransfer);
            this.Controls.Add(this.label_emptyTransfer);
            this.Controls.Add(this.textBox_shelfId);
            this.Controls.Add(this.label_shelfId);
            this.Controls.Add(this.textBox_carrierId);
            this.Controls.Add(this.label_carrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_CarrierShelfComplete);
            this.Name = "WESCarrierShelfComplete";
            this.Text = "CarrierShelfComplete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CarrierShelfComplete;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_carrierId;
        private System.Windows.Forms.TextBox textBox_carrierId;
        private System.Windows.Forms.Label label_shelfId;
        private System.Windows.Forms.TextBox textBox_shelfId;
        private System.Windows.Forms.Label label_emptyTransfer;
        private System.Windows.Forms.TextBox textBox_emptyTransfer;
    }
}