using System.Data;
using System.Data.SqlClient;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class KhoaDAL
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        public void DeleteKhoaSafe(string maKhoaXoa, string maKhoaChuyenToi, SqlConnection conn, SqlTransaction tx)
        {
            string sqlUpdateSV = "UPDATE SinhVien SET MaKhoa = @MaKhoaMoi WHERE MaKhoa = @MaKhoaCu";
            using (SqlCommand cmd = new SqlCommand(sqlUpdateSV, conn, tx))
            {
                cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 10).Value = maKhoaChuyenToi;
                cmd.Parameters.Add("@MaKhoaCu", SqlDbType.VarChar, 10).Value = maKhoaXoa;
                cmd.ExecuteNonQuery();
            }

            string sqlDeleteKhoa = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";
            using (SqlCommand cmd = new SqlCommand(sqlDeleteKhoa, conn, tx))
            {
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoaXoa;
                cmd.ExecuteNonQuery();
            }
        }
    }
}