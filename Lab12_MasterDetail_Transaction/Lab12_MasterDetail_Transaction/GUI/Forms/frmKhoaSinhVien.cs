using System;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmKhoaSinhVien : Form
    {
        private readonly KhoaBUS _khoaBus = new KhoaBUS();
        private readonly SinhVienBUS _sinhVienBus = new SinhVienBUS();

        public frmKhoaSinhVien()
        {
            InitializeComponent();
        }

        private void frmKhoaSinhVien_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện DataError để chặn hộp thoại thông báo lỗi hiển thị mặc định
            dgvSinhVien.DataError += dgvSinhVien_DataError;
            dgvKhoa.DataError += dgvKhoa_DataError;

            // Thiết lập chế độ chọn nguyên dòng
            dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Tải danh sách Khoa vào DataGridView trên
            dgvKhoa.DataSource = _khoaBus.GetAll();
        }

        private void dgvKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoa.CurrentRow == null || dgvKhoa.CurrentRow.IsNewRow) return;

            string maKhoa = Convert.ToString(dgvKhoa.CurrentRow.Cells["MaKhoa"].Value);

            // Tải danh sách SinhVien theo MaKhoa được chọn
            dgvSinhVien.DataSource = _sinhVienBus.GetByDepartment(maKhoa);

            // Ẩn cột RowVersion (nếu có) để DataGridView không tự nạp byte[] thành hình ảnh gây lỗi
            if (dgvSinhVien.Columns["RowVersion"] != null)
            {
                dgvSinhVien.Columns["RowVersion"].Visible = false;
            }

            lblChiTiet.Text = $"Danh sách sinh viên thuộc khoa: {maKhoa}";
        }

        private void dgvSinhVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Bỏ qua ngoại lệ format tự động của DataGridView
            e.ThrowException = false;
        }

        private void dgvKhoa_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Bỏ qua ngoại lệ format tự động của DataGridView
            e.ThrowException = false;
        }
    }
}