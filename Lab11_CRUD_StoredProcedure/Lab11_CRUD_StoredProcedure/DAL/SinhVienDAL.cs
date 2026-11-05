using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        public List<SinhVienDTO> Search(string keyword, string maKhoa)
        {
            List<SinhVienDTO> list = new List<SinhVienDTO>();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_Search", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 100).Value =
                    string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : keyword.Trim();
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value =
                    string.IsNullOrWhiteSpace(maKhoa) ? (object)DBNull.Value : maKhoa.Trim();

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SinhVienDTO
                        {
                            MaSV = reader["MaSV"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            GioiTinh = Convert.ToBoolean(reader["GioiTinh"]),
                            MaKhoa = reader["MaKhoa"].ToString(),
                            TenKhoa = reader["TenKhoa"].ToString(),
                            DiemTB = Convert.ToDecimal(reader["DiemTB"]),
                            Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public int Insert(SinhVienDTO dto)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_Insert", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = dto.GioiTinh;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal).Value = dto.DiemTB;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value =
                    string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(SinhVienDTO dto)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_Update", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = dto.GioiTinh;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal).Value = dto.DiemTB;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value =
                    string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string maSV)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_Delete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}