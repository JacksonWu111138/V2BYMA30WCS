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
    public partial class WESLotPutawayCheck : Form
    {
        public WESLotPutawayCheck()
        {
            InitializeComponent();
        }

        private void button_LotPutawayCheck_Click(object sender, EventArgs e)
        {
            LotPutawayCheckInfo info = new LotPutawayCheckInfo
            {
                jobId = textBox_jobId.Text,
                portId = textBox_portId.Text,
                lotId = textBox_lotId.Text
            };
            if (!clsAPI.GetAPI().GetLotPutawayCheck().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Lot PutAway Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Lot PutAway Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
