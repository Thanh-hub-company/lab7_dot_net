using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    public partial class FormLab10 : Form
    {
        private SqlDataAdapter _adapter;
        private DataTable _tableSinhVien;
        private DataSet _dsQLSV;

        // Hàm khởi tạo DUY NHẤT của FormLab10 nằm tại đây
        public FormLab10()
        {
            InitializeComponent();
        }

        private void FormLab10_Load(object sender, EventArgs e)
        {
            DataTable dtKhoa = new DataTable();
            dtKhoa.Columns.Add("MaKhoa", typeof(string));
            dtKhoa.Columns.Add("TenKhoa", typeof(string));
            dtKhoa.Rows.Add("CNTT", "Công nghệ Thông tin");
            dtKhoa.Rows.Add("DTVT", "Điện tử Viễn thông");
            dtKhoa.Rows.Add("QTKD", "Quản trị Kinh doanh");

            cboKhoa.DataSource = dtKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
        }

        // --- BÀI 1 ---
        private void btnBai1_Click(object sender, EventArgs e)
        {
            _tableSinhVien = new DataTable("SinhVien");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SinhVien ORDER BY MaSV", conn))
            {
                adapter.Fill(_tableSinhVien);
            }
            dgvSinhVien.DataSource = _tableSinhVien;
        }

        // --- BÀI 2 ---
        private void btnBai2_Click(object sender, EventArgs e)
        {
            _dsQLSV = new DataSet("QLSinhVien");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                new SqlDataAdapter("SELECT * FROM Khoa", conn).Fill(_dsQLSV, "Khoa");
                new SqlDataAdapter("SELECT * FROM SinhVien", conn).Fill(_dsQLSV, "SinhVien");
            }

            dgvKhoa.DataSource = _dsQLSV.Tables["Khoa"];
            dgvSinhVien.DataSource = _dsQLSV.Tables["SinhVien"];
        }

        // --- BÀI 3 ---
        private void btnBai3_Click(object sender, EventArgs e)
        {
            if (_dsQLSV == null) btnBai2_Click(sender, e);

            if (!_dsQLSV.Relations.Contains("FK_Khoa_SinhVien"))
            {
                DataRelation relation = new DataRelation(
                    "FK_Khoa_SinhVien",
                    _dsQLSV.Tables["Khoa"].Columns["MaKhoa"],
                    _dsQLSV.Tables["SinhVien"].Columns["MaKhoa"]);
                _dsQLSV.Relations.Add(relation);
            }

            if (_dsQLSV.Tables["Khoa"].Rows.Count > 0)
            {
                DataRow khoa = _dsQLSV.Tables["Khoa"].Rows[0];
                DataRow[] sinhViens = khoa.GetChildRows("FK_Khoa_SinhVien");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Sinh viên thuộc khoa: {khoa["TenKhoa"]}\n");
                foreach (DataRow row in sinhViens)
                {
                    sb.AppendLine($"- {row["MaSV"]} : {row["HoTen"]} (ĐTB: {row["DiemTB"]})");
                }
                MessageBox.Show(sb.ToString(), "Bài 3 - Chi tiết dòng con");
            }
        }

        // --- BÀI 4 ---
        private void btnBai4_Click(object sender, EventArgs e)
        {
            if (_dsQLSV == null) btnBai2_Click(sender, e);

            DataView view = new DataView(_dsQLSV.Tables["SinhVien"]);
            string maKhoa = cboKhoa.SelectedValue?.ToString().Replace("'", "''") ?? "CNTT";
            string minDiem = numMinDiem.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);

            view.RowFilter = string.Format("MaKhoa = '{0}' AND DiemTB >= {1}", maKhoa, minDiem);
            view.Sort = "DiemTB DESC, HoTen ASC";

            dgvSinhVien.DataSource = view;
        }

        // --- BÀI 5 ---
        private void btnLoadBai5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DbConnectionFactory.Create();
            _adapter = new SqlDataAdapter("SELECT * FROM SinhVien", conn);
            new SqlCommandBuilder(_adapter);

            _tableSinhVien = new DataTable("SinhVien");
            _adapter.Fill(_tableSinhVien);
            dgvSinhVien.DataSource = _tableSinhVien;
        }

        private void btnSaveBai5_Click(object sender, EventArgs e)
        {
            if (_adapter == null || _tableSinhVien == null) return;

            dgvSinhVien.EndEdit();
            int rows = _adapter.Update(_tableSinhVien);
            MessageBox.Show($"Đã cập nhật thành công {rows} dòng thay đổi vào CSDL!");
        }

        // --- BÀI 6 ---
        private void btnBai6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("BangDiem");
            dt.Columns.Add("MaSV", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("DiemTB", typeof(double));

            DataColumn colXepLoai = new DataColumn("XepLoai", typeof(string))
            {
                Expression = "IIF(DiemTB >= 8.0, 'Giỏi', IIF(DiemTB >= 6.5, 'Khá', IIF(DiemTB >= 5.0, 'Trung bình', 'Yếu')))"
            };
            dt.Columns.Add(colXepLoai);

            dt.Rows.Add("SV01", "Nguyễn Văn A", 8.5);
            dt.Rows.Add("SV02", "Trần Thị B", 6.8);
            dt.Rows.Add("SV03", "Lê Văn C", 4.5);

            dgvSinhVien.DataSource = dt;
        }

        // --- BÀI 7 ---
        private void btnBai7_Click(object sender, EventArgs e)
        {
            if (_tableSinhVien == null)
            {
                MessageBox.Show("Vui lòng tải dữ liệu bài 5 trước!");
                return;
            }

            DataTable changes = _tableSinhVien.GetChanges();
            if (changes == null || changes.Rows.Count == 0)
            {
                MessageBox.Show("Không có dòng nào bị thay đổi!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    sb.AppendLine($"[DELETED] MaSV: {row["MaSV", DataRowVersion.Original]}");
                }
                else if (row.RowState == DataRowState.Added)
                {
                    sb.AppendLine($"[ADDED] MaSV: {row["MaSV"]}, Tên: {row["HoTen"]}");
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    sb.AppendLine($"[MODIFIED] MaSV: {row["MaSV"]} -> Tên mới: {row["HoTen"]}");
                }
            }
            MessageBox.Show(sb.ToString(), "Bài 7 - Trạng thái RowState");
        }

        // --- BÀI 8 ---
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_tableSinhVien == null) return;
            _tableSinhVien.AcceptChanges();
            MessageBox.Show("Đã gọi AcceptChanges(). Các RowState hiện chuyển về Unchanged.");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_tableSinhVien == null) return;
            _tableSinhVien.RejectChanges();
            MessageBox.Show("Đã gọi RejectChanges(). Đã hoàn tác các thay đổi chưa lưu.");
        }

        // --- BÀI 9 ---
        private void btnExportXml_Click(object sender, EventArgs e)
        {
            if (_dsQLSV == null) btnBai2_Click(sender, e);
            _dsQLSV.WriteXml("QLSinhVien.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Đã lưu DataSet ra tệp QLSinhVien.xml!");
        }

        private void btnImportXml_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (System.IO.File.Exists("QLSinhVien.xml"))
            {
                ds.ReadXml("QLSinhVien.xml");
                dgvSinhVien.DataSource = ds.Tables["SinhVien"];
                MessageBox.Show("Đã nạp thành công DataSet từ tệp XML!");
            }
        }

        // --- BÀI 10 ---
        private void btnBai10_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable("Nguon1");
            dt1.Columns.Add("MaSV", typeof(string));
            dt1.Columns.Add("HoTen", typeof(string));
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["MaSV"] };
            dt1.Rows.Add("SV01", "Nguyễn Văn A");

            DataTable dt2 = new DataTable("Nguon2");
            dt2.Columns.Add("MaSV", typeof(string));
            dt2.Columns.Add("HoTen", typeof(string));
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["MaSV"] };
            dt2.Rows.Add("SV01", "Nguyễn Văn A (Đã cập nhật)");
            dt2.Rows.Add("SV02", "Trần Thị B");

            dt1.Merge(dt2, preserveChanges: false, missingSchemaAction: MissingSchemaAction.Add);
            dgvSinhVien.DataSource = dt1;
        }

        private void numMinDiem_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}