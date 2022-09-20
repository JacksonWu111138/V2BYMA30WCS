using Mirle.Def;
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
using Mirle.DB.Object;

namespace Mirle.WebAPI.Test.WES.testingList
{
    public partial class WESLotPositionReport : Form
    {
        public WESLotPositionReport()
        {
            InitializeComponent();
        }


        private void button_LotPositionReport_Click(object sender, EventArgs e)
        {
            LotPositionReportInfo info = new LotPositionReportInfo
            {
                jobId = textBox_jobId.Text,
                lotId = textBox_lotId.Text,
                location = textBox_location.Text
            };
            if (!clsAPI.GetAPI().GetLotPositionReport().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Lot Position Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Lot Position Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
