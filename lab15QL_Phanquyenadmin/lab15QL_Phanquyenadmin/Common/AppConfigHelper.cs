using System;
using System.Configuration;
using System.IO;

namespace QLSinhVien.Common
{
    public static class AppConfigHelper
    {
        public const string DefaultConnectionName = "QLSinhVien";

        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[DefaultConnectionName];
                if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        string.Format("Không tìm thấy chuỗi kết nối '{0}' trong tệp cấu hình App.config.", DefaultConnectionName));
                }
                return settings.ConnectionString;
            }
        }

        public static string ReportFolder
        {
            get
            {
                string folder = ConfigurationManager.AppSettings["ReportFolder"];
                if (string.IsNullOrWhiteSpace(folder))
                {
                    folder = "Reports";
                }

                return Path.IsPathRooted(folder)
                    ? folder
                    : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            }
        }

        public static bool RequireCrystalReports
        {
            get
            {
                string raw = ConfigurationManager.AppSettings["RequireCrystalReports"];
                bool result;
                return bool.TryParse(raw, out result) && result;
            }
        }

        public static bool RunPreFlightOnStartup
        {
            get
            {
                string raw = ConfigurationManager.AppSettings["RunPreFlightOnStartup"];
                bool result;
                return !bool.TryParse(raw, out result) || result;
            }
        }
    }
}
