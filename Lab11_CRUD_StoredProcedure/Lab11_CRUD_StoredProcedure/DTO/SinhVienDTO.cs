using System;

namespace DTO
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; } // Phục vụ hiển thị lên DataGridView
        public decimal DiemTB { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}