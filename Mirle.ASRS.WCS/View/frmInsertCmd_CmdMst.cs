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
    public partial class frmInsertCmd_CmdMst : Form
    {
        public frmInsertCmd_CmdMst()
        {
            InitializeComponent();

            cbbPriority.SelectedIndex = 4;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            cbbCmdMode.SelectedIndex = -1;
            cbbPriority.SelectedIndex = 4;
            txtBoxID.Text = "";
            txtRackLocation.Text = "";
            txtLargest.Text = "";
            txtEquNo.Text = "";
            txtCarrierType.Text = "";
            txtJobID.Text = "";
            txtLoc.Text = "";
            txtNewLoc.Text = "";
            txtStnNo.Text = "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            butSave.Enabled = false;
            try
            {
                if(IsOK())
                {
                    CmdMstInfo cmd = new CmdMstInfo
                    {
                        Cmd_Sno = clsDB_Proc.GetDB_Object().GetSNO().FunGetSeqNo(clsEnum.enuSnoType.CMDSNO)
                    };

                    if (string.IsNullOrWhiteSpace(cmd.Cmd_Sno))
                    {
                        MessageBox.Show("取得命令序號失敗！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.carrierType = txtCarrierType.Text.Trim();
                    cmd.Cmd_Mode = cbbCmdMode.Text.Trim().Split(':')[0];
                    cmd.Cmd_Sts = clsConstValue.CmdSts.strCmd_Initial;
                    cmd.Equ_No = txtEquNo.Text.Trim();
                    cmd.IO_Type = cbbCmdMode.Text.Trim().Split(':')[0];
                    cmd.JobID = txtJobID.Text.Trim();
                    cmd.largest = txtLargest.Text.Trim();
                    cmd.Loc = txtLoc.Text.Trim();
                    cmd.BoxID = txtBoxID.Text.Trim();
                    cmd.New_Loc = txtNewLoc.Text.Trim();
                    cmd.Prty = cbbPriority.Text.Trim();
                    cmd.rackLocation = txtRackLocation.Text.Trim();
                    cmd.Stn_No = txtStnNo.Text.Trim();

                    string strEM = "";
                    if (clsDB_Proc.GetDB_Object().GetCmd_Mst().FunInsCmdMst(cmd, ref strEM))
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, $"手動產生命令成功 => <CmdSno>{cmd.Cmd_Sno} <BoxID>{cmd.BoxID}");
                        MessageBox.Show("儲存成功");
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動產生命令失敗 => <CmdSno>{cmd.Cmd_Sno} <BoxID>{cmd.BoxID}");
                        MessageBox.Show($"儲存失敗 => {strEM}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                string.IsNullOrWhiteSpace(txtCarrierType.Text) ||
                string.IsNullOrWhiteSpace(txtJobID.Text))
                return false;

            switch (cbbCmdMode.Text.Trim().Split(':')[0])
            {
                case clsConstValue.CmdMode.StockIn:
                case clsConstValue.CmdMode.StockOut:
                    if (string.IsNullOrWhiteSpace(txtEquNo.Text) ||
                        string.IsNullOrWhiteSpace(txtLoc.Text) ||
                        string.IsNullOrWhiteSpace(txtStnNo.Text))
                        return false;
                    else return true;
                case clsConstValue.CmdMode.S2S:
                    if (string.IsNullOrWhiteSpace(txtStnNo.Text) ||
                        string.IsNullOrWhiteSpace(txtNewLoc.Text))
                        return false;
                    else return true;
                case clsConstValue.CmdMode.L2L:
                    if (string.IsNullOrWhiteSpace(txtEquNo.Text) ||
                        string.IsNullOrWhiteSpace(txtLoc.Text) ||
                        string.IsNullOrWhiteSpace(txtNewLoc.Text))
                        return false;
                    else return true;
                default:
                    return true;
            }
        }
    }
}
