namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESEmptyMagazineLoadRequest
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
            this.button_EmptyMagazineLoadRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_EmptyMagazineLoadRequest
            // 
            this.button_EmptyMagazineLoadRequest.Location = new System.Drawing.Point(281, 68);
            this.button_EmptyMagazineLoadRequest.Name = "button_EmptyMagazineLoadRequest";
            this.button_EmptyMagazineLoadRequest.Size = new System.Drawing.Size(149, 148);
            this.button_EmptyMagazineLoadRequest.TabIndex = 0;
            this.button_EmptyMagazineLoadRequest.Text = "send";
            this.button_EmptyMagazineLoadRequest.UseVisualStyleBackColor = true;
            this.button_EmptyMagazineLoadRequest.Click += new System.EventHandler(this.button_EmptyMagazineLoadRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(58, 90);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(133, 88);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(38, 149);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "location";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(133, 146);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(100, 29);
            this.textBox_location.TabIndex = 2;
            // 
            // WESEmptyMagazineLoadRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 277);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_EmptyMagazineLoadRequest);
            this.Name = "WESEmptyMagazineLoadRequest";
            this.Text = "EmptyMagazineLoadRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EmptyMagazineLoadRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_location;
    }
}