namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlHealthCheck
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
            this.button_HealthCheck = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_HealthCheck
            // 
            this.button_HealthCheck.Location = new System.Drawing.Point(365, 58);
            this.button_HealthCheck.Name = "button_HealthCheck";
            this.button_HealthCheck.Size = new System.Drawing.Size(128, 122);
            this.button_HealthCheck.TabIndex = 0;
            this.button_HealthCheck.Text = "send";
            this.button_HealthCheck.UseVisualStyleBackColor = true;
            this.button_HealthCheck.Click += new System.EventHandler(this.button_HealthCheck_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LIFT4C",
            "LIFT5C",
            "B800C"});
            this.comboBox1.Location = new System.Drawing.Point(122, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(216, 26);
            this.comboBox1.TabIndex = 1;
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(119, 134);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 2;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(210, 131);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(128, 29);
            this.textBox_jobId.TabIndex = 3;
            // 
            // CtrlHealthCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 221);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_HealthCheck);
            this.Name = "CtrlHealthCheck";
            this.Text = "HealthCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_HealthCheck;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
    }
}