using System;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmXoaKhoa : Form
    {
        private readonly KhoaBUS _khoaBus = new KhoaBUS();

        public frmXoaKhoa()
        {
            InitializeComponent();
        }

        private void frmXoaKhoa_Load(object sender, EventArgs e)
        {
            LoadKhoaCombobox();
        }

        private void LoadKhoaCombobox()
        {
            cboKhoaXoa.DataSource = _khoaBus.GetAll();
            cboKhoaXoa.DisplayMember = "TenKhoa";
            cboKhoaXoa.ValueMember = "MaKhoa";

            cboKhoaChuyenToi.DataSource = _khoaBus.GetAll();
            cboKhoaChuyenToi.DisplayMember = "TenKhoa";
            cboKhoaChuyenToi.ValueMember = "MaKhoa";
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            string maKhoaXoa = Convert.ToString(cboKhoaXoa.SelectedValue);
            string maKhoaChuyen = Convert.ToString(cboKhoaChuyenToi.SelectedValue);

            if (maKhoaXoa == maKhoaChuyen)
            {
                MessageBox.Show("Khoa nhận phải khác khoa cần xóa!", "Cảnh báo");
                return;
            }

            try
            {
                _khoaBus.XoaKhoaAnToan(maKhoaXoa, maKhoaChuyen);
                MessageBox.Show("Đã điều hướng sinh viên và xóa khoa an toàn!", "Thành công");
                LoadKhoaCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Rollback Giao Dịch");
            }
        }
    }
}