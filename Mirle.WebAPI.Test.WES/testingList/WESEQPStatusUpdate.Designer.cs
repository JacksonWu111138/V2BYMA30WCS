namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESEQPStatusUpdate
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
            this.button_EQPStatusUpdate = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_craneId = new System.Windows.Forms.Label();
            this.textBox_craneId = new System.Windows.Forms.TextBox();
            this.label_craneStatus = new System.Windows.Forms.Label();
            this.textBox_craneStatus = new System.Windows.Forms.TextBox();
            this.label_portId = new System.Windows.Forms.Label();
            this.textBox_portId = new System.Windows.Forms.TextBox();
            this.label_portStatus = new System.Windows.Forms.Label();
            this.textBox_portStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_EQPStatusUpdate
            // 
            this.button_EQPStatusUpdate.Location = new System.Drawing.Point(270, 80);
            this.button_EQPStatusUpdate.Name = "button_EQPStatusUpdate";
            this.button_EQPStatusUpdate.Size = new System.Drawing.Size(116, 131);
            this.button_EQPStatusUpdate.TabIndex = 0;
            this.button_EQPStatusUpdate.Text = "send";
            this.button_EQPStatusUpdate.UseVisualStyleBackColor = true;
            this.button_EQPStatusUpdate.Click += new System.EventHandler(this.button_EQPStatusUpdate_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(65, 66);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(139, 63);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_craneId
            // 
            this.label_craneId.AutoSize = true;
            this.label_craneId.Location = new System.Drawing.Point(48, 101);
            this.label_craneId.Name = "label_craneId";
            this.label_craneId.Size = new System.Drawing.Size(60, 18);
            this.label_craneId.TabIndex = 1;
            this.label_craneId.Text = "craneId";
            // 
            // textBox_craneId
            // 
            this.textBox_craneId.Location = new System.Drawing.Point(139, 98);
            this.textBox_craneId.Name = "textBox_craneId";
            this.textBox_craneId.Size = new System.Drawing.Size(100, 29);
            this.textBox_craneId.TabIndex = 2;
            // 
            // label_craneStatus
            // 
            this.label_craneStatus.AutoSize = true;
            this.label_craneStatus.Location = new System.Drawing.Point(20, 136);
            this.label_craneStatus.Name = "label_craneStatus";
            this.label_craneStatus.Size = new System.Drawing.Size(88, 18);
            this.label_craneStatus.TabIndex = 1;
            this.label_craneStatus.Text = "craneStatus";
            this.label_craneStatus.Click += new System.EventHandler(this.label_craneStatus_Click);
            // 
            // textBox_craneStatus
            // 
            this.textBox_craneStatus.Location = new System.Drawing.Point(139, 133);
            this.textBox_craneStatus.Name = "textBox_craneStatus";
            this.textBox_craneStatus.Size = new System.Drawing.Size(100, 29);
            this.textBox_craneStatus.TabIndex = 2;
            this.textBox_craneStatus.TextChanged += new System.EventHandler(this.textBox_craneStatus_TextChanged);
            // 
            // label_portId
            // 
            this.label_portId.AutoSize = true;
            this.label_portId.Location = new System.Drawing.Point(59, 175);
            this.label_portId.Name = "label_portId";
            this.label_portId.Size = new System.Drawing.Size(49, 18);
            this.label_portId.TabIndex = 1;
            this.label_portId.Text = "portId";
            this.label_portId.Click += new System.EventHandler(this.label_craneStatus_Click);
            // 
            // textBox_portId
            // 
            this.textBox_portId.Location = new System.Drawing.Point(139, 172);
            this.textBox_portId.Name = "textBox_portId";
            this.textBox_portId.Size = new System.Drawing.Size(100, 29);
            this.textBox_portId.TabIndex = 2;
            this.textBox_portId.TextChanged += new System.EventHandler(this.textBox_craneStatus_TextChanged);
            // 
            // label_portStatus
            // 
            this.label_portStatus.AutoSize = true;
            this.label_portStatus.Location = new System.Drawing.Point(31, 210);
            this.label_portStatus.Name = "label_portStatus";
            this.label_portStatus.Size = new System.Drawing.Size(77, 18);
            this.label_portStatus.TabIndex = 1;
            this.label_portStatus.Text = "portStatus";
            this.label_portStatus.Click += new System.EventHandler(this.label_craneStatus_Click);
            // 
            // textBox_portStatus
            // 
            this.textBox_portStatus.Location = new System.Drawing.Point(139, 207);
            this.textBox_portStatus.Name = "textBox_portStatus";
            this.textBox_portStatus.Size = new System.Drawing.Size(100, 29);
            this.textBox_portStatus.TabIndex = 2;
            this.textBox_portStatus.TextChanged += new System.EventHandler(this.textBox_craneStatus_TextChanged);
            // 
            // WESEQPStatusUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 308);
            this.Controls.Add(this.textBox_portStatus);
            this.Controls.Add(this.label_portStatus);
            this.Controls.Add(this.textBox_portId);
            this.Controls.Add(this.label_portId);
            this.Controls.Add(this.textBox_craneStatus);
            this.Controls.Add(this.label_craneStatus);
            this.Controls.Add(this.textBox_craneId);
            this.Controls.Add(this.label_craneId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_EQPStatusUpdate);
            this.Name = "WESEQPStatusUpdate";
            this.Text = "EQPStatusUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EQPStatusUpdate;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_craneId;
        private System.Windows.Forms.TextBox textBox_craneId;
        private System.Windows.Forms.Label label_craneStatus;
        private System.Windows.Forms.TextBox textBox_craneStatus;
        private System.Windows.Forms.Label label_portId;
        private System.Windows.Forms.TextBox textBox_portId;
        private System.Windows.Forms.Label label_portStatus;
        private System.Windows.Forms.TextBox textBox_portStatus;
    }
}