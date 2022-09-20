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
    public partial class WESNGPositionReport : Form
    {
        public WESNGPositionReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_NGPositionReport_Click(object sender, EventArgs e)
        {
            NGPositionReportInfo info = new NGPositionReportInfo
            {
                jobId = textBox_jobId.Text,
                lotId = textBox_lotId.Text,
                ngLocation = textBox_ngLocation.Text
            };
            if (!clsAPI.GetAPI().GetNGPositionReport().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "NG Position Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "NG Position Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
