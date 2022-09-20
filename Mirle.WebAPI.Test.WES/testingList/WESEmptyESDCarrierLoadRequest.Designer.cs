namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESEmptyESDCarrierLoadRequest
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
            this.button_EmptyESDCarrierLoadRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_reqQty = new System.Windows.Forms.Label();
            this.textBox_reqQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_EmptyESDCarrierLoadRequest
            // 
            this.button_EmptyESDCarrierLoadRequest.Location = new System.Drawing.Point(257, 64);
            this.button_EmptyESDCarrierLoadRequest.Name = "button_EmptyESDCarrierLoadRequest";
            this.button_EmptyESDCarrierLoadRequest.Size = new System.Drawing.Size(124, 106);
            this.button_EmptyESDCarrierLoadRequest.TabIndex = 0;
            this.button_EmptyESDCarrierLoadRequest.Text = "send";
            this.button_EmptyESDCarrierLoadRequest.UseVisualStyleBackColor = true;
            this.button_EmptyESDCarrierLoadRequest.Click += new System.EventHandler(this.button_EmptyESDCarrierLoadRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(72, 78);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(144, 75);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(52, 113);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "location";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(144, 110);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(100, 29);
            this.textBox_location.TabIndex = 2;
            // 
            // label_reqQty
            // 
            this.label_reqQty.AutoSize = true;
            this.label_reqQty.Location = new System.Drawing.Point(60, 144);
            this.label_reqQty.Name = "label_reqQty";
            this.label_reqQty.Size = new System.Drawing.Size(55, 18);
            this.label_reqQty.TabIndex = 1;
            this.label_reqQty.Text = "reqQty";
            // 
            // textBox_reqQty
            // 
            this.textBox_reqQty.Location = new System.Drawing.Point(144, 141);
            this.textBox_reqQty.Name = "textBox_reqQty";
            this.textBox_reqQty.Size = new System.Drawing.Size(100, 29);
            this.textBox_reqQty.TabIndex = 2;
            // 
            // WESEmptyESDCarrierLoadRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 224);
            this.Controls.Add(this.textBox_reqQty);
            this.Controls.Add(this.label_reqQty);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_EmptyESDCarrierLoadRequest);
            this.Name = "WESEmptyESDCarrierLoadRequest";
            this.Text = "EmptyESDCarrierLoadRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EmptyESDCarrierLoadRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_reqQty;
        private System.Windows.Forms.TextBox textBox_reqQty;
    }
}