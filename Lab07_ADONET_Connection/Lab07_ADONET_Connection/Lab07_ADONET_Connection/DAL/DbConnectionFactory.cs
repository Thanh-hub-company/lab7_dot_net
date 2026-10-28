using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    /// <summary>
    /// Lớp Factory quản lý và khởi tạo đối tượng kết nối SQL Server
    /// </summary>
    public static class DbConnectionFactory
    {
        private const string ConnectionKey = "QLSinhVienConnection";

        // Chuỗi kết nối mặc định làm phương án dự phòng nếu App.config thiếu thẻ cấu hình
        private const string FallbackConnectionString =
            @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";

        private static readonly string ConnectionString;

        static DbConnectionFactory()
        {
            // Đọc chuỗi kết nối từ App.config
            string configString = ConfigurationManager.ConnectionStrings[ConnectionKey]?.ConnectionString;

            // Nếu đọc được từ App.config thì lấy chuỗi đó, ngược lại lấy chuỗi dự phòng
            ConnectionString = !string.IsNullOrWhiteSpace(configString)
                ? configString
                : FallbackConnectionString;
        }

        /// <summary>
        /// Tạo mới một đối tượng SqlConnection
        /// </summary>
        /// <returns>Đối tượng SqlConnection chưa mở (Cần gọi conn.Open() khi sử dụng)</returns>
        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Lấy chuỗi kết nối hiện tại
        /// </summary>
        public static string CurrentConnectionString => ConnectionString;
    }
}