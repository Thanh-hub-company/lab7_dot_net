using System;
using System.Data;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmMenu : Form
    {
        private readonly SinhVienBUS _svBus = new SinhVienBUS();

        public frmMenu()
        {
            InitializeComponent();
        }

        // Bài 1: Master-Detail Khoa - SinhVien
        private void btnBai1_Click(object sender, EventArgs e)
        {
            new frmKhoaSinhVien().ShowDialog();
        }

        // Bài 2, 3, 4, 5: Master-Detail SV - DangKy & SqlTransaction (Thêm/Rollback)
        private void btnBai2345_Click(object sender, EventArgs e)
        {
            new frmSinhVienDangKy().ShowDialog();
        }

        // Bài 6: Transaction Chuyển Khoa Sinh Viên
        private void btnBai6_Click(object sender, EventArgs e)
        {
            new frmChuyenKhoa().ShowDialog();
        }

        // Bài 7: Transaction Xóa Khoa An Toàn
        private void btnBai7_Click(object sender, EventArgs e)
        {
            new frmXoaKhoa().ShowDialog();
        }

        // Bài 8: Transaction Cập Nhật Điểm Hàng Loạt
        private void btnBai8_Click(object sender, EventArgs e)
        {
            new frmCapNhatDiem().ShowDialog();
        }

        // Bài 9: Kiểm Soát Xung Đột Dữ Liệu (Optimistic Concurrency)
        private void btnBai9_Click(object sender, EventArgs e)
        {
            var frm = new frmSuaSinhVien();

            // Lấy mẫu dữ liệu sinh viên đầu tiên để truyền vào Form Bài 9
            DataTable dt = _svBus.GetByDepartment("CNTT");
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
                frm.SetStudentData(sv);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên để chạy thử Bài 9!", "Thông báo");
            }
        }
    }
}