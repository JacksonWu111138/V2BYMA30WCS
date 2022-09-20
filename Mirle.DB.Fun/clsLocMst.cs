using System;
using Mirle.Structure;
using Mirle.Def;
using System.Data;
using Mirle.DataBase;

namespace Mirle.DB.Fun
{
    public class clsLocMst
    {
        private clsSno sno = new clsSno();
        private clsLocDtl LocDtl = new clsLocDtl();
        public int FunGetTeachLoc_Grid(ref DataTable dtTmp, DataBase.DB db)
        {
            try
            {
                string strEM = "";
                string strSql = "select * from Teach_Loc";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
        }

        public int GetTeachLoc_byBoxID(string BoxID, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select Loc from Teach_Loc where BoxId = '{BoxID}' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet != DBResult.Success && iRet != DBResult.NoDataSelect)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                }

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public string GetTeachLoc(string DeviceID, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strEM = "";
                string strSql = $"select Loc from Teach_Loc where DeviceID = '{DeviceID}' ";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success)
                {
                    return Convert.ToString(dtTmp.Rows[0][0]);
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return string.Empty;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public int CheckIsTeach(string DeviceID, string Loc, ref bool IsTeach, DataBase.DB db)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string strSql = $"select * from Teach_Loc where DeviceID = '{DeviceID}' and Loc = '{Loc}' ";
                string strEM = "";
                int iRet = db.GetDataTable(strSql, ref dtTmp, ref strEM);
                if (iRet == DBResult.Success) IsTeach = true;
                else if (iRet == DBResult.NoDataSelect) IsTeach = false;
                else clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{strSql} => {strEM}");

                return iRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                dtTmp = null;
            }
        }

        public bool FunUpdTeachLocSts(string sDeviceID, string sLoc, clsEnum.LocSts sts, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                string strSql = "update Teach_Loc set LocSts = '" + sts.ToString() + "' ";
                strSql += ", OldSts = LocSts ";
                strSql += $", TrnDate = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}' ";
                strSql += " where Loc = '" + sLoc + "' ";
                strSql += $" and DeviceID = '{sDeviceID}' ";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
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

        public bool FunUpdTeachLocSts(string sDeviceID, string sLoc, clsEnum.LocSts sts, string sBoxID, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                string strSql = "update Teach_Loc set LocSts = '" + sts.ToString() + "' ";
                strSql += $", BoxId = '{sBoxID}' ";
                strSql += ", OldSts = LocSts ";
                strSql += $", TrnDate = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}' ";
                strSql += " where Loc = '" + sLoc + "' ";
                strSql += $" and DeviceID = '{sDeviceID}' ";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
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

        public bool FunClearTeachLoc_byBoxID(string sBoxID, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                string strSql = "update Teach_Loc set LocSts = '" + clsEnum.LocSts.N.ToString() + "' ";
                strSql += $", BoxId = '' ";
                strSql += ", OldSts = LocSts ";
                strSql += $", TrnDate = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}' ";
                strSql += " where BoxId = '" + sBoxID + "' ";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
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

        public bool FunInsTeachLoc(string sDeviceID, string sLoc, clsEnum.LocSts sts, string sBoxID, DataBase.DB db)
        {
            string strEM = "";
            try
            {
                string strSql = "insert into Teach_Loc (DeviceID, Loc, LocSts, BoxId) VALUES";
                strSql += $"('{sDeviceID}','{sLoc}','{sts.ToString()}','{sBoxID}')";
                if (db.ExecuteSQL(strSql, ref strEM) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSql);
                    return true;
                }
                else
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSql + " => " + strEM);
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
        /// Double Deep 檢查內儲位狀態
        /// </summary>
        /// <param name="strLoc">儲位編號</param>
        /// <param name="sLocDD">內儲位編號變數</param>
        /// <returns></returns>
        public int funCheckLocDDSts(string strLoc, out string sLocDD, DataBase.DB db)
        {
            string strSQL = string.Empty;
            string strErrMsg = string.Empty;
            string strLocDD = string.Empty;
            sLocDD = "";        //回傳內儲位
            int intRet = DBResult.Initial;
            DataTable drLoc = new DataTable();
            DataTable drLocDD = new DataTable();
            try
            {
                strSQL = $"SELECT {Parameter.clsLoc_Mst.Column.Loc_DD} FROM {Parameter.clsLoc_Mst.TableName} WHERE {Parameter.clsLoc_Mst.Column.Loc}='" + strLoc + "'";
                intRet =  db.GetDataTable(strSQL, ref drLoc, ref strErrMsg);
                if (intRet == DBResult.Success)
                {
                    strLocDD = drLoc.Rows[0][Parameter.clsLoc_Mst.Column.Loc_DD].ToString();
                }
                else
                {
                    return intRet;
                }

                if (!string.IsNullOrWhiteSpace(strLocDD))
                {
                    strSQL = $"SELECT {Parameter.clsLoc_Mst.Column.Equ_RowNo} FROM {Parameter.clsLoc_Mst.TableName} WHERE {Parameter.clsLoc_Mst.Column.Loc}='" + strLocDD + 
                        $"' AND {Parameter.clsLoc_Mst.Column.Loc_Sts}='{clsEnum.LocSts.L.ToString()}'";
                    intRet = db.GetDataTable(strSQL, ref drLocDD, ref strErrMsg);
                    if (intRet == DBResult.Success)
                    {
                        sLocDD = strLocDD;
                    }
                }

                return intRet;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return DBResult.Exception;
            }
            finally
            {
                drLoc.Dispose();
                drLocDD.Dispose();
            }
        }

        public bool FunUpdLocSts_Mode_In(CmdMstInfo cmd, DataBase.DB db)
        {
            try
            {
                string sLocSts = ""; string sOldLocSts = clsEnum.LocSts.I.ToString();
                switch (cmd.IO_Type)
                {
                    case clsConstValue.clsDec_IoType.stkIn_MergePlt:
                    case clsConstValue.clsDec_IoType.stkIn_Offline:
                        sLocSts = clsEnum.LocSts.S.ToString();
                        break;
                    case clsConstValue.clsDec_IoType.stkIn_EmptyPlt:
                        sLocSts = clsEnum.LocSts.E.ToString();
                        break;
                    default:
                        sLocSts = clsEnum.LocSts.S.ToString();
                        break;
                }

                if (string.IsNullOrWhiteSpace(cmd.Loc)) return true;
                else
                {
                    string strErrMsg = string.Empty;
                    string sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sLocSts + 
                        $"', {Parameter.clsLoc_Mst.Column.Old_Sts}='" + sOldLocSts + "' ";
                    sSQL = sSQL + $", {Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                    sSQL = sSQL + $", {Parameter.clsLoc_Mst.Column.Trn_User} = '" + cmd.Trn_User + "' ";
                    sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + cmd.Loc + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + cmd.WH_ID + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sOldLocSts + "' ";
                    if(db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
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
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunUpdLocStsCnl_Mode_In(CmdMstInfo tCmd_Mst, DataBase.DB db)
        {
            try
            {
                string sOldLocSts = clsEnum.LocSts.I.ToString();
                switch (tCmd_Mst.IO_Type)
                {
                    case clsConstValue.clsDec_IoType.stkIn_EmptyPlt:
                    case clsConstValue.clsDec_IoType.stkIn_Offline:
                    case clsConstValue.clsDec_IoType.stkIn_Mold://v1.10
                    case clsConstValue.clsDec_IoType.stkIn_Tkt:
                        if (tCmd_Mst.Loc == "") return true;
                        else
                        {
                            string sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                                $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = {Parameter.clsLoc_Mst.Column.Old_Sts}," +
                                $" {Parameter.clsLoc_Mst.Column.Old_Sts} = {Parameter.clsLoc_Mst.Column.Loc_Sts}";
                            sSQL = sSQL + $", {Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                            sSQL = sSQL + $" WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                            sSQL = sSQL + $" AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "'";
                            sSQL = sSQL + $" AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sOldLocSts + "' ";

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
                    case clsConstValue.clsDec_IoType.stkIn_MergePlt:
                        return true;
                    default:
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

        public bool FunUpdLocStsCnl_Mode_Out(CmdMstInfo tCmd_Mst, DataBase.DB db)
        {
            try
            {
                string sSQL = "";
                string sLocSts = ""; string sOldLocSts = "";
                switch (tCmd_Mst.IO_Type)
                {

                    case clsConstValue.clsDec_IoType.stkOut_ShipmentOrder:
                    case clsConstValue.clsDec_IoType.stkOut_Shipment:
                    case clsConstValue.clsDec_IoType.stkOut_MergePlt:
                    default:
                        sLocSts = clsEnum.LocSts.S.ToString();
                        sOldLocSts = clsEnum.LocSts.O.ToString();
                        break;
                    case clsConstValue.clsDec_IoType.stkOut_EmptyPlt:
                        sLocSts = clsEnum.LocSts.E.ToString(); 
                        sOldLocSts = clsEnum.LocSts.O.ToString();
                        break;
                    case clsConstValue.clsDec_IoType.stkCycle_Loc:
                    case clsConstValue.clsDec_IoType.stkCycle_Item:
                        sLocSts = clsEnum.LocSts.S.ToString(); 
                        sOldLocSts = clsEnum.LocSts.C.ToString();
                        break;
                }

                if (tCmd_Mst.Loc == "") return true;
                else
                {
                    sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sLocSts + "'";
                    sSQL = sSQL + $" WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                    sSQL = sSQL + $" AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "'";
                    sSQL = sSQL + $" AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sOldLocSts + "'";

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
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunUpdLocSts_Mode_Out(CmdMstInfo cmd, string strLocDD, DataBase.DB db)
        {
            try
            {
                string sSQL = "";
                string sLocSts = ""; string sOldLocSts = "";
                switch (cmd.IO_Type)
                {

                    case clsConstValue.clsDec_IoType.stkOut_ShipmentOrder:
                    case clsConstValue.clsDec_IoType.stkOut_Shipment:
                    case clsConstValue.clsDec_IoType.stkOut_MergePlt:
                    case clsConstValue.clsDec_IoType.stkOut_Mold:    //v1.05
                        if (cmd.Cmd_Mode == clsConstValue.CmdMode.StockOut)
                        {
                            sLocSts = clsEnum.LocSts.N.ToString(); 
                            sOldLocSts = clsEnum.LocSts.O.ToString();
                        }
                        else
                        {
                            sLocSts = clsEnum.LocSts.S.ToString();
                            sOldLocSts = clsEnum.LocSts.O.ToString();
                        }
                        break;
                    case clsConstValue.clsDec_IoType.stkOut_EmptyPlt:
                        sLocSts = clsEnum.LocSts.N.ToString();
                        sOldLocSts = clsEnum.LocSts.O.ToString();
                        break;
                    case clsConstValue.clsDec_IoType.stkCycle_Loc:
                    case clsConstValue.clsDec_IoType.stkCycle_Item:
                        sLocSts = clsEnum.LocSts.P.ToString(); 
                        sOldLocSts = clsEnum.LocSts.C.ToString();
                        break;
                    default:
                        return false;
                }

                if (string.IsNullOrWhiteSpace(cmd.Loc)) return true;
                else
                {
                    sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sLocSts + "', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_User} = '" + cmd.Trn_User + "' ";
                    sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + cmd.Loc + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + cmd.WH_ID + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '" + sOldLocSts + "' ";

                    string strErrMsg = "";
                    if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strErrMsg}");
                        return false;
                    }

                    string strSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Loc_Sts}='{clsEnum.LocSts.N.ToString()}'" +
                        $" WHERE {Parameter.clsLoc_Mst.Column.Loc}='" + strLocDD +
                        $"' AND {Parameter.clsLoc_Mst.Column.Loc_Sts}='{clsEnum.LocSts.L.ToString()}'";   //更新內儲位
                    int iRet = db.ExecuteSQL(strSQL, ref strErrMsg);
                    if (iRet == DBResult.Success || iRet == DBResult.NoDataUpdate)
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strSQL);
                        return true;
                    }
                    else
                    {
                        clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, strSQL + " => " + strErrMsg);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }

        public bool FunUpdLocSts_Mode_R2R(CmdMstInfo tCmd_Mst, DataBase.DB db)
        {
            try
            {
                string sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                    $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.S.ToString()}', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Cycle_Date} = '', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_User} = '" + tCmd_Mst.Trn_User + "' ";
                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.New_Loc + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.I.ToString()}' ";

                string strErrMsg = string.Empty;
                if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);

                    sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.N.ToString()}', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Cycle_Date} = '', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_User} = '" + tCmd_Mst.Trn_User + "' ";
                    sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.O.ToString()}' ";
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

        public bool FunUpdLocStsCnl_Mode_R2R(CmdMstInfo tCmd_Mst, DataBase.DB db)
        {
            try
            {
                string sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                    $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.S.ToString()}', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Cycle_Date} = '', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_User} = '" + tCmd_Mst.Trn_User + "' ";
                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.WH_ID} = '" + tCmd_Mst.WH_ID + "' ";
                sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.O.ToString()}' ";

                string strErrMsg = string.Empty;
                if (db.ExecuteSQL(sSQL, ref strErrMsg) == DBResult.Success)
                {
                    clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, sSQL);

                    sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.N.ToString()}', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Cycle_Date} = '', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Trn_User} = '" + tCmd_Mst.Trn_User + "' ";
                    sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.New_Loc + "' ";
                    sSQL = sSQL + $"AND {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.I.ToString()}' ";
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
        /// 更新儲位使用率和混載數
        /// </summary>
        /// <param name="tCmd_Mst"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool FunCmd_LocMixQty(CmdMstInfo tCmd_Mst, DataBase.DB db)
        {
            try
            {
                if (tCmd_Mst.Loc == "") { return false; }

                string strErrMsg = string.Empty;
                string sSQL = "";
                int iMixQty = 0;
                double dAvail = 0;

                iMixQty = LocDtl.FunGetMixQty(tCmd_Mst.Loc, db);
                dAvail = LocDtl.FunGetAvail(tCmd_Mst.Loc, db);

                sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                    $" {Parameter.clsLoc_Mst.Column.Mix_Qty} = " + iMixQty + ", ";
                sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Avail} = " + dAvail + " ";
                sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "' ";
                if (db.ExecuteSQL(sSQL) == DBResult.Success)
                {
                    //Success
                }

                if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.L2L)
                {
                    iMixQty = LocDtl.FunGetMixQty(tCmd_Mst.New_Loc, db);
                    dAvail = LocDtl.FunGetAvail(tCmd_Mst.New_Loc, db);

                    sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                        $" {Parameter.clsLoc_Mst.Column.Mix_Qty} = " + iMixQty + ", ";
                    sSQL = sSQL + $"{Parameter.clsLoc_Mst.Column.Avail} = " + dAvail + " ";
                    sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.New_Loc + "' ";
                    if (db.ExecuteSQL(sSQL) == DBResult.Success)
                    {
                        //Success
                    }
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

        public bool FunLocSts_S_LocDtl_Null(CmdMstInfo tCmd_Mst, string strLocDtl13, DataBase.DB db)
        {
            DataTable ds = new DataTable();
            try
            {
                if (tCmd_Mst.Cmd_Mode == clsConstValue.CmdMode.Cycle)
                {
                    //該儲位是否還有庫存(如沒有會Select Fail)
                    string sSQL = $"SELECT * FROM {Parameter.clsLoc_Dtl.TableName}" +
                        $" WHERE {Parameter.clsLoc_Dtl.Column.Loc} = '" + tCmd_Mst.Loc + "'";
                    string strEM = "";
                    if (db.GetDataTable(sSQL, ref ds) == DBResult.NoDataSelect)
                    {
                        //更新LOC_MST(無庫存 將狀態改為E)
                        sSQL = $"UPDATE {Parameter.clsLoc_Mst.TableName} SET" +
                            $" {Parameter.clsLoc_Mst.Column.Loc_Sts} = '{clsEnum.LocSts.E.ToString()}'";
                        sSQL = sSQL + $" ,{Parameter.clsLoc_Mst.Column.Trn_Date} = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        sSQL = sSQL + $" ,{Parameter.clsLoc_Mst.Column.Trn_User} = '" + tCmd_Mst.Trn_User + "' ";
                        sSQL = sSQL + $"WHERE {Parameter.clsLoc_Mst.Column.Loc} = '" + tCmd_Mst.Loc + "'";

                        if (db.TransactionCtrl(TransactionTypes.Begin) != DBResult.Success) return false;
                        if (db.ExecuteSQL(sSQL, ref strEM) == DBResult.Success)
                        {
                            //新增EmptyPlt(空棧板)的Loc_Dtl
                            sSQL = $"INSERT INTO {Parameter.clsLoc_Dtl.TableName} (" +
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
                            sSQL += "'" + sno.FunGetSeqNo(clsEnum.enuSnoType.LOCTXNO, db) + "',";//LOC_TXNO
                            sSQL += "'" + tCmd_Mst.WH_ID + "',";//WH_ID
                            sSQL += "'" + tCmd_Mst.Loc + "',";//LOC
                            sSQL += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',";//IN_DATE
                            sSQL += "'',";//PLT_ID
                            sSQL += "'',";//LOT_NO
                            sSQL += "'1',";//PLT_QTY
                            sSQL += "'0',";//ALO_QTY
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "(select top 1 Item_No from Itm_Mst where Item_Grp ='EmptyPlt' ),";//LOCDTL04
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'',";
                            sSQL += "'0.00',";//LOCDTL11
                            sSQL += "'',";
                            sSQL += "'" + strLocDtl13 + "',";
                            sSQL += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                            if (db.ExecuteSQL(sSQL, ref strEM) != DBResult.Success)
                            {
                                db.TransactionCtrl(TransactionTypes.Rollback);
                                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"{sSQL} => {strEM}");
                                return false;
                            }

                            db.TransactionCtrl(TransactionTypes.Commit);
                            return true;
                        }
                        else
                        {
                            db.TransactionCtrl(TransactionTypes.Rollback);
                            return false;
                        }
                    }
                    else return true;
                }
                else return true;
            }
            catch (Exception ex)
            {
                db.TransactionCtrl(TransactionTypes.Rollback);
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
            finally
            {
                ds.Dispose();
            }
        }
    }
}
