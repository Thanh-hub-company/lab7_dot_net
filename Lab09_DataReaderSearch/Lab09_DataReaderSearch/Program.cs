using System;
using System.Windows.Forms;
using Lab09_DataReaderSearch.Forms;

namespace Lab09_DataReaderSearch
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}