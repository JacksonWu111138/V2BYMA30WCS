namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESPortStatusUpdate
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
            this.button_PortStatusUpload = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_portId = new System.Windows.Forms.Label();
            this.textBox_portId = new System.Windows.Forms.TextBox();
            this.label_portStatus = new System.Windows.Forms.Label();
            this.textBox_portStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_PortStatusUpload
            // 
            this.button_PortStatusUpload.Location = new System.Drawing.Point(296, 81);
            this.button_PortStatusUpload.Name = "button_PortStatusUpload";
            this.button_PortStatusUpload.Size = new System.Drawing.Size(125, 124);
            this.button_PortStatusUpload.TabIndex = 0;
            this.button_PortStatusUpload.Text = "send";
            this.button_PortStatusUpload.UseVisualStyleBackColor = true;
            this.button_PortStatusUpload.Click += new System.EventHandler(this.button_PortStatusUpload_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(107, 101);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(168, 98);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_portId
            // 
            this.label_portId.AutoSize = true;
            this.label_portId.Location = new System.Drawing.Point(101, 136);
            this.label_portId.Name = "label_portId";
            this.label_portId.Size = new System.Drawing.Size(49, 18);
            this.label_portId.TabIndex = 1;
            this.label_portId.Text = "portId";
            // 
            // textBox_portId
            // 
            this.textBox_portId.Location = new System.Drawing.Point(168, 133);
            this.textBox_portId.Name = "textBox_portId";
            this.textBox_portId.Size = new System.Drawing.Size(100, 29);
            this.textBox_portId.TabIndex = 2;
            // 
            // label_portStatus
            // 
            this.label_portStatus.AutoSize = true;
            this.label_portStatus.Location = new System.Drawing.Point(73, 171);
            this.label_portStatus.Name = "label_portStatus";
            this.label_portStatus.Size = new System.Drawing.Size(77, 18);
            this.label_portStatus.TabIndex = 1;
            this.label_portStatus.Text = "portStatus";
            // 
            // textBox_portStatus
            // 
            this.textBox_portStatus.Location = new System.Drawing.Point(168, 168);
            this.textBox_portStatus.Name = "textBox_portStatus";
            this.textBox_portStatus.Size = new System.Drawing.Size(100, 29);
            this.textBox_portStatus.TabIndex = 2;
            // 
            // WESPortStatusUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 266);
            this.Controls.Add(this.textBox_portStatus);
            this.Controls.Add(this.label_portStatus);
            this.Controls.Add(this.textBox_portId);
            this.Controls.Add(this.label_portId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_PortStatusUpload);
            this.Name = "WESPortStatusUpdate";
            this.Text = "PortStatusUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_PortStatusUpload;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_portId;
        private System.Windows.Forms.TextBox textBox_portId;
        private System.Windows.Forms.Label label_portStatus;
        private System.Windows.Forms.TextBox textBox_portStatus;
    }
}