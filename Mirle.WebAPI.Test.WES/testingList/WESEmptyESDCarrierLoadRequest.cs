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
    public partial class WESEmptyESDCarrierLoadRequest : Form
    {
        public WESEmptyESDCarrierLoadRequest()
        {
            InitializeComponent();
        }

        private void button_EmptyESDCarrierLoadRequest_Click(object sender, EventArgs e)
        {
            EmptyESDCarrierLoadRequestInfo info = new EmptyESDCarrierLoadRequestInfo
            {
                jobId = textBox_jobId.Text,
                location = textBox_location.Text
            };
            if (textBox_reqQty.Text != "")
            {
                info.reqQty = Convert.ToInt32(textBox_reqQty.Text);
                if (!clsAPI.GetAPI().GetEmptyESDCarrierLoadRequest().FunReport(info, clsAPI.GetWesApiConfig().IP))
                {
                    MessageBox.Show($"失敗, jobId:{info.jobId}.", "Empty ESDCarrier Load Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"成功, jobId:{info.jobId}.", "Empty ESDCarrier Load Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show($"reqQty欄位為空, jobId:{info.jobId}.", "Empty ESDCarrier Load Request", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
