using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Def
{
    public class clsConstValue
    {
        public class Crane
        {
            public class Mode
            {
                /// <summary>
                /// 電腦模式
                /// </summary>
                public const string Computer = "C";
                /// <summary>
                /// 地上盤模式
                /// </summary>
                public const string Manual = "R";
                /// <summary>
                /// 地上盤維護模式
                /// </summary>
                public const string MasterMaintain = "I";
                /// <summary>
                /// 車上盤維護模式
                /// </summary>
                public const string CarMaintain = "M";
                /// <summary>
                /// 電腦離線中
                /// </summary>
                public const string ComputerOffLine = "N";
                /// <summary>
                /// 無資料
                /// </summary>
                public const string Error = "X";
            }

            public class Status
            {
                /// <summary>
                /// PLC檢查命令中
                /// </summary>
                public const string PlcCheck = "I";
                /// <summary>
                /// 動作中
                /// </summary>
                public const string Busy = "A";
                /// <summary>
                /// 異常中
                /// </summary>
                public const string Alarm = "E";
                /// <summary>
                /// 待命中
                /// </summary>
                public const string Idle = "W";
                /// <summary>
                /// 電腦離線中
                /// </summary>
                public const string ComputerOffLine = "N";
                /// <summary>
                /// 與PLC未連線
                /// </summary>
                public const string Error = "X";
            }
        }

        public class YesNo
        {
            public const string Yes = "Y";
            public const string No = "N";
        }

        public const string BcrError = "ERROR1";

        public const string CarrierNoCmd = "FAILID";

        public class ApiReturnCode
        {
            public const string Success = "200";
            public const string Fail = "500";
            /// <summary>
            /// 等待並重試
            /// </summary>
            public const string Waitretry = "300";
        }

        public class CmdSts_MiddleCmd
        {
            public const string strCmd_Initial = "0";
            /// <summary>
            /// 預約周邊站口
            /// </summary>
            public const string strCmd_WriteCV = "1";
            /// <summary>
            /// 下達設備命令
            /// </summary>
            public const string strCmd_WriteDeviceCmd = "2";
            /// <summary>
            /// 7:命令完成待過帳
            /// </summary>
            public const string strCmd_Finish_Wait = "7";

            /// <summary>
            /// 8:命令取消待過帳
            /// </summary>
            public const string strCmd_Cancel_Wait = "8";
        }

        public class CmdSts
        {
            public const string strCmd_Initial = "0";
            /// <summary>
            /// 執行中
            /// </summary>
            public const string strCmd_Running = "1";
            /// <summary>
            /// 7:命令完成待過帳
            /// </summary>
            public const string strCmd_Finish_Wait = "7";

            /// <summary>
            /// 8:命令取消待過帳
            /// </summary>
            public const string strCmd_Cancel_Wait = "8";

            /// <summary>
            /// 9:命令完成
            /// </summary>
            public const string strCmd_Finished = "9";

            /// <summary>
            /// D:命令取消
            /// </summary>
            public const string strCmd_Cancelled = "D";
        }

        public class CmdMode
        {
            public const string StockIn = "1";
            public const string StockOut = "2";
            public const string Cycle = "3";
            /// <summary>
            /// 站對站
            /// </summary>
            public const string S2S = "4";
            /// <summary>
            /// 庫對庫
            /// </summary>
            public const string L2L = "5";
            public const string Move = "6";
            /// <summary>
            /// 取物
            /// </summary>
            public const string Pick = "8";
            /// <summary>
            /// 置物
            /// </summary>
            public const string Deposit = "9";
        }

        ///<summary>
        ///作業類別 
        ///</summary>
        public class clsDec_IoType
        {
            /// <summary>
            /// 11:單據入庫
            /// </summary>
            public const string stkIn_Tkt = "11";

            /// <summary>
            /// 12:無單入庫作業
            /// </summary>
            public const string stkIn_Offline = "12";

            /// <summary>
            /// 13:併板入庫
            /// </summary>
            public const string stkIn_MergePlt = "13";

            /// <summary>
            /// 14:空棧板入庫
            /// </summary>
            public const string stkIn_EmptyPlt = "14";

            /// <summary>
            /// 21:單據出庫
            /// </summary>
            public const string stkOut_ShipmentOrder = "21";

            /// <summary>
            /// 22:無單出貨作業
            /// </summary>
            public const string stkOut_Shipment = "22";

            /// <summary>
            /// 23:併板出庫
            /// </summary>
            public const string stkOut_MergePlt = "23";

            /// <summary>
            /// 24:空棧板出庫
            /// </summary>
            public const string stkOut_EmptyPlt = "24";

            /// <summary>
            /// 31:依儲位盤點
            /// </summary>
            public const string stkCycle_Loc = "31";

            /// <summary>
            /// 32:依料號盤點
            /// </summary>
            public const string stkCycle_Item = "32";

            /// <summary>
            /// 33:盤點調帳
            /// </summary>
            public const string stkCycle_LocMaintain = "33";

            /// <summary>
            /// 41:站對站
            /// </summary>
            public const string stkStn2Stn = "41";

            /// <summary>
            /// 51:庫對庫
            /// </summary>
            public const string stkL2L = "51";

            /// <summary>
            /// 61:模具資料維護
            /// </summary>
            public const string stkMoldMaintain = "61";

            /// <summary>
            /// 62:模具領用作業
            /// </summary>
            public const string stkOut_Mold = "62";

            /// <summary>
            /// 63:模具歸還作業
            /// </summary>
            public const string stkIn_Mold = "63";
        }

        /// <summary>
        /// 倉儲別 WH_ID
        /// </summary>
        public static class clsDec_Wh_Id
        {
            /// <summary>
            /// 自動倉
            /// </summary>
            public const string ASRS = "ASRS";

            /// <summary>
            /// 平面倉
            /// </summary>
            public const string Plane = "Plane";
        }

        /// <summary>
        /// 併板狀態 Merge_Sts
        /// </summary>
        public class clsDec_MergeSts
        {
            /// <summary>
            /// N:初始狀態
            /// </summary>
            public const string Merge_Inital = "N";

            /// <summary>
            /// A:併板執行中
            /// </summary>
            public const string Merge_Action = "A";

            /// <summary>
            /// F:併板完成
            /// </summary>
            public const string Merge_Finish = "F";
        }

        /// <summary>
        /// 單據狀態 Tkt_Sts
        /// </summary>
        public class clsDec_TktSts
        {
            /// <summary>
            /// 0:初始狀態
            /// </summary>
            public const string Initial = "0";

            /// <summary>
            /// 2:處理中
            /// </summary>
            public const string Runing = "2";

            /// <summary>
            /// 8:強制結束
            /// </summary>
            public const string Force_Complete = "8";

            /// <summary>
            /// 9:處理完成
            /// </summary>
            public const string Finished = "9";

            /// <summary>
            /// F:上載完成
            /// </summary>
            public const string UpLoad_Finished = "F";

            /// <summary>
            /// D:刪除
            /// </summary>
            public const string Deleted = "D";
        }

        public class LocSts
        {
            /// <summary>
            /// 空儲位
            /// </summary>
            public const string Empty = "NONE";
            /// <summary>
            /// 空料盒
            /// </summary>
            public const string EmptyBox = "EMPTY";
            /// <summary>
            /// 入庫預約
            /// </summary>
            public const string IN = "IN";
            /// <summary>
            /// 出庫預約
            /// </summary>
            public const string OUT = "OUT";
            /// <summary>
            /// 禁用
            /// </summary>
            public const string Block = "DISABLE";
            public const string Normal = "NORMAL";
            public const string Abnormal = "ABNORMAL";
            /// <summary>
            /// 滿板
            /// </summary>
            public const string Full = "FULL";
            /// <summary>
            /// 不滿板
            /// </summary>
            public const string NotFull = "NOTFULL";
        }
        public class WesApi
        {
            public class EmptyRetrieval
            {
                /// <summary>
                /// 空出庫
                /// </summary>
                public const string EmptyRetrieve = "Y";
                /// <summary>
                /// 正常
                /// </summary>
                public const string Normal = "N";
                /// <summary>
                /// 料捲取出失敗
                /// </summary>
                public const string RetrieveFail = "F";
            }

            public class CarrierType
            {
                /// <summary>
                /// 電子料捲
                /// </summary>
                public const string Lot = "Reel";
                /// <summary>
                /// 料架
                /// </summary>
                public const string Rack = "Rack";
                /// <summary>
                /// 靜電箱
                /// </summary>
                public const string Bin = "Bin";
                public const string Mag = "Mag";
            }

            public class CancelType
            {
                public const string Lot_Retrieve = "Lot RETRIEVE";
                public const string Lot_Putaway = "Lot PUTAWAY";
                public const string Lot_Shelf = "Lot SHELF";
                public const string Carrier_Retrieve = "Carrier RETRIEVE";
                public const string Carrier_Putaway = "Carrier PUTAWAY";
                public const string Carrier_Shelf = "Carrier SHELF";
                public const string Carrier_Transfer = "Carrier Transfer";
            }

            public class PCBAMode
            {
                /// <summary>
                /// 正常模式
                /// </summary>
                public const string Normal = "1";
                /// <summary>
                /// 故障模式
                /// </summary>
                public const string Malfuction = "2";
                /// <summary>
                /// 盤點模式
                /// </summary>
                public const string Cycle = "3";

            }

        }
        

        public class CompleteCode
        {
            public const string PickProc_T2TimeOut = "C0";             //取物 T2 time out
            public const string PickProc_EQLReqOn = "C1";               //取物檢測到EQ L-REQ訊號ON
            public const string PickProc_EQUReqOff = "C2";             //取物檢測到EQ U-REQ訊號OFF
            public const string PickProc_EQReadyOn = "C3";              //取物檢測到EQ Ready訊號ON
            public const string PickProc_EQOnlineOffBeforePick = "C4"; //RM取物前行程EQ Online信號中斷
            public const string PickProc_EQRYOff = "C5";                //RM取物Tr-on檢測到EQ RY信號中斷
            public const string PickProc_EQNoCST = "C6";               //EQ Port站口無物
            public const string PickProc_EQNotForkAccess = "C7";       //EQ Port不允許Fork存取
            public const string PickProc_T5TimeOut = "C8";             //取物 T5 time out
            public const string PickProc_EQUReqOnAfterRMFinish = "C9";  //RM取物完檢測到EQ U-REQ訊號ON
            public const string PickProc_EQOnLineOffAfterRMFinish = "CA";   //RM取物完檢測到EQ Online OFF
            public const string DeposProc_T2TimeOut = "D0";         //置物 T2 time out
            public const string DeposProc_EQLReqOff = "D1";         //置物檢測到EQ L-REQ訊號OFF
            public const string DeposProc_EQUReqOn = "D2";              //置物檢測到EQ U-REQ訊號ON
            public const string DeposProc_EQReadyOn = "D3";         //置物檢測到EQ Ready訊號ON
            public const string DeposProc_EQOnlineOffBeforeDepos = "D4";    //RM置物前行程EQ Online信號中斷
            public const string DeposProc_EQRYOffBeforeDepos = "D5";    //RM置物Tr-on檢測到EQ RY信號中斷
            public const string DeposProc_EQHaveCST = "D6";         //EQ Port站口有物
            public const string DeposProc_EQNotForkAccess = "D7";       //EQ Port不允許Fork存置
            public const string DeposProc_T5TimeOut = "D8";         //置物 T5 time out
            public const string DeposProc_EQLReqOnAfterDepos = "D9";    //RM置物完檢測到EQ L-REQ訊號ON
            public const string DeposProc_EQOnlineOffAfterDepos = "DA"; //RM置物完檢測到EQ Online OFF
            public const string InlineInterlockError_OnLine = "E0"; //Inline Interlock Error(On-Line)
            public const string TransferRequestWrong = "E1";            //Transfer Request Wrong.
            public const string EmptyRetrieval = "E2";                  //儲位空出庫
            public const string ScanIDReadError = "E3";                 //Scan ID Read Error
            public const string IDMismatch = "E4";                      //ID Mismatch
            public const string ScanNoResponse = "E5";                  //Scan No Response
            public const string NoCST = "E6";                           //檢知無CST
            public const string IDReadError = "E7";                     //ID Read Error
            public const string NoResponse = "E8";                      //No Response
            public const string FromCommandAbout = "E9";                //From Command about
            public const string MoveScanCommandAbout = "EA";            //Move/Scan command about
            public const string CassetteTypeMissmach = "EB";            //Cassette Type MissMach
            public const string DoubleStorage = "EC";                   //Double storage
            public const string InlineInterlockError_LD = "ED";     //Inline Interlock Error(LD)
            public const string InlineInterlockError_ULD = "EE";        //Inline Interlock Error(ULD)
            public const string HMIUserForceAbortCommand = "EF";        //HMI User Force Abort Command
            public const string HMIUserForceFinishCommand = "FF";       //HMI User Force Finish Command
            public const string Success_FromReturnCodeAck = "91";       //From Return code Ack
            public const string Success_ToReturnCode = "92";            //To Return code
            public const string Success_CraneIsRunningRetryMoving = "94";   //Crane is running retry moving
            public const string Success_ScanComplete = "97";            //Scan complete
            public const string Success_IdleTimeOutReset = "99";            //Idle Timeout Reset Abnormal complete
            public const string Success_AbortDuringCycle1 = "93";                   //AbortCMD in Cycle1

            public const string DeposProc_Obstruction = "DB";          //RM置物前發生 Obstruction
            public const string PickProc_Obstruction = "CB";            //RM取物前發生 Obstruction

            public const string PickupCycle_Error = "F1";
            public const string DepositCycle_Error = "F2";

            // Form STKC
            //retry
            public const string CannotRetrieveFromSourcePortFromSTKC_P0 = "P0";    //STKC 來源Port無法取物
            public const string CannotDepositToDestinationPortFromSTKC_P1 = "P1";  //STKC 目的Port無法置物


            //abort 
            public const string CannotRetrieveHasCarrierOnCraneFromSTKC_P2 = "P2"; //STKC 車上有物無法取物
            public const string CannotDepositNoCarrierOnCraneFromSTKC_P3 = "P3";   //STKC 車上無物無法置物

            //complete
            public const string CannotScanHasCarrierOnCraneFromSTKC_P4 = "P4";     //STKC 車上有物無法Scan

            public const string CannotExcuteFromSTKC = "PD";            //STKC 判斷地上盤無法執行該命令
            public const string CommandTimeoutFromSTKC = "PE";          //STKC 下命令給地上盤命令後，地上盤未有反應或執行超過10分鐘
            /// <summary>
            /// 電腦強制取消
            /// </summary>
            public const string ComputerCancel = "CC";

            /// <summary>
            /// 出庫料捲取出失敗
            /// </summary>
            public const string RetrieveFail = "RF";         //電子料塔 出庫命令料捲取出失敗
        }
    }
}
