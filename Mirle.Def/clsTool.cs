using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;

namespace Mirle.Def
{
    public class clsTool
    {
        /// <summary>
        /// 寫入Ini中特定位置
        /// </summary>
        /// <param name="Section">Section位置</param>
        /// <param name="Key">参數位置</param>
        /// <param name="Value">参數</param>
        public static void funWriteValue(string Section, string Key, string Value)
        {
            string strIniFilePath = Application.StartupPath + "\\Config\\ASRS.ini";
            clsNativeMethods.WritePrivateProfileString(Section, Key, Value, strIniFilePath);
        }

        /// <summary>
        /// win API Class
        /// </summary>
        private class clsNativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern int WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern int GetPrivateProfileString(string Section, string Key, string Definition, StringBuilder stringBuilder, int Size, string FilePath);
        }

        public static void FunVisbleChange(ref Button control)
        {
            if (control.Visible == true)
                control.Visible = false;
            else
                control.Visible = true;
        }

        public static void FunVisbleChange(ref CheckBox control)
        {
            if (control.Visible == true)
                control.Visible = false;
            else
                control.Visible = true;
        }
    }
}
