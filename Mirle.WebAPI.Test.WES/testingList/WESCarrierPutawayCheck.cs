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
    public partial class WESCarrierPutawayCheck : Form
    {
        public WESCarrierPutawayCheck()
        {
            InitializeComponent();
        }

        private void button_CarrierPutawayCheck_Click(object sender, EventArgs e)
        {
            CarrierPutawayCheckInfo info = new CarrierPutawayCheckInfo
            {
                jobId = textBox_jobId.Text,
                portId = textBox_portId.Text,
                carrierId = textBox_carrierId.Text,
                storageType = textBox_storageType.Text
            };
            if (!clsAPI.GetAPI().GetCarrierPutawayCheck().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
