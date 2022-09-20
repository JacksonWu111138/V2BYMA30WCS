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

namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    public partial class CtrlLotRetrieveTransfer : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        private LotRetrieveTransferInfo info = new LotRetrieveTransferInfo { lotList = new List<LotListInfo>() };

        public CtrlLotRetrieveTransfer()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void label_jobId_Click(object sender, EventArgs e)
        {

        }

        private void textBox_jobId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            LotListInfo list = new LotListInfo
            {
                cmdSno = textBox_cmdSno.Text,
                lotId = textBox_lotId.Text,
                fromShelfId = textBox_fromShelfId.Text,
                toPortId = textBox_toPortId.Text,
                rackLocation = textBox_rackLocation.Text,
                largest = textBox_largest.Text
            };
            info.lotList.Add(list);
            MessageBox.Show($"加入完成, lotId:{list.lotId}.", "Lot Retrieve Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_LotRetrieveTransfer_Click(object sender, EventArgs e)
        {
            info.jobId = textBox_jobId.Text;
            info.priority = textBox_priority.Text;

            if (!clsAPI.GetAPI().GetLotRetrieveTransfer().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Lot Retrieve Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Lot Retrieve Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
