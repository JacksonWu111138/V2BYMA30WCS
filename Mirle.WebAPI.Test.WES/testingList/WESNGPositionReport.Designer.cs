namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESNGPositionReport
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
            this.button_NGPositionReport = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_ngLocation = new System.Windows.Forms.TextBox();
            this.label_ngLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_NGPositionReport
            // 
            this.button_NGPositionReport.Location = new System.Drawing.Point(233, 64);
            this.button_NGPositionReport.Name = "button_NGPositionReport";
            this.button_NGPositionReport.Size = new System.Drawing.Size(102, 75);
            this.button_NGPositionReport.TabIndex = 0;
            this.button_NGPositionReport.Text = "send";
            this.button_NGPositionReport.UseVisualStyleBackColor = true;
            this.button_NGPositionReport.Click += new System.EventHandler(this.button_NGPositionReport_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(41, 47);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(90, 44);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(101, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(90, 89);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(101, 29);
            this.textBox_lotId.TabIndex = 4;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(41, 92);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 3;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_ngLocation
            // 
            this.textBox_ngLocation.Location = new System.Drawing.Point(90, 135);
            this.textBox_ngLocation.Name = "textBox_ngLocation";
            this.textBox_ngLocation.Size = new System.Drawing.Size(101, 29);
            this.textBox_ngLocation.TabIndex = 6;
            // 
            // label_ngLocation
            // 
            this.label_ngLocation.AutoSize = true;
            this.label_ngLocation.Location = new System.Drawing.Point(0, 138);
            this.label_ngLocation.Name = "label_ngLocation";
            this.label_ngLocation.Size = new System.Drawing.Size(84, 18);
            this.label_ngLocation.TabIndex = 5;
            this.label_ngLocation.Text = "ngLocation";
            // 
            // WESNGPositionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 236);
            this.Controls.Add(this.textBox_ngLocation);
            this.Controls.Add(this.label_ngLocation);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_NGPositionReport);
            this.Name = "WESNGPositionReport";
            this.Text = "NGPositionReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_NGPositionReport;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_ngLocation;
        private System.Windows.Forms.Label label_ngLocation;
    }
}