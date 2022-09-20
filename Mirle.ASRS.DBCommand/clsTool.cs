using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.ASRS.DBCommand
{
    public class clsTool
    {
        public static string GetSqlEquNo(DeviceInfo device)
        {
            return $"'{device.DeviceID}'";
        }

        public static string GetAllSqlEquNo(DeviceInfo[] devices)
        {
            string EquNoString = "";
            for (int i = 0; i < devices.Length; i++)
            {
                if (i == 0) EquNoString = GetSqlEquNo(devices[i]);
                else EquNoString += "," + GetSqlEquNo(devices[i]);
            }

            return EquNoString;
        }

        public static string GetSqlLocation_ForIn(DeviceInfo device)
        {
            string StockInLoc_Sql = "";
            int count = 1;
            foreach (var floor in device.Floors)
            {
                foreach (var conveyer in floor.Group_IN)
                {
                    if (count == 1)
                    {
                        StockInLoc_Sql = $"'{conveyer.BufferName}'";
                    }
                    else
                    {
                        StockInLoc_Sql += $",'{conveyer.BufferName}'";
                    }

                    count++;
                }
            }

            return StockInLoc_Sql;
        }

        public static string GetAllSqlLocation_ForIn(DeviceInfo[] devices)
        {
            string StockInLoc_Sql = "";
            for (int i = 0; i < devices.Length; i++)
            {
                if (i == 0) StockInLoc_Sql = GetSqlLocation_ForIn(devices[i]);
                else StockInLoc_Sql += "," + GetSqlLocation_ForIn(devices[i]);
            }

            return StockInLoc_Sql;
        }
    }
}
