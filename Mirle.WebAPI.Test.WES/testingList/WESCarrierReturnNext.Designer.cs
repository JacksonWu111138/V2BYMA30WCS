namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESCarrierReturnNext
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
            this.button_CarrierReturnNext = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_carrierId = new System.Windows.Forms.Label();
            this.textBox_carrierId = new System.Windows.Forms.TextBox();
            this.label_fromLocation = new System.Windows.Forms.Label();
            this.textBox_formLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_CarrierReturnNext
            // 
            this.button_CarrierReturnNext.Location = new System.Drawing.Point(253, 100);
            this.button_CarrierReturnNext.Name = "button_CarrierReturnNext";
            this.button_CarrierReturnNext.Size = new System.Drawing.Size(75, 56);
            this.button_CarrierReturnNext.TabIndex = 0;
            this.button_CarrierReturnNext.Text = "send";
            this.button_CarrierReturnNext.UseVisualStyleBackColor = true;
            this.button_CarrierReturnNext.Click += new System.EventHandler(this.button_CarrierReturnNext_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(72, 66);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(121, 66);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_carrierId
            // 
            this.label_carrierId.AutoSize = true;
            this.label_carrierId.Location = new System.Drawing.Point(46, 104);
            this.label_carrierId.Name = "label_carrierId";
            this.label_carrierId.Size = new System.Drawing.Size(69, 18);
            this.label_carrierId.TabIndex = 1;
            this.label_carrierId.Text = "carrierId";
            this.label_carrierId.Click += new System.EventHandler(this.label_carrierId_Click);
            // 
            // textBox_carrierId
            // 
            this.textBox_carrierId.Location = new System.Drawing.Point(121, 101);
            this.textBox_carrierId.Name = "textBox_carrierId";
            this.textBox_carrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_carrierId.TabIndex = 2;
            // 
            // label_fromLocation
            // 
            this.label_fromLocation.AutoSize = true;
            this.label_fromLocation.Location = new System.Drawing.Point(12, 139);
            this.label_fromLocation.Name = "label_fromLocation";
            this.label_fromLocation.Size = new System.Drawing.Size(101, 18);
            this.label_fromLocation.TabIndex = 1;
            this.label_fromLocation.Text = "fromLocation";
            this.label_fromLocation.Click += new System.EventHandler(this.label_carrierId_Click);
            // 
            // textBox_formLocation
            // 
            this.textBox_formLocation.Location = new System.Drawing.Point(121, 136);
            this.textBox_formLocation.Name = "textBox_formLocation";
            this.textBox_formLocation.Size = new System.Drawing.Size(100, 29);
            this.textBox_formLocation.TabIndex = 2;
            // 
            // WESCarrierReturnNext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 254);
            this.Controls.Add(this.textBox_formLocation);
            this.Controls.Add(this.label_fromLocation);
            this.Controls.Add(this.textBox_carrierId);
            this.Controls.Add(this.label_carrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_CarrierReturnNext);
            this.Name = "WESCarrierReturnNext";
            this.Text = "CarrierReturnNext";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CarrierReturnNext;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_carrierId;
        private System.Windows.Forms.TextBox textBox_carrierId;
        private System.Windows.Forms.Label label_fromLocation;
        private System.Windows.Forms.TextBox textBox_formLocation;
    }
}