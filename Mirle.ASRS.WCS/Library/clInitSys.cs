using System;
using System.Windows.Forms;
using Mirle.Def;
using Config.Net;
using Mirle.Def.U2NMMA30;
using Mirle.DataBase;
using Mirle.Structure;
using System.Text;
using System.Runtime.InteropServices;
using Mirle.ASRS.WCS.View;

namespace Mirle.ASRS.WCS
{
    public class clInitSys
    {
        public static clsDbConfig DbConfig = new clsDbConfig();
        public static clsDbConfig DbConfig_WMS = new clsDbConfig();
        public static WebApiConfig AgvApi_Config = new WebApiConfig();
        public static WebApiConfig TowerApi_Config = new WebApiConfig();
        public static WebApiConfig WmsApi_Config = new WebApiConfig();
        public static WebApiConfig BoxApi_Config = new WebApiConfig();
        public static WebApiConfig PcbaApi_Config = new WebApiConfig();
        public static WebApiConfig SmtcApi_Config = new WebApiConfig();
        public static WebApiConfig OsmtcApi_Config = new WebApiConfig();
        public static WebApiConfig E04Api_Config = new WebApiConfig();
        public static WebApiConfig E05Api_Config = new WebApiConfig();
        public static WebApiConfig WcsApi_Config = new WebApiConfig();
        public static ASRSINI lcsini;
        public static int L2L_MaxCount = 5;
        
        //API
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString
            (string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void FunLoadIniSys()
        {
            try
            {
                lcsini = new ConfigurationBuilder<ASRSINI>()
                   .UseIniFile("Config\\ASRS.ini")
                   .Build();

                FunDbConfig(lcsini);
                FunSysConfig(lcsini);
                FunControllerID_Config(lcsini);
                FunApiConfig(lcsini);
                FunStkStnConfig(lcsini);
                FunStnNoConfig(lcsini);
                //MainForm.AGVBuffer_Initial();
                MainForm.CraneBuffer_Initial();
                FunDeviceConfig(lcsini);
            }
            catch(Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                MessageBox.Show("找不到.ini資料，請洽系統管理人員 !!", "MIRLE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
        }

        private static void FunDbConfig(ASRSINI lcsini)
        {
            DbConfig.CommandTimeOut = lcsini.Database.CommandTimeOut;
            DbConfig.ConnectTimeOut = lcsini.Database.ConnectTimeOut;
            DbConfig.DbName = lcsini.Database.DataBase;
            DbConfig.DbPassword = lcsini.Database.DbPswd;
            DbConfig.DbServer = lcsini.Database.DbServer;
            DbConfig.DBType = (DBTypes)Enum.Parse(typeof(DBTypes), lcsini.Database.DBMS);
            DbConfig.DbUser = lcsini.Database.DbUser;
            DbConfig.FODBServer = lcsini.Database.FODbServer;
            DbConfig.WriteLog = true;

            DbConfig_WMS.CommandTimeOut = lcsini.Database_WMS.CommandTimeOut;
            DbConfig_WMS.ConnectTimeOut = lcsini.Database_WMS.ConnectTimeOut;
            DbConfig_WMS.DbName = lcsini.Database_WMS.DataBase;
            DbConfig_WMS.DbPassword = lcsini.Database_WMS.DbPswd;
            DbConfig_WMS.DbServer = lcsini.Database_WMS.DbServer;
            DbConfig_WMS.DBType = (DBTypes)Enum.Parse(typeof(DBTypes), lcsini.Database_WMS.DBMS);
            DbConfig_WMS.DbUser = lcsini.Database_WMS.DbUser;
            DbConfig_WMS.FODBServer = lcsini.Database_WMS.FODbServer;
            DbConfig_WMS.WriteLog = true;
        }

        private static void FunSysConfig(ASRSINI lcsini)
        {
            L2L_MaxCount = lcsini.System_Info.L2L_MaxCount;
        }

        private static void FunControllerID_Config(ASRSINI lcsini)
        {
            ConveyorDef.AGV.E1_01.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.Tower.E1_04.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E1_08.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_35.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_36.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_37.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_38.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_39.ControllerID = lcsini.ControllerID.Tower;
            ConveyorDef.AGV.E2_44.ControllerID = lcsini.ControllerID.Tower;

            ConveyorDef.Box.B1_001.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_004.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_007.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_010.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_013.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_016.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_019.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_022.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_025.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_028.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_031.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_034.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_081.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_084.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_087.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_090.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_093.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_096.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_099.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_102.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_105.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_108.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_111.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_114.ControllerID = lcsini.ControllerID.Box;

            ConveyorDef.Box.B1_037.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_041.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_045.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_054.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_117.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_121.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_125.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_134.ControllerID = lcsini.ControllerID.Box;

            ConveyorDef.Box.B1_062.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_067.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_142.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.Box.B1_147.ControllerID = lcsini.ControllerID.Box;

            ConveyorDef.AGV.B1_070.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.AGV.B1_071.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.AGV.B1_074.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.AGV.B1_075.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.AGV.B1_078.ControllerID = lcsini.ControllerID.Box;
            ConveyorDef.AGV.B1_079.ControllerID = lcsini.ControllerID.Box;

            ConveyorDef.PCBA.M1_01.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.PCBA.M1_06.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.PCBA.M1_11.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.PCBA.M1_16.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.AGV.M1_05.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.AGV.M1_10.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.AGV.M1_15.ControllerID = lcsini.ControllerID.PCBA;
            ConveyorDef.AGV.M1_20.ControllerID = lcsini.ControllerID.PCBA;

            ConveyorDef.AGV.S1_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_07.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_13.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_25.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_31.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_37.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_38.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_39.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_40.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_41.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_42.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_43.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_44.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_45.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_46.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S1_47.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_48.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_49.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S1_50.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_07.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_13.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_25.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_31.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S2_49.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_07.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_13.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_19.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_25.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_31.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_37.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_38.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_39.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_42.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_43.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_45.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_46.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S3_47.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S3_49.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_07.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_13.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_19.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_25.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_49.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S4_50.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S5_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S5_07.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S5_37.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S5_38.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.SMTC.S5_39.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S5_49.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S6_01.ControllerID = lcsini.ControllerID.SMTC;
            ConveyorDef.AGV.S6_07.ControllerID = lcsini.ControllerID.SMTC;

            ConveyorDef.AGV.A4_01.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_02.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_03.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_04.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_05.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_06.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_07.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_08.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_09.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_10.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_11.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_12.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_13.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_14.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_15.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_16.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_17.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_18.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.Line.A4_19.ControllerID = lcsini.ControllerID.Line;
            ConveyorDef.AGV.A4_20.ControllerID = lcsini.ControllerID.Line;

            ConveyorDef.AGV.A1_01.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_02.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_03.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.AGV.A1_04.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.AGV.A1_05.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_06.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_07.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.AGV.A1_08.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.AGV.A1_09.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_10.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.SMT3C.A1_11.ControllerID = lcsini.ControllerID.SMT3C;
            ConveyorDef.AGV.A1_12.ControllerID = lcsini.ControllerID.SMT3C;

            ConveyorDef.AGV.A2_01.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_02.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_03.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_04.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_05.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_06.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_07.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_08.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_09.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_10.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_11.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_12.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_13.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_14.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_15.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_16.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_17.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_18.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.SMT5C.A2_19.ControllerID = lcsini.ControllerID.SMT5C;
            ConveyorDef.AGV.A2_20.ControllerID = lcsini.ControllerID.SMT5C;

            ConveyorDef.AGV.A3_01.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_02.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_03.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_04.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_05.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_06.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_07.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_08.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_09.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_10.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_11.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_12.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_13.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_14.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_15.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_16.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_17.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_18.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.SMT6C.A3_19.ControllerID = lcsini.ControllerID.SMT6C;
            ConveyorDef.AGV.A3_20.ControllerID = lcsini.ControllerID.SMT6C;

            ConveyorDef.E04.LO1_02.ControllerID = lcsini.ControllerID.E04;
            ConveyorDef.E04.LO1_07.ControllerID = lcsini.ControllerID.E04;
            ConveyorDef.AGV.LO2_01.ControllerID = lcsini.ControllerID.E04;
            ConveyorDef.AGV.LO2_04.ControllerID = lcsini.ControllerID.E04;

            ConveyorDef.AGV.LO4_01.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO4_04.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO5_01.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO5_04.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO6_01.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO6_04.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO3_01.ControllerID = lcsini.ControllerID.E05;
            ConveyorDef.AGV.LO3_04.ControllerID = lcsini.ControllerID.E05;
        }

        private static void FunStnNoConfig(ASRSINI lcsini)
        {
            ConveyorDef.E04.LO1_02.StnNo = lcsini.StnNo.LO1_02;
            ConveyorDef.E04.LO1_07.StnNo = lcsini.StnNo.LO1_07;
            ConveyorDef.Box.B1_062.StnNo = lcsini.StnNo.B1_062;
            ConveyorDef.Box.B1_067.StnNo = lcsini.StnNo.B1_067;
            ConveyorDef.AGV.B1_070.StnNo = lcsini.StnNo.B1_070;
            //ConveyorDef.AGV.B1_071.StnNo = lcsini.StnNo.B1_071;
            ConveyorDef.AGV.B1_074.StnNo = lcsini.StnNo.B1_074;
            ConveyorDef.AGV.B1_078.StnNo = lcsini.StnNo.B1_078;
            //ConveyorDef.AGV.B1_079.StnNo = lcsini.StnNo.B1_079;
            ConveyorDef.Box.B1_142.StnNo = lcsini.StnNo.B1_142;
            ConveyorDef.Box.B1_147.StnNo = lcsini.StnNo.B1_147;
            ConveyorDef.SMT3C.A1_02.StnNo = lcsini.StnNo.A1_02;
            ConveyorDef.SMT3C.A1_03.StnNo = lcsini.StnNo.A1_03;
            ConveyorDef.SMT3C.A1_06.StnNo = lcsini.StnNo.A1_06;
            ConveyorDef.SMT3C.A1_07.StnNo = lcsini.StnNo.A1_07;
            ConveyorDef.SMT3C.A1_10.StnNo = lcsini.StnNo.A1_10;
            ConveyorDef.SMT3C.A1_11.StnNo = lcsini.StnNo.A1_11;
            ConveyorDef.SMT5C.A2_02.StnNo = lcsini.StnNo.A2_02;
            ConveyorDef.SMT5C.A2_03.StnNo = lcsini.StnNo.A2_03;
            ConveyorDef.SMT5C.A2_06.StnNo = lcsini.StnNo.A2_06;
            ConveyorDef.SMT5C.A2_07.StnNo = lcsini.StnNo.A2_07;
            ConveyorDef.SMT5C.A2_10.StnNo = lcsini.StnNo.A2_10;
            ConveyorDef.SMT5C.A2_11.StnNo = lcsini.StnNo.A2_11;
            ConveyorDef.SMT5C.A2_14.StnNo = lcsini.StnNo.A2_14;
            ConveyorDef.SMT5C.A2_15.StnNo = lcsini.StnNo.A2_15;
            ConveyorDef.SMT5C.A2_18.StnNo = lcsini.StnNo.A2_18;
            ConveyorDef.SMT5C.A2_19.StnNo = lcsini.StnNo.A2_19;
            ConveyorDef.SMT6C.A3_02.StnNo = lcsini.StnNo.A3_02;
            ConveyorDef.SMT6C.A3_03.StnNo = lcsini.StnNo.A3_03;
            ConveyorDef.SMT6C.A3_06.StnNo = lcsini.StnNo.A3_06;
            ConveyorDef.SMT6C.A3_07.StnNo = lcsini.StnNo.A3_07;
            ConveyorDef.SMT6C.A3_10.StnNo = lcsini.StnNo.A3_10;
            ConveyorDef.SMT6C.A3_11.StnNo = lcsini.StnNo.A3_11;
            ConveyorDef.SMT6C.A3_14.StnNo = lcsini.StnNo.A3_14;
            ConveyorDef.SMT6C.A3_15.StnNo = lcsini.StnNo.A3_15;
            ConveyorDef.SMT6C.A3_18.StnNo = lcsini.StnNo.A3_18;
            ConveyorDef.SMT6C.A3_19.StnNo = lcsini.StnNo.A3_19;
            ConveyorDef.AGV.S1_01.StnNo = lcsini.StnNo.S1_01;
            ConveyorDef.AGV.S1_07.StnNo = lcsini.StnNo.S1_07;
            ConveyorDef.AGV.S1_13.StnNo = lcsini.StnNo.S1_13;
            ConveyorDef.AGV.S1_25.StnNo = lcsini.StnNo.S1_25;
            ConveyorDef.AGV.S1_31.StnNo = lcsini.StnNo.S1_31;
            ConveyorDef.SMTC.S1_38.StnNo = lcsini.StnNo.S1_38;
            ConveyorDef.SMTC.S1_39.StnNo = lcsini.StnNo.S1_39;
            ConveyorDef.SMTC.S1_42.StnNo = lcsini.StnNo.S1_42;
            ConveyorDef.SMTC.S1_43.StnNo = lcsini.StnNo.S1_43;
            ConveyorDef.SMTC.S1_46.StnNo = lcsini.StnNo.S1_46;
            ConveyorDef.SMTC.S1_47.StnNo = lcsini.StnNo.S1_47;
            ConveyorDef.AGV.S1_49.StnNo = lcsini.StnNo.S1_49;
            ConveyorDef.AGV.S1_50.StnNo = lcsini.StnNo.S1_50;
            ConveyorDef.AGV.S2_01.StnNo = lcsini.StnNo.S2_01;
            ConveyorDef.AGV.S2_07.StnNo = lcsini.StnNo.S2_07;
            ConveyorDef.AGV.S2_13.StnNo = lcsini.StnNo.S2_13;
            ConveyorDef.AGV.S2_25.StnNo = lcsini.StnNo.S2_25;
            ConveyorDef.AGV.S2_31.StnNo = lcsini.StnNo.S2_31;
            ConveyorDef.AGV.S2_49.StnNo = lcsini.StnNo.S2_49;
            ConveyorDef.AGV.S3_01.StnNo = lcsini.StnNo.S3_01;
            ConveyorDef.AGV.S3_07.StnNo = lcsini.StnNo.S3_07;
            ConveyorDef.AGV.S3_13.StnNo = lcsini.StnNo.S3_13;
            ConveyorDef.AGV.S3_19.StnNo = lcsini.StnNo.S3_19;
            ConveyorDef.AGV.S3_25.StnNo = lcsini.StnNo.S3_25;
            ConveyorDef.AGV.S3_31.StnNo = lcsini.StnNo.S3_31;
            ConveyorDef.SMTC.S3_38.StnNo = lcsini.StnNo.S3_38;
            ConveyorDef.SMTC.S3_39.StnNo = lcsini.StnNo.S3_39;
            ConveyorDef.SMTC.S3_42.StnNo = lcsini.StnNo.S3_42;
            ConveyorDef.SMTC.S3_43.StnNo = lcsini.StnNo.S3_43;
            ConveyorDef.SMTC.S3_46.StnNo = lcsini.StnNo.S3_46;
            ConveyorDef.SMTC.S3_47.StnNo = lcsini.StnNo.S3_47;
            ConveyorDef.AGV.S3_49.StnNo = lcsini.StnNo.S3_49;
            ConveyorDef.AGV.S4_01.StnNo = lcsini.StnNo.S4_01;
            ConveyorDef.AGV.S4_07.StnNo = lcsini.StnNo.S4_07;
            ConveyorDef.AGV.S4_13.StnNo = lcsini.StnNo.S4_13;
            ConveyorDef.AGV.S4_19.StnNo = lcsini.StnNo.S4_19;
            ConveyorDef.AGV.S4_25.StnNo = lcsini.StnNo.S4_25;
            ConveyorDef.AGV.S4_49.StnNo = lcsini.StnNo.S4_49;
            ConveyorDef.AGV.S4_50.StnNo = lcsini.StnNo.S4_50;
            ConveyorDef.SMTC.S5_38.StnNo = lcsini.StnNo.S5_38;
            ConveyorDef.SMTC.S5_39.StnNo = lcsini.StnNo.S5_39;
            ConveyorDef.Line.A4_02.StnNo = lcsini.StnNo.A4_02;
            ConveyorDef.Line.A4_03.StnNo = lcsini.StnNo.A4_03;
            ConveyorDef.Line.A4_06.StnNo = lcsini.StnNo.A4_06;
            ConveyorDef.Line.A4_07.StnNo = lcsini.StnNo.A4_07;
            ConveyorDef.Line.A4_10.StnNo = lcsini.StnNo.A4_10;
            ConveyorDef.Line.A4_11.StnNo = lcsini.StnNo.A4_11;
            ConveyorDef.Line.A4_14.StnNo = lcsini.StnNo.A4_14;
            ConveyorDef.Line.A4_15.StnNo = lcsini.StnNo.A4_15;
            ConveyorDef.Line.A4_18.StnNo = lcsini.StnNo.A4_18;
            ConveyorDef.Line.A4_19.StnNo = lcsini.StnNo.A4_19;
            ConveyorDef.Tower.E1_04.StnNo = lcsini.StnNo.E1_04;
            ConveyorDef.Tower.E1_10.StnNo = lcsini.StnNo.E1_10;
            ConveyorDef.AGV.E2_35.StnNo = lcsini.StnNo.E2_35;
            ConveyorDef.AGV.E2_36.StnNo = lcsini.StnNo.E2_36;
            ConveyorDef.AGV.E2_37.StnNo = lcsini.StnNo.E2_37;
            ConveyorDef.AGV.E2_38.StnNo = lcsini.StnNo.E2_38;
            ConveyorDef.AGV.E2_39.StnNo = lcsini.StnNo.E2_39;
            ConveyorDef.AGV.E2_44.StnNo = lcsini.StnNo.E2_44;
            ConveyorDef.AGV.M1_10.StnNo = lcsini.StnNo.M1_10;
            ConveyorDef.AGV.M1_20.StnNo = lcsini.StnNo.M1_20;
            ConveyorDef.AGV.M1_05.StnNo = lcsini.StnNo.M1_05;
            ConveyorDef.AGV.M1_15.StnNo = lcsini.StnNo.M1_15;
            ConveyorDef.WES_B800CV = lcsini.StnNo.WES_B800CV;
        }

        private static void FunDeviceConfig(ASRSINI lcsini)
        {
            string[] adPCBA = lcsini.EquNo.PCBA.Split(',');
            for (int i = 0; i < MainForm.PCBA.Length; i++)
            {
                MainForm.PCBA[i].DeviceID = adPCBA[i];
            }

            string[] adBox = lcsini.EquNo.Box.Split(',');
            for (int i = 0; i < MainForm.Box.Length; i++)
            {
                MainForm.Box[i].DeviceID = adBox[i];
            }

            ConveyorDef.DeviceID_AGV = lcsini.EquNo.AGV.Trim();
            ConveyorDef.DeviceID_Tower = lcsini.EquNo.Tower.Trim();
        }
      
        private static void FunApiConfig(ASRSINI lcsini)
        {
            WmsApi_Config.IP = lcsini.Client_API.WES;
            AgvApi_Config.IP = lcsini.Client_API.AGV;
            TowerApi_Config.IP = lcsini.Client_API.Tower;
            BoxApi_Config.IP = lcsini.Client_API.Box;
            PcbaApi_Config.IP = lcsini.Client_API.PCBA;
            SmtcApi_Config.IP = lcsini.Client_API.SMTC;
            OsmtcApi_Config.IP = lcsini.Client_API.SMT3C;
            E04Api_Config.IP = lcsini.Client_API.E04;
            E05Api_Config.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.E1_01.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.Tower.E1_04.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E1_08.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_35.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_36.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_37.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_38.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_39.API.IP = lcsini.Client_API.Tower;
            ConveyorDef.AGV.E2_44.API.IP = lcsini.Client_API.Tower;

            ConveyorDef.Box.B1_001.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_004.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_007.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_010.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_013.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_016.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_019.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_022.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_025.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_028.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_031.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_034.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_081.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_084.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_087.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_090.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_093.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_096.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_099.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_102.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_105.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_108.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_111.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_114.API.IP = lcsini.Client_API.Box;

            ConveyorDef.Box.B1_037.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_041.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_045.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_054.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_117.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_121.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_125.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_134.API.IP = lcsini.Client_API.Box;

            ConveyorDef.Box.B1_062.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_067.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_142.API.IP = lcsini.Client_API.Box;
            ConveyorDef.Box.B1_147.API.IP = lcsini.Client_API.Box;

            ConveyorDef.AGV.B1_070.API.IP = lcsini.Client_API.Box;
            ConveyorDef.AGV.B1_071.API.IP = lcsini.Client_API.Box;
            ConveyorDef.AGV.B1_074.API.IP = lcsini.Client_API.Box;
            ConveyorDef.AGV.B1_075.API.IP = lcsini.Client_API.Box;
            ConveyorDef.AGV.B1_078.API.IP = lcsini.Client_API.Box;
            ConveyorDef.AGV.B1_079.API.IP = lcsini.Client_API.Box;

            ConveyorDef.PCBA.M1_01.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.PCBA.M1_06.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.PCBA.M1_11.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.PCBA.M1_16.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.AGV.M1_05.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.AGV.M1_10.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.AGV.M1_15.API.IP = lcsini.Client_API.PCBA;
            ConveyorDef.AGV.M1_20.API.IP = lcsini.Client_API.PCBA;

            ConveyorDef.AGV.S1_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_07.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_13.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_25.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_31.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_37.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_38.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_39.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_40.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_41.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_42.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_43.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_44.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_45.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_46.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S1_47.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_48.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_49.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S1_50.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_07.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_13.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_25.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_31.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S2_49.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_07.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_13.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_19.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_25.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_31.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_37.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_38.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_39.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_42.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_43.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_45.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_46.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S3_47.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S3_49.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_07.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_13.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_19.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_25.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_49.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S4_50.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S5_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S5_07.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S5_37.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S5_38.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.SMTC.S5_39.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S5_49.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S6_01.API.IP = lcsini.Client_API.SMTC;
            ConveyorDef.AGV.S6_07.API.IP = lcsini.Client_API.SMTC;

            ConveyorDef.AGV.A4_01.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_02.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_03.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_04.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_05.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_06.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_07.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_08.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_09.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_10.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_11.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_12.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_13.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_14.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_15.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_16.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_17.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_18.API.IP = lcsini.Client_API.Line;
            ConveyorDef.Line.A4_19.API.IP = lcsini.Client_API.Line;
            ConveyorDef.AGV.A4_20.API.IP = lcsini.Client_API.Line;

            ConveyorDef.AGV.A1_01.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_02.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_03.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.AGV.A1_04.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.AGV.A1_05.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_06.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_07.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.AGV.A1_08.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.AGV.A1_09.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_10.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.SMT3C.A1_11.API.IP = lcsini.Client_API.SMT3C;
            ConveyorDef.AGV.A1_12.API.IP = lcsini.Client_API.SMT3C;

            ConveyorDef.AGV.A2_01.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_02.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_03.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_04.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_05.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_06.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_07.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_08.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_09.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_10.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_11.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_12.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_13.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_14.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_15.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_16.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_17.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_18.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.SMT5C.A2_19.API.IP = lcsini.Client_API.SMT5C;
            ConveyorDef.AGV.A2_20.API.IP = lcsini.Client_API.SMT5C;

            ConveyorDef.AGV.A3_01.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_02.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_03.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_04.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_05.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_06.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_07.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_08.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_09.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_10.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_11.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_12.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_13.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_14.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_15.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_16.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_17.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_18.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.SMT6C.A3_19.API.IP = lcsini.Client_API.SMT6C;
            ConveyorDef.AGV.A3_20.API.IP = lcsini.Client_API.SMT6C;

            ConveyorDef.E04.LO1_02.API.IP = lcsini.Client_API.E04;
            ConveyorDef.E04.LO1_07.API.IP = lcsini.Client_API.E04;
            ConveyorDef.AGV.LO2_01.API.IP = lcsini.Client_API.E04;
            ConveyorDef.AGV.LO2_04.API.IP = lcsini.Client_API.E04;

            ConveyorDef.AGV.LO4_01.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO4_04.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO5_01.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO5_04.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO6_01.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO6_04.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO3_01.API.IP = lcsini.Client_API.E05;
            ConveyorDef.AGV.LO3_04.API.IP = lcsini.Client_API.E05;

            WcsApi_Config.IP = lcsini.Server_API.IP;
        }

        private static void FunStkStnConfig(ASRSINI lcsini)
        {
            ConveyorDef.PCBA.M1_01.StkPortID = lcsini.STK_STN.PCBA_Left;
            ConveyorDef.PCBA.M1_06.StkPortID = lcsini.STK_STN.PCBA_Right;
            ConveyorDef.PCBA.M1_11.StkPortID = lcsini.STK_STN.PCBA_Left;
            ConveyorDef.PCBA.M1_16.StkPortID = lcsini.STK_STN.PCBA_Right;

            ConveyorDef.Box.B1_001.StkPortID = lcsini.STK_STN.Left_Small_All;
            ConveyorDef.Box.B1_004.StkPortID = lcsini.STK_STN.Left_Small_Half;
            ConveyorDef.Box.B1_007.StkPortID = lcsini.STK_STN.Right_Small_Half;
            ConveyorDef.Box.B1_010.StkPortID = lcsini.STK_STN.Right_Small_All;
            ConveyorDef.Box.B1_081.StkPortID = lcsini.STK_STN.Left_Big_All;
            ConveyorDef.Box.B1_084.StkPortID = lcsini.STK_STN.Left_Big_Half;
            ConveyorDef.Box.B1_087.StkPortID = lcsini.STK_STN.Right_Big_Half;
            ConveyorDef.Box.B1_090.StkPortID = lcsini.STK_STN.Right_Big_All;

            ConveyorDef.Box.B1_013.StkPortID = lcsini.STK_STN.Left_Small_All;
            ConveyorDef.Box.B1_016.StkPortID = lcsini.STK_STN.Left_Small_Half;
            ConveyorDef.Box.B1_019.StkPortID = lcsini.STK_STN.Right_Small_Half;
            ConveyorDef.Box.B1_022.StkPortID = lcsini.STK_STN.Right_Small_All;
            ConveyorDef.Box.B1_093.StkPortID = lcsini.STK_STN.Left_Big_All;
            ConveyorDef.Box.B1_096.StkPortID = lcsini.STK_STN.Left_Big_Half;
            ConveyorDef.Box.B1_099.StkPortID = lcsini.STK_STN.Right_Big_Half;
            ConveyorDef.Box.B1_102.StkPortID = lcsini.STK_STN.Right_Big_All;

            ConveyorDef.Box.B1_025.StkPortID = lcsini.STK_STN.Left_Small_All;
            ConveyorDef.Box.B1_028.StkPortID = lcsini.STK_STN.Left_Small_Half;
            ConveyorDef.Box.B1_031.StkPortID = lcsini.STK_STN.Right_Small_Half;
            ConveyorDef.Box.B1_034.StkPortID = lcsini.STK_STN.Right_Small_All;
            ConveyorDef.Box.B1_105.StkPortID = lcsini.STK_STN.Left_Big_All;
            ConveyorDef.Box.B1_108.StkPortID = lcsini.STK_STN.Left_Big_Half;
            ConveyorDef.Box.B1_111.StkPortID = lcsini.STK_STN.Right_Big_Half;
            ConveyorDef.Box.B1_114.StkPortID = lcsini.STK_STN.Right_Big_All;
        }

        /// <summary>
        /// 讀取ini檔的單一欄位
        /// </summary>
        /// <param name="sFileName">INI檔檔名</param>
        /// <param name="sAppName">區段名</param>
        /// <param name="sKeyName">KEY名稱</param>
        /// <param name="strDefault">Default</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string funReadParam(string sFileName, string sAppName, string sKeyName, string strDefault = "")
        {
            StringBuilder sResult = new StringBuilder(255);
            int intResult;
            try
            {
                intResult = GetPrivateProfileString(sAppName, sKeyName, strDefault, sResult, sResult.Capacity, sFileName);
                string R = sResult.ToString().Trim();
                return R;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return strDefault;
            }
        }
    }
}
