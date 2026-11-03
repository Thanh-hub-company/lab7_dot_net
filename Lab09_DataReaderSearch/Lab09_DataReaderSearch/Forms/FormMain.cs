using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Lab09_DataReaderSearch.DataAccess;
using Lab09_DataReaderSearch.Helpers;

namespace Lab09_DataReaderSearch.Forms
{
    public partial class FormMain : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadComboBoxKhoa();
            LoadComboBoxSapXep();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvSinhVien.DataSource = LoadStudents();
            FormatDataGridView();
        }

        private void LoadComboBoxKhoa()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) dt.Load(reader);
            }

            cboKhoa.DataSource = dt.Copy();
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            DataRow dr = dt.NewRow();
            dr["MaKhoa"] = "";
            dr["TenKhoa"] = "-- Tất cả các khoa --";
            dt.Rows.InsertAt(dr, 0);

            cboKhoaFilter.DataSource = dt;
            cboKhoaFilter.DisplayMember = "TenKhoa";
            cboKhoaFilter.ValueMember = "MaKhoa";
        }

        // Đã thêm dữ liệu cho cboSortDirection trước khi gán SelectedIndex = 0
        private void LoadComboBoxSapXep()
        {
            cboSortColumn.Items.Clear();
            cboSortColumn.Items.AddRange(new string[] { "MaSV", "HoTen", "NgaySinh", "DiemTB", "TenKhoa" });
            cboSortColumn.SelectedIndex = 0;

            cboSortDirection.Items.Clear();
            cboSortDirection.Items.AddRange(new string[] { "Tăng dần", "Giảm dần" });
            cboSortDirection.SelectedIndex = 0;
        }

        // ==========================================
        // LAB 7 & 8: CRUD DỮ LIỆU
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã SV và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email) 
                           VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";

            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHoTen.Text.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = (cboGioiTinh.Text == "Nam") ? 1 : 0;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = cboKhoa.SelectedValue ?? "CNTT";
                    cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal).Value = decimal.TryParse(txtDiemTB.Text, out decimal d) ? d : 0.0m;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã SV cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"UPDATE SinhVien 
                           SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                               MaKhoa = @MaKhoa, DiemTB = @DiemTB, Email = @Email
                           WHERE MaSV = @MaSV";

            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHoTen.Text.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = (cboGioiTinh.Text == "Nam") ? 1 : 0;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = cboKhoa.SelectedValue;
                    cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal).Value = decimal.TryParse(txtDiemTB.Text, out decimal d) ? d : 0.0m;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Mã SV để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên [{txtMaSV.Text}] không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                try
                {
                    using (SqlConnection conn = DbConnectionFactory.Create())
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = txtMaSV.Text.Trim();
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            txtEmail.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            RefreshGrid();
        }

        // ==========================================
        // LAB 9: BÀI 1 ĐẾN BÀI 10[cite: 1, 2, 3]
        // ==========================================
        private DataTable LoadStudents()
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa";
            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) table.Load(reader);
            }
            return table;
        }

        private DataTable SearchByName(string keyword)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.HoTen LIKE @Keyword
                           ORDER BY sv.HoTen";
            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 100).Value = "%" + keyword.Trim() + "%";
                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private DataTable FilterByDepartmentAndScore(string maKhoa, decimal min, decimal max)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.DiemTB BETWEEN @Min AND @Max";
            if (!string.IsNullOrEmpty(maKhoa)) sql += " AND sv.MaKhoa = @MaKhoa";

            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Min", SqlDbType.Decimal).Value = min;
                cmd.Parameters.Add("@Max", SqlDbType.Decimal).Value = max;
                if (!string.IsNullOrEmpty(maKhoa))
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa;

                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private DataTable GetPagedStudents(int pageIndex, int pageSize)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           ORDER BY sv.MaSV
                           OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Offset", SqlDbType.Int).Value = (pageIndex - 1) * pageSize;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null || dgvSinhVien.CurrentRow.IsNewRow) return;

            DataGridViewRow row = dgvSinhVien.CurrentRow;
            txtMaSV.Text = Convert.ToString(row.Cells["MaSV"].Value);
            txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);
            txtDiemTB.Text = Convert.ToString(row.Cells["DiemTB"].Value);

            if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            if (row.Cells["GioiTinh"].Value != DBNull.Value)
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();

            if (row.Cells["TenKhoa"].Value != DBNull.Value)
                cboKhoa.Text = row.Cells["TenKhoa"].Value.ToString();

            if (row.Cells["Email"].Value != DBNull.Value)
                txtEmail.Text = row.Cells["Email"].Value.ToString();

            lblTrangThai.Text = "Đang chọn: " + txtMaSV.Text;
        }

        private DataTable MultiCriteriaSearch(string maSV, string hoTen, string maKhoa, int? gioiTinh, decimal? minDiem, decimal? maxDiem)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(maSV))
            {
                sql += " AND sv.MaSV LIKE @MaSV";
                parameters.Add(new SqlParameter("@MaSV", SqlDbType.VarChar, 20) { Value = "%" + maSV.Trim() + "%" });
            }
            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                sql += " AND sv.HoTen LIKE @HoTen";
                parameters.Add(new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = "%" + hoTen.Trim() + "%" });
            }
            if (!string.IsNullOrWhiteSpace(maKhoa))
            {
                sql += " AND sv.MaKhoa = @MaKhoa";
                parameters.Add(new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10) { Value = maKhoa });
            }
            if (gioiTinh.HasValue)
            {
                sql += " AND sv.GioiTinh = @GioiTinh";
                parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.Bit) { Value = gioiTinh.Value });
            }
            if (minDiem.HasValue)
            {
                sql += " AND sv.DiemTB >= @MinDiem";
                parameters.Add(new SqlParameter("@MinDiem", SqlDbType.Decimal) { Value = minDiem.Value });
            }
            if (maxDiem.HasValue)
            {
                sql += " AND sv.DiemTB <= @MaxDiem";
                parameters.Add(new SqlParameter("@MaxDiem", SqlDbType.Decimal) { Value = maxDiem.Value });
            }

            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private DataTable SearchAndSort(string columnName, bool isAscending)
        {
            Dictionary<string, string> validColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "MaSV", "sv.MaSV" },
                { "HoTen", "sv.HoTen" },
                { "NgaySinh", "sv.NgaySinh" },
                { "DiemTB", "sv.DiemTB" },
                { "TenKhoa", "k.TenKhoa" }
            };

            string sortedColumn = validColumns.ContainsKey(columnName) ? validColumns[columnName] : "sv.MaSV";
            string sortDirection = isAscending ? "ASC" : "DESC";

            string sql = $@"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                   CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                   k.TenKhoa, sv.DiemTB, sv.Email
                            FROM SinhVien sv 
                            INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                            ORDER BY {sortedColumn} {sortDirection}";

            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private DataTable FilterByAgeRange(int minAge, int maxAge)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                                  CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                                  k.TenKhoa, sv.DiemTB, sv.Email,
                                  (DATEDIFF(YEAR, sv.NgaySinh, GETDATE()) - 
                                   CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, sv.NgaySinh, GETDATE()), sv.NgaySinh) > GETDATE() THEN 1 ELSE 0 END) AS Tuoi
                           FROM SinhVien sv 
                           INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE (DATEDIFF(YEAR, sv.NgaySinh, GETDATE()) - 
                                  CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, sv.NgaySinh, GETDATE()), sv.NgaySinh) > GETDATE() THEN 1 ELSE 0 END) BETWEEN @MinAge AND @MaxAge
                           ORDER BY Tuoi ASC";

            DataTable table = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MinAge", SqlDbType.Int).Value = minAge;
                cmd.Parameters.Add("@MaxAge", SqlDbType.Int).Value = maxAge;
                conn.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        private void FormatDataGridView()
        {
            if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvSinhVien.Columns["NgaySinh"] != null)
            {
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvSinhVien.Columns["GioiTinh"] != null) dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvSinhVien.Columns["TenKhoa"] != null) dgvSinhVien.Columns["TenKhoa"].HeaderText = "Khoa";
            if (dgvSinhVien.Columns["DiemTB"] != null)
            {
                dgvSinhVien.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvSinhVien.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
            }
            if (dgvSinhVien.Columns["Email"] != null) dgvSinhVien.Columns["Email"].HeaderText = "Email";
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "DiemTB" && e.Value != null && e.Value != DBNull.Value)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal diem))
                {
                    if (diem < 5.0m)
                    {
                        dgvSinhVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                        dgvSinhVien.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (diem >= 8.0m)
                    {
                        dgvSinhVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                        dgvSinhVien.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"DanhSachSinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CsvExporter.ExportToCsv(dgvSinhVien, sfd.FileName);
                        MessageBox.Show("Xuất dữ liệu ra file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            dgvSinhVien.DataSource = SearchByName(txtSearchName.Text);
            FormatDataGridView();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string maKhoa = cboKhoaFilter.SelectedValue?.ToString();
            decimal min = numMinScore.Value;
            decimal max = numMaxScore.Value;
            dgvSinhVien.DataSource = FilterByDepartmentAndScore(maKhoa, min, max);
            FormatDataGridView();
        }

        private void btnMultiSearch_Click(object sender, EventArgs e)
        {
            int? gioiTinh = null;
            if (radNam.Checked) gioiTinh = 1;
            else if (radNu.Checked) gioiTinh = 0;

            decimal? minDiem = chkScore.Checked ? (decimal?)numMinScore.Value : null;
            decimal? maxDiem = chkScore.Checked ? (decimal?)numMaxScore.Value : null;

            dgvSinhVien.DataSource = MultiCriteriaSearch(
                txtSearchMaSV.Text,
                txtSearchName.Text,
                cboKhoaFilter.SelectedValue?.ToString(),
                gioiTinh,
                minDiem,
                maxDiem
            );
            FormatDataGridView();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cboSortColumn.SelectedItem == null || cboSortDirection.SelectedItem == null) return;
            string col = cboSortColumn.SelectedItem.ToString();
            bool isAsc = cboSortDirection.SelectedIndex == 0;
            dgvSinhVien.DataSource = SearchAndSort(col, isAsc);
            FormatDataGridView();
        }

        private void btnFilterAge_Click(object sender, EventArgs e)
        {
            int minAge = (int)numMinAge.Value;
            int maxAge = (int)numMaxAge.Value;
            dgvSinhVien.DataSource = FilterByAgeRange(minAge, maxAge);
            FormatDataGridView();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                dgvSinhVien.DataSource = GetPagedStudents(currentPage, pageSize);
                FormatDataGridView();
                lblPageInfo.Text = $"Trang {currentPage}";
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            dgvSinhVien.DataSource = GetPagedStudents(currentPage, pageSize);
            FormatDataGridView();
            lblPageInfo.Text = $"Trang {currentPage}";
        }
    }
}