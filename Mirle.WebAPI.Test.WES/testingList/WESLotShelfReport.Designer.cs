namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotShelfReport
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
            this.button_LotShelfReport = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_shelfId = new System.Windows.Forms.Label();
            this.textBox_shelfId = new System.Windows.Forms.TextBox();
            this.label_shelfStatus = new System.Windows.Forms.Label();
            this.textBox_shelfStatus = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_disableLocation = new System.Windows.Forms.Label();
            this.textBox_disableLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotShelfReport
            // 
            this.button_LotShelfReport.Location = new System.Drawing.Point(256, 92);
            this.button_LotShelfReport.Name = "button_LotShelfReport";
            this.button_LotShelfReport.Size = new System.Drawing.Size(121, 74);
            this.button_LotShelfReport.TabIndex = 0;
            this.button_LotShelfReport.Text = "send";
            this.button_LotShelfReport.UseVisualStyleBackColor = true;
            this.button_LotShelfReport.Click += new System.EventHandler(this.button_LotShelfReport_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(81, 45);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(139, 42);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_shelfId
            // 
            this.label_shelfId.AutoSize = true;
            this.label_shelfId.Location = new System.Drawing.Point(68, 85);
            this.label_shelfId.Name = "label_shelfId";
            this.label_shelfId.Size = new System.Drawing.Size(56, 18);
            this.label_shelfId.TabIndex = 1;
            this.label_shelfId.Text = "shelfId";
            // 
            // textBox_shelfId
            // 
            this.textBox_shelfId.Location = new System.Drawing.Point(139, 82);
            this.textBox_shelfId.Name = "textBox_shelfId";
            this.textBox_shelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_shelfId.TabIndex = 2;
            // 
            // label_shelfStatus
            // 
            this.label_shelfStatus.AutoSize = true;
            this.label_shelfStatus.Location = new System.Drawing.Point(40, 120);
            this.label_shelfStatus.Name = "label_shelfStatus";
            this.label_shelfStatus.Size = new System.Drawing.Size(84, 18);
            this.label_shelfStatus.TabIndex = 1;
            this.label_shelfStatus.Text = "shelfStatus";
            // 
            // textBox_shelfStatus
            // 
            this.textBox_shelfStatus.Location = new System.Drawing.Point(139, 117);
            this.textBox_shelfStatus.Name = "textBox_shelfStatus";
            this.textBox_shelfStatus.Size = new System.Drawing.Size(100, 29);
            this.textBox_shelfStatus.TabIndex = 2;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(81, 155);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(139, 152);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 2;
            // 
            // label_disableLocation
            // 
            this.label_disableLocation.AutoSize = true;
            this.label_disableLocation.Location = new System.Drawing.Point(16, 190);
            this.label_disableLocation.Name = "label_disableLocation";
            this.label_disableLocation.Size = new System.Drawing.Size(117, 18);
            this.label_disableLocation.TabIndex = 1;
            this.label_disableLocation.Text = "disableLocation";
            // 
            // textBox_disableLocation
            // 
            this.textBox_disableLocation.Location = new System.Drawing.Point(139, 187);
            this.textBox_disableLocation.Name = "textBox_disableLocation";
            this.textBox_disableLocation.Size = new System.Drawing.Size(100, 29);
            this.textBox_disableLocation.TabIndex = 2;
            // 
            // WESLotShelfReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 290);
            this.Controls.Add(this.textBox_disableLocation);
            this.Controls.Add(this.label_disableLocation);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_shelfStatus);
            this.Controls.Add(this.label_shelfStatus);
            this.Controls.Add(this.textBox_shelfId);
            this.Controls.Add(this.label_shelfId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotShelfReport);
            this.Name = "WESLotShelfReport";
            this.Text = "LotShelfReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotShelfReport;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_shelfId;
        private System.Windows.Forms.TextBox textBox_shelfId;
        private System.Windows.Forms.Label label_shelfStatus;
        private System.Windows.Forms.TextBox textBox_shelfStatus;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_disableLocation;
        private System.Windows.Forms.TextBox textBox_disableLocation;
    }
}