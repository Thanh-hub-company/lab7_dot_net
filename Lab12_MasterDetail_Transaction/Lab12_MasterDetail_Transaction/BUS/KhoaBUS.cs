using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class KhoaBUS
    {
        private readonly KhoaDAL _khoaDal = new KhoaDAL();

        public DataTable GetAll()
        {
            return _khoaDal.GetAll();
        }

        public void XoaKhoaAnToan(string maKhoaXoa, string maKhoaChuyenToi)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        _khoaDal.DeleteKhoaSafe(maKhoaXoa, maKhoaChuyenToi, conn, tx);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}