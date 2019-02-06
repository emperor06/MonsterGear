using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace MonsterGear
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MonsterUI appUI = new MonsterUI();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => { appUI.SaveConfig(); };
            Application.Run(appUI);
        }
    }
}
