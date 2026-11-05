using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

            // 1. Khởi chạy Lab 07 trước (Ứng dụng dừng tại đây cho tới khi đóng Form Lab 7)
            using (frmConnectionTest lab7Form = new frmConnectionTest())
            {
                Application.Run(lab7Form);
            }

            // 2. Lấy đường dẫn thư mục gốc chứa các Lab
            string rootPath = GetRootPath();

            // 3. Tự động tìm kiếm file .exe của từng Lab (Quét thông minh mọi thư mục bin/Debug)
            string lab8Path = LocateExe(rootPath, "Lab08_SqlCommand", "Lab08_SqlCommand.exe");
            string lab9Path = LocateExe(rootPath, "Lab09_DataReaderSearch", "Lab09_DataReaderSearch.exe");
            string lab10Path = LocateExe(rootPath, "Lab10_DisconnectedData", "Lab10_DisconnectedData.exe");
            string lab11Path = LocateExe(rootPath, "Lab11_CRUD_StoredProcedure", "GUI.exe", "Lab11_CRUD_StoredProcedure.exe", "Lab11.exe");

            // 4. Khởi chạy các Lab tiếp theo
            StartProgram(lab8Path, "Lab 8");
            StartProgram(lab9Path, "Lab 9");
            StartProgram(lab10Path, "Lab 10");
            StartProgram(lab11Path, "Lab 11");
        }

        /// <summary>
        /// Xác định thư mục gốc của Solution
        /// </summary>
        private static string GetRootPath()
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo projectDirectory = currentDirectory.Parent?.Parent?.Parent;
            return projectDirectory?.Parent?.FullName ?? AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Thuật toán quét và tìm kiếm file .exe linh hoạt trong toàn bộ cây thư mục của Lab
        /// </summary>
        private static string LocateExe(string rootPath, string folderName, params string[] possibleExeNames)
        {
            string targetFolder = Path.Combine(rootPath, folderName);

            // Tìm thư mục nếu tên bị lệch chữ hoa/thường
            if (!Directory.Exists(targetFolder))
            {
                string[] subDirs = Directory.GetDirectories(rootPath, $"*{folderName}*", SearchOption.TopDirectoryOnly);
                if (subDirs.Length > 0)
                {
                    targetFolder = subDirs[0];
                }
            }

            if (Directory.Exists(targetFolder))
            {
                // Quét tất cả file .exe phù hợp trong các thư mục con (bin/Debug, net472, net8.0,...)
                foreach (string exeName in possibleExeNames)
                {
                    string[] foundFiles = Directory.GetFiles(targetFolder, exeName, SearchOption.AllDirectories);

                    // Ưu tiên lấy file nằm trong thư mục bin\Debug
                    string debugExe = foundFiles.FirstOrDefault(f => f.IndexOf(@"\bin\Debug\", StringComparison.OrdinalIgnoreCase) >= 0);
                    if (!string.IsNullOrEmpty(debugExe)) return debugExe;

                    if (foundFiles.Length > 0) return foundFiles[0];
                }
            }

            // Trả về đường dẫn giả định chuẩn để hiển thị thông báo nếu không tìm thấy
            return Path.Combine(targetFolder, "GUI", "bin", "Debug", possibleExeNames[0]);
        }

        /// <summary>
        /// Hàm mở tiến trình file .exe
        /// </summary>
        private static void StartProgram(string programPath, string programName)
        {
            if (!File.Exists(programPath))
            {
                MessageBox.Show(
                    $"Không tìm thấy file chạy của {programName}.\n\n" +
                    $"Đường dẫn kiểm tra: {programPath}\n\n" +
                    $"Cách xử lý:\n" +
                    $"1. Nhấp chuột phải vào Project '{programName}' (hoặc Project GUI của Lab 11) trong Solution Explorer.\n" +
                    $"2. Chọn 'Build' (hoặc Rebuild) để biên dịch sinh ra file .exe.\n" +
                    $"3. Kiểm tra cửa sổ Error List xem có lỗi biên dịch C# nào không.",
                    "Lỗi khởi động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = programPath,
                    WorkingDirectory = Path.GetDirectoryName(programPath),
                    UseShellExecute = true
                });
            }