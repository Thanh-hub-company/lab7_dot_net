using System.Data.SqlClient;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.DAL
{
    public class DatabaseCheckerDAL
    {
        public ConnectionInfoDTO GetRawConnectionStatus()
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();

                return new ConnectionInfoDTO
                {
                    DataSource = conn.DataSource,
                    Database = conn.Database,
                    ServerVersion = conn.ServerVersion,
                    State = conn.State.ToString()
                };
            }
        }
    }
}