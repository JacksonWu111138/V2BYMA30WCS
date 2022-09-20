namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlControlStatusQuery
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
            this.button_ControlStatusQuery = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_chipSTKCId = new System.Windows.Forms.Label();
            this.textBox_chipSTKCId = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.label_note = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_ControlStatusQuery
            // 
            this.button_ControlStatusQuery.Location = new System.Drawing.Point(287, 130);
            this.button_ControlStatusQuery.Name = "button_ControlStatusQuery";
            this.button_ControlStatusQuery.Size = new System.Drawing.Size(120, 71);
            this.button_ControlStatusQuery.TabIndex = 0;
            this.button_ControlStatusQuery.Text = "send";
            this.button_ControlStatusQuery.UseVisualStyleBackColor = true;
            this.button_ControlStatusQuery.Click += new System.EventHandler(this.button_ControlStatusQuery_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(74, 156);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(150, 153);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_chipSTKCId
            // 
            this.label_chipSTKCId.AutoSize = true;
            this.label_chipSTKCId.Location = new System.Drawing.Point(36, 42);
            this.label_chipSTKCId.Name = "label_chipSTKCId";
            this.label_chipSTKCId.Size = new System.Drawing.Size(93, 18);
            this.label_chipSTKCId.TabIndex = 1;
            this.label_chipSTKCId.Text = "chipSTKCId";
            // 
            // textBox_chipSTKCId
            // 
            this.textBox_chipSTKCId.Location = new System.Drawing.Point(150, 39);
            this.textBox_chipSTKCId.Name = "textBox_chipSTKCId";
            this.textBox_chipSTKCId.Size = new System.Drawing.Size(100, 29);
            this.textBox_chipSTKCId.TabIndex = 2;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(290, 38);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(117, 38);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "add Id";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Font = new System.Drawing.Font("新細明體", 15F);
            this.label_note.Location = new System.Drawing.Point(184, 97);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(223, 30);
            this.label_note.TabIndex = 4;
            this.label_note.Text = "Plz \"add Id\" first!!";
            // 
            // CtrlControlStatusQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 247);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_chipSTKCId);
            this.Controls.Add(this.label_chipSTKCId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_ControlStatusQuery);
            this.Name = "CtrlControlStatusQuery";
            this.Text = "ControlStatusQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ControlStatusQuery;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_chipSTKCId;
        private System.Windows.Forms.TextBox textBox_chipSTKCId;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label_note;
    }
}