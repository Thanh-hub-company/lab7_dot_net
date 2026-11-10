using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class DangKyDAL
    {
        public DataTable GetEnrollmentsByStudent(string maSV)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT dk.MaSV, dk.MaHP, hp.TenHP, hp.SoTinChi, dk.HocKy, dk.Diem
                               FROM DangKy dk
                               JOIN HocPhan hp ON dk.MaHP = hp.MaHP
                               WHERE dk.MaSV = @MaSV
                               ORDER BY dk.HocKy, hp.TenHP";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV;
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        public void InsertEnrollment(DangKyDTO dto, SqlConnection conn, SqlTransaction tx)
        {
            const string sql = @"INSERT INTO DangKy(MaSV, MaHP, HocKy, Diem)
                                 VALUES(@MaSV, @MaHP, @HocKy, @Diem)";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV;
                cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = dto.MaHP;
                cmd.Parameters.Add("@HocKy", SqlDbType.Int).Value = dto.HocKy;
                cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value =
                    dto.Diem.HasValue ? (object)dto.Diem.Value : DBNull.Value;
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateGrade(DangKyDTO dto, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"UPDATE DangKy SET Diem = @Diem 
                           WHERE MaSV = @MaSV AND MaHP = @MaHP AND HocKy = @HocKy";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV;
                cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = dto.MaHP;
                cmd.Parameters.Add("@HocKy", SqlDbType.Int).Value = dto.HocKy;
                cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value =
                    dto.Diem.HasValue ? (object)dto.Diem.Value : DBNull.Value;
                cmd.ExecuteNonQuery();
            }
        }
    }
}