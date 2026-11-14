using System;
using System.Threading;
using System.Windows.Forms;
using QLSinhVien.Common;
using QLSinhVien.GUI;

namespace QLSinhVien
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            // Hỗ trợ mã hóa / giải mã connectionStrings qua tham số dòng lệnh
            if (args != null && args.Length > 0)
            {
                if (string.Equals(args[0], "--encrypt-config", StringComparison.OrdinalIgnoreCase))
                {
                    ConfigSecurityHelper.ProtectConnectionStrings();
                    return;
                }
                if (string.Equals(args[0], "--decrypt-config", StringComparison.OrdinalIgnoreCase))
                {
                    ConfigSecurityHelper.UnprotectConnectionStrings();
                    return;
                }
            }

            // Bắt buộc cấu hình trước khi khởi tạo bất kỳ Form nào
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.Info("=== Khởi động ứng dụng Quản lý Sinh viên ===");

            // Kiểm tra điều kiện môi trường trước khi vào màn hình chính
            if (AppConfigHelper.RunPreFlightOnStartup)
            {
                using (FrmPreFlightCheck preFlight = new FrmPreFlightCheck(autoCloseIfAllPassed: true))
                {
                    if (preFlight.ShowDialog() != DialogResult.OK)
                    {
                        Logger.Warn("Người dùng hủy khởi động tại màn hình kiểm tra hệ thống.");
                        return;
                    }
                }
            }

            Application.Run(new FrmSinhVien());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleFatalException(e.Exception, "UI Thread Exception");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception
                ?? new Exception(Convert.ToString(e.ExceptionObject));
            HandleFatalException(ex, "AppDomain Unhandled Exception");
        }

        private static void HandleFatalException(Exception ex, string source)
        {
            string errorId = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            Logger.Error(string.Format("LỖI NGHIÊM TRỌNG ({0}) [Mã sự cố: {1}]", source, errorId), ex);

            MessageBox.Show(
                string.Format(
                    "Ứng dụng gặp lỗi nghiêm trọng và buộc phải đóng để bảo toàn dữ liệu.\r\n" +
                    "Mã sự cố: {0}\r\n" +
                    "Chi tiết kỹ thuật đã được ghi vào thư mục Logs.",
                    errorId),
                "Lỗi nghiêm trọng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);

            Environment.Exit(1);
        }
    }
}