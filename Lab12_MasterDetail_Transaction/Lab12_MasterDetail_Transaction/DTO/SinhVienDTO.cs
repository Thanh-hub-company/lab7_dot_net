using System;

namespace Lab12_MasterDetail_Transaction.DTO
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaKhoa { get; set; }
        public byte[] RowVersion { get; set; }
    }
}