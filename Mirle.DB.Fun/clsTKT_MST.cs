using System;
using Mirle.Structure;
using Mirle.Def;
using System.Data;
using Mirle.DataBase;

namespace Mirle.DB.Fun
{
    public class clsTKT_MST
    {
        public bool FunCmdFinishUpdTkt(LocDtlInfo tLoc_Dtl, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            try
            {
                string sSQL = $"UPDATE {Parameter.clsTktMst.TableName} SET";
                sSQL += $" {Parameter.clsTktMst.Column.Proc_Qty} = {Parameter.clsTktMst.Column.Proc_Qty} + " + tLoc_Dtl.AloQty + ",";
                sSQL += $" {Parameter.clsTktMst.Column.Act_Qty} = {Parameter.clsTktMst.Column.Act_Qty} - " + tLoc_Dtl.AloQty + ",";
                sSQL += $" {Parameter.clsTktMst.Column.Trn_User} = 'AutoUpFile',";
                sSQL += $" {Parameter.clsTktMst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                ////v1.01   不判斷單據類別
                sSQL += $" WHERE {Parameter.clsTktMst.Column.TktNo} = '" + tLoc_Dtl.TktNo + "'";
                sSQL += $" AND {Parameter.clsTktMst.Column.Line} = '" + tLoc_Dtl.TktSeq + "'";
                sSQL += $" AND {Parameter.clsTktMst.Column.Tkt_Type} = '" + tLoc_Dtl.TktType + "'";

                if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strErrMsg}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunCmdCancelUpdTkt(LocDtlInfo tLoc_Dtl, string strTktSts, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            try
            {
                string sSQL = $"UPDATE {Parameter.clsTktMst.TableName} SET";
                sSQL += $" {Parameter.clsTktMst.Column.Tkt_Sts} = '" + strTktSts + "',";
                sSQL += $" {Parameter.clsTktMst.Column.Act_Qty} = {Parameter.clsTktMst.Column.Act_Qty} - " + tLoc_Dtl.AloQty + ",";
                sSQL += $" {Parameter.clsTktMst.Column.Trn_User} = 'AutoUpFile',";
                sSQL += $" {Parameter.clsTktMst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                //v1.01  不判斷單據類別
                sSQL += $" WHERE {Parameter.clsTktMst.Column.TktNo} = '" + tLoc_Dtl.TktNo + "'";
                sSQL += $" AND {Parameter.clsTktMst.Column.Tkt_Type} = '" + tLoc_Dtl.TktType + "'";
                sSQL += $" AND {Parameter.clsTktMst.Column.Line} = '" + tLoc_Dtl.TktSeq + "'";

                if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strErrMsg}");
                    return false;
                }
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
