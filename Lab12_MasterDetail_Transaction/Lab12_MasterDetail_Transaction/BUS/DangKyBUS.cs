using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class DangKyBUS
    {
        private readonly DangKyDAL _dkDal = new DangKyDAL();

        public DataTable GetEnrollmentsByStudent(string maSV)
        {
            return _dkDal.GetEnrollmentsByStudent(maSV);
        }

        public void CapNhatDiemHangLoat(List<DangKyDTO> dsDiem)
        {
            foreach (var item in dsDiem)
            {
                if (item.Diem.HasValue && (item.Diem.Value < 0 || item.Diem.Value > 10))
                {
                    throw new ArgumentOutOfRangeException($"Điểm sinh viên {item.MaSV} - Môn {item.MaHP} nằm ngoài dải [0, 10]!");
                }
            }

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in dsDiem)
                        {
                            _dkDal.UpdateGrade(item, conn, tx);
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
    }
}