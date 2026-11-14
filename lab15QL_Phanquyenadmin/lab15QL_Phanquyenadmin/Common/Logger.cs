using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace QLSinhVien.Common
{
    public static class Logger
    {
        private static readonly object SyncLock = new object();
        private static string _resolvedLogDirectory;
        private static DateTime _lastCleanupDate = DateTime.MinValue;

        public static void Info(string message)
        {
            WriteLog("INFO", message, null);
        }

        public static void Warn(string message, Exception ex = null)
        {
            WriteLog("WARN", message, ex);
        }

        public static void Error(string message, Exception ex = null)
        {
            WriteLog("ERROR", message, ex);
        }

        public static string GetActiveLogDirectory()
        {
            if (!string.IsNullOrEmpty(_resolvedLogDirectory))
            {
                return _resolvedLogDirectory;
            }

            string configuredFolder = ConfigurationManager.AppSettings["LogFolder"];
            if (string.IsNullOrWhiteSpace(configuredFolder))
            {
                configuredFolder = "Logs";
            }

            string primaryDir = Path.IsPathRooted(configuredFolder)
                ? configuredFolder
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuredFolder);

            if (CanWriteToDirectory(primaryDir))
            {
                _resolvedLogDirectory = primaryDir;
                return _resolvedLogDirectory;
            }

            // Fallback sang %LocalAppData% nếu thư mục cài đặt (như Program Files) không có quyền ghi
            string fallbackDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "QLSinhVien",
                "Logs");

            Directory.CreateDirectory(fallbackDir);
            _resolvedLogDirectory = fallbackDir;
            return _resolvedLogDirectory;
        }

        private static bool CanWriteToDirectory(string dirPath)
        {
            try
            {
                Directory.CreateDirectory(dirPath);
                string probeFile = Path.Combine(dirPath, ".write_test_" + Guid.NewGuid().ToString("N") + ".tmp");
                File.WriteAllText(probeFile, "ok");
                File.Delete(probeFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void WriteLog(string level, string message, Exception ex)
        {
            try
            {
                lock (SyncLock)
                {
                    string logDir = GetActiveLogDirectory();
                    string currentLogFile = Path.Combine(logDir, DateTime.Now.ToString("yyyyMMdd") + ".log");

                    RotateIfExceedsSize(logDir, currentLogFile);

                    if (_lastCleanupDate.Date != DateTime.Today)
                    {
                        CleanupOldLogs(logDir);
                        _lastCleanupDate = DateTime.Today;
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("{0:yyyy-MM-dd HH:mm:ss.fff} | {1,-5} | {2}", DateTime.Now, level, message);
                    sb.AppendLine();

                    if (ex != null)
                    {
                        sb.AppendLine("--- Chi tiết ngoại lệ ---");
                        sb.AppendLine(ex.ToString());
                        sb.AppendLine("-------------------------");
                    }

                    File.AppendAllText(currentLogFile, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                // Tuyệt đối không để lỗi ghi log làm crash thêm ứng dụng
            }
        }

        private static void RotateIfExceedsSize(string logDir, string currentLogFile)
        {
            if (!File.Exists(currentLogFile))
            {
                return;
            }

            int maxSizeMB = GetIntAppSetting("LogMaxSizeMB", 5);
            long maxBytes = maxSizeMB * 1024L * 1024L;

            FileInfo fi = new FileInfo(currentLogFile);
            if (fi.Length < maxBytes)
            {
                return;
            }

            string stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string archivedLog = Path.Combine(logDir, string.Format("archive_{0}.log", stamp));
            string zipPath = Path.Combine(logDir, string.Format("archive_{0}.zip", stamp));

            File.Move(currentLogFile, archivedLog);

            try
            {
                using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(archivedLog, Path.GetFileName(archivedLog), CompressionLevel.Optimal);
                }
                File.Delete(archivedLog);
            }
            catch
            {
                // Giữ lại file .log đã đổi tên nếu quá trình nén gặp lỗi
            }
        }

        private static void CleanupOldLogs(string logDir)
        {
            int retentionDays = GetIntAppSetting("LogRetentionDays", 30);
            DateTime cutoff = DateTime.Now.AddDays(-retentionDays);

            string[] files = Directory.GetFiles(logDir);
            foreach (string file in files)
            {
                if (file.EndsWith(".log", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastWriteTime < cutoff)
                    {
                        try
                        {
                            fi.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private static int GetIntAppSetting(string key, int defaultValue)
        {
            int value;
            if (int.TryParse(ConfigurationManager.AppSettings[key], out value) && value > 0)
            {
                return value;
            }
            return defaultValue;
        }
    }
}