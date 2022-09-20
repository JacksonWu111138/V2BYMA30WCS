using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.Def;
using Mirle.DB.Object;

namespace Mirle.WebAPI.Test.WES.testingList
{
    public partial class WESEQPStatusUpdate : Form
    {
        public WESEQPStatusUpdate()
        {
            InitializeComponent();
        }

        private void label_craneStatus_Click(object sender, EventArgs e)
        {

        }

        private void textBox_craneStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_EQPStatusUpdate_Click(object sender, EventArgs e)
        {
            EQPStatusUpdateInfo info = new EQPStatusUpdateInfo
            {
                jobId = textBox_jobId.Text,
                craneId = textBox_craneId.Text,
                craneStatus = textBox_craneStatus.Text,
                portId = textBox_portId.Text,
                portStatus = textBox_portStatus.Text
            };
            if (!clsAPI.GetAPI().GetEQPStatusUpdate().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "EQP Status Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "EQP Status Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
