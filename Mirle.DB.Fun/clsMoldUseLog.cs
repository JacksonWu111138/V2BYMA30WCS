using System;
using System.Collections.Generic;
using Mirle.Structure;
using Mirle.DataBase;
using System.Threading.Tasks;

namespace Mirle.DB.Fun
{
    public class clsMoldUseLog
    {
        public bool FunInsMoldUseLog(MoldUseLogInfo tMoldUseLog, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            try
            {
                string sSQL = $"INSERT INTO {Parameter.clsMoldUseLog.TableName} ({Parameter.clsMoldUseLog.Column.MoldUse_Txno}," +
                    $"{Parameter.clsMoldUseLog.Column.MoldTkt_No},{Parameter.clsMoldUseLog.Column.MoldCode}," +
                    $"{Parameter.clsMoldUseLog.Column.UsedStatus},{Parameter.clsMoldUseLog.Column.MoldStatus}," +
                    $"{Parameter.clsMoldUseLog.Column.UsedQty},{Parameter.clsMoldUseLog.Column.UsedPerson},";
                sSQL += $"{Parameter.clsMoldUseLog.Column.UseDate},{Parameter.clsMoldUseLog.Column.Remark}," +
                    $"{Parameter.clsMoldUseLog.Column.ClientNo},{Parameter.clsMoldUseLog.Column.ClientName}," +
                    $"{Parameter.clsMoldUseLog.Column.UpdatedPerson},{Parameter.clsMoldUseLog.Column.UpdatedDate},";
                sSQL += $"{Parameter.clsMoldUseLog.Column.CreatedPerson},{Parameter.clsMoldUseLog.Column.CreatedDate}) VALUES(";
                sSQL += "'" + tMoldUseLog.MoldUse_Txno + "',";
                sSQL += "'" + tMoldUseLog.MoldTkt_No + "',";
                sSQL += "'" + tMoldUseLog.MoldCode + "',";
                sSQL += "'" + tMoldUseLog.UsedStatus + "',"; //v1.03
                sSQL += "'" + tMoldUseLog.MoldStatus + "',";
                sSQL += "'" + tMoldUseLog.UsedQty + "',";
                sSQL += "'" + tMoldUseLog.UsedPerson + "',";
                sSQL += "'" + tMoldUseLog.UseDate + "',";
                sSQL += "'" + tMoldUseLog.Memo + "',";
                sSQL += "'" + tMoldUseLog.CustNo + "',";
                sSQL += "'" + tMoldUseLog.CustName + "',";
                sSQL += "'" + tMoldUseLog.UpdatedPerson + "',";
                sSQL += "'" + tMoldUseLog.UpdatedDate + "',";
                sSQL += "'" + tMoldUseLog.CreatedPerson + "',";
                sSQL += "'" + tMoldUseLog.CreatedDate + "')";

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
