using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class KhoaBUS
    {
        private readonly KhoaDAL _dal = new KhoaDAL();

        public List<KhoaDTO> GetAll() => _dal.GetAll();

        public void Add(KhoaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaKhoa))
                throw new ArgumentException("Mã khoa không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.TenKhoa))
                throw new ArgumentException("Tên khoa không được để trống.");

            _dal.Insert(dto);
        }

        public void Delete(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa))
                throw new ArgumentException("Chưa chọn khoa cần xóa.");

            _dal.Delete(maKhoa);
        }
    }
}