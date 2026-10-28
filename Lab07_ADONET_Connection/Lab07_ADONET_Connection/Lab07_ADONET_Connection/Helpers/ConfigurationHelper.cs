using System;
using System.Configuration;

namespace Lab07_ADONET_Connection.Helpers
{
    /// <summary>
    /// Lớp tiện ích hỗ trợ truy xuất và quản lý cấu hình từ App.config
    /// </summary>
    public static class ConfigurationHelper
    {
        private const string DefaultConnectionKey = "QLSinhVienConnection";

        /// <summary>
        /// Lấy chuỗi kết nối từ section <connectionStrings> trong tệp App.config
        /// </summary>
        /// <param name="key">Tên khóa đại diện cho chuỗi kết nối (Mặc định là 'QLSinhVienConnection')</param>
        /// <returns>Chuỗi kết nối hoặc string.Empty nếu không tìm thấy</returns>
        public static string GetConnectionString(string key = DefaultConnectionKey)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return string.Empty;
            }

            return ConfigurationManager.ConnectionStrings[key]?.ConnectionString ?? string.Empty;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của một chuỗi kết nối trong App.config
        /// </summary>
        /// <param name="key">Tên khóa cần kiểm tra</param>
        /// <returns>True nếu khóa tồn tại và có giá trị, ngược lại False</returns>
        public static bool HasConnectionString(string key = DefaultConnectionKey)
        {
            string connectionString = GetConnectionString(key);
            return !string.IsNullOrWhiteSpace(connectionString);
        }

        /// <summary>
        /// Đọc giá trị cấu hình tùy chỉnh từ section <appSettings> trong App.config
        /// </summary>
        /// <param name="key">Tên khóa cấu hình</param>
        /// <param name="defaultValue">Giá trị trả về mặc định nếu không tìm thấy khóa</param>
        /// <returns>Giá trị chuỗi tương ứng</returns>
        public static string GetAppSetting(string key, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defaultValue;
            }

            string value = ConfigurationManager.AppSettings[key];
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        /// <summary>
        /// Đọc giá trị cấu hình từ <appSettings> và tự động ép kiểu dữ liệu (int, bool, double, ...)
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu đầu ra mong muốn</typeparam>
        /// <param name="key">Tên khóa cấu hình</param>
        /// <param name="defaultValue">Giá trị mặc định nếu ép kiểu thất bại hoặc không có khóa</param>
        /// <returns>Giá trị đã được ép sang kiểu T</returns>
        public static T GetAppSetting<T>(string key, T defaultValue = default)
        {
            string value = GetAppSetting(key, null);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}