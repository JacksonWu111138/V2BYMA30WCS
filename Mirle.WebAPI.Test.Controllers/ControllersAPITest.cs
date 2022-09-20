using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.Def;
using Mirle.WebAPI.Test.Controllers.ApiList;

namespace Mirle.WebAPI.Test.Controllers
{
    public partial class ControllersAPITest : Form
    {
        public ControllersAPITest()
        {
            InitializeComponent();
        }

        private void CtrlBlockStatusQuery_Click(object sender, EventArgs e)
        {
            CtrlBlockStatusQuery form = new CtrlBlockStatusQuery();
            form.Show();
        }

        private void CtrlBufferRollInfo_Click(object sender, EventArgs e)
        {
            CtrlBufferRollInfo form = new CtrlBufferRollInfo();
            form.Show();
        }

        private void CtrlBufferStatusQuery_Click(object sender, EventArgs e)
        {
            CtrlBufferStatusQuery form = new CtrlBufferStatusQuery();
            form.Show();
        }

        private void CtrlControlStatusQuery_Click(object sender, EventArgs e)
        {
            CtrlControlStatusQuery form = new CtrlControlStatusQuery();
            form.Show();
        }

        private void CtrlCVReceiveNewBinCmd_Click(object sender, EventArgs e)
        {
            CtrlCVReceiveNewBinCmd form = new CtrlCVReceiveNewBinCmd();
            form.Show();
        }
        private void CtrlHealthCheck_Click(object sender, EventArgs e)
        {
            CtrlHealthCheck form = new CtrlHealthCheck();
            form.Show();
        }

        private void CtrlLotRetrieveTransfer_Click(object sender, EventArgs e)
        {
            CtrlLotRetrieveTransfer form = new CtrlLotRetrieveTransfer();
            form.Show();
        }

        private void button_LotTransferCancel_Click(object sender, EventArgs e)
        {
            CtrlLotTransferCancel form = new CtrlLotTransferCancel();
            form.Show();
        }

        private void CtrlNewCarrierToStage_Click(object sender, EventArgs e)
        {
            CtrlNewCarrierToStage form = new CtrlNewCarrierToStage();
            form.Show();
        }

        private void CtrlPutawayTransferInfo_Click(object sender, EventArgs e)
        {
            CtrlPutawayTransferInfo form = new CtrlPutawayTransferInfo();
            form.Show();
        }

        private void CtrlMoveTask_Click(object sender, EventArgs e)
        {
            CtrlMoveTask form = new CtrlMoveTask();
            form.Show();
        }

        private void CtrlRackRequest_Click(object sender, EventArgs e)
        {
            CtrlRackRequest form = new CtrlRackRequest();
            form.Show();
        }

        private void CtrlRackTurn_Click(object sender, EventArgs e)
        {
            CtrlRackTurn form = new CtrlRackTurn();
            form.Show();
        }

        private void CtrlRemoteLocalRequest_Click(object sender, EventArgs e)
        {
            CtrlRemoteLocalRequest form = new CtrlRemoteLocalRequest();
            form.Show();
        }

        private void CtrlRetrieveTransferInfo_Click(object sender, EventArgs e)
        {
            CtrlRetrieveTransferInfo form = new CtrlRetrieveTransferInfo();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void CtrlTaskCancel_Click(object sender, EventArgs e)
        {
            CtrlTaskCancel form = new CtrlTaskCancel();
            form.Show();
        }

        private void CtrlTransferCommandRequest_Click(object sender, EventArgs e)
        {
            CtrlTransferCommandRequest form = new CtrlTransferCommandRequest();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void CtrlBufferInitial_Click(object sender, EventArgs e)
        {
            CtrlBufferInitial form = new CtrlBufferInitial();
            form.Show();
        }
    }
}
