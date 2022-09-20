namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotPositionReport
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
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.button_LotPositionReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(102, 38);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(158, 35);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(158, 70);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 4;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(102, 73);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 3;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(158, 105);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(100, 29);
            this.textBox_location.TabIndex = 6;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(82, 108);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 5;
            this.label_location.Text = "location";
            // 
            // button_LotPositionReport
            // 
            this.button_LotPositionReport.Location = new System.Drawing.Point(279, 55);
            this.button_LotPositionReport.Name = "button_LotPositionReport";
            this.button_LotPositionReport.Size = new System.Drawing.Size(112, 54);
            this.button_LotPositionReport.TabIndex = 7;
            this.button_LotPositionReport.Text = "send";
            this.button_LotPositionReport.UseVisualStyleBackColor = true;
            this.button_LotPositionReport.Click += new System.EventHandler(this.button_LotPositionReport_Click);
            // 
            // WESLotPositionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 161);
            this.Controls.Add(this.button_LotPositionReport);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Name = "WESLotPositionReport";
            this.Text = "LotPositionReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Button button_LotPositionReport;
    }
}