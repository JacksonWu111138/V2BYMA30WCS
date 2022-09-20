namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlBufferInitial
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
            this.label_bufferId = new System.Windows.Forms.Label();
            this.textBox_bufferId = new System.Windows.Forms.TextBox();
            this.button_BufferInitial = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(75, 95);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 0;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(163, 92);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 1;
            // 
            // label_bufferId
            // 
            this.label_bufferId.AutoSize = true;
            this.label_bufferId.Location = new System.Drawing.Point(54, 143);
            this.label_bufferId.Name = "label_bufferId";
            this.label_bufferId.Size = new System.Drawing.Size(64, 18);
            this.label_bufferId.TabIndex = 2;
            this.label_bufferId.Text = "bufferId";
            // 
            // textBox_bufferId
            // 
            this.textBox_bufferId.Location = new System.Drawing.Point(163, 140);
            this.textBox_bufferId.Name = "textBox_bufferId";
            this.textBox_bufferId.Size = new System.Drawing.Size(100, 29);
            this.textBox_bufferId.TabIndex = 3;
            // 
            // button_BufferInitial
            // 
            this.button_BufferInitial.Location = new System.Drawing.Point(298, 92);
            this.button_BufferInitial.Name = "button_BufferInitial";
            this.button_BufferInitial.Size = new System.Drawing.Size(102, 84);
            this.button_BufferInitial.TabIndex = 4;
            this.button_BufferInitial.Text = "send";
            this.button_BufferInitial.UseVisualStyleBackColor = true;
            this.button_BufferInitial.Click += new System.EventHandler(this.button_BufferInitial_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "E800C",
            "SMTC",
            "LIFT4C",
            "LIFT5C",
            "B800C",
            "M800C",
            "OSMTC"});
            this.comboBox1.Location = new System.Drawing.Point(78, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // CtrlBufferInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 228);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_BufferInitial);
            this.Controls.Add(this.textBox_bufferId);
            this.Controls.Add(this.label_bufferId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Name = "CtrlBufferInitial";
            this.Text = "CtrlBufferInitial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_bufferId;
        private System.Windows.Forms.TextBox textBox_bufferId;
        private System.Windows.Forms.Button button_BufferInitial;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}