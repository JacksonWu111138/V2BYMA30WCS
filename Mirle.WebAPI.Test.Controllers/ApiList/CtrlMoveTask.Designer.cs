namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlMoveTask
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
            this.button_MoveTask = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_fromLoc = new System.Windows.Forms.Label();
            this.textBox_fromLoc = new System.Windows.Forms.TextBox();
            this.label_toLoc = new System.Windows.Forms.Label();
            this.textBox_toLoc = new System.Windows.Forms.TextBox();
            this.label_carrierType = new System.Windows.Forms.Label();
            this.textBox_carrierType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_MoveTask
            // 
            this.button_MoveTask.Location = new System.Drawing.Point(292, 77);
            this.button_MoveTask.Name = "button_MoveTask";
            this.button_MoveTask.Size = new System.Drawing.Size(155, 123);
            this.button_MoveTask.TabIndex = 0;
            this.button_MoveTask.Text = "send";
            this.button_MoveTask.UseVisualStyleBackColor = true;
            this.button_MoveTask.Click += new System.EventHandler(this.button_MoveTask_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(57, 74);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(127, 71);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(130, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_fromLoc
            // 
            this.label_fromLoc.AutoSize = true;
            this.label_fromLoc.Location = new System.Drawing.Point(33, 109);
            this.label_fromLoc.Name = "label_fromLoc";
            this.label_fromLoc.Size = new System.Drawing.Size(67, 18);
            this.label_fromLoc.TabIndex = 1;
            this.label_fromLoc.Text = "fromLoc";
            // 
            // textBox_fromLoc
            // 
            this.textBox_fromLoc.Location = new System.Drawing.Point(127, 106);
            this.textBox_fromLoc.Name = "textBox_fromLoc";
            this.textBox_fromLoc.Size = new System.Drawing.Size(130, 29);
            this.textBox_fromLoc.TabIndex = 2;
            // 
            // label_toLoc
            // 
            this.label_toLoc.AutoSize = true;
            this.label_toLoc.Location = new System.Drawing.Point(53, 144);
            this.label_toLoc.Name = "label_toLoc";
            this.label_toLoc.Size = new System.Drawing.Size(47, 18);
            this.label_toLoc.TabIndex = 1;
            this.label_toLoc.Text = "toLoc";
            this.label_toLoc.Click += new System.EventHandler(this.label_toLoc_Click);
            // 
            // textBox_toLoc
            // 
            this.textBox_toLoc.Location = new System.Drawing.Point(127, 141);
            this.textBox_toLoc.Name = "textBox_toLoc";
            this.textBox_toLoc.Size = new System.Drawing.Size(130, 29);
            this.textBox_toLoc.TabIndex = 2;
            this.textBox_toLoc.TextChanged += new System.EventHandler(this.textBox_toLoc_TextChanged);
            // 
            // label_carrierType
            // 
            this.label_carrierType.AutoSize = true;
            this.label_carrierType.Location = new System.Drawing.Point(11, 179);
            this.label_carrierType.Name = "label_carrierType";
            this.label_carrierType.Size = new System.Drawing.Size(89, 18);
            this.label_carrierType.TabIndex = 1;
            this.label_carrierType.Text = "carrierType";
            this.label_carrierType.Click += new System.EventHandler(this.label_toLoc_Click);
            // 
            // textBox_carrierType
            // 
            this.textBox_carrierType.Location = new System.Drawing.Point(127, 176);
            this.textBox_carrierType.Name = "textBox_carrierType";
            this.textBox_carrierType.Size = new System.Drawing.Size(130, 29);
            this.textBox_carrierType.TabIndex = 2;
            this.textBox_carrierType.TextChanged += new System.EventHandler(this.textBox_toLoc_TextChanged);
            // 
            // CtrlMoveTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 294);
            this.Controls.Add(this.textBox_carrierType);
            this.Controls.Add(this.label_carrierType);
            this.Controls.Add(this.textBox_toLoc);
            this.Controls.Add(this.label_toLoc);
            this.Controls.Add(this.textBox_fromLoc);
            this.Controls.Add(this.label_fromLoc);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_MoveTask);
            this.Name = "CtrlMoveTask";
            this.Text = "MoveTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_MoveTask;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_fromLoc;
        private System.Windows.Forms.TextBox textBox_fromLoc;
        private System.Windows.Forms.Label label_toLoc;
        private System.Windows.Forms.TextBox textBox_toLoc;
        private System.Windows.Forms.Label label_carrierType;
        private System.Windows.Forms.TextBox textBox_carrierType;
    }
}