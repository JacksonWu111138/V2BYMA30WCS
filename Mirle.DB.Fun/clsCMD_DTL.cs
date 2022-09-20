using Mirle.Structure;
using System.Collections.Generic;
using System.Linq;
using Mirle.DataBase;
using System.Threading;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mirle.DB.Fun
{
    public class clsCMD_DTL
    {
        private clsTool tool = new clsTool();
        public bool FunReadCmdDtl(CmdMstInfo cmd, ref List<LocDtlInfo> locDtls, 
            ref List<TrnLogInfo> trnLogs, ref List<MoldUseLogInfo> moldUseLogs, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                int iRet = FunGetCmdDtl(cmd.Cmd_Sno, ref dtTmp, db);
                if (iRet == DBResult.Success)
                {
                    for (int i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        LocDtlInfo locDtlInfo = tool.GetLocDtl_FromCmdDtl(cmd, dtTmp.Rows[i]);
                        locDtls.Add(locDtlInfo);
                        Thread.SpinWait(1);
                        trnLogs.Add(tool.GetTrnLogInfo(cmd, locDtlInfo));
                        MoldUseLogInfo moldUseLogInfo = new MoldUseLogInfo
                        {
                            MoldUse_Txno = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Cmd_Txno].ToString(),
                            MoldTkt_No = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Trn_Tkt_No].ToString(),
                            MoldCode = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.ItemNo].ToString(),       //v1.02 寫在Cmd_Dtl的料號裡 by Ian
                            Loc = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Loc].ToString()
                        };
                        moldUseLogInfo.MoldStatus = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Factory].ToString();
                        moldUseLogInfo.UsedQty = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Trn_Qty].ToString();
                        moldUseLogInfo.UpdatedPerson = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Remark].ToString();
                        moldUseLogInfo.UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        moldUseLogInfo.CreatedPerson = cmd.Trn_User;
                        moldUseLogInfo.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        moldUseLogInfo.Loc = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.Loc].ToString(); ;              //v1.05
                        moldUseLogInfo.Item_no = dtTmp.Rows[i][Parameter.clsCmd_Dtl.Column.ItemNo].ToString(); ;     //v1.05
                        moldUseLogs.Add(moldUseLogInfo);
                    }

                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"<CmdSno>{cmd.Cmd_Sno} => 取得命令明細資料失敗！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public int FunGetCmdDtl(string sCmdSno, ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strSql = $"SELECT * FROM {Parameter.clsCmd_Dtl.TableName} WHERE {Parameter.clsCmd_Dtl.Column.Cmd_Sno} = '{sCmdSno}' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Exception)
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public int FunGetCmdDtl(string sCmdSno, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                return FunGetCmdDtl(sCmdSno, ref dtTmp, db);
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp.Dispose();
            }
        }

        public bool FunDelCmd_Dtl(string CommandID, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSQL = $"delete from {Parameter.clsCmd_Dtl.TableName} where {Parameter.clsCmd_Dtl.Column.Cmd_Sno} = '" + CommandID + "' ";
                int Ret = db.ExecuteSQL(strSQL, ref strEM);
                if (Ret == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSQL); return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSQL + " => " + strEM); return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunInsertCmd_Dtl_His(string sCmdSno, DataBase.DB db)
        {
            try
            {
                string SQL = $"INSERT INTO {Parameter.clsCmd_Dtl_His.TableName} ";
                SQL += $" SELECT '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', * FROM {Parameter.clsCmd_Dtl.TableName} ";
                SQL += $" WHERE {Parameter.clsCmd_Dtl.Column.Cmd_Sno}='{sCmdSno}'";

                int iRet = db.ExecuteSQL(SQL);
                if (iRet == DBResult.Success)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }
    }
}
