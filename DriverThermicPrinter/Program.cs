using DriverThermicPrinter.Forms;
using System;
using System.Windows.Forms;

namespace DriverThermicPrinter {
    internal static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayAppContext(new Form_Configurar()));
        }
    }
}
