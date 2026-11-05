using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using DTO;

namespace BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        public List<SinhVienDTO> Search(string keyword, string maKhoa) => _dal.Search(keyword, maKhoa);

        public void Add(SinhVienDTO dto)
        {
            Validate(dto);
            _dal.Insert(dto);
        }

        public void Update(SinhVienDTO dto)
        {
            Validate(dto);
            _dal.Update(dto);
        }

        public void Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ArgumentException("Vui lòng chọn sinh viên cần xóa.");
            _dal.Delete(maSV);
        }

        private void Validate(SinhVienDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaSV))
                throw new ArgumentException("Mã sinh viên không được rỗng.");
            if (string.IsNullOrWhiteSpace(dto.HoTen))
                throw new ArgumentException("Họ tên không được rỗng.");
            if (dto.NgaySinh > DateTime.Today.AddYears(-15))
                throw new ArgumentException("Tuổi sinh viên chưa đủ 15 tuổi.");
            if (dto.DiemTB < 0 || dto.DiemTB > 10)
                throw new ArgumentException("Điểm trung bình phải nằm trong khoảng [0, 10].");
            if (string.IsNullOrWhiteSpace(dto.MaKhoa))
                throw new ArgumentException("Vui lòng chọn khoa.");

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(dto.Email, emailPattern))
                    throw new ArgumentException("Định dạng email không hợp lệ.");
            }
        }
    }
}