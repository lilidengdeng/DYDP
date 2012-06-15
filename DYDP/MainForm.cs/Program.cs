using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainForm.cs
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new welcome());
            login loginform = new login();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                int i = loginform.USERID;
                Application.Run(new mainform(i));
            }

        }
    }
}
