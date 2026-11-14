using System;
using System.Text.RegularExpressions;
using QLSinhVien.Common;
using QLSinhVien.DTO;

namespace QLSinhVien.BUS.Validators
{
    public static class SinhVienValidator
    {
        public static ValidationResult Validate(SinhVienDTO dto)
        {
            ValidationResult result = new ValidationResult();

            if (dto == null)
            {
                result.AddError("Dữ liệu sinh viên không được để trống.");
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.MaSV))
            {
                result.AddError("Thiếu mã sinh viên.");
            }
            else if (!Regex.IsMatch(dto.MaSV.Trim(), @"^[A-Za-z0-9]{4,15}$"))
            {
                result.AddError("Mã sinh viên chỉ gồm chữ và số (từ 4 đến 15 ký tự).");
            }

            if (string.IsNullOrWhiteSpace(dto.HoTen))
            {
                result.AddError("Thiếu họ tên sinh viên.");
            }
            else if (dto.HoTen.Trim().Length < 2 || dto.HoTen.Trim().Length > 100)
            {
                result.AddError("Họ tên sinh viên phải từ 2 đến 100 ký tự.");
            }

            if (dto.DiemTB < 0 || dto.DiemTB > 10)
            {
                result.AddError("Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");
            }

            if (dto.NgaySinh > DateTime.Today.AddYears(-16))
            {
                result.AddError("Sinh viên phải đủ từ 16 tuổi trở lên.");
            }

            return result;
        }
    }
}