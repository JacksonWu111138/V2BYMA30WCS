using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.WebAPI.V2BYMA30.Function;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.Def;
using Mirle.DB.Object;

namespace Mirle.WebAPI.Test.WES.testingList
{
    public partial class WESPositionReport : Form
    {
        public WESPositionReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button_PositionReport_Click_1(object sender, EventArgs e)
        {
            PositionReportInfo info = new PositionReportInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                location = textBox_location.Text,
                inStock = textBox_inStock.Text
            };

            if (!clsAPI.GetAPI().GetPositionReport().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Position Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Position Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
