using QLSinhVien.Common;
using QLSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLSinhVien.DAL
{
    /// <summary>
    /// Tầng truy xuất dữ liệu Sinh viên qua ADO.NET (dùng SqlParameter, đọc chuỗi kết nối từ App.config).
    /// </summary>
    public class SinhVienDAL
    {
        public List<SinhVienDTO> GetAll()
        {
            List<SinhVienDTO> list = new List<SinhVienDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(BuildSelectSql(conn) + " ORDER BY MaSV", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToDto(reader));
                        }
                    }
                }
                return list;
            }
            catch (SqlException ex)
            {
                Logger.Error("Lỗi SQL tại SinhVienDAL.GetAll()", ex);
                ex.Data["Logged"] = true;
                throw; // Giữ nguyên StackTrace gốc
            }
        }

        public List<SinhVienDTO> Search(string keyword)
        {
            List<SinhVienDTO> list = new List<SinhVienDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        BuildSelectSql(conn) + " WHERE MaSV LIKE @Keyword OR HoTen LIKE @Keyword OR " +
                        GetClassColumn(conn) + " LIKE @Keyword ORDER BY MaSV", conn))
                    {
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 120).Value = "%" + (keyword ?? string.Empty).Trim() + "%";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToDto(reader));
                        }
                    }
                    }
                }
                return list;
            }
            catch (SqlException ex)
            {
                Logger.Error(string.Format("Lỗi SQL tại SinhVienDAL.Search(keyword={0})", keyword), ex);
                ex.Data["Logged"] = true;
                throw;
            }
        }

        // Một số bài lab trước dùng MaKhoa thay cho MaLop và không có DiemTB.
        // Dùng metadata để ứng dụng vẫn đọc được dữ liệu từ cùng CSDL QLSinhVien.
        private static string BuildSelectSql(SqlConnection conn)
        {
            EnsureColumn(conn, "MaSV");
            EnsureColumn(conn, "HoTen");
            EnsureColumn(conn, "NgaySinh");
            EnsureColumn(conn, "GioiTinh");

            string score = HasColumn(conn, "DiemTB") ? "DiemTB" : "CAST(NULL AS float) AS DiemTB";
            string classColumn = GetClassColumn(conn);
            return "SELECT MaSV, HoTen, NgaySinh, GioiTinh, " + score + ", " + classColumn + " FROM SinhVien";
        }

        private static string GetClassColumn(SqlConnection conn)
        {
            if (HasColumn(conn, "MaLop"))
            {
                return "MaLop";
            }
            if (HasColumn(conn, "MaKhoa"))
            {
                return "MaKhoa AS MaLop";
            }
            return "CAST(NULL AS varchar(20)) AS MaLop";
        }

        private static bool HasColumn(SqlConnection conn, string columnName)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SinhVien' AND COLUMN_NAME = @ColumnName", conn))
            {
                cmd.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 128).Value = columnName;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static void EnsureColumn(SqlConnection conn, string columnName)
        {
            if (!HasColumn(conn, columnName))
            {
                throw new InvalidOperationException("Bảng SinhVien thiếu cột bắt buộc '" + columnName + "'.");
            }
        }

        public bool Exists(string maSV)
        {
            const string sql = "SELECT COUNT(1) FROM SinhVien WHERE MaSV = @MaSV";

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = maSV;
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(string.Format("Lỗi SQL tại SinhVienDAL.Exists(MaSV={0})", maSV), ex);
                ex.Data["Logged"] = true;
                throw;
            }
        }

        public bool Insert(SinhVienDTO dto)
        {
            const string sql = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiemTB, MaLop)
                                 VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DiemTB, @MaLop)";

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddSinhVienParameters(cmd, dto);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(string.Format("Lỗi SQL tại SinhVienDAL.Insert(MaSV={0})", dto.MaSV), ex);
                ex.Data["Logged"] = true;
                throw;
            }
        }

        public bool Update(SinhVienDTO dto)
        {
            const string sql = @"UPDATE SinhVien
                                 SET HoTen = @HoTen,
                                     NgaySinh = @NgaySinh,
                                     GioiTinh = @GioiTinh,
                                     DiemTB = @DiemTB,
                                     MaLop = @MaLop
                                 WHERE MaSV = @MaSV";

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddSinhVienParameters(cmd, dto);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(string.Format("Lỗi SQL tại SinhVienDAL.Update(MaSV={0})", dto.MaSV), ex);
                ex.Data["Logged"] = true;
                throw;
            }
        }

        public bool Delete(string maSV)
        {
            const string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfigHelper.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = maSV;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(string.Format("Lỗi SQL tại SinhVienDAL.Delete(MaSV={0})", maSV), ex);
                ex.Data["Logged"] = true;
                throw;
            }
        }

        private static void AddSinhVienParameters(SqlCommand cmd, SinhVienDTO dto)
        {
            cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = dto.MaSV.Trim();
            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen.Trim();
            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh.Date;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 10).Value =
                string.IsNullOrWhiteSpace(dto.GioiTinh) ? (object)DBNull.Value : dto.GioiTinh.Trim();
            cmd.Parameters.Add("@DiemTB", SqlDbType.Float).Value = dto.DiemTB;
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value =
                string.IsNullOrWhiteSpace(dto.MaLop) ? (object)DBNull.Value : dto.MaLop.Trim();
        }

        private static SinhVienDTO MapReaderToDto(SqlDataReader reader)
        {
            return new SinhVienDTO
            {
                MaSV = reader["MaSV"].ToString(),
                HoTen = reader["HoTen"].ToString(),
                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                GioiTinh = reader["GioiTinh"] == DBNull.Value ? string.Empty : reader["GioiTinh"].ToString(),
                DiemTB = reader["DiemTB"] == DBNull.Value ? 0 : Convert.ToDouble(reader["DiemTB"]),
                MaLop = reader["MaLop"] == DBNull.Value ? string.Empty : reader["MaLop"].ToString()
            };
        }
    }
}