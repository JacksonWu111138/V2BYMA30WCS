using System;
using Mirle.Def;
using System.Windows.Forms;
using Mirle.Structure;
using Mirle.Structure.Info;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Mirle.DB.Object
{
    public class clsAPI
    {
        private static WebAPI.V2BYMA30.clsHost api;
        private static WebApiConfig wesApiconfig = new WebApiConfig();
        public static WebApiConfig _AgvApi_Config = new WebApiConfig();
        public static WebApiConfig _TowerApi_Config = new WebApiConfig();
        public static WebApiConfig _BoxApi_Config = new WebApiConfig();
        public static WebApiConfig _PcbaApi_Config = new WebApiConfig();
        public static WebApiConfig _SmtcApi_Config = new WebApiConfig();
        public static WebApiConfig _OsmtcApi_Config = new WebApiConfig();
        public static WebApiConfig _E04Api_Config = new WebApiConfig();
        public static WebApiConfig _E05Api_Config = new WebApiConfig();
        public static void Initial(WebApiConfig WesApiConfig, WebApiConfig AgvApi_config, WebApiConfig TowerApi_config, WebApiConfig BoxApi_config,
            WebApiConfig PcbaApi_config, WebApiConfig SmtcApi_config, WebApiConfig OsmtcApi_config, WebApiConfig E04Api_config, WebApiConfig E05Api_config)
        {
            api = new WebAPI.V2BYMA30.clsHost();
            wesApiconfig = WesApiConfig;
            _AgvApi_Config = AgvApi_config;
            _TowerApi_Config = TowerApi_config;
            _BoxApi_Config = BoxApi_config;
            _PcbaApi_Config = PcbaApi_config;
            _SmtcApi_Config = SmtcApi_config;
            _OsmtcApi_Config = OsmtcApi_config;
            _E04Api_Config = E04Api_config;
            _E05Api_Config = E05Api_config;
        }

        public static WebAPI.V2BYMA30.clsHost GetAPI() => api;
        public static WebApiConfig GetWesApiConfig() => wesApiconfig;
        public static WebApiConfig GetAgvcApiConfig() => _AgvApi_Config;
        public static WebApiConfig GetTowerApiConfig() => _TowerApi_Config;
        public static WebApiConfig GetBoxApiConfig() => _BoxApi_Config;
        public static WebApiConfig GetPcbaApiConfig() => _PcbaApi_Config;
        public static WebApiConfig GetStmcApiConfig() => _SmtcApi_Config;
        public static WebApiConfig GetOsmtcApiConfig() => _OsmtcApi_Config;
        public static WebApiConfig GetE04ApiConfig() => _E04Api_Config;
        public static WebApiConfig GetE05ApiConfig() => _E05Api_Config;
    }
}
