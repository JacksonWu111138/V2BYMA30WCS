using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.ASRS.WCS.View;
using System.Windows.Forms;

namespace Mirle.ASRS.WCS
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
