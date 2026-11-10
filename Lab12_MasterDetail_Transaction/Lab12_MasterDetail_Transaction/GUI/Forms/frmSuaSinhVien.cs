using System;
using System.Data;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmSuaSinhVien : Form
    {
        private readonly SinhVienBUS _svBus = new SinhVienBUS();
        private byte[] _currentTimestamp;

        public frmSuaSinhVien()
        {
            InitializeComponent();
        }

        // Hàm nạp thông tin sinh viên từ DataGridView/Database
        public void SetStudentData(SinhVienDTO sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;
            cboGioiTinh.Text = sv.GioiTinh;
            txtMaKhoa.Text = sv.MaKhoa;

            // Lưu trữ RowVersion byte array tại thời điểm xem dữ liệu
            _currentTimestamp = sv.RowVersion;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = cboGioiTinh.Text,
                MaKhoa = txtMaKhoa.Text.Trim(),
                RowVersion = _currentTimestamp // Đưa RowVersion ban đầu xuống DAL để kiểm tra
            };

            try
            {
                _svBus.UpdateSinhVienSafe(sv);
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DBConcurrencyException ex)
            {
                // Phát hiện bản ghi đã bị thay đổi bởi người khác trong CSDL
                MessageBox.Show(ex.Message, "Cảnh báo Xung đột Dữ liệu (Concurrency)",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}