using System;

namespace Lab12_MasterDetail_Transaction.DTO
{
    public class LichSuChuyenKhoaDTO
    {
        public int ID { get; set; }
        public string MaSV { get; set; }
        public string MaKhoaCu { get; set; }
        public string MaKhoaMoi { get; set; }
        public DateTime NgayChuyen { get; set; }
        public string GhiChu { get; set; }
    }
}