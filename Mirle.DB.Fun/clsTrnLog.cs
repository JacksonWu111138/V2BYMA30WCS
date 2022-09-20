using System;
using System.Collections.Generic;
using Mirle.Structure;
using Mirle.DataBase;
using System.Threading.Tasks;

namespace Mirle.DB.Fun
{
    public class clsTrnLog
    {
        public bool FunInsTrnLog(TrnLogInfo tTrn_Log, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            try
            {
                string sSQL = $"INSERT INTO {Parameter.clsTrn_Log.TableName}({Parameter.clsTrn_Log.Column.Log_Date}," +
                    $"{Parameter.clsTrn_Log.Column.Cmd_Sno},{Parameter.clsTrn_Log.Column.Cmd_Txno},{Parameter.clsTrn_Log.Column.Cmd_Sts}," +
                    $"{Parameter.clsTrn_Log.Column.Cmd_Abnormal},{Parameter.clsTrn_Log.Column.Prty},{Parameter.clsTrn_Log.Column.Stn_No}," +
                    $"{Parameter.clsTrn_Log.Column.Cmd_Mode},{Parameter.clsTrn_Log.Column.IO_Type},{Parameter.clsTrn_Log.Column.Tkt_IO}," +
                    $"{Parameter.clsTrn_Log.Column.Tkt_Type},{Parameter.clsTrn_Log.Column.WH_ID},{Parameter.clsTrn_Log.Column.Loc},";
                sSQL += $"{Parameter.clsTrn_Log.Column.New_Loc},{Parameter.clsTrn_Log.Column.Mix_Qty},{Parameter.clsTrn_Log.Column.Avail}," +
                    $"{Parameter.clsTrn_Log.Column.Zone},{Parameter.clsTrn_Log.Column.BoxID},{Parameter.clsTrn_Log.Column.Create_Date}," +
                    $"{Parameter.clsTrn_Log.Column.Expose_Date},{Parameter.clsTrn_Log.Column.End_Date},{Parameter.clsTrn_Log.Column.Trn_User}," +
                    $"{Parameter.clsTrn_Log.Column.Host_Name},{Parameter.clsTrn_Log.Column.Trace},{Parameter.clsTrn_Log.Column.Pallet_Count}," +
                    $"{Parameter.clsTrn_Log.Column.Equ_No},{Parameter.clsTrn_Log.Column.Plt_Qty},{Parameter.clsTrn_Log.Column.Trn_Qty},";
                sSQL += $"{Parameter.clsTrn_Log.Column.Plt_Id},{Parameter.clsTrn_Log.Column.Lot_No},{Parameter.clsTrn_Log.Column.IN_Date}," +
                    $"{Parameter.clsTrn_Log.Column.IN_Tkt_No},{Parameter.clsTrn_Log.Column.IN_Tkt_Seq},{Parameter.clsTrn_Log.Column.Trn_Tkt_No}," +
                    $"{Parameter.clsTrn_Log.Column.Trn_Tkt_Seq},{Parameter.clsTrn_Log.Column.ShelfLife},{Parameter.clsTrn_Log.Column.ItemNo},";
                sSQL += $"{Parameter.clsTrn_Log.Column.Factory},{Parameter.clsTrn_Log.Column.ClientNo},{Parameter.clsTrn_Log.Column.ClientName}," +
                    $"{Parameter.clsTrn_Log.Column.SupplierNo},{Parameter.clsTrn_Log.Column.SupplierName},{Parameter.clsTrn_Log.Column.Unit}," +
                    $"{Parameter.clsTrn_Log.Column.BoxCount},{Parameter.clsTrn_Log.Column.Remark},{Parameter.clsTrn_Log.Column.WH_Type}," +
                    $"{Parameter.clsTrn_Log.Column.BeginDate},{Parameter.clsTrn_Log.Column.Print_Flag}) VALUES(";
                sSQL += "'" + tTrn_Log.LogDate + "',";
                sSQL += "'" + tTrn_Log.CmdSno + "',";
                sSQL += "'" + tTrn_Log.CmdTxno + "',";
                sSQL += "'" + tTrn_Log.CmdSts + "',";
                sSQL += "'" + tTrn_Log.CmdAbnormal + "',";
                sSQL += "'" + tTrn_Log.Prty + "',";
                sSQL += "'" + tTrn_Log.StnNo + "',";
                sSQL += "'" + tTrn_Log.CmdMode + "',";
                sSQL += "'" + tTrn_Log.IoType + "',";
                sSQL += "'" + tTrn_Log.TktIO + "',";
                sSQL += "'" + tTrn_Log.TktType + "',";
                sSQL += "'" + tTrn_Log.WhId + "',";
                sSQL += "'" + tTrn_Log.Loc + "',";
                sSQL += "'" + tTrn_Log.NewLoc + "',";
                sSQL += tTrn_Log.MixQty + ",";
                sSQL += tTrn_Log.Avail + ",";
                sSQL += "'" + tTrn_Log.ZoneId + "',";
                sSQL += "'" + tTrn_Log.LocId + "',";
                sSQL += "'" + tTrn_Log.CrtDate + "',";
                sSQL += "'" + tTrn_Log.ExpDate + "',";
                sSQL += "'" + tTrn_Log.EndDate + "',";
                sSQL += "'" + tTrn_Log.TrnUser + "',";
                sSQL += "'" + tTrn_Log.HostName + "',";
                sSQL += "'" + tTrn_Log.Trace + "',";
                sSQL += "'" + tTrn_Log.PltCount + "',";
                sSQL += "'" + tTrn_Log.EquNo + "',";
                sSQL += tTrn_Log.PltQty + ",";
                sSQL += tTrn_Log.TrnQty + ",";
                sSQL += "'" + tTrn_Log.PltId + "',";
                sSQL += "'" + tTrn_Log.LotNo + "',";
                sSQL += "'" + tTrn_Log.InDate + "',";
                sSQL += "'" + tTrn_Log.InTktNo + "',";
                sSQL += "'" + tTrn_Log.InTktSeq + "',";
                sSQL += "'" + tTrn_Log.TrnTktNo + "',";
                sSQL += "'" + tTrn_Log.TrnTktSeq + "',";
                sSQL += "'" + tTrn_Log.ValidDate + "',";
                sSQL += "'" + tTrn_Log.ItemNo + "',";
                sSQL += "'" + tTrn_Log.Factory + "',";
                sSQL += "'" + tTrn_Log.CustomerId + "',";
                sSQL += "'" + tTrn_Log.CustomerName + "',";
                sSQL += "'" + tTrn_Log.ProviderId + "',";
                sSQL += "'" + tTrn_Log.ProviderName + "',";
                sSQL += "'" + tTrn_Log.ItemUnit + "',";
                sSQL += "'" + tTrn_Log.BoxQty + "',";
                sSQL += "'" + tTrn_Log.Remarks + "',";
                sSQL += "'" + tTrn_Log.StoreCode + "',";
                sSQL += "'" + tTrn_Log.ProdDate + "',";
                sSQL += "'" + tTrn_Log.PrintFlag + "')";

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
