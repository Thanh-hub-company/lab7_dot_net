using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmMain : Form
    {
        private readonly KhoaBUS _khoaBus = new KhoaBUS();
        private readonly SinhVienBUS _svBus = new SinhVienBUS();
        private readonly DangKyBUS _dkBus = new DangKyBUS();

        // Biến lưu RowVersion phục vụ Bài 9
        private byte[] _currentTimestamp;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Triệt tiêu thông báo lỗi định dạng tự động của các DataGridView
            dgvKhoa_B1.DataError += DataGridView_DataError;
            dgvSinhVien_B1.DataError += DataGridView_DataError;
            dgvSinhVien_B2.DataError += DataGridView_DataError;
            dgvDangKy_B2.DataError += DataGridView_DataError;
            dgvDiem_B8.DataError += DataGridView_DataError;

            // Load dữ liệu ban đầu cho các Tab
            LoadTab1();
            LoadTab2();
            LoadTab3And7Combobox();
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        // =========================================================================
        // BÀI 1: MASTER-DETAIL KHOA - SINH VIÊN
        // =========================================================================
        private void LoadTab1()
        {
            dgvKhoa_B1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien_B1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoa_B1.DataSource = _khoaBus.GetAll();
        }

        private void dgvKhoa_B1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoa_B1.CurrentRow == null || dgvKhoa_B1.CurrentRow.IsNewRow) return;

            string maKhoa = Convert.ToString(dgvKhoa_B1.CurrentRow.Cells["MaKhoa"].Value);
            dgvSinhVien_B1.DataSource = _svBus.GetByDepartment(maKhoa);

            if (dgvSinhVien_B1.Columns["RowVersion"] != null)
                dgvSinhVien_B1.Columns["RowVersion"].Visible = false;

            lblChiTiet_B1.Text = $"Danh sách sinh viên thuộc khoa: {maKhoa}";
        }

        // =========================================================================
        // BÀI 2, 3, 4, 5: MASTER-DETAIL SV - DANGKY & TRANSACTION + ROLLBACK TEST
        // =========================================================================
        private void LoadTab2()
        {
            dgvSinhVien_B2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDangKy_B2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien_B2.DataSource = _svBus.GetByDepartment("CNTT");

            if (dgvSinhVien_B2.Columns["RowVersion"] != null)
                dgvSinhVien_B2.Columns["RowVersion"].Visible = false;
        }

        private void dgvSinhVien_B2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien_B2.CurrentRow == null || dgvSinhVien_B2.CurrentRow.IsNewRow) return;

            string maSV = Convert.ToString(dgvSinhVien_B2.CurrentRow.Cells["MaSV"].Value);
            dgvDangKy_B2.DataSource = _dkBus.GetEnrollmentsByStudent(maSV);
        }

        private void btnThemHopLe_B3_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Thêm thành công SinhVien [{sv.MaSV}] và các đăng ký học phần trong SqlTransaction!",
                                "Thành công (Bài 3)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTab2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Giao dịch Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoPhongRollback_B4_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = "SV_FAIL_" + DateTime.Now.ToString("ss"),
                HoTen = "Sinh Viên Thử Nghiệm Lỗi",
                NgaySinh = new DateTime(2003, 5, 5),
                GioiTinh = "Nữ",
                MaKhoa = "CNTT"
            };

            // Cố tình thêm MaHP không tồn tại để kích hoạt Rollback
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
                MessageBox.Show("Giao dịch thất bại và đã HOÀN TÁC (Rollback)!\nChi tiết: " + ex.Message,
                                "Kiểm chứng Rollback (Bài 4)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadTab2();
        }

        // =========================================================================
        // BÀI 6 & 7: CHUYỂN KHOA VÀ XÓA KHOA AN TOÀN
        // =========================================================================
        private void LoadTab3And7Combobox()
        {
            DataTable dtKhoa = _khoaBus.GetAll();

            cboKhoaMoi_B6.DataSource = dtKhoa.Copy();
            cboKhoaMoi_B6.DisplayMember = "TenKhoa";
            cboKhoaMoi_B6.ValueMember = "MaKhoa";

            cboKhoaXoa_B7.DataSource = dtKhoa.Copy();
            cboKhoaXoa_B7.DisplayMember = "TenKhoa";
            cboKhoaXoa_B7.ValueMember = "MaKhoa";

            cboKhoaChuyenToi_B7.DataSource = dtKhoa.Copy();
            cboKhoaChuyenToi_B7.DisplayMember = "TenKhoa";
            cboKhoaChuyenToi_B7.ValueMember = "MaKhoa";
        }

        private void btnChuyenKhoa_B6_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV_B6.Text.Trim();
            string maKhoaCu = txtKhoaCu_B6.Text.Trim();
            string maKhoaMoi = Convert.ToString(cboKhoaMoi_B6.SelectedValue);
            string ghiChu = txtGhiChu_B6.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maKhoaCu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã sinh viên và khoa cũ!", "Thông báo");
                return;
            }

            try
            {
                _svBus.ChuyenKhoa(maSV, maKhoaCu, maKhoaMoi, ghiChu);
                MessageBox.Show($"Chuyển thành công sinh viên {maSV} sang khoa {maKhoaMoi} và lưu lịch sử!", "Thành công (Bài 6)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giao dịch chuyển khoa thất bại: " + ex.Message, "Lỗi Rollback");
            }
        }

        private void btnXoaKhoa_B7_Click(object sender, EventArgs e)
        {
            string maKhoaXoa = Convert.ToString(cboKhoaXoa_B7.SelectedValue);
            string maKhoaChuyen = Convert.ToString(cboKhoaChuyenToi_B7.SelectedValue);

            if (maKhoaXoa == maKhoaChuyen)
            {
                MessageBox.Show("Khoa nhận phải khác khoa cần xóa!", "Cảnh báo");
                return;
            }

            if (MessageBox.Show($"Xóa khoa [{maKhoaXoa}] và chuyển sinh viên sang [{maKhoaChuyen}]?",
                               "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _khoaBus.XoaKhoaAnToan(maKhoaXoa, maKhoaChuyen);
                    MessageBox.Show("Đã điều hướng sinh viên và xóa khoa thành công!", "Thành công (Bài 7)");
                    LoadTab3And7Combobox();
                    LoadTab1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xóa Khoa: " + ex.Message, "Lỗi Rollback");
                }
            }
        }

        // =========================================================================
        // BÀI 8: CẬP NHẬT ĐIỂM HÀNG LOẠT
        // =========================================================================
        private void btnTaiDanhSach_B8_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV_B8.Text.Trim();
            if (!string.IsNullOrEmpty(maSV))
            {
                dgvDiem_B8.DataSource = _dkBus.GetEnrollmentsByStudent(maSV);
            }
        }

        private void btnLuuDiem_B8_Click(object sender, EventArgs e)
        {
            List<DangKyDTO> dsCapNhat = new List<DangKyDTO>();

            foreach (DataGridViewRow row in dgvDiem_B8.Rows)
            {
                if (row.IsNewRow) continue;

                decimal? diemVal = null;
                var raw = row.Cells["Diem"].Value;
                if (raw != null && !string.IsNullOrWhiteSpace(raw.ToString()))
                {
                    if (decimal.TryParse(raw.ToString(), out decimal parsed))
                    {
                        diemVal = parsed;
                    }
                    else
                    {
                        MessageBox.Show("Điểm phải là kiểu số!", "Lỗi nhập liệu");
                        return;
                    }
                }

                dsCapNhat.Add(new DangKyDTO
                {
                    MaSV = Convert.ToString(row.Cells["MaSV"].Value),
                    MaHP = Convert.ToString(row.Cells["MaHP"].Value),
                    HocKy = Convert.ToInt32(row.Cells["HocKy"].Value),
                    Diem = diemVal
                });
            }

            try
            {
                _dkBus.CapNhatDiemHangLoat(dsCapNhat);
                MessageBox.Show("Cập nhật toàn bộ điểm thành công!", "Thành công (Bài 8)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\nToàn bộ thao tác đã được Rollback.", "Lỗi Rollback");
            }
        }

        // =========================================================================
        // BÀI 9: KIỂM SOÁT XUNG ĐỘT CẬP NHẬT (ROWVERSION)
        // =========================================================================
        private void btnNapData_B9_Click(object sender, EventArgs e)
        {
            DataTable dt = _svBus.GetByDepartment("CNTT");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMaSV_B9.Text = Convert.ToString(row["MaSV"]);
                txtHoTen_B9.Text = Convert.ToString(row["HoTen"]);
                dtpNgaySinh_B9.Value = Convert.ToDateTime(row["NgaySinh"]);
                cboGioiTinh_B9.Text = Convert.ToString(row["GioiTinh"]);
                txtMaKhoa_B9.Text = Convert.ToString(row["MaKhoa"]);
                _currentTimestamp = row["RowVersion"] != DBNull.Value ? (byte[])row["RowVersion"] : null;

                MessageBox.Show($"Đã nạp dữ liệu sinh viên {txtMaSV_B9.Text} cùng RowVersion!", "Nạp thành công");
            }
        }

        private void btnLuu_B9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV_B9.Text)) return;

            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = txtMaSV_B9.Text.Trim(),
                HoTen = txtHoTen_B9.Text.Trim(),
                NgaySinh = dtpNgaySinh_B9.Value,
                GioiTinh = cboGioiTinh_B9.Text,
                MaKhoa = txtMaKhoa_B9.Text.Trim(),
                RowVersion = _currentTimestamp
            };

            try
            {
                _svBus.UpdateSinhVienSafe(sv);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công (Bài 9)");
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo Xung Đột Concurrency (Bài 9)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}