using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSinhVien.Common;

namespace QLSinhVien.GUI
{
    public class FrmPreFlightCheck : Form
    {
        private readonly bool _autoCloseIfAllPassed;
        private DataGridView _dgvChecks;
        private Button _btnRecheck;
        private Button _btnEncryptConfig;
        private Button _btnContinue;
        private Button _btnExit;
        private Label _lblStatus;

        private class CheckItemResult
        {
            public string HangMuc { get; set; }
            public string TrangThai { get; set; }
            public string ChiTiet { get; set; }
            public string GoiYKhacPhuc { get; set; }
            public bool IsPassed { get; set; }
        }

        public FrmPreFlightCheck(bool autoCloseIfAllPassed = false)
        {
            _autoCloseIfAllPassed = autoCloseIfAllPassed;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Kiểm tra môi trường hệ thống (Pre-flight Check)";
            this.Size = new Size(860, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblTitle = new Label
            {
                Text = "KIỂM TRA ĐIỀU KIỆN VẬN HÀNH ỨNG DỤNG",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 70, 140),
                Location = new Point(16, 14),
                AutoSize = true
            };

            _lblStatus = new Label
            {
                Text = "Đang kiểm tra các thành phần hệ thống...",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                Location = new Point(16, 44),
                AutoSize = true
            };

            _dgvChecks = new DataGridView
            {
                Location = new Point(16, 72),
                Size = new Size(812, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            _dgvChecks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hạng mục kiểm tra", DataPropertyName = "HangMuc", FillWeight = 24 });
            _dgvChecks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "TrangThai", FillWeight = 12 });
            _dgvChecks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chi tiết", DataPropertyName = "ChiTiet", FillWeight = 32 });
            _dgvChecks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Gợi ý khắc phục", DataPropertyName = "GoiYKhacPhuc", FillWeight = 32 });
            _dgvChecks.CellFormatting += DgvChecks_CellFormatting;

            _btnRecheck = new Button { Text = "Kiểm tra lại", Location = new Point(16, 388), Size = new Size(120, 36) };
            _btnRecheck.Click += async (s, e) => await RunAllChecksAsync();

            _btnEncryptConfig = new Button { Text = "Mã hóa Config", Location = new Point(146, 388), Size = new Size(130, 36) };
            _btnEncryptConfig.Click += BtnEncryptConfig_Click;

            _btnContinue = new Button { Text = "Tiếp tục vào ứng dụng", Location = new Point(548, 388), Size = new Size(165, 36), Enabled = false };
            _btnContinue.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            _btnExit = new Button { Text = "Thoát", Location = new Point(723, 388), Size = new Size(105, 36) };
            _btnExit.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { lblTitle, _lblStatus, _dgvChecks, _btnRecheck, _btnEncryptConfig, _btnContinue, _btnExit });
            this.Load += async (s, e) => await RunAllChecksAsync();
        }

        private void DgvChecks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvChecks.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                if (status == "OK")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.BackColor = Color.FromArgb(230, 250, 230);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.BackColor = Color.FromArgb(255, 232, 232);
                }
            }
        }

        private void BtnEncryptConfig_Click(object sender, EventArgs e)
        {
            if (ConfigSecurityHelper.IsConnectionStringsProtected())
            {
                MessageBox.Show("Chuỗi kết nối đã được mã hóa trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ConfigSecurityHelper.ProtectConnectionStrings();
        }

        private async Task RunAllChecksAsync()
        {
            _btnRecheck.Enabled = false;
            _btnContinue.Enabled = false;
            _lblStatus.Text = "Đang chạy kiểm tra hệ thống, vui lòng chờ...";

            List<CheckItemResult> results = await Task.Run(() =>
            {
                List<CheckItemResult> list = new List<CheckItemResult>();
                list.Add(CheckSqlServerConnection());
                list.Add(CheckDatabaseAndTables());
                list.Add(CheckLogsDirectory());
                list.Add(CheckFileWritePermission());
                list.Add(CheckCrystalReportsRuntime());
                return list;
            });

            _dgvChecks.DataSource = null;
            _dgvChecks.DataSource = results;

            bool allPassed = true;
            foreach (CheckItemResult item in results)
            {
                if (!item.IsPassed)
                {
                    allPassed = false;
                    break;
                }
            }

            _btnRecheck.Enabled = true;
            _btnContinue.Enabled = allPassed;

            if (allPassed)
            {
                _lblStatus.Text = "Tất cả hạng mục đều đạt yêu cầu (OK). Sẵn sàng vận hành!";
                _lblStatus.ForeColor = Color.DarkGreen;

                if (_autoCloseIfAllPassed)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                _lblStatus.Text = "Phát hiện hạng mục chưa đạt (FAIL). Vui lòng khắc phục theo gợi ý bên dưới.";
                _lblStatus.ForeColor = Color.DarkRed;
            }
        }

        private CheckItemResult CheckSqlServerConnection()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(AppConfigHelper.ConnectionString);
                builder.InitialCatalog = "master";
                builder.ConnectTimeout = 5;

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    return new CheckItemResult
                    {
                        HangMuc = "1. Kết nối SQL Server",
                        TrangThai = "OK",
                        ChiTiet = "Kết nối thành công tới: " + builder.DataSource,
                        GoiYKhacPhuc = "Không cần thao tác.",
                        IsPassed = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new CheckItemResult
                {
                    HangMuc = "1. Kết nối SQL Server",
                    TrangThai = "FAIL",
                    ChiTiet = ex.Message,
                    GoiYKhacPhuc = "Kiểm tra dịch vụ SQL Server (services.msc) đã Start chưa và sửa Data Source trong App.config.",
                    IsPassed = false
                };
            }
        }

        private CheckItemResult CheckDatabaseAndTables()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(AppConfigHelper.ConnectionString);
                builder.ConnectTimeout = 5;

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SinhVien'", conn))
                    {
                        int exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            return new CheckItemResult
                            {
                                HangMuc = "2. Cơ sở dữ liệu & Bảng",
                                TrangThai = "FAIL",
                                ChiTiet = "Đã thấy DB nhưng thiếu bảng 'SinhVien'.",
                                GoiYKhacPhuc = "Chạy file script QLSinhVien.sql trên SQL Server Management Studio.",
                                IsPassed = false
                            };
                        }
                    }

                    return new CheckItemResult
                    {
                        HangMuc = "2. Cơ sở dữ liệu & Bảng",
                        TrangThai = "OK",
                        ChiTiet = "CSDL '" + builder.InitialCatalog + "' và bảng SinhVien hoạt động tốt.",
                        GoiYKhacPhuc = "Không cần thao tác.",
                        IsPassed = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new CheckItemResult
                {
                    HangMuc = "2. Cơ sở dữ liệu & Bảng",
                    TrangThai = "FAIL",
                    ChiTiet = ex.Message,
                    GoiYKhacPhuc = "Tạo database QLSinhVien hoặc kiểm tra quyền truy cập của tài khoản SQL.",
                    IsPassed = false
                };
            }
        }

        private CheckItemResult CheckLogsDirectory()
        {
            try
            {
                string logDir = Logger.GetActiveLogDirectory();
                if (Directory.Exists(logDir))
                {
                    return new CheckItemResult
                    {
                        HangMuc = "3. Thư mục ghi Log",
                        TrangThai = "OK",
                        ChiTiet = logDir,
                        GoiYKhacPhuc = "Không cần thao tác.",
                        IsPassed = true
                    };
                }
                throw new DirectoryNotFoundException("Không thể tạo thư mục Logs.");
            }
            catch (Exception ex)
            {
                return new CheckItemResult
                {
                    HangMuc = "3. Thư mục ghi Log",
                    TrangThai = "FAIL",
                    ChiTiet = ex.Message,
                    GoiYKhacPhuc = "Cấp quyền Modify cho thư mục ứng dụng hoặc cấu hình LogFolder sang %LocalAppData%.",
                    IsPassed = false
                };
            }
        }

        private CheckItemResult CheckFileWritePermission()
        {
            string tempFile = string.Empty;
            try
            {
                string logDir = Logger.GetActiveLogDirectory();
                tempFile = Path.Combine(logDir, "preflight_probe_" + Guid.NewGuid().ToString("N") + ".tmp");
                File.WriteAllText(tempFile, "Pre-flight write test at " + DateTime.Now);
                string readBack = File.ReadAllText(tempFile);
                File.Delete(tempFile);

                if (string.IsNullOrEmpty(readBack))
                {
                    throw new IOException("Đọc lại nội dung tệp tạm thất bại.");
                }

                return new CheckItemResult
                {
                    HangMuc = "4. Quyền tạo/xóa tệp",
                    TrangThai = "OK",
                    ChiTiet = "Tạo, ghi và xóa tệp tạm thành công.",
                    GoiYKhacPhuc = "Không cần thao tác.",
                    IsPassed = true
                };
            }
            catch (Exception ex)
            {
                return new CheckItemResult
                {
                    HangMuc = "4. Quyền tạo/xóa tệp",
                    TrangThai = "FAIL",
                    ChiTiet = ex.Message,
                    GoiYKhacPhuc = "Kiểm tra quyền NTFS (Write/Delete) hoặc phần mềm diệt virus chặn ghi file.",
                    IsPassed = false
                };
            }
        }

        private CheckItemResult CheckCrystalReportsRuntime()
        {
            if (!AppConfigHelper.RequireCrystalReports)
            {
                return new CheckItemResult
                {
                    HangMuc = "5. Crystal Reports Runtime",
                    TrangThai = "OK",
                    ChiTiet = "Đã tắt kiểm tra trong App.config (RequireCrystalReports=false).",
                    GoiYKhacPhuc = "Không cần thao tác.",
                    IsPassed = true
                };
            }

            try
            {
                Assembly crAssembly = Assembly.Load("CrystalDecisions.CrystalReports.Engine, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304");
                if (crAssembly == null)
                {
                    crAssembly = Assembly.Load("CrystalDecisions.CrystalReports.Engine, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304");
                }

                return new CheckItemResult
                {
                    HangMuc = "5. Crystal Reports Runtime",
                    TrangThai = "OK",
                    ChiTiet = "Đã cài đặt: " + crAssembly.GetName().Version,
                    GoiYKhacPhuc = "Không cần thao tác.",
                    IsPassed = true
                };
            }
            catch
            {
                return new CheckItemResult
                {
                    HangMuc = "5. Crystal Reports Runtime",
                    TrangThai = "FAIL",
                    ChiTiet = "Không tìm thấy CrystalDecisions.CrystalReports.Engine trong GAC.",
                    GoiYKhacPhuc = "Cài đặt SAP Crystal Reports Runtime Engine for .NET Framework (đúng bản x86/x64 của app).",
                    IsPassed = false
                };
            }
        }
    }
}