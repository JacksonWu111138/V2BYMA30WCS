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
    public partial class WESPortStatusUpdate : Form
    {
        public WESPortStatusUpdate()
        {
            InitializeComponent();
        }

        private void button_PortStatusUpload_Click(object sender, EventArgs e)
        {
            PortStatusUpdateInfo info = new PortStatusUpdateInfo
            {
                jobId = textBox_jobId.Text,
                portId = textBox_portId.Text,
                portStatus = textBox_portStatus.Text
            };
            if (!clsAPI.GetAPI().GetPortStatusUpdate().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Port Status Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Port Status Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
