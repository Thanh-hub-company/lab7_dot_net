using System;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Khởi chạy đúng FormLab10
            Application.Run(new FormLab10());
        }
    }
}