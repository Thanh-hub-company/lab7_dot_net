using System;

namespace Lab07_ADONET_Connection.DTO
{
    public class DangKyDTO
    {
        public string MaSV { get; set; }
        public string MaHP { get; set; }
        public int HocKy { get; set; }
        public DateTime NgayDangKy { get; set; }
        public decimal? Diem { get; set; }
    }
}