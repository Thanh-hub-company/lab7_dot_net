using System.Diagnostics;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.BUS
{
    public class ConnectionBUS
    {
        private readonly DatabaseCheckerDAL _checkerDAL = new DatabaseCheckerDAL();

        public ConnectionInfoDTO CheckConnection()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Gọi DAL lấy thông tin
            ConnectionInfoDTO info = _checkerDAL.GetRawConnectionStatus();

            timer.Stop();
            info.ResponseTimeMs = timer.ElapsedMilliseconds;

            return info;
        }
    }
}