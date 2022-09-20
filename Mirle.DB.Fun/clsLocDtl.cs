using System;
using Mirle.Structure;
using Mirle.DataBase;
using Mirle.Def;
using System.Data;
using System.Collections.Generic;

namespace Mirle.DB.Fun
{
    public class clsLocDtl
    {
        private clsTrnLog TrnLog = new clsTrnLog();
        private clsMoldUseLog MoldUseLog = new clsMoldUseLog();
        private clsTKT_MST TKT_MST = new clsTKT_MST();
        public int FunGetMixQty(string sLoc, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            string sSQL = "";
            int iCnt = 0;
            DataTable dbRS = new DataTable();
            sSQL = $"SELECT COUNT(*) FROM {Parameter.clsLoc_Dtl.TableName}" +
                $" WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + sLoc + "' ";
            if (db.GetDataTable(sSQL, ref dbRS, ref strErrMsg) == DBResult.Success)
            {
                iCnt = Convert.ToInt32(dbRS.Rows[0][0]);
            }
            dbRS.Dispose();
            return iCnt;
        }

        public double FunGetAvail(string sLoc, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            string sSQL = ""; DataTable dbRS = new DataTable();
            double dAvail = 0; int iPltQty = 0; int iMaxPlt = 0;

            sSQL = $"SELECT D.{Parameter.clsLoc_Dtl.Column.ItemNo}," +
                $"D.{Parameter.clsLoc_Dtl.Column.Plt_Qty},I.{Parameter.clsItmMst.Column.Qty_Plt} ";
            sSQL = sSQL + $"FROM {Parameter.clsLoc_Dtl.TableName} D LEFT JOIN {Parameter.clsItmMst.TableName} I ";
            sSQL = sSQL + $"ON D.{Parameter.clsLoc_Dtl.Column.ItemNo} = I.{Parameter.clsItmMst.Column.Item_No} ";
            sSQL = sSQL + $"WHERE D.{Parameter.clsLoc_Dtl.Column.Loc} = '" + sLoc + "' ";
            if (db.GetDataTable(sSQL, ref dbRS, ref strErrMsg) == DBResult.Success)
            {
                iPltQty = Convert.ToInt32(dbRS.Rows[0][Parameter.clsLoc_Dtl.Column.Plt_Qty]);
                iMaxPlt = Convert.ToInt32(dbRS.Rows[0][Parameter.clsItmMst.Column.Qty_Plt]);
                if (iMaxPlt == 0)
                {
                    dAvail = dAvail + 0;
                }
                else
                {
                    dAvail = dAvail + Math.Round(iPltQty / (double)iMaxPlt * 100, 2);
                }
                if (dAvail > 100)
                {
                    dAvail = 100;
                }
            }

            dbRS.Dispose();
            return dAvail;
        }

        public bool FunLocDtl_Mode_In(CmdMstInfo tCmd_Mst,
                                      List<LocDtlInfo> tLoc_Dtl,
                                      List<TrnLogInfo> tTrn_Log,
                                      List<MoldUseLogInfo> tMoldUseLog,
                                      DataBase.DB db)
        {
            try
            {
                #region 一般入庫 (不含單據入庫)
                //寫入儲位明細中
                if ((tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockIn) &&
                    (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_EmptyPlt || tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Offline ||
                     tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Mold))     //v1.02 模具入庫 by Ian
                {
                    foreach(var locdtl in tLoc_Dtl)
                    {
                        if (!FunInsLocDtl(locdtl, db)) return false;
                    }

                    foreach(var trnlog in tTrn_Log)
                    {
                        if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                    }

                    //v1.02  增加模具log
                    if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Mold)
                    {
                        foreach(var mold in tMoldUseLog)
                        {
                            if (!MoldUseLog.FunInsMoldUseLog(mold, db)) return false;
                        }
                    }

                    return true;
                }
                #endregion

                #region 併板入庫
                //寫入儲位明細中
                if ((tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockIn) &&
                    (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_MergePlt))
                {
                    string sSQL = string.Empty;
                    foreach(var locdtl in tLoc_Dtl)
                    {
                        if ((locdtl.PltQty != 0) && (locdtl.AloQty != 0))
                        {
                            if (!FunUpdLocDtl_ForMerge(locdtl, db)) return false;
                        }
                        else if (locdtl.PltQty == 0)
                        {
                            if (!FunInsLocDtl(locdtl, db)) return false;
                        }

                        //併板入庫完成，更新 LOC_DTL_LOG 狀態
                        sSQL = $"UPDATE {Parameter.clsLoc_Dtl_Log.TableName} SET" +
                            $" {Parameter.clsLoc_Dtl_Log.Column.Merge_Sts} = '" + clsConstValue.clsDec_MergeSts.Merge_Finish + "'";
                        sSQL += $" WHERE {Parameter.clsLoc_Dtl_Log.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                        sSQL += $" AND {Parameter.clsLoc_Dtl_Log.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "'";

                        string strErrMsg = "";
                        if (db.ExecuteSQL(sSQL, ref strErrMsg) != DBResult.Success)
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strErrMsg}");
                            return false;
                        }
                    }

                    foreach(var trnlog in tTrn_Log)
                    {
                        if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                    }

                    return true;
                }
                #endregion

                #region 單據入庫
                //寫入儲位明細中
                if ((tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockIn) &&
                    (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Tkt))
                {
                    foreach(var locdtl in tLoc_Dtl)
                    {
                        if (!FunInsLocDtl(locdtl, db)) return false;
                        if (!TKT_MST.FunCmdFinishUpdTkt(locdtl, db)) return false;
                    }

                    foreach(var trnlog in tTrn_Log)
                    {
                        if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                    }

                    return true;
                }
                #endregion

                #region 一般入庫(加料)  //v1.01 
                //寫入儲位明細中
                if ((tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.Cycle) &&
                    (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Tkt || tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Offline ||
                     tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Mold))
                {

                    foreach(var locdtl in tLoc_Dtl)
                    {
                        if(!FunUpdLocDtl_ForMerge(locdtl, db))
                        {
                            if (!FunInsLocDtl(locdtl, db)) return false;
                        }

                        if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Tkt)
                        {
                            if (!TKT_MST.FunCmdFinishUpdTkt(locdtl, db)) return false;
                        }
                    }

                    foreach (var trnlog in tTrn_Log)
                    {
                        if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                    }

                    if(tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_Mold)
                    {
                        foreach (var mold in tMoldUseLog)
                        {
                            if (!MoldUseLog.FunInsMoldUseLog(mold, db)) return false;
                        }
                    }

                    return true;
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunLocDtlCnl_Mode_In(CmdMstInfo tCmd_Mst, List<LocDtlInfo> tLoc_Dtl, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                #region 單據入庫
                if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockIn)
                {
                    foreach (var locdtl in tLoc_Dtl)
                    {
                        if (!TKT_MST.FunCmdCancelUpdTkt(locdtl, clsConstValue.clsDec_TktSts.Runing, db)) return false;
                    }
                }
                #endregion
                #region 併板入庫
                if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockIn &&
                    tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkIn_MergePlt)
                {
                    string sSQL = string.Empty;
                    foreach (var locdtl in tLoc_Dtl)
                    {
                        sSQL = $"UPDATE {Parameter.clsLoc_Dtl_Log.TableName} SET" +
                            $" {Parameter.clsLoc_Dtl_Log.Column.Merge_Sts} = '" + clsConstValue.clsDec_MergeSts.Merge_Inital + "'";
                        sSQL += $" WHERE {Parameter.clsLoc_Dtl_Log.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                        sSQL += $" AND {Parameter.clsLoc_Dtl_Log.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "'";
                        if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                            return false;
                        }
                    }
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunLocDtl_Mode_Out(CmdMstInfo tCmd_Mst,
                                      List<LocDtlInfo> tLoc_Dtl,
                                      List<TrnLogInfo> tTrn_Log,
                                      List<MoldUseLogInfo> tMoldUseLog,
                                      DataBase.DB db)
        {
            try
            {
                string sSQL = ""; string strEM = "";
                #region 盤點出庫
                if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkCycle_Loc || tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkCycle_Item)
                {
                    //2015.12.03 v1.0.0.3 不更新盤點狀態
                    foreach(var locdtl in tLoc_Dtl)
                    {
                        //將過帳
                        sSQL = $"UPDATE {Parameter.clsCycle.TableName} SET" +
                            $" {Parameter.clsCycle.Column.Use_Set} = '{clsConstValue.YesNo.No}'";
                        sSQL += $" WHERE {Parameter.clsCycle.Column.Cyc_No} = '" + locdtl.CycNo + "'";
                        sSQL += $" AND {Parameter.clsCycle.Column.Loc_Txno} = '" + locdtl.LocTxno + "' ";
                        if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                            return false;
                        }
                    }
                }
                else if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkOut_MergePlt)    //併板出庫
                {
                    foreach (var locdtl in tLoc_Dtl)
                    {
                        sSQL = $"DELETE FROM {Parameter.clsLoc_Dtl.TableName} WHERE" +
                            $" {Parameter.clsLoc_Dtl.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                        sSQL += $" AND {Parameter.clsLoc_Dtl.Column.WH_ID} = '" + clsConstValue.clsDec_Wh_Id.ASRS + "'";
                        sSQL += $" AND {Parameter.clsLoc_Dtl.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                        if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                            return false;
                        }

                        if (!FunInsLocDtl_Log(locdtl, db)) return false;
                    }
                }
                else
                {
                    if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.StockOut)   //出庫
                    {
                        foreach (var locdtl in tLoc_Dtl)
                        {
                            sSQL = $"DELETE FROM {Parameter.clsLoc_Dtl.TableName} WHERE" +
                                $" {Parameter.clsLoc_Dtl.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                            sSQL += $" AND {Parameter.clsLoc_Dtl.Column.WH_ID} = '" + clsConstValue.clsDec_Wh_Id.ASRS + "'";
                            sSQL += $" AND {Parameter.clsLoc_Dtl.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                            if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                            {
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                                return false;
                            }
                        }

                    }
                    else if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.Cycle)  //撿料
                    {
                        foreach (var locdtl in tLoc_Dtl)
                        {
                            double iQty = locdtl.PltQty - locdtl.AloQty;
                            if (iQty <= 0)
                            {
                                sSQL = $"DELETE FROM {Parameter.clsLoc_Dtl.TableName} ";
                                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + locdtl.Loc + 
                                    $"' AND {Parameter.clsLoc_Dtl.Column.Loc_Txno} = '" + locdtl.LocTxno + "' ";
                            }
                            else
                            {
                                sSQL = $"UPDATE {Parameter.clsLoc_Dtl.TableName} SET" +
                                    $" {Parameter.clsLoc_Dtl.Column.Plt_Qty} = " + iQty + $",{Parameter.clsLoc_Dtl.Column.Alo_Qty} = 0 ";
                                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + locdtl.Loc + 
                                    $"' AND {Parameter.clsLoc_Dtl.Column.Loc_Txno} = '" + locdtl.LocTxno + "' ";
                            }

                            if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                            {
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                                return false;
                            }
                        }
                    }
                }

                foreach (var trnlog in tTrn_Log)
                {
                    if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                }

                //v1.05  增加模具log
                if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkOut_Mold)
                {
                    foreach (var mold in tMoldUseLog)
                    {
                        if (!MoldUseLog.FunInsMoldUseLog(mold, db)) return false;
                    }
                }

                return true;
                #endregion
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunLocDtlCnl_Mode_Out(CmdMstInfo tCmd_Mst, List<LocDtlInfo> tLoc_Dtl, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                #region 盤點出庫
                if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkCycle_Loc || 
                    tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkCycle_Item)
                {
                    foreach (var locdtl in tLoc_Dtl)
                    {
                        string sSQL = $"UPDATE {Parameter.clsCycle.TableName} SET {Parameter.clsCycle.Column.Use_Set} = 'C'";
                        sSQL = sSQL + $" WHERE {Parameter.clsCycle.Column.Loc} = '" + locdtl.Loc + "'";
                        sSQL = sSQL + $" AND {Parameter.clsCycle.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "'";
                        sSQL = sSQL + $" AND {Parameter.clsCycle.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                        sSQL = sSQL + $" AND {Parameter.clsCycle.Column.Cyc_No} = '" + locdtl.CycNo + "'";
                        if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                        {
                            clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                            return false;
                        }
                    }
                }
                #endregion

                #region 單據出庫
                if (tCmd_Mst.IO_Type == clsConstValue.clsDec_IoType.stkOut_ShipmentOrder)
                {
                    foreach (var locdtl in tLoc_Dtl)
                    {
                        if (!TKT_MST.FunCmdCancelUpdTkt(locdtl, clsConstValue.clsDec_TktSts.Runing, db)) return false;
                    }
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunLocDtl_Mode_R2R(CmdMstInfo tCmd_Mst,
                                     List<LocDtlInfo> tLoc_Dtl,
                                     List<TrnLogInfo> tTrn_Log,
                                     DataBase.DB db)
        {
            try
            {

                foreach (var locdtl in tLoc_Dtl)
                {
                    string sSQL = $"UPDATE {Parameter.clsLoc_Dtl.TableName} SET" +
                        $" {Parameter.clsLoc_Dtl.Column.Loc} = '" + tCmd_Mst.New_Loc + "'";
                    sSQL += $" WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                    sSQL += $" AND {Parameter.clsLoc_Dtl.Column.Loc_Txno} = '" + locdtl.LocTxno + "'";
                    sSQL += $" AND {Parameter.clsLoc_Dtl.Column.WH_ID} = '" + locdtl.WhId + "'";

                    string strEM = "";
                    if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                        return false;
                    }
                }

                foreach (var trnlog in tTrn_Log)
                {
                    if (!TrnLog.FunInsTrnLog(trnlog, db)) return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunInsLocDtl(LocDtlInfo tLoc_Dtl, DataBase.DB db)
        {
            try
            {
                string sSQL = $"INSERT INTO {Parameter.clsLoc_Dtl.TableName} (" +
                               $"{Parameter.clsLoc_Dtl.Column.Loc_Txno},{Parameter.clsLoc_Dtl.Column.WH_ID}," +
                               $"{Parameter.clsLoc_Dtl.Column.Loc},{Parameter.clsLoc_Dtl.Column.IN_Date}," +
                               $"{Parameter.clsLoc_Dtl.Column.Plt_Id},{Parameter.clsLoc_Dtl.Column.Lot_No}," +
                               $"{Parameter.clsLoc_Dtl.Column.Plt_Qty},{Parameter.clsLoc_Dtl.Column.Alo_Qty}," +
                               $"{Parameter.clsLoc_Dtl.Column.Tkt_Type},{Parameter.clsLoc_Dtl.Column.TktNo},";
                sSQL += $"{Parameter.clsLoc_Dtl.Column.Line},{Parameter.clsLoc_Dtl.Column.ShelfLife}," +
                    $"{Parameter.clsLoc_Dtl.Column.ItemNo},{Parameter.clsLoc_Dtl.Column.Factory}," +
                    $"{Parameter.clsLoc_Dtl.Column.ClientNo},{Parameter.clsLoc_Dtl.Column.ClientName}," +
                    $"{Parameter.clsLoc_Dtl.Column.SupplierNo},{Parameter.clsLoc_Dtl.Column.SupplierName}";
                sSQL += $",{Parameter.clsLoc_Dtl.Column.Unit},{Parameter.clsLoc_Dtl.Column.BoxCount}," +
                    $"{Parameter.clsLoc_Dtl.Column.Remark},{Parameter.clsLoc_Dtl.Column.WH_Type}," +
                    $"{Parameter.clsLoc_Dtl.Column.BeginDate})VALUES (";

                sSQL += "'" + tLoc_Dtl.LocTxno + "',";
                sSQL += "'" + tLoc_Dtl.WhId + "',";
                sSQL += "'" + tLoc_Dtl.Loc + "',";
                sSQL += "'" + tLoc_Dtl.InDate + "',";
                sSQL += "'" + tLoc_Dtl.PltId + "',";
                sSQL += "'" + tLoc_Dtl.LotNo + "',";
                sSQL += tLoc_Dtl.AloQty + ",";
                sSQL += "0,";                             //預約量為0
                sSQL += "'" + tLoc_Dtl.TktType + "',";
                sSQL += "'" + tLoc_Dtl.TktNo + "',";
                sSQL += "'" + tLoc_Dtl.TktSeq + "',";
                sSQL += "'" + tLoc_Dtl.ValidDate + "',";
                sSQL += "'" + tLoc_Dtl.ItemNo + "',";
                sSQL += "'" + tLoc_Dtl.Factory + "',";
                sSQL += "'" + tLoc_Dtl.CustomerId + "',";
                sSQL += "'" + tLoc_Dtl.CustomerName + "',";
                sSQL += "'" + tLoc_Dtl.ProviderId + "',";
                sSQL += "'" + tLoc_Dtl.ProviderName + "',";
                sSQL += "'" + tLoc_Dtl.ItemUnit + "',";
                sSQL += "'" + tLoc_Dtl.BoxQty + "',";
                sSQL += "'" + tLoc_Dtl.Remarks + "',";
                sSQL += "'" + tLoc_Dtl.StoreCode + "',";
                sSQL += "'" + tLoc_Dtl.ProdDate + "')";
                
                string strErrMsg = "";
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

        /// <summary>
        /// 寫入Loc_Dtl_Log   for 併板出庫
        /// </summary>
        /// <param name="tLoc_Dtl">LOC_DTL 結構</param>
        /// <returns></returns>
        public bool FunInsLocDtl_Log(LocDtlInfo tLoc_Dtl, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            string sSQL = string.Empty;

            sSQL = $"INSERT INTO {Parameter.clsLoc_Dtl_Log.TableName} (" +
                               $"{Parameter.clsLoc_Dtl_Log.Column.Loc_Txno},{Parameter.clsLoc_Dtl_Log.Column.WH_ID}," +
                               $"{Parameter.clsLoc_Dtl_Log.Column.Loc},{Parameter.clsLoc_Dtl_Log.Column.IN_Date}," +
                               $"{Parameter.clsLoc_Dtl_Log.Column.Plt_Id},{Parameter.clsLoc_Dtl_Log.Column.Lot_No}," +
                               $"{Parameter.clsLoc_Dtl_Log.Column.Plt_Qty},{Parameter.clsLoc_Dtl_Log.Column.Alo_Qty}," +
                               $"{Parameter.clsLoc_Dtl_Log.Column.Tkt_Type},{Parameter.clsLoc_Dtl_Log.Column.TktNo},";
            sSQL += $"{Parameter.clsLoc_Dtl_Log.Column.Line},{Parameter.clsLoc_Dtl_Log.Column.ShelfLife}," +
                $"{Parameter.clsLoc_Dtl_Log.Column.ItemNo},{Parameter.clsLoc_Dtl_Log.Column.Factory}," +
                $"{Parameter.clsLoc_Dtl_Log.Column.ClientNo},{Parameter.clsLoc_Dtl_Log.Column.ClientName}," +
                $"{Parameter.clsLoc_Dtl_Log.Column.SupplierNo},{Parameter.clsLoc_Dtl_Log.Column.SupplierName}";
            sSQL += $",{Parameter.clsLoc_Dtl_Log.Column.Unit},{Parameter.clsLoc_Dtl_Log.Column.BoxCount}," +
                $"{Parameter.clsLoc_Dtl_Log.Column.Remark},{Parameter.clsLoc_Dtl_Log.Column.WH_Type}," +
                $"{Parameter.clsLoc_Dtl_Log.Column.BeginDate})VALUES (";
            sSQL += "'" + tLoc_Dtl.LocTxno + "',";
            sSQL += "'" + tLoc_Dtl.WhId + "',";
            sSQL += "'',";                              //Loc
            sSQL += "'" + tLoc_Dtl.InDate + "',";
            sSQL += "'" + tLoc_Dtl.PltId + "',";
            sSQL += "'" + tLoc_Dtl.LotNo + "',";
            sSQL += tLoc_Dtl.AloQty + ",";
            sSQL += "0,";                             //預約量為0
            sSQL += "'" + tLoc_Dtl.TktType + "',";
            sSQL += "'N',";                           //併板狀態
            sSQL += "'" + tLoc_Dtl.TktNo + "',";
            sSQL += "'" + tLoc_Dtl.TktSeq + "',";
            sSQL += "'" + tLoc_Dtl.ValidDate + "',";
            sSQL += "'" + tLoc_Dtl.ItemNo + "',";
            sSQL += "'" + tLoc_Dtl.Factory + "',";
            sSQL += "'" + tLoc_Dtl.CustomerId + "',";
            sSQL += "'" + tLoc_Dtl.CustomerName + "',";
            sSQL += "'" + tLoc_Dtl.ProviderId + "',";
            sSQL += "'" + tLoc_Dtl.ProviderName + "',";
            sSQL += "'" + tLoc_Dtl.ItemUnit + "',";
            sSQL += "'" + tLoc_Dtl.BoxQty + "',";
            sSQL += "'" + tLoc_Dtl.Remarks + "',";
            sSQL += "'" + tLoc_Dtl.StoreCode + "',";
            sSQL += "'" + tLoc_Dtl.ProdDate + "')";

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

        public bool FunUpdLocDtl_ForMerge(LocDtlInfo tLoc_Dtl, DataBase.DB db)
        {
            string strErrMsg = string.Empty;
            double dblPltQty = 0;
            try
            {
                dblPltQty = tLoc_Dtl.PltQty + tLoc_Dtl.AloQty;  //庫存量 + 預約量 for 加料入庫 only

                string sSQL = $"UPDATE {Parameter.clsLoc_Dtl.TableName} SET" +
                    $" {Parameter.clsLoc_Dtl.Column.Plt_Qty} = {Parameter.clsLoc_Dtl.Column.Plt_Qty} + " + dblPltQty + " ";
                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + tLoc_Dtl.Loc + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Dtl.Column.ItemNo} = '" + tLoc_Dtl.ItemNo + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Dtl.Column.Lot_No} = '" + tLoc_Dtl.LotNo + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Dtl.Column.IN_Date} = '" + tLoc_Dtl.InDate + "' ";
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

        /// <summary>
        /// 刪除過期併板暫存資料
        /// </summary>
        /// <param name="dblDay">刪除幾天之前</param>
        /// <returns></returns>
        public bool FunDelLocDtlLog(double dblDay, DataBase.DB db)
        {
            try
            {
                string strLogString = string.Empty;
                DateTime dtDay = DateTime.Today;
                string strDelDay = dtDay.Date.AddDays(dblDay * (-1)).ToString("yyyy-MM-dd");

                string strSQL = $"DELETE FROM {Parameter.clsLoc_Dtl_Log.TableName} WHERE" +
                    $" {Parameter.clsLoc_Dtl_Log.Column.Merge_Sts} IN ('{clsConstValue.clsDec_MergeSts.Merge_Finish}')" +
                    $" AND {Parameter.clsLoc_Dtl_Log.Column.IN_Date} < '" + strDelDay + "'";
                string strEM = "";
                int intRet = db.ExecuteSQL(strSQL, ref strEM);
                if (intRet == DBResult.Success)
                {
                    //刪除成功
                    strLogString = "刪除" + dblDay + "天前完成過帳之併板資料成功";
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strLogString);
                    return true;
                }
                else if(intRet == DBResult.Exception)
                {
                    strLogString = "刪除" + dblDay + "天前完成過帳之併板資料失敗(LOC_DTL_LOG)." + strEM;
                    throw new Exception(strLogString);
                }

                return false;
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
