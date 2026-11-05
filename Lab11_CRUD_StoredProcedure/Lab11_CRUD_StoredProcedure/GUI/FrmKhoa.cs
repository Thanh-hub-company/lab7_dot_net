// GUI/FrmKhoa.cs
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FrmKhoa : Form
    {
        private readonly KhoaBUS _khoaBus = new KhoaBUS();

        public FrmKhoa()
        {
            InitializeComponent();
        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhoa.DataSource = _khoaBus.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ExecuteAction(() =>
            {
                KhoaDTO dto = new KhoaDTO
                {
                    MaKhoa = txtMaKhoa.Text.Trim(),
                    TenKhoa = txtTenKhoa.Text.Trim()
                };

                _khoaBus.Add(dto);
                MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteAction(() =>
                {
                    _khoaBus.Delete(txtMaKhoa.Text.Trim());
                    MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                });
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];
                txtMaKhoa.Text = row.Cells["MaKhoa"].Value?.ToString();
                txtTenKhoa.Text = row.Cells["TenKhoa"].Value?.ToString();
            }
        }

        private void ClearForm()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtMaKhoa.Focus();
        }

        private void ExecuteAction(Action action)
        {
            try
            {
                action();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"[SQL Server Error]: {ex.Message}", "Lỗi nghiệp vụ cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}