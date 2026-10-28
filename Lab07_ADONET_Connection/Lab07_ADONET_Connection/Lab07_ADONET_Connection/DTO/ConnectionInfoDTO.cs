namespace Lab07_ADONET_Connection.DTO
{
    public class ConnectionInfoDTO
    {
        public string DataSource { get; set; }
        public string Database { get; set; }
        public string ServerVersion { get; set; }
        public string State { get; set; }
        public long ResponseTimeMs { get; set; }
    }
}