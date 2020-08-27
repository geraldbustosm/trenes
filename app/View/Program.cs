using System;
using System.Windows.Forms;
using Database;
using Event;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseUtility.ResetDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LayoutForm());
        }
    }
}
