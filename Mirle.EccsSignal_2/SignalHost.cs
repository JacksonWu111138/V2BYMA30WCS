using Mirle.DataBase;
using Mirle.Def;
using Mirle.EccsSignal.DB_Proc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.EccsSignal
{
    public class SignalHost
    {
        private System.Timers.Timer timRead = new System.Timers.Timer();
        private ECCS_Structure Crn = new ECCS_Structure();
        private readonly clsHost db; private string sEquNo = "";
        private string mode = ""; private string sts = "";
        private int gintMaxStn = 15;
        public SignalHost(clsDbConfig config, string EquNo)
        {
            db = new clsHost(config); sEquNo = EquNo;
            Crn.sStnSts = new sceStnSts[gintMaxStn];

            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = true; timRead.Interval = 500;
        }

        public void Start() => timRead.Enabled = true;
        public void Stop() => timRead.Enabled = false;
        public void Change_Interval(double value) => timRead.Interval = value;
        public double Timer_Interval
        {
            get { return timRead.Interval; }
        }

        public ECCS_Structure Signal
        {
            get { return Crn; }
        }

        public string CrnMode
        {
            get { return mode; }
        }

        public string CrnSts
        {
            get { return sts; }
        }

        private bool ArrayTransfer_S2I(string[] strInput, ref int[] intOutput)
        {
            try
            {
                intOutput = Array.ConvertAll(strInput, new Converter<string, int>(StringToInt));
                return true;
            }
            catch
            {
                return false;
            }
        }
        private int StringToInt(string s)
        {
            return Convert.ToInt32(s);
        }

        private bool IsHex(string strData, out int intRet)
        {
            intRet = 0;
            if (int.TryParse(strData, System.Globalization.NumberStyles.HexNumber, null, out intRet))
                return true;
            else
                return false;
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            var dtTmp = new DataTable();
            var dtMode = new DataTable();
            var dtSts = new DataTable();
            try
            {
                string strEM = "";
                int iRet = db.GetProc().FunGetCrane(sEquNo, ref dtTmp, ref dtMode, ref dtSts, ref strEM);
                if(iRet==DBResult.Success)
                {
                    mode = dtMode.Rows[0]["EQUMODE"].ToString();
                    sts = dtSts.Rows[0]["EQUSTS"].ToString();
                    string strTXT = string.Empty;
                    string[] sPlcData = new string[3];
                    string[] strRetData;
                    int[] intRetData = null;
                    string strTemp = string.Empty;
                    int intTemp = -1;

                    for (int i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        if (dtTmp.Rows[i]["EquPlcData"].ToString() == "")
                        {
                            continue;
                        }

                        switch (dtTmp.Rows[i]["SerialNo"].ToString())
                        {
                            case "1-3":
                                sPlcData[0] = dtTmp.Rows[i]["EquPlcData"].ToString();
                                break;
                            case "2-3":
                                sPlcData[1] = dtTmp.Rows[i]["EquPlcData"].ToString();
                                break;
                            default:
                                sPlcData[2] = dtTmp.Rows[i]["EquPlcData"].ToString();
                                break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(sPlcData[0]) ||
                        string.IsNullOrWhiteSpace(sPlcData[1]) ||
                        string.IsNullOrWhiteSpace(sPlcData[2]))
                        return;

                    strTXT = sPlcData[0] + "," + sPlcData[1] + "," + sPlcData[2];
                    strTXT = "0,0,0," + strTXT;
                    strRetData = strTXT.Split(","[0]);
                    ArrayTransfer_S2I(strRetData, ref intRetData);

                    //PC Write PLC Zone
                    //==========================================================================================================
                    //D00~D04
                    Crn.sPCInfo.strD00_HS_yymm = intRetData[0].ToString().Trim();
                    Crn.sPCInfo.strD01_HS_ddhh = intRetData[1].ToString().Trim();
                    Crn.sPCInfo.strD02_HS_mmss = intRetData[2].ToString().Trim();
                    Crn.sPCInfo.strD03_SystemInfo = intRetData[3].ToString().Trim();
                    Crn.sPCInfo.strD04_SchTotalCmds = intRetData[4].ToString().Trim();

                    //D10
                    Crn.strPcCMDCompleteIndex = strRetData[10];

                    //D11 ACK
                    strTemp = Convert.ToString(intRetData[11], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sPCAck.str11B00_AckStoreAltRequest = strTemp.Substring(15, 1);
                    Crn.sPCAck.str11B01_AckEmptyRetrieval = strTemp.Substring(14, 1);
                    Crn.sPCAck.str11B02_AckDoubleStorage = strTemp.Substring(13, 1);
                    Crn.sPCAck.str11B03_AckObstruction = strTemp.Substring(12, 1);
                    Crn.sPCAck.str11B04_AckScanComplete = strTemp.Substring(11, 1);
                    Crn.sPCAck.str11B05_AckLDErr = strTemp.Substring(10, 1);
                    Crn.sPCAck.str11B06_AckULDErr = strTemp.Substring(9, 1);
                    Crn.sPCAck.str11B07_AckReadyErr = strTemp.Substring(8, 1);
                    Crn.sPCAck.str11B08_AckCstTypeMismatch = strTemp.Substring(7, 1);
                    Crn.sPCAck.str11B09_AckTransferReqWrong = strTemp.Substring(6, 1);
                    Crn.sPCAck.str11B11_AckMPLCCancelCMD = strTemp.Substring(4, 1);
                    Crn.sPCAck.str11B13_AckIDReadErr = strTemp.Substring(2, 1);
                    Crn.sPCAck.str11B14_AckIDMismatch = strTemp.Substring(1, 1);

                    //D12 ACK
                    strTemp = Convert.ToString(intRetData[12], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sPCInfo.strD12B00_SynPLCDT = strTemp.Substring(15, 1);
                    Crn.sPCInfo.strD12B01_butErrReset = strTemp.Substring(14, 1);
                    Crn.sPCInfo.strD12B02_butBuzzerStop = strTemp.Substring(13, 1);
                    Crn.sPCInfo.strD12B03_butRun = strTemp.Substring(12, 1);
                    Crn.sPCInfo.strD12B04_butStop = strTemp.Substring(11, 1);
                    Crn.sPCAck.str12B08_AckTransferCMDRequest = strTemp.Substring(7, 1);
                    Crn.sPCAck.str12B09_PCAboutCMDRequest = strTemp.Substring(6, 1);
                    Crn.sPCInfo.strD12B10_butPowerOn = strTemp.Substring(5, 1);
                    Crn.sPCInfo.strD12B11_butReturnHP = strTemp.Substring(4, 1);

                    //D09
                    IsHex(intRetData[9].ToString(), out intTemp);
                    Crn.sPCCmd.strD09_SpeedLevel = intTemp.ToString();

                    //D13~D19
                    Crn.sPCCmd.strD13_CmdSno = intRetData[13].ToString().Trim();
                    Crn.sPCCmd.strD14_CmdMode = intRetData[14].ToString().Trim();
                    Crn.sPCCmd.strD15_FBank = intRetData[15].ToString().Trim();
                    Crn.sPCCmd.strD16_FBayLevel = intRetData[16].ToString().Trim();
                    Crn.sPCCmd.strD17_TBank = intRetData[17].ToString().Trim();
                    Crn.sPCCmd.strD18_TBayLevel = intRetData[18].ToString().Trim();
                    Crn.sPCCmd.strD19_TransformInfo = intRetData[19].ToString().Trim();
                    //D20
                    Crn.strPcErrIndex = intRetData[20].ToString().Trim();

                    //預約
                    for (int intStn = 1; intStn < gintMaxStn; intStn++)
                        if (gintMaxStn >= 1 && gintMaxStn <= 16)
                        {
                            //D51 入庫預約
                            strTemp = Convert.ToString(intRetData[51], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                            //D55 出庫預約 
                            strTemp = Convert.ToString(intRetData[55], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                        }
                        else if (gintMaxStn >= 17 && gintMaxStn <= 32)
                        {
                            //D52 入庫預約
                            strTemp = Convert.ToString(intRetData[52], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                            //D56 出庫預約 
                            strTemp = Convert.ToString(intRetData[56], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                        }
                        else if (gintMaxStn >= 33 && gintMaxStn <= 48)
                        {
                            //D53 入庫預約
                            strTemp = Convert.ToString(intRetData[53], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                            //D57 出庫預約 
                            strTemp = Convert.ToString(intRetData[57], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                        }
                        else
                        {
                            //D54 入庫預約
                            strTemp = Convert.ToString(intRetData[54], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                            //D58 出庫預約 
                            strTemp = Convert.ToString(intRetData[58], 2).PadLeft(16, Convert.ToChar("0"));
                            Crn.sStnSts[intStn].intBookingInSts = Convert.ToInt32(strTemp.Substring(16 - intStn, 1));
                        }

                    //PLC 2 PC Zone
                    //==========================================================================================================
                    //D60 System Status
                    strTemp = Convert.ToString(intRetData[60], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sSysSts.strD60B00_MPLCBatteryLow = strTemp.Substring(15, 1);
                    Crn.sSysSts.strD60B01_CPLCBatteryLow = strTemp.Substring(14, 1);
                    Crn.sSysSts.strD60B08_CIDSetComplete = strTemp.Substring(7, 1);

                    ////D61 Crane Status 1
                    strTemp = Convert.ToString(intRetData[61], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sCrnStatus.str61B00_CrnInService = strTemp.Substring(15, 1);
                    Crn.sCrnStatus.str61B01_MPLCRun = strTemp.Substring(14, 1);
                    Crn.sCrnStatus.str61B02_Error = strTemp.Substring(13, 1);
                    Crn.sCrnStatus.str61B03_Ready = strTemp.Substring(12, 1);
                    Crn.sCrnStatus.str61B04_Action = strTemp.Substring(11, 1);
                    Crn.sCrnStatus.str61B05_CTSPresenceOn = strTemp.Substring(10, 1);
                    Crn.sCrnStatus.str61B06_ForkDepPos = strTemp.Substring(9, 1);
                    Crn.sCrnStatus.str61B07_ForkPicPos = strTemp.Substring(8, 1);
                    Crn.sCrnStatus.str61B08_Moving2HP = strTemp.Substring(7, 1);
                    Crn.sCrnStatus.str61B09_Escape = strTemp.Substring(6, 1);
                    Crn.sCrnStatus.str61B11_MPLCOnLine = strTemp.Substring(4, 1);
                    Crn.sCrnStatus.str61B12_MPLCRemote = strTemp.Substring(3, 1);
                    Crn.sCrnStatus.str61B14_MPLCMainTain = strTemp.Substring(1, 1);

                    //Crane Mode
                    if (Crn.sCrnStatus.str61B11_MPLCOnLine == "1")
                        Crn.eCrnMode = enuCrnMode.eOnLine;
                    else if (Crn.sCrnStatus.str61B12_MPLCRemote == "1")
                        Crn.eCrnMode = enuCrnMode.eRemote;
                    else if (Crn.sCrnStatus.str61B14_MPLCMainTain == "1")
                        Crn.eCrnMode = enuCrnMode.eMPLCMaintain;
                    else
                        Crn.eCrnMode = enuCrnMode.eNoMode;

                    //Crane Status
                    if (Crn.sCrnStatus.str61B02_Error == "1")
                        Crn.eCrnSts = enuCrnStatus.eCrnError;
                    else if (Crn.sCrnStatus.str61B03_Ready == "1")
                        Crn.eCrnSts = enuCrnStatus.eCrnReady;
                    else if (Crn.sCrnStatus.str61B04_Action == "1")
                        Crn.eCrnSts = enuCrnStatus.eCrnAction;
                    else
                    {
                        //若是地上盤模式 因為PLC未給 Wait 或 Ready 訊號  所以由電腦自行判斷 非動作中、異常中 則顯示等待中
                        if (Crn.eCrnMode == enuCrnMode.eRemote)
                            Crn.eCrnSts = enuCrnStatus.eCrnReady;
                        else
                            Crn.eCrnSts = enuCrnStatus.eCrnNoSts;
                    }

                    //D62 Crane Status 2
                    strTemp = Convert.ToString(intRetData[62], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sCrnStatus.str62B00_TransferCmdReceived = strTemp.Substring(15, 1);
                    Crn.sCrnStatus.str62B01_EmptyRetrieval = strTemp.Substring(14, 1);
                    Crn.sCrnStatus.str62B02_DoubleStorage = strTemp.Substring(13, 1);
                    Crn.sCrnStatus.str62B04_ScanComplete = strTemp.Substring(12, 1);
                    Crn.sCrnStatus.str62B05_LDError = strTemp.Substring(10, 1);
                    Crn.sCrnStatus.str62B06_ULDError = strTemp.Substring(9, 1);
                    Crn.sCrnStatus.str62B07_ReadyErr = strTemp.Substring(8, 1);
                    Crn.sCrnStatus.str62B08_CasTypeMismatch = strTemp.Substring(7, 1);
                    Crn.sCrnStatus.str62B09_TRW = strTemp.Substring(6, 1);
                    Crn.sCrnStatus.str62B10_CrnLocationUpd = strTemp.Substring(5, 1);
                    Crn.sCrnStatus.str62B11_AckMPLCCancelCMD = strTemp.Substring(4, 1);
                    Crn.sCrnStatus.str62B12_FF = strTemp.Substring(3, 1);
                    Crn.sCrnStatus.str62B13_IDReadErr = strTemp.Substring(2, 1);
                    Crn.sCrnStatus.str62B14_IDMismatch = strTemp.Substring(1, 1);
                    Crn.sCrnStatus.str62B15_Retrying = strTemp.Substring(0, 1);

                    //D63 Crane Status 3
                    strTemp = Convert.ToString(intRetData[63], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sCrnStatus.str63B08_Forking1 = strTemp.Substring(7, 1);
                    Crn.sCrnStatus.str63B09_Forking2 = strTemp.Substring(6, 1);
                    Crn.sCrnStatus.str63B10_Cycle1 = strTemp.Substring(5, 1);
                    Crn.sCrnStatus.str63B11_Cycle2 = strTemp.Substring(4, 1);

                    //D64 Crane Sensor Signals 1
                    strTemp = Convert.ToString(intRetData[64], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sCrnSensor.str64B05_TravelHP = strTemp.Substring(10, 1);
                    Crn.sCrnSensor.str64B06_LifterHP = strTemp.Substring(9, 1);
                    Crn.sCrnSensor.str64B07_RotateHP = strTemp.Substring(8, 1);

                    //搭載盤有物 => 0: 荷無 1: 荷有
                    Crn.sCrnSensor.str64B08_LoadPresence = strTemp.Substring(7, 1);
                    Crn.sCrnSensor.str64B09_ForkHP = strTemp.Substring(6, 1);
                    Crn.sCrnSensor.str64B10_FFUError = strTemp.Substring(5, 1);
                    Crn.sCrnSensor.str64B12_TravelMoving = strTemp.Substring(3, 1);
                    Crn.sCrnSensor.str64B13_LifterActing = strTemp.Substring(2, 1);
                    Crn.sCrnSensor.str64B14_Forking = strTemp.Substring(1, 1);
                    Crn.sCrnSensor.str64B15_Rotating = strTemp.Substring(0, 1);

                    //D65 Crane Sensor Signals 2
                    strTemp = Convert.ToString(intRetData[65], 2).PadLeft(16, Convert.ToChar("0"));
                    Crn.sCrnSensor.str65B00_RunEnable = strTemp.Substring(15, 1);
                    Crn.sCrnSensor.str65B02_EmergencyStop = strTemp.Substring(13, 1);
                    Crn.sCrnSensor.str65B03_LaserDeviceLoss = strTemp.Substring(12, 1);
                    Crn.sCrnSensor.str65B04_LeftStorage = strTemp.Substring(11, 1);
                    Crn.sCrnSensor.str65B05_RightStorage = strTemp.Substring(10, 1);
                    Crn.sCrnSensor.str65B06_SRI_MPLCAuto = strTemp.Substring(9, 1);
                    Crn.sCrnSensor.str65B07_SRI_SafetyDoorClosed = strTemp.Substring(8, 1);
                    Crn.sCrnSensor.str65B08_SRI_CraneAuto = strTemp.Substring(7, 1);
                    Crn.sCrnSensor.str65B09_SRI_EMO = strTemp.Substring(6, 1);
                    Crn.sCrnSensor.str65B10_MPLCPowerSts = strTemp.Substring(5, 1);
                    Crn.sCrnSensor.str65B12_EmptyRetrievalSetup = strTemp.Substring(4, 1);
                    Crn.sCrnSensor.str65B13_DoubleStorageSetup = strTemp.Substring(2, 1);
                    Crn.sCrnSensor.str65B14_StnInterLockSetup = strTemp.Substring(1, 1);
                    Crn.sCrnSensor.str65B15_CasTypeMismatchSetup = strTemp.Substring(0, 1);

                    if (Crn.sCrnSensor.str65B08_SRI_CraneAuto == "0")
                        Crn.eCrnMode = enuCrnMode.eCrnMaintain;

                    //D66
                    Crn.sOtherData.strD66_CrnLocation = strRetData[66].PadLeft(5, Convert.ToChar("0"));
                    //D67
                    Crn.sOtherData.strD67_CrnTravelPos = strRetData[67];
                    //D68
                    Crn.sOtherData.strD68_CrnLifterPos = strRetData[68];
                    //D78
                    Crn.sOtherData.strD78_TimerCount = strRetData[78];

                    //D83
                    IsHex(intRetData[83].ToString(), out intTemp);
                    Crn.sOtherData.strD83_CrnSpeedLevel = intTemp.ToString();

                    //D84
                    Crn.sOtherData.strD84_PlcCmdCompleteIndex = strRetData[84];
                    //D85
                    Crn.sOtherData.strD85_CmdSequence = strRetData[85];
                    //D86
                    Crn.sOtherData.strD86_CompleteCmdSno = strRetData[86];
                    //D87
                    Crn.sOtherData.strD87_CompleteCode = strRetData[87];
                    //D88
                    Crn.sOtherData.strD88_TransferWrongCode = strRetData[88];
                    //D89
                    Crn.sOtherData.strD89_PlcErrIndex = strRetData[89];
                    //D90
                    Crn.sOtherData.strD90_PlcErrCode = strRetData[90];

                    //D71~D77    Execution Command
                    Crn.sExcetingCmd.strCmdSno = strRetData[71];
                    strTemp = strRetData[72];
                    Crn.sExcetingCmd.strCmdMode = (enuTransferType)Enum.Parse(typeof(enuTransferType), strTemp);
                    Crn.sExcetingCmd.strFBank = strRetData[73];
                    Crn.sExcetingCmd.strFBayLevel = strRetData[74].PadLeft(5, Convert.ToChar("0"));
                    Crn.sExcetingCmd.strTBank = strRetData[75];
                    Crn.sExcetingCmd.strTBayLevel = strRetData[76].PadLeft(5, Convert.ToChar("0"));
                    Crn.sExcetingCmd.strTransferInfo = strRetData[77];

                    //D422~D485 For Stnation I/O
                    for (int intStn = 0; intStn < gintMaxStn; intStn++)
                    {
                        strTemp = Convert.ToString(intRetData[422 + intStn], 2).PadLeft(16, Convert.ToChar("0"));
                        Crn.sStnSts[intStn].strStnNo = (intStn + 1).ToString();
                        Crn.sStnSts[intStn].intB00_Load = Convert.ToInt32(strTemp.Substring(15, 1));
                        Crn.sStnSts[intStn].intB01_Position = Convert.ToInt32(strTemp.Substring(14, 1));
                        Crn.sStnSts[intStn].intB02_Finish = Convert.ToInt32(strTemp.Substring(13, 1));
                        Crn.sStnSts[intStn].intB03_EMC = Convert.ToInt32(strTemp.Substring(12, 1));
                        Crn.sStnSts[intStn].intB08_Ining = Convert.ToInt32(strTemp.Substring(7, 1));
                        Crn.sStnSts[intStn].intB09_Outing = Convert.ToInt32(strTemp.Substring(6, 1));
                        Crn.sStnSts[intStn].intB10_Complete = Convert.ToInt32(strTemp.Substring(5, 1));
                        Crn.sStnSts[intStn].intB11_ForkOnCenter = Convert.ToInt32(strTemp.Substring(4, 1));
                    }
                }
                else
                {
                    mode = "X";
                    sts = "X";
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                dtMode.Dispose();
                dtSts.Dispose();
                dtTmp.Dispose();
                timRead.Enabled = true;
            }
        }
    }
}
