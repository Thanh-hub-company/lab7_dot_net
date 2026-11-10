using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _svDal = new SinhVienDAL();
        private readonly DangKyDAL _dkDal = new DangKyDAL();
        private readonly LichSuChuyenKhoaDAL _lsDal = new LichSuChuyenKhoaDAL();

        public DataTable GetByDepartment(string maKhoa)
        {
            return _svDal.GetByDepartment(maKhoa);
        }

        public void AddStudentWithEnrollments(SinhVienDTO sv, List<DangKyDTO> dsDangKy)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        _svDal.Insert(sv, conn, tx);

                        foreach (var dk in dsDangKy)
                        {
                            dk.MaSV = sv.MaSV;
                            _dkDal.InsertEnrollment(dk, conn, tx);
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ChuyenKhoa(string maSV, string maKhoaCu, string maKhoaMoi, string ghiChu)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        _svDal.UpdateMaKhoa(maSV, maKhoaMoi, conn, tx);

                        LichSuChuyenKhoaDTO ls = new LichSuChuyenKhoaDTO
                        {
                            MaSV = maSV,
                            MaKhoaCu = maKhoaCu,
                            MaKhoaMoi = maKhoaMoi,
                            GhiChu = ghiChu
                        };
                        _lsDal.Insert(ls, conn, tx);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateSinhVienSafe(SinhVienDTO sv)
        {
            bool success = _svDal.UpdateWithConcurrencyCheck(sv);
            if (!success)
            {
                throw new DBConcurrencyException("Dữ liệu đã bị thay đổi bởi người dùng khác. Vui lòng nạp lại dữ liệu!");
            }
        }
    }
}