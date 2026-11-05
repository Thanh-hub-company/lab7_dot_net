// GUI/FrmSinhVien.cs
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FrmSinhVien : Form
    {
        private readonly SinhVienBUS _svBus = new SinhVienBUS();
        private readonly KhoaBUS _khoaBus = new KhoaBUS();

        public FrmSinhVien()
        {
            InitializeComponent();
        }

        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            LoadKhoaCombobox();
            LoadData();
        }

        private void LoadKhoaCombobox()
        {
            var dsKhoa = _khoaBus.GetAll();
            cboKhoa.DataSource = dsKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
        }

        private void LoadData()
        {
            dgvSinhVien.DataSource = _svBus.Search(txtTimKiem.Text.Trim(), cboKhoaTimKiem.SelectedValue?.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ExecuteAction(() =>
            {
                SinhVienDTO dto = GetFormData();
                _svBus.Add(dto);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ExecuteAction(() =>
            {
                SinhVienDTO dto = GetFormData();
                _svBus.Update(dto);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteAction(() =>
                {
                    _svBus.Delete(txtMaSV.Text.Trim());
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                });
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private SinhVienDTO GetFormData()
        {
            if (!decimal.TryParse(txtDiemTB.Text.Trim(), out decimal diemTB))
                throw new ArgumentException("Điểm trung bình phải là số thực.");

            return new SinhVienDTO
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = radNam.Checked,
                MaKhoa = cboKhoa.SelectedValue?.ToString(),
                DiemTB = diemTB,
                Email = txtEmail.Text.Trim()
            };
        }

        private void ClearForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            txtEmail.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            radNam.Checked = true;
            txtMaSV.Focus();
        }

        // Standardized Exception Handler (Chuẩn hóa xử lý lỗi - Bài 10)
        private void ExecuteAction(Action action)
        {
            try
            {
                action();
            }
            catch (ArgumentException ex)
            {
                // Lỗi dữ liệu đầu vào (BUS)
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                // Lỗi do Stored Procedure bắn về qua THROW
                MessageBox.Show($"[SQL Server Error]: {ex.Message}", "Lỗi nghiệp vụ cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Lỗi hệ thống không xác định
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}