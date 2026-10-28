using System;
using System.Windows.Forms;
using Lab07_ADONET_Connection.GUI;

namespace Lab07_ADONET_Connection
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy Form test kết nối đã có sẵn trong thư mục GUI
            Application.Run(new frmConnectionTest());
        }
    }
}
