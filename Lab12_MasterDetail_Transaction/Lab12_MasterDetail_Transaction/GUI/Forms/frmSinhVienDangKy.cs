using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmSinhVienDangKy : Form
    {
        private readonly SinhVienBUS _svBus = new SinhVienBUS();
        private readonly DangKyBUS _dkBus = new DangKyBUS();

        public frmSinhVienDangKy()
        {
            InitializeComponent();
        }

        private void frmSinhVienDangKy_Load(object sender, EventArgs e)
        {
            LoadDanhSachSinhVien();
        }

        private void LoadDanhSachSinhVien()
        {
            dgvSinhVien.DataSource = _svBus.GetByDepartment("CNTT");
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDangKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Bài 2: Master-Detail SinhVien -> DangKy
        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null || dgvSinhVien.CurrentRow.IsNewRow) return;

            string maSV = Convert.ToString(dgvSinhVien.CurrentRow.Cells["MaSV"].Value);
            dgvDangKy.DataSource = _dkBus.GetEnrollmentsByStudent(maSV);
        }

        // Bài 3: Thêm SinhVien và danh sách Đăng ký hợp lệ bằng Transaction
        private void btnThemHopLe_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = "SV" + DateTime.Now.ToString("fff"),
                HoTen = "Nguyễn Văn Mới",
                NgaySinh = new DateTime(2003, 1, 1),
                GioiTinh = "Nam",
                MaKhoa = "CNTT"
            };

            List<DangKyDTO> dsDK = new List<DangKyDTO>
            {
                new DangKyDTO { MaHP = "IT3212", HocKy = 1 },
                new DangKyDTO { MaHP = "IT3213", HocKy = 1 }
            };

            try
            {
                _svBus.AddStudentWithEnrollments(sv, dsDK);
                MessageBox.Show($"Thêm thành công SinhVien [{sv.MaSV}] và các học phần đăng ký!",
                                "Thông báo Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giao dịch thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 4: Mô phỏng lỗi MaHP sai để kiểm chứng SqlTransaction Rollback
        private void btnMoPhongRollback_Click(object sender, EventArgs e)
        {
            string maSVSai = "SV_FAIL_" + DateTime.Now.ToString("ss");

            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = maSVSai,
                HoTen = "Sinh Viên Thử Nghiệm Lỗi",
                NgaySinh = new DateTime(2003, 5, 5),
                GioiTinh = "Nữ",
                MaKhoa = "CNTT"
            };

            // Cố ý đưa vào 1 MaHP không tồn tại ("HP_KHONG_TON_TAI") để kích hoạt lỗi Foreign Key
            List<DangKyDTO> dsDKCoLoi = new List<DangKyDTO>
            {
                new DangKyDTO { MaHP = "IT3212", HocKy = 1 },
                new DangKyDTO { MaHP = "HP_KHONG_TON_TAI", HocKy = 1 }
            };

            try
            {
                _svBus.AddStudentWithEnrollments(sv, dsDKCoLoi);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Giao dịch thất bại và đã HOÀN TÁC (Rollback)!\n" +
                                "Ngoại lệ SQL: " + ex.Message,
                                "Kiểm chứng Rollback thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Reload dữ liệu để chứng minh MaSV không hề xuất hiện trong Database
            LoadDanhSachSinhVien();
        }
    }
}