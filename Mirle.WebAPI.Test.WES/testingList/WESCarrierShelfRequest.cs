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
    public partial class WESCarrierShelfRequest : Form
    {
        public WESCarrierShelfRequest()
        {
            InitializeComponent();
        }

        private void button_CarrierShelfRequest_Click(object sender, EventArgs e)
        {
            CarrierShelfRequestInfo info = new CarrierShelfRequestInfo
            {
                jobId = textBox_jobId.Text,
                fromShelfId = textBox_fromShelfId.Text,
                toShelfId = textBox_toShelfId.Text,
                disableLocation = textBox_disableLocation.Text
            };
            if (!clsAPI.GetAPI().GetCarrierShelfRequest().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Shelf Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Shelf Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
