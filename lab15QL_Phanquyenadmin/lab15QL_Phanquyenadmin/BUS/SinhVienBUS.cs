using QLSinhVien.BUS.Validators;
using QLSinhVien.Common;
using QLSinhVien.DAL;
using QLSinhVien.DTO;
using System.Collections.Generic;

namespace QLSinhVien.BUS
{
    /// <summary>
    /// Tầng xử lý nghiệp vụ Quản lý Sinh viên.
    /// </summary>
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        public List<SinhVienDTO> GetAll()
        {
            return _dal.GetAll();
        }

        public List<SinhVienDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _dal.GetAll();
            }
            return _dal.Search(keyword);
        }

        public bool Add(SinhVienDTO dto)
        {
            ValidationResult validation = SinhVienValidator.Validate(dto);
            if (!validation.IsValid)
            {
                throw new BusinessException(validation.ToFormattedMessage());
            }

            string maSV = dto.MaSV.Trim();
            if (_dal.Exists(maSV))
            {
                throw new BusinessException(string.Format("Mã sinh viên '{0}' đã tồn tại trong hệ thống.", maSV));
            }

            return _dal.Insert(dto);
        }

        public bool Update(SinhVienDTO dto)
        {
            ValidationResult validation = SinhVienValidator.Validate(dto);
            if (!validation.IsValid)
            {
                throw new BusinessException(validation.ToFormattedMessage());
            }

            string maSV = dto.MaSV.Trim();
            if (!_dal.Exists(maSV))
            {
                throw new BusinessException(string.Format("Không tìm thấy sinh viên có mã '{0}' để cập nhật.", maSV));
            }

            return _dal.Update(dto);
        }

        public bool Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new BusinessException("Vui lòng chọn hoặc nhập mã sinh viên cần xóa.");
            }

            string trimmedId = maSV.Trim();
            if (!_dal.Exists(trimmedId))
            {
                throw new BusinessException(string.Format("Sinh viên có mã '{0}' không tồn tại hoặc đã bị xóa.", trimmedId));
            }

            return _dal.Delete(trimmedId);
        }
    }
}