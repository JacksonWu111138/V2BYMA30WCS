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
    public partial class WESLotShelfComplete : Form
    {
        public WESLotShelfComplete()
        {
            InitializeComponent();
        }

        private void button_LotShelfComplete_Click(object sender, EventArgs e)
        {
            LotShelfCompleteInfo info = new LotShelfCompleteInfo
            {
                jobId = textBox_jobId.Text,
                lotId = textBox_lotId.Text,
                shelfId = textBox_shelfId.Text,
                emptyTransfer = textBox_emptyTransfer.Text
            };
            if (!clsAPI.GetAPI().GetLotShelfComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Lot Shelf Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Lot Shelf Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
