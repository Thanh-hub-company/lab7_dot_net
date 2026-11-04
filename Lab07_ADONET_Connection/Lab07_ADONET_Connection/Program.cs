using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Lab07_ADONET_Connection.GUI;

namespace Lab07_ADONET_Connection
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy Lab 7 trước.
            // Chương trình sẽ dừng tại đây cho đến khi đóng Lab 7.
            using (frmConnectionTest lab7Form = new frmConnectionTest())
            {
                Application.Run(lab7Form);
            }

            // Sau khi đóng Lab 7, chạy tiếp Lab 8, Lab 9 và Lab 10.
            string rootPath = GetRootPath();

            string lab8Path = Path.Combine(
                rootPath,
                "Lab08_SqlCommand",
                "Lab08_SqlCommand",
                "bin",
                "Debug",
                "Lab08_SqlCommand.exe");

            string lab9Path = Path.Combine(
                rootPath,
                "Lab09_DataReaderSearch",
                "Lab09_DataReaderSearch",
                "bin",
                "Debug",
                "Lab09_DataReaderSearch.exe");

            string lab10Path = Path.Combine(
                rootPath,
                "Lab10_DisconnectedData",
                "Lab10_DisconnectedData",
                "bin",
                "Debug",
                "Lab10_DisconnectedData.exe");

            StartProgram(lab8Path, "Lab 8");
            StartProgram(lab9Path, "Lab 9");
            StartProgram(lab10Path, "Lab 10");
        }

        private static string GetRootPath()
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(
                AppDomain.CurrentDomain.BaseDirectory);

            DirectoryInfo projectDirectory = currentDirectory
                .Parent?
                .Parent?
                .Parent;

            return projectDirectory?.Parent?.FullName
                   ?? AppDomain.CurrentDomain.BaseDirectory;
        }

        private static void StartProgram(string programPath, string programName)
        {
            if (!File.Exists(programPath))
            {
                MessageBox.Show(
                    $"Không tìm thấy file chạy {programName}:\n\n" +
                    $"{programPath}\n\n" +
                    $"Hãy Build project {programName} trước.",
                    "Lỗi khởi động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = programPath,
                WorkingDirectory = Path.GetDirectoryName(programPath),
                UseShellExecute = true
            });
        }
    }
}