using System;
using System.Collections.Generic;
using Mirle.Structure;
using System.Data;
using Mirle.Def;
using Mirle.DataBase;

namespace Mirle.DB.Fun
{
    public class clsSno
    {
        private clsCmd_Mst cmd_Mst = new clsCmd_Mst();
        public string FunGetSeqNo(clsEnum.enuSnoType objType, DataBase.DB db)
        {
            int intGetCnt = 0;
            long lngSeq1 = 0;
            long lngSeq2 = 0;
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strMonthFlag = string.Empty;     //月異動 Y/N
            //string strDayFlag = string.Empty;       //v1.0 日異動 Y/N by Ian
            int intSnoLen = 0;                      //Sno_Len 序號長度

            DataTable dtSno = new DataTable();
            int intRtn;

            try
            {

            ProNext:

                intGetCnt = intGetCnt + 1;

                strSql = $"SELECT C.{Parameter.clsSno_Ctl.Column.Sno_Type},C.{Parameter.clsSno_Ctl.Column.Trn_Month}," +
                    $"C.{Parameter.clsSno_Ctl.Column.Sno},M.{Parameter.clsSno_Max.Column.Month_Flag}," +
                    $"M.{Parameter.clsSno_Max.Column.Init_Sno},M.{Parameter.clsSno_Max.Column.Max_Sno}," +
                    $"M.{Parameter.clsSno_Max.Column.Sno_Len} FROM {Parameter.clsSno_Ctl.TableName} C LEFT JOIN ";
                strSql += $"{Parameter.clsSno_Max.TableName} M ON " +
                    $"C.{Parameter.clsSno_Ctl.Column.Sno_Type}=M.{Parameter.clsSno_Max.Column.Sno_Type}";
                strSql += $" WHERE C.{Parameter.clsSno_Ctl.Column.Sno_Type}='" + objType.ToString() + "'";

                intRtn = db.GetDataTable(strSql, ref dtSno, ref strEM);
                if (intRtn == DBResult.Success)
                {
                    lngSeq2 = int.Parse(dtSno.Rows[0][Parameter.clsSno_Ctl.Column.Sno].ToString());
                    strMonthFlag = dtSno.Rows[0][Parameter.clsSno_Max.Column.Month_Flag].ToString();

                    if (dtSno.Rows[0][Parameter.clsSno_Max.Column.Sno_Len].ToString() == "")
                        intSnoLen = 0;
                    else
                    {
                        intSnoLen = int.Parse(dtSno.Rows[0][Parameter.clsSno_Max.Column.Sno_Len].ToString());
                    }

                    if (lngSeq2 >= int.Parse(dtSno.Rows[0][Parameter.clsSno_Max.Column.Max_Sno].ToString()))
                    {
                        lngSeq1 = int.Parse(dtSno.Rows[0][Parameter.clsSno_Max.Column.Init_Sno].ToString());
                    }
                    else
                    {
                        lngSeq1 = lngSeq2 + 1;
                    }

                    strSql = $"UPDATE {Parameter.clsSno_Ctl.TableName} SET {Parameter.clsSno_Ctl.Column.Sno} = " + lngSeq1;
                    //if (strMonthFlag == "Y")
                    //{
                    //    strSql += ",TRN_MONTH = '" + strGetYearMonth + "'";
                    //}
                    strSql += $" WHERE {Parameter.clsSno_Ctl.Column.Sno_Type} = '" + objType.ToString() + "'";
                    strSql += $" AND {Parameter.clsSno_Ctl.Column.Sno} = " + lngSeq2;
                }
                else if (intRtn == DBResult.NoDataSelect)
                {
                    #region v1.3 找尋序號長度 by Ian
                    strSql = $"select {Parameter.clsSno_Max.Column.Sno_Len}, {Parameter.clsSno_Max.Column.Init_Sno} from " +
                        $"{Parameter.clsSno_Max.TableName} where {Parameter.clsSno_Max.Column.Sno_Type}='" + objType.ToString() + "' ";
                    dtSno = new DataTable();
                    if (db.GetDataTable(strSql, ref dtSno, ref strEM) != DBResult.Success)
                        throw new Exception();
                    intSnoLen = int.Parse(dtSno.Rows[0][Parameter.clsSno_Max.Column.Sno_Len].ToString());
                    int iInitial = int.Parse(dtSno.Rows[0][Parameter.clsSno_Max.Column.Init_Sno].ToString());
                    #endregion v1.3 找尋序號長度 by Ian

                    strSql = $"INSERT INTO {Parameter.clsSno_Ctl.TableName} ({Parameter.clsSno_Ctl.Column.Sno_Type}," +
                        $"{Parameter.clsSno_Ctl.Column.Trn_Month},{Parameter.clsSno_Ctl.Column.Sno}) VALUES ('" + objType.ToString() + "','" +
                        DateTime.Now.ToString("yyyyMMdd") + "'," + iInitial.ToString() + ")";

                    lngSeq1 = iInitial;
                }
                else
                {
                    return "";
                }

                if (db.ExecuteSQL(strSql, ref strEM) != DBResult.Success)
                {
                    //讀取Count
                    if (intGetCnt >= 5)
                    {
                        return "";
                    }
                    else
                    {
                        goto ProNext;
                    }
                }

                switch (objType)
                {
                    case clsEnum.enuSnoType.CMDSNO:
                    case clsEnum.enuSnoType.CMDSUO:
                        string sCmdSno = lngSeq1.ToString().PadLeft(intSnoLen, '0');
                        CmdMstInfo cmd = new CmdMstInfo(); int iRet = DBResult.Initial;
                        if (cmd_Mst.FunGetCommand(sCmdSno, ref cmd, ref iRet, db)) goto ProNext;
                        else return sCmdSno;
                    case clsEnum.enuSnoType.WCSTrxNo:
                        return DateTime.Now.ToString("HHmmss") + lngSeq1.ToString().PadLeft(intSnoLen, '0');
                    case clsEnum.enuSnoType.LOCTXNO:
                    case clsEnum.enuSnoType.BATCH:
                        return DateTime.Now.ToString("yyMMdd") + lngSeq1.ToString().PadLeft(intSnoLen, '0');
                    default:
                        return lngSeq1.ToString().PadLeft(intSnoLen, '0');
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
                dtSno.Dispose();
            }
        }
    }
}
