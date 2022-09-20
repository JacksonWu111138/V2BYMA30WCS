using Mirle.DataBase;
using Mirle.Def;

namespace Mirle.Middle.DB_Proc
{
    public class clsGetDB
    {
        public static DB GetDB(clsDbConfig _config)
        {
            DBOptions options = new DBOptions();
            options.SetDBType(_config.DBType);
            options.SetAccount(_config.DbName, _config.DbUser, _config.DbPassword);
            options.SetCommandTimeOut(_config.CommandTimeOut);
            options.SetConnectTimeOut(_config.ConnectTimeOut);
            options.SetDBServer(_config.DbServer, _config.DbPort, _config.FODBServer);
            options.EnableWriteLog();
            DB db;
            if (_config.DBType == DBTypes.SqlServer)
                db = new SqlServer(options);
            else if (_config.DBType == DBTypes.SQLite)
                db = new SQLite(options);
            else db = new OracleClient(options);

            return db;
        }

        public static int FunDbOpen(DB db)
        {
            string strEM = "";
            return FunDbOpen(db, ref strEM);
        }

        public static int FunDbOpen(DB db, ref string strEM)
        {
            int iRet = db.Open(ref strEM);
            if(iRet != DBResult.Success)
            {
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"資料庫開啟失敗！=> {strEM}");
            }

            return iRet;
        }
    }
}
