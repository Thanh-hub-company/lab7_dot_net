using System;
using System.Data;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;
using Lab12_MasterDetail_Transaction.GUI.Forms;

namespace Lab12_MasterDetail_Transaction
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Lab 7: Transaction Xóa Khoa An Toàn (Đóng [X] tự mở Lab 8)
            ChayFormAnToan(() => new frmXoaKhoa(), "Lab 7");

            // 2. Lab 8: Transaction Cập Nhật Điểm Hàng Loạt (Đóng [X] tự mở Lab 9)
            ChayFormAnToan(() => new frmCapNhatDiem(), "Lab 8");

            // 3. Lab 9: Kiểm Soát Xung Đột Concurrency (Đóng [X] tự mở Lab 10)
            ChayLab9();

            // 4. Lab 10: Giao Diện Thống Nhất (frmMain) (Đóng [X] tự mở Lab 11)
            ChayFormAnToan(() => new frmMain(), "Lab 10");

            // 5. Lab 11: Master-Detail Khoa - SinhVien (Đóng [X] tự mở Lab 12)
            ChayFormAnToan(() => new frmKhoaSinhVien(), "Lab 11");

            // 6. Lab 12: Master-Detail SinhVien - DangKy (Mở ngay sau khi tắt Lab 11)
            ChayFormAnToan(() => new frmSinhVienDangKy(), "Lab 12");
        }

        private static void ChayFormAnToan(Func<Form> taoFormFunc, string tenLab)
        {
            try
            {
                using (Form form = taoFormFunc())
                {
                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{tenLab} gặp lỗi khi mở:\n{ex.Message}\n\nTự động chuyển sang Lab tiếp theo!",
                    "Thông báo " + tenLab,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private static void ChayLab9()
        {
            try
            {
                SinhVienBUS svBus = new SinhVienBUS();
                DataTable dt = svBus.GetByDepartment("CNTT");

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    SinhVienDTO sv = new SinhVienDTO
                    {
                        MaSV = Convert.ToString(row["MaSV"]),
                        HoTen = Convert.ToString(row["HoTen"]),
                        NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = Convert.ToString(row["GioiTinh"]),
                        MaKhoa = Convert.ToString(row["MaKhoa"]),
                        RowVersion = row["RowVersion"] != DBNull.Value ? (byte[])row["RowVersion"] : null
                    };

                    frmSuaSinhVien frm9 = new frmSuaSinhVien();
                    frm9.SetStudentData(sv);

                    using (frm9)
                    {
                        Application.Run(frm9);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu sinh viên mẫu cho Lab 9! Chuyển sang Lab 10.", "Lab 9");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lab 9 gặp lỗi: {ex.Message}\nChuyển sang Lab 10!", "Lỗi Lab 9");
            }
        }
    }
}