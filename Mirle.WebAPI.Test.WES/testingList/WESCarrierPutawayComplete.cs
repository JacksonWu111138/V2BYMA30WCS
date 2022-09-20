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
    public partial class WESCarrierPutawayComplete : Form
    {
        public WESCarrierPutawayComplete()
        {
            InitializeComponent();
        }

        private void button_CarrierPutawayComplete_Click(object sender, EventArgs e)
        {
            CarrierPutawayCompleteInfo info = new CarrierPutawayCompleteInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                shelfId = textBox_shelfId.Text,
                isComplete = textBox_isComplete.Text
            };
            if (!clsAPI.GetAPI().GetCarrierPutawayComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier PutAway Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier PutAway Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
