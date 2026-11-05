using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhoaDAL
    {
        public List<KhoaDTO> GetAll()
        {
            List<KhoaDTO> list = new List<KhoaDTO>();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_Khoa_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhoaDTO
                        {
                            MaKhoa = reader["MaKhoa"].ToString(),
                            TenKhoa = reader["TenKhoa"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public int Insert(KhoaDTO dto)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_Khoa_Insert", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa;
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 100).Value = dto.TenKhoa;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string maKhoa)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_Khoa_Delete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}