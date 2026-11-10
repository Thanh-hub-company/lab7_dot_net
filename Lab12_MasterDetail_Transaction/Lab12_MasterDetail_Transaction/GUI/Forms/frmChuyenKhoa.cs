using System;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmChuyenKhoa : Form
    {
        private readonly SinhVienBUS _svBus = new SinhVienBUS();
        private readonly KhoaBUS _khoaBus = new KhoaBUS();

        public frmChuyenKhoa()
        {
            InitializeComponent();
        }

        private void frmChuyenKhoa_Load(object sender, EventArgs e)
        {
            cboKhoaMoi.DataSource = _khoaBus.GetAll();
            cboKhoaMoi.DisplayMember = "TenKhoa";
            cboKhoaMoi.ValueMember = "MaKhoa";
        }

        private void btnChuyenKhoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maKhoaCu = txtMaKhoaCu.Text.Trim();
            string maKhoaMoi = Convert.ToString(cboKhoaMoi.SelectedValue);
            string ghiChu = txtGhiChu.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maKhoaCu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã sinh viên và khoa cũ!", "Cảnh báo");
                return;
            }

            if (maKhoaCu == maKhoaMoi)
            {
                MessageBox.Show("Khoa mới phải khác khoa cũ!", "Cảnh báo");
                return;
            }

            try
            {
                // Thực hiện Transaction cập nhật MaKhoa và ghi sổ LichSuChuyenKhoa
                _svBus.ChuyenKhoa(maSV, maKhoaCu, maKhoaMoi, ghiChu);
                MessageBox.Show($"Đã chuyển sinh viên {maSV} sang khoa {maKhoaMoi} và lưu lịch sử thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giao dịch chuyển khoa thất bại (Đã Rollback): " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}