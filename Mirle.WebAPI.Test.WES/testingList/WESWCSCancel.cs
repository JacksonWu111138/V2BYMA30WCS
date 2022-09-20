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
    public partial class WESWCSCancel : Form
    {
        public WESWCSCancel()
        {
            InitializeComponent();
        }

        private void button_WCSCancel_Click(object sender, EventArgs e)
        {
            WCSCancelInfo info = new WCSCancelInfo
            {
                jobId = textBox_jobId.Text,
                lotIdCarrierId = textBox_lotIdCarrierId.Text,
                cancelType = textBox_cancelType.Text
            };
            if (!clsAPI.GetAPI().GetWCSCancel().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "WCS Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "WCS Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
