namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESCarrierShelfRequest
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
            this.button_CarrierShelfRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_fromShelfId = new System.Windows.Forms.Label();
            this.textBox_fromShelfId = new System.Windows.Forms.TextBox();
            this.label_toShelfId = new System.Windows.Forms.Label();
            this.textBox_toShelfId = new System.Windows.Forms.TextBox();
            this.label_disableLocation = new System.Windows.Forms.Label();
            this.textBox_disableLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_CarrierShelfRequest
            // 
            this.button_CarrierShelfRequest.Location = new System.Drawing.Point(305, 47);
            this.button_CarrierShelfRequest.Name = "button_CarrierShelfRequest";
            this.button_CarrierShelfRequest.Size = new System.Drawing.Size(149, 105);
            this.button_CarrierShelfRequest.TabIndex = 0;
            this.button_CarrierShelfRequest.Text = "send";
            this.button_CarrierShelfRequest.UseVisualStyleBackColor = true;
            this.button_CarrierShelfRequest.Click += new System.EventHandler(this.button_CarrierShelfRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(104, 50);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(162, 47);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_fromShelfId
            // 
            this.label_fromShelfId.AutoSize = true;
            this.label_fromShelfId.Location = new System.Drawing.Point(56, 90);
            this.label_fromShelfId.Name = "label_fromShelfId";
            this.label_fromShelfId.Size = new System.Drawing.Size(91, 18);
            this.label_fromShelfId.TabIndex = 1;
            this.label_fromShelfId.Text = "fromShelfId";
            // 
            // textBox_fromShelfId
            // 
            this.textBox_fromShelfId.Location = new System.Drawing.Point(162, 87);
            this.textBox_fromShelfId.Name = "textBox_fromShelfId";
            this.textBox_fromShelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_fromShelfId.TabIndex = 2;
            // 
            // label_toShelfId
            // 
            this.label_toShelfId.AutoSize = true;
            this.label_toShelfId.Location = new System.Drawing.Point(76, 123);
            this.label_toShelfId.Name = "label_toShelfId";
            this.label_toShelfId.Size = new System.Drawing.Size(71, 18);
            this.label_toShelfId.TabIndex = 1;
            this.label_toShelfId.Text = "toShelfId";
            // 
            // textBox_toShelfId
            // 
            this.textBox_toShelfId.Location = new System.Drawing.Point(162, 123);
            this.textBox_toShelfId.Name = "textBox_toShelfId";
            this.textBox_toShelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_toShelfId.TabIndex = 2;
            // 
            // label_disableLocation
            // 
            this.label_disableLocation.AutoSize = true;
            this.label_disableLocation.Location = new System.Drawing.Point(30, 158);
            this.label_disableLocation.Name = "label_disableLocation";
            this.label_disableLocation.Size = new System.Drawing.Size(117, 18);
            this.label_disableLocation.TabIndex = 1;
            this.label_disableLocation.Text = "disableLocation";
            // 
            // textBox_disableLocation
            // 
            this.textBox_disableLocation.Location = new System.Drawing.Point(162, 158);
            this.textBox_disableLocation.Name = "textBox_disableLocation";
            this.textBox_disableLocation.Size = new System.Drawing.Size(100, 29);
            this.textBox_disableLocation.TabIndex = 2;
            // 
            // WESCarrierShelfRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 243);
            this.Controls.Add(this.textBox_disableLocation);
            this.Controls.Add(this.label_disableLocation);
            this.Controls.Add(this.textBox_toShelfId);
            this.Controls.Add(this.label_toShelfId);
            this.Controls.Add(this.textBox_fromShelfId);
            this.Controls.Add(this.label_fromShelfId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_CarrierShelfRequest);
            this.Name = "WESCarrierShelfRequest";
            this.Text = "CarrierShelfRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CarrierShelfRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_fromShelfId;
        private System.Windows.Forms.TextBox textBox_fromShelfId;
        private System.Windows.Forms.Label label_toShelfId;
        private System.Windows.Forms.TextBox textBox_toShelfId;
        private System.Windows.Forms.Label label_disableLocation;
        private System.Windows.Forms.TextBox textBox_disableLocation;
    }
}