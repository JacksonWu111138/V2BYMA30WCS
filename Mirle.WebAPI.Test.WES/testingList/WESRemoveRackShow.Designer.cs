namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESRemoveRackShow
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
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_carrierId = new System.Windows.Forms.Label();
            this.textBox_carrierId = new System.Windows.Forms.TextBox();
            this.button_RemoveRackShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(58, 57);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(117, 54);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(38, 92);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "location";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(117, 89);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(100, 29);
            this.textBox_location.TabIndex = 2;
            // 
            // label_carrierId
            // 
            this.label_carrierId.AutoSize = true;
            this.label_carrierId.Location = new System.Drawing.Point(32, 127);
            this.label_carrierId.Name = "label_carrierId";
            this.label_carrierId.Size = new System.Drawing.Size(69, 18);
            this.label_carrierId.TabIndex = 1;
            this.label_carrierId.Text = "carrierId";
            // 
            // textBox_carrierId
            // 
            this.textBox_carrierId.Location = new System.Drawing.Point(117, 124);
            this.textBox_carrierId.Name = "textBox_carrierId";
            this.textBox_carrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_carrierId.TabIndex = 2;
            // 
            // button_RemoveRackShow
            // 
            this.button_RemoveRackShow.Location = new System.Drawing.Point(260, 52);
            this.button_RemoveRackShow.Name = "button_RemoveRackShow";
            this.button_RemoveRackShow.Size = new System.Drawing.Size(119, 100);
            this.button_RemoveRackShow.TabIndex = 3;
            this.button_RemoveRackShow.Text = "send";
            this.button_RemoveRackShow.UseVisualStyleBackColor = true;
            this.button_RemoveRackShow.Click += new System.EventHandler(this.button_RemoveRackShow_Click);
            // 
            // WESRemoveRackShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 205);
            this.Controls.Add(this.button_RemoveRackShow);
            this.Controls.Add(this.textBox_carrierId);
            this.Controls.Add(this.label_carrierId);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Name = "WESRemoveRackShow";
            this.Text = "RemoveRackShow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_carrierId;
        private System.Windows.Forms.TextBox textBox_carrierId;
        private System.Windows.Forms.Button button_RemoveRackShow;
    }
}