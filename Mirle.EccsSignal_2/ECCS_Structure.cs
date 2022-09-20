using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirle.EccsSignal
{
    public class ECCS_Structure
    {
        public string strEquNo = "";
        public string strLastPlcString_2DB = "";          //記錄上次的EQUDATA(從PLC所讀回的資料)
        public string strLastPlcString_2TXT = "";          //記錄上次的EQUDATA(從PLC所讀回的資料)
        public enuCrnStatus eCrnSts = new enuCrnStatus();
        public enuCrnMode eCrnMode = new enuCrnMode();
        public sceMPLCSystemStatus sSysSts = new sceMPLCSystemStatus();
        public sceCrnStatus sCrnStatus = new sceCrnStatus();
        public sceCrnSensorSignal sCrnSensor = new sceCrnSensorSignal();
        public sceCrnOtherData sOtherData = new sceCrnOtherData();
        public sceStnSts[] sStnSts = new sceStnSts[16];
        public secCMDdata sCmdBuffer = new secCMDdata();
        public secCMDdata sExcetingCmd = new secCMDdata();
        public secCMDdata sPCLastCmdLog = new secCMDdata();
        public sceInfo_PC2PLC sPCInfo = new sceInfo_PC2PLC();
        public sceCMD_PC2PLC sPCCmd = new sceCMD_PC2PLC();
        public sceAck_PC2PLC sPCAck = new sceAck_PC2PLC();
        public string strPcErrIndex = "";
        public string strPcCMDCompleteIndex = "";
        public bool bolAlarmHappened = false;        //記錄上個Timer是否異常中
        public bool bolPlcConn = false;              //記錄PLC是否連線中
        public enuCrnCmdSts objFinishSts = new enuCrnCmdSts();         //記錄該筆命令是否為強制完成、強制取消
    }

    public enum enuCrnStatus
    {
        eCrnNoSts = 0,       //無狀態值
        eCrnReady = 1,       //Crane has finished transfer command,ready to received new command
        eCrnAction = 2,      //Crane Executing a command
        eCrnError = 3,       //Error happened
    }
    public enum enuCrnMode
    {
        eNoMode = 0,         //'無模式(Initial)
        eOnLine = 1,         //'電腦連線模式
        eRemote = 2,         //'地上盤模式
        eCrnMaintain = 3,    //'CRANE 維護模式
        eMPLCMaintain = 4,   //'維護模式
    }

    public class sceMPLCSystemStatus
    {
        public string strD60B00_MPLCBatteryLow = ""; //The MPLC CPU Battery Low
        public string strD60B01_CPLCBatteryLow = ""; //The Crane PLC  CPU Battery Low
        public string strD60B08_CIDSetComplete = ""; //Cassette ID Set Complete
    }

    public class sceCrnStatus
    {
        public string str61B00_CrnInService = "";               //The Crane Can be Controlled By MasterPLC (Auto Mode)
        public string str61B01_MPLCRun = "";                  //There is a cassette on the fork of crane
        public string str61B02_Error = "";                    //Error Happen
        public string str61B03_Ready = "";                    //Ready Received Command
        public string str61B04_Action = "";                   //Action
        public string str61B05_CTSPresenceOn = "";            //There is a cassette on the fork of crane
        public string str61B06_ForkDepPos = "";               //Fork at deposit position
        public string str61B07_ForkPicPos = "";               //Fork at pick-up position
        public string str61B08_Moving2HP = "";                //Crane is executing a HP return
        public string str61B09_Escape = "";                   //When Crane is performing an evacuation move. (for Dual Crane) 
        public string str61B11_MPLCOnLine = "";               //The MPLC OnLine Mode
        public string str61B12_MPLCRemote = "";               //The Crane Maintain Mode
        public string str61B14_MPLCMainTain = "";             //The MPLC Maintain Mode
        public string str62B00_TransferCmdReceived = "";      //MPLC Received PC//Coommand(D13~D19 B12B08>1)
        public string str62B01_EmptyRetrieval = "";
        public string str62B02_DoubleStorage = "";
        public string str62B04_ScanComplete = "";
        public string str62B05_LDError = "";                  //Load request off before TR_Req On
        public string str62B06_ULDError = "";                 //EQ UnLoad request signal off before TR_Req signal on
        public string str62B07_ReadyErr = "";                 //EQ Ready signal not on when TR_Req On.(T2 Timeout)
        public string str62B08_CasTypeMismatch = "";          //Cassette Type Mismatch
        public string str62B09_TRW = "";                      //Transfer Request Wrong
        public string str62B10_CrnLocationUpd = "";           //Crane Location Updated.

        //V2.3.0.0
        public string str62B11_AckMPLCCancelCMD = "";
        //Dim str62B11_FC;                       //Transfer Command Complete  > Force Cancel

        public string str62B12_FF = "";                       //Transfer Command Complete  > Force Finish
        public string str62B13_IDReadErr = "";
        public string str62B14_IDMismatch = "";
        public string str62B15_Retrying = "";                 //Crane is runing Retry moving.
        public string str63B08_Forking1 = "";                 //when Forking during pick up cycle.
        public string str63B09_Forking2 = "";                 //when Forking during deposit cycle.
        public string str63B10_Cycle1 = "";                   //Pickup Cycle
        public string str63B11_Cycle2 = "";                   //Deposit Cycle
    }

    public class sceCrnSensorSignal
    {
        public string str64B05_TravelHP = "";                 //Travel at Home Position
        public string str64B06_LifterHP = "";                 //Lifter at Home Position
        public string str64B07_RotateHP = "";                 //Rotate at Home Position
        public string str64B08_LoadPresence = "";             //On:Load Presence On
        public string str64B09_ForkHP = "";                   //On:When Fork at HP Position
        public string str64B10_FFUError = "";                 //On:Any one FFU of Crane is Error
        public string str64B12_TravelMoving = "";             //On:Moving       Off:Stop
        public string str64B13_LifterActing = "";             //On:Acting       Off:Stop
        public string str64B14_Forking = "";                  //On:Fork Acting  Off:Fork Stop
        public string str64B15_Rotating = "";                 //Rotation
        public string str65B00_RunEnable = "";                //Run Enable
        public string str65B02_EmergencyStop = "";            //Emergency Stop From Safety Role
        public string str65B03_LaserDeviceLoss = "";          //Laser Device Loss
        public string str65B04_LeftStorage = "";              //Detected storage at Left shelf(Sensor on)
        public string str65B05_RightStorage = "";             //Detected storage at Right shelf(Sensor on)
        public string str65B06_SRI_MPLCAuto = "";             //The Auto/Manual Switch of MPLC is Auto
        public string str65B07_SRI_SafetyDoorClosed = "";     //Safety Door Closed
        public string str65B08_SRI_CraneAuto = "";            //The Auto/Manual Switch of Crane is Auto
        public string str65B09_SRI_EMO = "";                  //EMO
        public string str65B10_MPLCPowerSts = "";             //HID Power On Crane 1
        //設定是PLC是發 ACK 還是 ALARM   :  1>ACK 0>ALARM
        public string str65B12_EmptyRetrievalSetup = "";      //No Error
        public string str65B13_DoubleStorageSetup = "";       //Main Circuit On Enable
        public string str65B14_StnInterLockSetup = "";        //Fork Fixed Position
        public string str65B15_CasTypeMismatchSetup = "";     //The Auto/Manual Switch of Crane is Auto
    }

    public class sceCrnOtherData
    {
        /// <summary>
        /// BBBLL
        /// </summary>
        public string strD66_CrnLocation = "";
        public string strD67_CrnTravelPos = "";
        public string strD68_CrnLifterPos = "";
        public string strD78_TimerCount = "";

        //V3.5.0.7
        public string strD83_CrnSpeedLevel = "";     //EX:2345 :  2>Fork   3>Rotate    4>Lifter    5>Travel

        public string strD84_PlcCmdCompleteIndex = "";
        public string strD85_CmdSequence = "";
        public string strD86_CompleteCmdSno = "";
        public string strD87_CompleteCode = "";
        public string strD88_TransferWrongCode = "";
        public string strD89_PlcErrIndex = "";
        public string strD90_PlcErrCode = "";
    }

    public class sceStnSts
    {
        public string strStnNo = "";
        public bool strStnBooking = false;
        public int intB00_Load = 0;
        public int intB01_Position = 0;
        public int intB02_Finish = 0;
        public int intB03_EMC = 0;
        public int intB08_Ining = 0;
        public int intB09_Outing = 0;
        public int intB10_Complete = 0;
        public int intB11_ForkOnCenter = 0;
        public string strBookingInAddress = "";
        public int intBookingInSts = 0;
        public string strBookingOutAddress = "";
        public int intBookingOutSts = 0;
    }

    public class secCMDdata
    {
        public string strCmdSno = "";
        public enuTransferType strCmdMode = new enuTransferType();
        public string strFBank = "";
        public string strFBayLevel = "";
        public string strTBank = "";
        public string strTBayLevel = "";
        public string strTransferInfo = "";
        public sceCmdTrace stuTrace = new sceCmdTrace();
        public string strSpeedLevel = "";

    }

    public class sceCmdTrace
    {
        public string strWriteBuffer = "";
        public string strWritePLC = "";
        public string strStartAction = "";
        public string strCycle1 = "";
        public string strCycle2 = "";
        public string strFork1 = "";
        public string strFork2 = "";
        public string strCSTPresence_On = "";
        public string strLoadPresence_On = "";
        public string strCSTPresence_Off = "";
        public string strLoadPresence_Off = "";
        public string strCmdFinish = "";
        public string strFinishCode = "";
        public string strPLCTimerCount = "";
        public string strCompleteIndex = "";
    }

    public class sceInfo_PC2PLC
    {
        public string strD00_HS_yymm = "";
        public string strD01_HS_ddhh = "";
        public string strD02_HS_mmss = "";
        public string strD03_SystemInfo = "";
        public string strD04_SchTotalCmds = "";
        public string strD05_D09CarrierID = "";
        public string strD12B00_SynPLCDT = "";
        public string strD12B01_butErrReset = "";
        public string strD12B02_butBuzzerStop = "";
        public string strD12B03_butRun = "";
        public string strD12B04_butStop = "";
        public string strD12B10_butPowerOn = "";
        public string strD12B11_butReturnHP = "";
    }

    public class sceCMD_PC2PLC
    {
        public string strD09_SpeedLevel = "";
        public string strD13_CmdSno = "";
        public string strD14_CmdMode = "";
        public string strD15_FBank = "";
        public string strD16_FBayLevel = "";
        public string strD17_TBank = "";
        public string strD18_TBayLevel = "";
        public string strD19_TransformInfo = "";
    }


    public class sceAck_PC2PLC
    {
        public string str11B00_AckStoreAltRequest = "";
        public string str11B01_AckEmptyRetrieval = "";
        public string str11B02_AckDoubleStorage = "";
        public string str11B03_AckObstruction = "";
        public string str11B04_AckScanComplete = "";
        public string str11B05_AckLDErr = "";
        public string str11B06_AckULDErr = "";
        public string str11B07_AckReadyErr = "";
        public string str11B08_AckCstTypeMismatch = "";
        public string str11B09_AckTransferReqWrong = "";

        public string str11B11_AckMPLCCancelCMD = "";

        public string str11B13_AckIDReadErr = "";
        public string str11B14_AckIDMismatch = "";
        public string str12B08_AckTransferCMDRequest = "";
        public string str12B09_PCAboutCMDRequest = "";

    }

    public enum enuCrnCmdSts
    {
        eInitial = 0,            //Initial
        eWriteMPLC = 1,          //Write PLC Success
        eForceCancel = 6,       //User Command Force Cancel
        eForceFinish = 7,        //User Command Force Finish
        eNormalCancel = 8,       //Auto Command Normal Cancel EX:命令格式錯誤
        eNormalFinish = 9,       //Auto Command Normal Finish
    }

    public enum enuTransferType
    {
        eNoCmd = 0,          //'無命令
        eStoreIn = 1,        //'入庫
        eStoreOut = 2,       //'出庫
        eStn2Stn = 4,        //'站對站
        eShelf2Shelf = 5,    //'庫對庫
        eMove = 6,           //'移動
        eScan = 7,           //'掃描
        ePickUp = 8,         //'取物
        eDeposit = 9,        //'置物
        eReturnHome = 10,    //'回原點
    }
}
