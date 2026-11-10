using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public static class DbConnectionFactory
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["QLSinhVienConn"]?.ConnectionString
            ?? @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True";

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}