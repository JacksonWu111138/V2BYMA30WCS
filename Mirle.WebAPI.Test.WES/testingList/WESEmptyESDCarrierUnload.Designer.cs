namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESEmptyESDCarrierUnload
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
            this.button_EmptyESDCarrierUnload = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_carrierId = new System.Windows.Forms.Label();
            this.textBox_carrierId = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_EmptyESDCarrierUnload
            // 
            this.button_EmptyESDCarrierUnload.Location = new System.Drawing.Point(320, 66);
            this.button_EmptyESDCarrierUnload.Name = "button_EmptyESDCarrierUnload";
            this.button_EmptyESDCarrierUnload.Size = new System.Drawing.Size(141, 127);
            this.button_EmptyESDCarrierUnload.TabIndex = 0;
            this.button_EmptyESDCarrierUnload.Text = "send";
            this.button_EmptyESDCarrierUnload.UseVisualStyleBackColor = true;
            this.button_EmptyESDCarrierUnload.Click += new System.EventHandler(this.button_EmptyESDCarrierUnload_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(119, 85);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(194, 82);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_carrierId
            // 
            this.label_carrierId.AutoSize = true;
            this.label_carrierId.Location = new System.Drawing.Point(93, 120);
            this.label_carrierId.Name = "label_carrierId";
            this.label_carrierId.Size = new System.Drawing.Size(69, 18);
            this.label_carrierId.TabIndex = 1;
            this.label_carrierId.Text = "carrierId";
            // 
            // textBox_carrierId
            // 
            this.textBox_carrierId.Location = new System.Drawing.Point(194, 117);
            this.textBox_carrierId.Name = "textBox_carrierId";
            this.textBox_carrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_carrierId.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(93, 155);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "location";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(194, 152);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(100, 29);
            this.textBox_location.TabIndex = 2;
            // 
            // WESEmptyESDCarrierUnload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 250);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_carrierId);
            this.Controls.Add(this.label_carrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_EmptyESDCarrierUnload);
            this.Name = "WESEmptyESDCarrierUnload";
            this.Text = "EmptyESDCarrierUnload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EmptyESDCarrierUnload;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_carrierId;
        private System.Windows.Forms.TextBox textBox_carrierId;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_location;
    }
}