using Mirle.DB.Object;
using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.ASRS.WCS.View
{
    public partial class frmInsertCmd_MiddleCmd : Form
    {
        public frmInsertCmd_MiddleCmd()
        {
            InitializeComponent();

            cbbPriority.SelectedIndex = 4;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            cbbCmdMode.SelectedIndex = -1;
            cbbPriority.SelectedIndex = 4;
            txtCSTID.Text = "";
            txtRackLocation.Text = "";
            txtLargest.Text = "";
            txtDeviceID.Text = "";
            txtCarrierType.Text = "";
            txtLotSize.Text = "";
            txtSource.Text = "";
            txtDestination.Text = "";
            txtBatchID.Text = "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            butSave.Enabled = false;
            try
            {
                if (IsOK())
                {
                    MiddleCmd cmd = new MiddleCmd
                    {
                        CommandID = clsDB_Proc.GetDB_Object().GetSNO().FunGetSeqNo(clsEnum.enuSnoType.CMDSUO)
                    };

                    if (string.IsNullOrWhiteSpace(cmd.CommandID))
                    {
                        MessageBox.Show("取得命令序號失敗！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.TaskNo = clsDB_Proc.GetDB_Object().GetSNO().FunGetSeqNo(clsEnum.enuSnoType.CMDSUO);
                    if (string.IsNullOrWhiteSpace(cmd.TaskNo))
                    {
                        MessageBox.Show("取得命令序號失敗！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.carrierType = txtCarrierType.Text.Trim();
                    cmd.CmdMode = cbbCmdMode.Text.Trim().Split(':')[0];
                    cmd.CmdSts = clsConstValue.CmdSts_MiddleCmd.strCmd_Initial;
                    cmd.DeviceID = txtDeviceID.Text.Trim();
                    cmd.Iotype = cbbCmdMode.Text.Trim().Split(':')[0];
                    cmd.BatchID = txtBatchID.Text.Trim();
                    cmd.largest = txtLargest.Text.Trim();
                    cmd.Source = txtSource.Text.Trim();
                    cmd.CSTID = txtCSTID.Text.Trim();
                    cmd.Destination = txtDestination.Text.Trim();
                    cmd.Priority = Convert.ToInt32(cbbPriority.Text.Trim());
                    cmd.rackLocation = txtRackLocation.Text.Trim();
                    cmd.lotSize = txtLotSize.Text.Trim();

                    if (clsDB_Proc.GetDB_Object().GetMiddleCmd().FunInsMiddleCmd(cmd))
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, $"手動產生Middle命令成功 => <CommandID>{cmd.CommandID} <CSTID>{cmd.CSTID}");
                        MessageBox.Show("儲存成功");
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動產生Middle命令失敗 => <CommandID>{cmd.CommandID} <CSTID>{cmd.CSTID}");
                        MessageBox.Show($"儲存失敗！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("資料未輸入齊全", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                butSave.Enabled = true;
            }
        }

        private bool IsOK()
        {
            if (string.IsNullOrWhiteSpace(cbbCmdMode.Text) ||
                string.IsNullOrWhiteSpace(txtCSTID.Text) ||
                string.IsNullOrWhiteSpace(txtCarrierType.Text) ||
                string.IsNullOrWhiteSpace(txtDeviceID.Text) ||
                string.IsNullOrWhiteSpace(txtDestination.Text))
                return false;

            if(cbbCmdMode.Text.Trim().Split(':')[0] != clsConstValue.CmdMode.Deposit)
            {
                if (string.IsNullOrWhiteSpace(txtSource.Text)) return false;
            }

            return true;
        }
    }
}
