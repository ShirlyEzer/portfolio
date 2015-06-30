using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
