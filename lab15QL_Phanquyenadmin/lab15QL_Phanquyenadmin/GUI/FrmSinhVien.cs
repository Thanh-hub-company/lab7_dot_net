using QLSinhVien.BUS;
using QLSinhVien.Common;
using QLSinhVien.DTO;
using QLSinhVien.GUI.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QLSinhVien.GUI
{
	public class FrmSinhVien : Form
	{
		private readonly SinhVienBUS _bus = new SinhVienBUS();

		private TextBox _txtMaSV;
		private TextBox _txtHoTen;
		private DateTimePicker _dtpNgaySinh;
		private ComboBox _cboGioiTinh;
		private TextBox _txtDiemTB;
		private TextBox _txtMaLop;
		private TextBox _txtTimKiem;
		private DataGridView _dgvSinhVien;

		private Button _btnThem;
		private Button _btnSua;
		private Button _btnXoa;
		private Button _btnLamMoi;
		private Button _btnTimKiem;
		private Button _btnXuatBaoCao;
		private Button _btnPreFlight;
		private Button _btnTestCrash;

		public FrmSinhVien()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.Text = "Quản lý Sinh viên - IT3212 (Lab 15)";
			this.Size = new Size(920, 560);
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Font = new Font("Segoe UI", 9.5F);

			// Nhóm nhập liệu
			GroupBox grpInfo = new GroupBox
			{
				Text = "Thông tin sinh viên",
				Location = new Point(15, 12),
				Size = new Size(875, 130)
			};

			Label lblMaSV = new Label { Text = "Mã SV:", Location = new Point(18, 30), AutoSize = true };
			_txtMaSV = new TextBox { Location = new Point(95, 27), Width = 160 };

			Label lblHoTen = new Label { Text = "Họ tên:", Location = new Point(285, 30), AutoSize = true };
			_txtHoTen = new TextBox { Location = new Point(355, 27), Width = 220 };

			Label lblNgaySinh = new Label { Text = "Ngày sinh:", Location = new Point(605, 30), AutoSize = true };
			_dtpNgaySinh = new DateTimePicker
			{
				Location = new Point(685, 27),
				Width = 165,
				Format = DateTimePickerFormat.Short,
				Value = new DateTime(2004, 1, 1)
			};

			Label lblGioiTinh = new Label { Text = "Giới tính:", Location = new Point(18, 72), AutoSize = true };
			_cboGioiTinh = new ComboBox
			{
				Location = new Point(95, 69),
				Width = 160,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			_cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
			_cboGioiTinh.SelectedIndex = 0;

			Label lblDiemTB = new Label { Text = "Điểm TB:", Location = new Point(285, 72), AutoSize = true };
			_txtDiemTB = new TextBox { Location = new Point(355, 69), Width = 220 };

			Label lblMaLop = new Label { Text = "Mã lớp:", Location = new Point(605, 72), AutoSize = true };
			_txtMaLop = new TextBox { Location = new Point(685, 69), Width = 165 };

			grpInfo.Controls.AddRange(new Control[]
			{
				lblMaSV, _txtMaSV, lblHoTen, _txtHoTen, lblNgaySinh, _dtpNgaySinh,
				lblGioiTinh, _cboGioiTinh, lblDiemTB, _txtDiemTB, lblMaLop, _txtMaLop
			});

			// Hàng nút chức năng
			_btnThem = new Button { Text = "Thêm", Location = new Point(15, 154), Size = new Size(90, 34) };
			_btnThem.Click += BtnThem_Click;

			_btnSua = new Button { Text = "Sửa", Location = new Point(113, 154), Size = new Size(90, 34) };
			_btnSua.Click += BtnSua_Click;

			_btnXoa = new Button { Text = "Xóa", Location = new Point(211, 154), Size = new Size(90, 34) };
			_btnXoa.Click += BtnXoa_Click;

			_btnLamMoi = new Button { Text = "Làm mới", Location = new Point(309, 154), Size = new Size(95, 34) };
			_btnLamMoi.Click += (s, e) => ClearInputs();

			_btnXuatBaoCao = new Button { Text = "Xuất báo cáo", Location = new Point(412, 154), Size = new Size(115, 34) };
			_btnXuatBaoCao.Click += BtnXuatBaoCao_Click;

			_btnPreFlight = new Button { Text = "Kiểm tra hệ thống", Location = new Point(535, 154), Size = new Size(145, 34) };
			_btnPreFlight.Click += BtnPreFlight_Click;

			_btnTestCrash = new Button { Text = "Test Global Error", Location = new Point(688, 154), Size = new Size(135, 34) };
			_btnTestCrash.Click += (s, e) =>
			{
				// Cố tình ném lỗi ngoài try-catch để kiểm thử Global Exception Handler trong Program.cs
				throw new InvalidOperationException("Kiểm thử ngoại lệ chưa được xử lý (Unhandled Exception).");
			};

			// Thanh tìm kiếm
			Label lblTimKiem = new Label { Text = "Tìm kiếm:", Location = new Point(15, 204), AutoSize = true };
			_txtTimKiem = new TextBox { Location = new Point(88, 201), Width = 260 };
			_btnTimKiem = new Button { Text = "Tìm", Location = new Point(358, 199), Size = new Size(80, 28) };
			_btnTimKiem.Click += BtnTimKiem_Click;

			// Bảng dữ liệu
			_dgvSinhVien = new DataGridView
			{
				Location = new Point(15, 238),
				Size = new Size(875, 265),
				ReadOnly = true,
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
				BackgroundColor = Color.White
			};
			_dgvSinhVien.CellClick += DgvSinhVien_CellClick;

			this.Controls.AddRange(new Control[]
			{
				grpInfo,
				_btnThem, _btnSua, _btnXoa, _btnLamMoi, _btnXuatBaoCao, _btnPreFlight, _btnTestCrash,
				lblTimKiem, _txtTimKiem, _btnTimKiem,
				_dgvSinhVien
			});

			this.Load += (s, e) => LoadDanhSachSinhVien();
		}

		private void LoadDanhSachSinhVien(string keyword = null)
		{
			try
			{
				_dgvSinhVien.DataSource = null;
				_dgvSinhVien.DataSource = string.IsNullOrWhiteSpace(keyword)
					? _bus.GetAll()
					: _bus.Search(keyword);
			}
			catch (Exception ex)
			{
				UiExceptionHandler.Handle(ex, "Tải danh sách sinh viên");
			}
		}

		private SinhVienDTO GetDtoFromForm()
		{
			double diemTB;
			if (!double.TryParse(_txtDiemTB.Text.Trim(), out diemTB))
			{
				throw new BusinessException("Điểm trung bình phải là giá trị số hợp lệ.");
			}

			return new SinhVienDTO
			{
				MaSV = _txtMaSV.Text.Trim(),
				HoTen = _txtHoTen.Text.Trim(),
				NgaySinh = _dtpNgaySinh.Value.Date,
				GioiTinh = _cboGioiTinh.Text,
				DiemTB = diemTB,
				MaLop = _txtMaLop.Text.Trim()
			};
		}

		private void BtnThem_Click(object sender, EventArgs e)
		{
			try
			{
				SinhVienDTO dto = GetDtoFromForm();
				if (_bus.Add(dto))
				{
					Logger.Info(string.Format("Thêm mới sinh viên: MaSV={0}", dto.MaSV));
					MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ClearInputs();
					LoadDanhSachSinhVien();
				}
			}
			catch (Exception ex)
			{
				UiExceptionHandler.Handle(ex, "Thêm mới sinh viên");
			}
		}

		private void BtnSua_Click(object sender, EventArgs e)
		{
			try
			{
				SinhVienDTO dto = GetDtoFromForm();
				if (_bus.Update(dto))
				{
					Logger.Info(string.Format("Cập nhật sinh viên: MaSV={0}", dto.MaSV));
					MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ClearInputs();
					LoadDanhSachSinhVien();
				}
			}
			catch (Exception ex)
			{
				UiExceptionHandler.Handle(ex, "Cập nhật sinh viên");
			}
		}

		private void BtnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				string maSV = _txtMaSV.Text.Trim();
				DialogResult confirm = MessageBox.Show(
					string.Format("Bạn có chắc chắn muốn xóa sinh viên '{0}'?", maSV),
					"Xác nhận xóa",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirm != DialogResult.Yes)
				{
					return;
				}

				if (_bus.Delete(maSV))
				{
					Logger.Info(string.Format("Xóa sinh viên: MaSV={0}", maSV));
					MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ClearInputs();
					LoadDanhSachSinhVien();
				}
			}
			catch (Exception ex)
			{
				UiExceptionHandler.Handle(ex, "Xóa sinh viên");
			}
		}

		private void BtnTimKiem_Click(object sender, EventArgs e)
		{
			LoadDanhSachSinhVien(_txtTimKiem.Text);
		}

		private void BtnXuatBaoCao_Click(object sender, EventArgs e)
		{
			try
			{
				// Đọc thư mục báo cáo từ App.config qua AppConfigHelper
				string reportDir = AppConfigHelper.ReportFolder;
				Directory.CreateDirectory(reportDir);

				string filePath = Path.Combine(reportDir, string.Format("DanhSachSinhVien_{0:yyyyMMdd_HHmmss}.csv", DateTime.Now));
				var list = _bus.GetAll();

				StringBuilder sb = new StringBuilder();
				sb.AppendLine("MaSV,HoTen,NgaySinh,GioiTinh,DiemTB,MaLop");
				foreach (SinhVienDTO sv in list)
				{
					sb.AppendFormat("{0},\"{1}\",{2:yyyy-MM-dd},{3},{4},{5}\r\n",
						sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.DiemTB, sv.MaLop);
				}

				File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
				Logger.Info("Xuất báo cáo thành công: " + filePath);
				MessageBox.Show("Đã xuất báo cáo tại:\r\n" + filePath, "Xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				UiExceptionHandler.Handle(ex, "Xuất báo cáo sinh viên");
			}
		}

		private void BtnPreFlight_Click(object sender, EventArgs e)
		{
			using (FrmPreFlightCheck frm = new FrmPreFlightCheck(autoCloseIfAllPassed: false))
			{
				frm.ShowDialog(this);
			}
		}

		private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || _dgvSinhVien.Rows[e.RowIndex].DataBoundItem == null)
			{
				return;
			}

			SinhVienDTO selected = _dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVienDTO;
			if (selected != null)
			{
				_txtMaSV.Text = selected.MaSV;
				_txtMaSV.ReadOnly = true;
				_txtHoTen.Text = selected.HoTen;
				_dtpNgaySinh.Value = selected.NgaySinh;
				_cboGioiTinh.Text = selected.GioiTinh;
				_txtDiemTB.Text = selected.DiemTB.ToString();
				_txtMaLop.Text = selected.MaLop;
			}
		}

		private void ClearInputs()
		{
			_txtMaSV.Clear();
			_txtMaSV.ReadOnly = false;
			_txtHoTen.Clear();
			_dtpNgaySinh.Value = new DateTime(2004, 1, 1);
			_cboGioiTinh.SelectedIndex = 0;
			_txtDiemTB.Clear();
			_txtMaLop.Clear();
			_txtMaSV.Focus();
		}
	}
}