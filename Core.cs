using System;
using System.Windows.Forms;

namespace Pre2Core
{
    public static class Core
    {
        private static Pre2Frame _Main { get; set;}

        public static void Init(Pre2Frame main) 
        {
            _Main = main;
        }

        [STAThread]
        public static void Launch() 
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Pre2Form(_Main));
        }
    }
}
