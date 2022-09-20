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
    public partial class WESRemoveRackShow : Form
    {
        public WESRemoveRackShow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_RemoveRackShow_Click(object sender, EventArgs e)
        {
            RemoveRackShowInfo info = new RemoveRackShowInfo
            {
                jobId = textBox_jobId.Text,
                location = textBox_location.Text,
                carrierId = textBox_carrierId.Text
            };
            if (!clsAPI.GetAPI().GetRemoveRackShow().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Remove Rack Show", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Remove Rack Show", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
