using System;

namespace QLSinhVien.DTO
{
    /// <summary>
    /// Đối tượng truyền dữ liệu Sinh viên giữa các tầng GUI - BUS - DAL.
    /// </summary>
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public double DiemTB { get; set; }
        public string MaLop { get; set; }
    }
}