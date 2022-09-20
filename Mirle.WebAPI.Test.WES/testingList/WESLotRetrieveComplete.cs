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
    public partial class WESLotRetrieveComplete : Form
    {
        public WESLotRetrieveComplete()
        {
            InitializeComponent();
        }

        private void label_emptyTransfer_Click(object sender, EventArgs e)
        {

        }

        private void textBox_emptyTransfer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_LotRetrieveComplete_Click(object sender, EventArgs e)
        {
            LotRetrieveCompleteInfo info = new LotRetrieveCompleteInfo
            {
                jobId = textBox_jobId.Text,
                lotId = textBox_lotId.Text,
                portId = textBox_portId.Text,
                carrierId = textBox_carrierId.Text,
                isComplete = textBox_isComplete.Text,
                emptyTransfer = textBox_emptyTransfer.Text,
                disableLocation = textBox_disableLocation.Text
            };
            if (!clsAPI.GetAPI().GetLotRetrieveComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Lot Retrieve Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Lot Retrieve Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
