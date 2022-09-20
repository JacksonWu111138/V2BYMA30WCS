namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlRemoteLocalRequest
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
            this.button_RemoteLocalRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_chipSTKCId = new System.Windows.Forms.Label();
            this.textBox_chipSTKCId = new System.Windows.Forms.TextBox();
            this.label_controlQuery = new System.Windows.Forms.Label();
            this.textBox_controlQuery = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_RemoteLocalRequest
            // 
            this.button_RemoteLocalRequest.Location = new System.Drawing.Point(298, 65);
            this.button_RemoteLocalRequest.Name = "button_RemoteLocalRequest";
            this.button_RemoteLocalRequest.Size = new System.Drawing.Size(144, 129);
            this.button_RemoteLocalRequest.TabIndex = 0;
            this.button_RemoteLocalRequest.Text = "send";
            this.button_RemoteLocalRequest.UseVisualStyleBackColor = true;
            this.button_RemoteLocalRequest.Click += new System.EventHandler(this.button_RemoteLocalRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(69, 79);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(132, 76);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(149, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_chipSTKCId
            // 
            this.label_chipSTKCId.AutoSize = true;
            this.label_chipSTKCId.Location = new System.Drawing.Point(19, 120);
            this.label_chipSTKCId.Name = "label_chipSTKCId";
            this.label_chipSTKCId.Size = new System.Drawing.Size(93, 18);
            this.label_chipSTKCId.TabIndex = 1;
            this.label_chipSTKCId.Text = "chipSTKCId";
            // 
            // textBox_chipSTKCId
            // 
            this.textBox_chipSTKCId.Location = new System.Drawing.Point(132, 117);
            this.textBox_chipSTKCId.Name = "textBox_chipSTKCId";
            this.textBox_chipSTKCId.Size = new System.Drawing.Size(149, 29);
            this.textBox_chipSTKCId.TabIndex = 2;
            // 
            // label_controlQuery
            // 
            this.label_controlQuery.AutoSize = true;
            this.label_controlQuery.Location = new System.Drawing.Point(14, 155);
            this.label_controlQuery.Name = "label_controlQuery";
            this.label_controlQuery.Size = new System.Drawing.Size(98, 18);
            this.label_controlQuery.TabIndex = 1;
            this.label_controlQuery.Text = "controlQuery";
            // 
            // textBox_controlQuery
            // 
            this.textBox_controlQuery.Location = new System.Drawing.Point(132, 152);
            this.textBox_controlQuery.Name = "textBox_controlQuery";
            this.textBox_controlQuery.Size = new System.Drawing.Size(149, 29);
            this.textBox_controlQuery.TabIndex = 2;
            // 
            // CtrlRemoteLocalRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 283);
            this.Controls.Add(this.textBox_controlQuery);
            this.Controls.Add(this.label_controlQuery);
            this.Controls.Add(this.textBox_chipSTKCId);
            this.Controls.Add(this.label_chipSTKCId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_RemoteLocalRequest);
            this.Name = "CtrlRemoteLocalRequest";
            this.Text = "RemoteLocalRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RemoteLocalRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_chipSTKCId;
        private System.Windows.Forms.TextBox textBox_chipSTKCId;
        private System.Windows.Forms.Label label_controlQuery;
        private System.Windows.Forms.TextBox textBox_controlQuery;
    }
}