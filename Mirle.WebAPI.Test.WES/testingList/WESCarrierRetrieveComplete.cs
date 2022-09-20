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
    public partial class WESCarrierRetrieveComplete : Form
    {
        public WESCarrierRetrieveComplete()
        {
            InitializeComponent();
        }

        private void button_CarrierRetrieveComplete_Click(object sender, EventArgs e)
        {
            CarrierRetrieveCompleteInfo info = new CarrierRetrieveCompleteInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                portId = textBox_portId.Text,
                location = textBox_location.Text,
                isComplete = textBox_isComplete.Text,
                emptyTransfer = textBox_emptyTransfer.Text
            };
            if (!clsAPI.GetAPI().GetCarrierRetrieveComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Retrieve Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Retrieve Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
