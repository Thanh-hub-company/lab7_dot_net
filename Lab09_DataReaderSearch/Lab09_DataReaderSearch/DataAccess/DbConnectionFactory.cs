using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab09_DataReaderSearch.DataAccess
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            var setting = ConfigurationManager.ConnectionStrings["QLSinhVienConn"];
            string connStr = setting?.ConnectionString;

            // Tự động gán chuỗi kết nối mặc định nếu App.config thiếu cấu hình
            if (string.IsNullOrEmpty(connStr))
            {
                connStr = "Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True";
            }

            return new SqlConnection(connStr);
        }
    }
}