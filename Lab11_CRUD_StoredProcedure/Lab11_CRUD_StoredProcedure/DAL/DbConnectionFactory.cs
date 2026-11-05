using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            string connStr = ConfigurationManager.ConnectionStrings["QLSinhVienConnection"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}