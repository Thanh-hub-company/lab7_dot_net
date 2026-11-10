using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class SinhVienDAL
    {
        public DataTable GetByDepartment(string maKhoa)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, RowVersion FROM SinhVien WHERE MaKhoa = @MaKhoa";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa;
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        public void Insert(SinhVienDTO sv, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa) 
                           VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa)";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = sv.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = sv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 5).Value = sv.GioiTinh;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = sv.MaKhoa;
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMaKhoa(string maSV, string maKhoaMoi, SqlConnection conn, SqlTransaction tx)
        {
            string sql = "UPDATE SinhVien SET MaKhoa = @MaKhoaMoi WHERE MaSV = @MaSV";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 10).Value = maKhoaMoi;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV;
                cmd.ExecuteNonQuery();
            }
        }

        public bool UpdateWithConcurrencyCheck(SinhVienDTO sv)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"UPDATE SinhVien 
                               SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, MaKhoa = @MaKhoa
                               WHERE MaSV = @MaSV AND RowVersion = @RowVersion";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = sv.MaSV;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = sv.HoTen;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 5).Value = sv.GioiTinh;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = sv.MaKhoa;
                    cmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = sv.RowVersion;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}