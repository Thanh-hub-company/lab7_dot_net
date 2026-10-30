using System.Configuration;
using System.Data.SqlClient;

namespace Lab08_SqlCommand.DataAccess
{
    public static class DbConnectionFactory
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["QLSinhVienConnectionString"].ConnectionString;

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}