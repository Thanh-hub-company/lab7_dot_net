using System.Data.SqlClient;

namespace Lab10_DisconnectedData
{
    public static class DbConnectionFactory
    {
        private static readonly string ConnectionString =
            @"Server=.;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}