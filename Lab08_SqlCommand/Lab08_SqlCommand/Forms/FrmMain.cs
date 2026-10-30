using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lab08_SqlCommand.DataAccess;

namespace Lab08_SqlCommand.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhoa();
            CapNhatThongKeCount();
            TaiDanhSachSinhVien();
        }

        private void TaiDanhSachKhoa()
        {
            try
            {
                const string sql =
                    "SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa";

                using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    DataTable table = new DataTable();
                    table.Load(reader);

                    cboKhoa.DataSource = table;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "MaKhoa";

                    if (table.Rows.Count > 0)
                    {
                        cboKhoa.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách khoa: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CapNhatThongKeCount()
        {
            try
            {
                object result = SqlHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM SinhVien");

                int count = Convert.ToInt32(result);
                lblTongSoSV.Text = $"Tổng số sinh viên: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đếm sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachSinhVien()
        {
            try
            {
                const string sql = @"
                    SELECT MaSV, HoTen, DiemTB
                    FROM SinhVien
                    ORDER BY HoTen";

                lstSinhVien.Items.Clear();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    while (reader.Read())
                    {
                        string maSV = reader["MaSV"].ToString();
                        string hoTen = reader["HoTen"].ToString();
                        decimal diem = Convert.ToDecimal(reader["DiemTB"]);

                        lstSinhVien.Items.Add(
                            $"{maSV} - {hoTen} - {diem:N2}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string LayMaKhoa()
        {
            if (cboKhoa.SelectedValue == null)
            {
                return string.Empty;
            }

            return cboKhoa.SelectedValue.ToString();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã sinh viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(LayMaKhoa()))
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return false;
            }

            decimal diem;

            if (!decimal.TryParse(txtDiemTB.Text, out diem)
                || diem < 0
                || diem > 10)
            {
                MessageBox.Show(
                    "Điểm trung bình phải là số từ 0 đến 10.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDiemTB.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
            {
                return;
            }

            try
            {
                const string sql = @"
                    INSERT INTO SinhVien
                    (
                        MaSV,
                        HoTen,
                        NgaySinh,
                        GioiTinh,
                        MaKhoa,
                        DiemTB,
                        Email
                    )
                    VALUES
                    (
                        @MaSV,
                        @HoTen,
                        @NgaySinh,
                        @GioiTinh,
                        @MaKhoa,
                        @DiemTB,
                        @Email
                    )";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 15)
                    {
                        Value = txtMaSV.Text.Trim()
                    },
                    new SqlParameter("@HoTen", SqlDbType.NVarChar, 100)
                    {
                        Value = txtHoTen.Text.Trim()
                    },
                    new SqlParameter("@NgaySinh", SqlDbType.Date)
                    {
                        Value = dtpNgaySinh.Value.Date
                    },
                    new SqlParameter("@GioiTinh", SqlDbType.Bit)
                    {
                        Value = radNam.Checked
                    },
                    new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10)
                    {
                        Value = LayMaKhoa()
                    },
                    new SqlParameter("@DiemTB", SqlDbType.Decimal)
                    {
                        Precision = 4,
                        Scale = 2,
                        Value = decimal.Parse(txtDiemTB.Text)
                    },
                    new SqlParameter("@Email", SqlDbType.VarChar, 100)
                    {
                        Value = string.IsNullOrWhiteSpace(txtEmail.Text)
                            ? (object)DBNull.Value
                            : txtEmail.Text.Trim()
                    }
                };

                SqlHelper.ExecuteNonQuery(
                    sql,
                    CommandType.Text,
                    parameters);

                MessageBox.Show(
                    "Thêm sinh viên thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CapNhatThongKeCount();
                TaiDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            decimal diem;

            if (!decimal.TryParse(txtDiemTB.Text, out diem)
                || diem < 0
                || diem > 10)
            {
                MessageBox.Show(
                    "Điểm phải là số từ 0 đến 10.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                const string sql = @"
                    UPDATE SinhVien
                    SET DiemTB = @DiemTB
                    WHERE MaSV = @MaSV";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@DiemTB", SqlDbType.Decimal)
                    {
                        Precision = 4,
                        Scale = 2,
                        Value = diem
                    },
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 15)
                    {
                        Value = txtMaSV.Text.Trim()
                    }
                };

                int rows = SqlHelper.ExecuteNonQuery(
                    sql,
                    CommandType.Text,
                    parameters);

                MessageBox.Show(
                    rows > 0
                        ? "Cập nhật điểm thành công."
                        : "Không tìm thấy sinh viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    rows > 0
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning);

                TaiDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật điểm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLocTheoKhoa_Click(object sender, EventArgs e)
        {
            string maKhoa = LayMaKhoa();

            if (string.IsNullOrEmpty(maKhoa))
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                const string sql = @"
                    SELECT MaSV, HoTen, DiemTB
                    FROM SinhVien
                    WHERE MaKhoa = @MaKhoa
                    ORDER BY HoTen";

                SqlParameter parameter = new SqlParameter(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    10)
                {
                    Value = maKhoa
                };

                lstSinhVien.Items.Clear();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    sql,
                    CommandType.Text,
                    parameter))
                {
                    while (reader.Read())
                    {
                        lstSinhVien.Items.Add(
                            $"{reader["MaSV"]} - " +
                            $"{reader["HoTen"]} - " +
                            $"Điểm: {reader["DiemTB"]}");
                    }
                }

                if (lstSinhVien.Items.Count == 0)
                {
                    MessageBox.Show(
                        $"Khoa {maKhoa} chưa có sinh viên.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lọc sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                const string sql = @"
                    SELECT MaSV, HoTen, NgaySinh, GioiTinh,
                           MaKhoa, DiemTB, Email
                    FROM SinhVien
                    WHERE MaSV = @MaSV";

                SqlParameter parameter = new SqlParameter(
                    "@MaSV",
                    SqlDbType.VarChar,
                    15)
                {
                    Value = txtMaSV.Text.Trim()
                };

                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    sql,
                    CommandType.Text,
                    parameter))
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show(
                            "Không tìm thấy sinh viên.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    txtHoTen.Text = reader["HoTen"].ToString();
                    dtpNgaySinh.Value =
                        Convert.ToDateTime(reader["NgaySinh"]);

                    bool gioiTinh =
                        Convert.ToBoolean(reader["GioiTinh"]);

                    radNam.Checked = gioiTinh;
                    radNu.Checked = !gioiTinh;

                    cboKhoa.SelectedValue =
                        reader["MaKhoa"].ToString();

                    txtDiemTB.Text =
                        Convert.ToDecimal(reader["DiemTB"])
                            .ToString("N2");

                    txtEmail.Text = reader["Email"] == DBNull.Value
                        ? string.Empty
                        : reader["Email"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDiemMax_Click(object sender, EventArgs e)
        {
            string maKhoa = LayMaKhoa();

            if (string.IsNullOrEmpty(maKhoa))
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                const string sql = @"
                    SELECT MAX(DiemTB)
                    FROM SinhVien
                    WHERE MaKhoa = @MaKhoa";

                SqlParameter parameter = new SqlParameter(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    10)
                {
                    Value = maKhoa
                };

                object result = SqlHelper.ExecuteScalar(
                    sql,
                    CommandType.Text,
                    parameter);

                if (result == null || result == DBNull.Value)
                {
                    lblMaxDiem.Text = "Khoa chưa có dữ liệu.";
                }
                else
                {
                    lblMaxDiem.Text =
                        $"Điểm cao nhất: {Convert.ToDecimal(result):N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lấy điểm cao nhất: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                const string sql =
                    "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                SqlParameter parameter = new SqlParameter(
                    "@MaSV",
                    SqlDbType.VarChar,
                    15)
                {
                    Value = txtMaSV.Text.Trim()
                };

                int rows = SqlHelper.ExecuteNonQuery(
                    sql,
                    CommandType.Text,
                    parameter);

                MessageBox.Show(
                    rows > 0
                        ? "Xóa sinh viên thành công."
                        : "Không tìm thấy sinh viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CapNhatThongKeCount();
                TaiDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThemSpOutput_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng này sử dụng nút Thêm mới.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}