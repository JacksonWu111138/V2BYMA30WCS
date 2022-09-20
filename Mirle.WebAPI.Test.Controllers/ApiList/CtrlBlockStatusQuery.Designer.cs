namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlBlockStatusQuery
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
            this.button_BlockStatusQuery = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_chipSTKCId = new System.Windows.Forms.Label();
            this.textBox_chipSTKCId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_BlockStatusQuery
            // 
            this.button_BlockStatusQuery.Location = new System.Drawing.Point(336, 79);
            this.button_BlockStatusQuery.Name = "button_BlockStatusQuery";
            this.button_BlockStatusQuery.Size = new System.Drawing.Size(143, 135);
            this.button_BlockStatusQuery.TabIndex = 0;
            this.button_BlockStatusQuery.Text = "send";
            this.button_BlockStatusQuery.UseVisualStyleBackColor = true;
            this.button_BlockStatusQuery.Click += new System.EventHandler(this.button_BlockStatusQuery_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(98, 107);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(177, 104);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(138, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_chipSTKCId
            // 
            this.label_chipSTKCId.AutoSize = true;
            this.label_chipSTKCId.Location = new System.Drawing.Point(48, 152);
            this.label_chipSTKCId.Name = "label_chipSTKCId";
            this.label_chipSTKCId.Size = new System.Drawing.Size(93, 18);
            this.label_chipSTKCId.TabIndex = 1;
            this.label_chipSTKCId.Text = "chipSTKCId";
            this.label_chipSTKCId.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_chipSTKCId
            // 
            this.textBox_chipSTKCId.Location = new System.Drawing.Point(177, 149);
            this.textBox_chipSTKCId.Name = "textBox_chipSTKCId";
            this.textBox_chipSTKCId.Size = new System.Drawing.Size(138, 29);
            this.textBox_chipSTKCId.TabIndex = 2;
            // 
            // CtrlBlockStatusQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 322);
            this.Controls.Add(this.textBox_chipSTKCId);
            this.Controls.Add(this.label_chipSTKCId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_BlockStatusQuery);
            this.Name = "CtrlBlockStatusQuery";
            this.Text = "BlockStatusQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_BlockStatusQuery;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_chipSTKCId;
        private System.Windows.Forms.TextBox textBox_chipSTKCId;
    }
}