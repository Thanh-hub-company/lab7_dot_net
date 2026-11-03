namespace Lab09_DataReaderSearch.Forms
{
    public partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.lblSearchMaSV = new System.Windows.Forms.Label();
            this.txtSearchMaSV = new System.Windows.Forms.TextBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.chkScore = new System.Windows.Forms.CheckBox();
            this.btnMultiSearch = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.lblKhoaFilter = new System.Windows.Forms.Label();
            this.cboKhoaFilter = new System.Windows.Forms.ComboBox();
            this.lblScoreRange = new System.Windows.Forms.Label();
            this.numMinScore = new System.Windows.Forms.NumericUpDown();
            this.lblScoreTo = new System.Windows.Forms.Label();
            this.numMaxScore = new System.Windows.Forms.NumericUpDown();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblSort = new System.Windows.Forms.Label();
            this.cboSortColumn = new System.Windows.Forms.ComboBox();
            this.cboSortDirection = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.lblAgeRange = new System.Windows.Forms.Label();
            this.numMinAge = new System.Windows.Forms.NumericUpDown();
            this.lblAgeTo = new System.Windows.Forms.Label();
            this.numMaxAge = new System.Windows.Forms.NumericUpDown();
            this.btnFilterAge = new System.Windows.Forms.Button();

            this.dgvSinhVien = new System.Windows.Forms.DataGridView();

            this.pnlPhanTrang = new System.Windows.Forms.Panel();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();

            this.grpChiTiet.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.pnlPhanTrang.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.lblMaSV);
            this.grpChiTiet.Controls.Add(this.txtMaSV);
            this.grpChiTiet.Controls.Add(this.lblHoTen);
            this.grpChiTiet.Controls.Add(this.txtHoTen);
            this.grpChiTiet.Controls.Add(this.lblNgaySinh);
            this.grpChiTiet.Controls.Add(this.dtpNgaySinh);
            this.grpChiTiet.Controls.Add(this.lblGioiTinh);
            this.grpChiTiet.Controls.Add(this.cboGioiTinh);
            this.grpChiTiet.Controls.Add(this.lblKhoa);
            this.grpChiTiet.Controls.Add(this.cboKhoa);
            this.grpChiTiet.Controls.Add(this.lblDiemTB);
            this.grpChiTiet.Controls.Add(this.txtDiemTB);
            this.grpChiTiet.Controls.Add(this.lblEmail);
            this.grpChiTiet.Controls.Add(this.txtEmail);
            this.grpChiTiet.Controls.Add(this.btnThem);
            this.grpChiTiet.Controls.Add(this.btnSua);
            this.grpChiTiet.Controls.Add(this.btnXoa);
            this.grpChiTiet.Controls.Add(this.btnLamMoi);
            this.grpChiTiet.Location = new System.Drawing.Point(12, 10);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(980, 95);
            this.grpChiTiet.TabIndex = 0;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Thông Tin Chi Tiết & Quản Lý Sinh Viên (Lab 7, 8)";

            // Controls chi tiết
            this.lblMaSV.Text = "Mã SV:"; this.lblMaSV.Location = new System.Drawing.Point(15, 23); this.lblMaSV.AutoSize = true;
            this.txtMaSV.Location = new System.Drawing.Point(65, 20); this.txtMaSV.Size = new System.Drawing.Size(90, 20);

            this.lblHoTen.Text = "Họ tên:"; this.lblHoTen.Location = new System.Drawing.Point(165, 23); this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new System.Drawing.Point(215, 20); this.txtHoTen.Size = new System.Drawing.Size(140, 20);

            this.lblNgaySinh.Text = "Ngày sinh:"; this.lblNgaySinh.Location = new System.Drawing.Point(365, 23); this.lblNgaySinh.AutoSize = true;
            this.dtpNgaySinh.Location = new System.Drawing.Point(430, 20); this.dtpNgaySinh.Size = new System.Drawing.Size(110, 20); this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblGioiTinh.Text = "Giới tính:"; this.lblGioiTinh.Location = new System.Drawing.Point(550, 23); this.lblGioiTinh.AutoSize = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(605, 20); this.cboGioiTinh.Size = new System.Drawing.Size(70, 21);
            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });

            this.lblKhoa.Text = "Khoa:"; this.lblKhoa.Location = new System.Drawing.Point(15, 57); this.lblKhoa.AutoSize = true;
            this.cboKhoa.Location = new System.Drawing.Point(65, 54); this.cboKhoa.Size = new System.Drawing.Size(140, 21);

            this.lblDiemTB.Text = "Điểm TB:"; this.lblDiemTB.Location = new System.Drawing.Point(215, 57); this.lblDiemTB.AutoSize = true;
            this.txtDiemTB.Location = new System.Drawing.Point(270, 54); this.txtDiemTB.Size = new System.Drawing.Size(55, 20);

            this.lblEmail.Text = "Email:"; this.lblEmail.Location = new System.Drawing.Point(335, 57); this.lblEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(380, 54); this.txtEmail.Size = new System.Drawing.Size(160, 20);

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new System.Drawing.Point(560, 50); this.btnThem.Size = new System.Drawing.Size(70, 26); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new System.Drawing.Point(640, 50); this.btnSua.Size = new System.Drawing.Size(70, 26); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new System.Drawing.Point(720, 50); this.btnXoa.Size = new System.Drawing.Size(70, 26); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Text = "Làm mới"; this.btnLamMoi.Location = new System.Drawing.Point(800, 50); this.btnLamMoi.Size = new System.Drawing.Size(75, 26); this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblSearchName);
            this.grpTimKiem.Controls.Add(this.txtSearchName);
            this.grpTimKiem.Controls.Add(this.btnSearchName);
            this.grpTimKiem.Controls.Add(this.lblSearchMaSV);
            this.grpTimKiem.Controls.Add(this.txtSearchMaSV);
            this.grpTimKiem.Controls.Add(this.radNam);
            this.grpTimKiem.Controls.Add(this.radNu);
            this.grpTimKiem.Controls.Add(this.chkScore);
            this.grpTimKiem.Controls.Add(this.btnMultiSearch);
            this.grpTimKiem.Controls.Add(this.btnExportCSV);
            this.grpTimKiem.Controls.Add(this.lblKhoaFilter);
            this.grpTimKiem.Controls.Add(this.cboKhoaFilter);
            this.grpTimKiem.Controls.Add(this.lblScoreRange);
            this.grpTimKiem.Controls.Add(this.numMinScore);
            this.grpTimKiem.Controls.Add(this.lblScoreTo);
            this.grpTimKiem.Controls.Add(this.numMaxScore);
            this.grpTimKiem.Controls.Add(this.btnFilter);
            this.grpTimKiem.Controls.Add(this.lblSort);
            this.grpTimKiem.Controls.Add(this.cboSortColumn);
            this.grpTimKiem.Controls.Add(this.cboSortDirection);
            this.grpTimKiem.Controls.Add(this.btnSort);
            this.grpTimKiem.Controls.Add(this.lblAgeRange);
            this.grpTimKiem.Controls.Add(this.numMinAge);
            this.grpTimKiem.Controls.Add(this.lblAgeTo);
            this.grpTimKiem.Controls.Add(this.numMaxAge);
            this.grpTimKiem.Controls.Add(this.btnFilterAge);
            this.grpTimKiem.Location = new System.Drawing.Point(12, 110);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(980, 95);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Bộ Lọc & Tra Cứu Nâng Cao (Lab 9)";

            this.lblSearchName.Text = "Từ khóa tên:"; this.lblSearchName.Location = new System.Drawing.Point(15, 23); this.lblSearchName.AutoSize = true;
            this.txtSearchName.Location = new System.Drawing.Point(85, 20); this.txtSearchName.Size = new System.Drawing.Size(100, 20);
            this.btnSearchName.Text = "Tìm tên"; this.btnSearchName.Location = new System.Drawing.Point(190, 18); this.btnSearchName.Size = new System.Drawing.Size(65, 24); this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);

            this.lblSearchMaSV.Text = "Mã SV:"; this.lblSearchMaSV.Location = new System.Drawing.Point(265, 23); this.lblSearchMaSV.AutoSize = true;
            this.txtSearchMaSV.Location = new System.Drawing.Point(310, 20); this.txtSearchMaSV.Size = new System.Drawing.Size(70, 20);

            this.radNam.Text = "Nam"; this.radNam.Location = new System.Drawing.Point(390, 22); this.radNam.Size = new System.Drawing.Size(50, 20);
            this.radNu.Text = "Nữ"; this.radNu.Location = new System.Drawing.Point(445, 22); this.radNu.Size = new System.Drawing.Size(45, 20);
            this.chkScore.Text = "Định khoảng điểm"; this.chkScore.Location = new System.Drawing.Point(495, 22); this.chkScore.Size = new System.Drawing.Size(115, 20);

            this.btnMultiSearch.Text = "Tìm Đa Tiêu Chí"; this.btnMultiSearch.Location = new System.Drawing.Point(615, 18); this.btnMultiSearch.Size = new System.Drawing.Size(105, 24); this.btnMultiSearch.Click += new System.EventHandler(this.btnMultiSearch_Click);

            this.btnExportCSV.Text = "Xuất CSV (Bài 10)"; this.btnExportCSV.Location = new System.Drawing.Point(825, 18); this.btnExportCSV.Size = new System.Drawing.Size(140, 24); this.btnExportCSV.BackColor = System.Drawing.Color.LightGreen; this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);

            this.lblKhoaFilter.Text = "Lọc khoa:"; this.lblKhoaFilter.Location = new System.Drawing.Point(15, 57); this.lblKhoaFilter.AutoSize = true;
            this.cboKhoaFilter.Location = new System.Drawing.Point(75, 54); this.cboKhoaFilter.Size = new System.Drawing.Size(120, 21);

            this.lblScoreRange.Text = "Điểm:"; this.lblScoreRange.Location = new System.Drawing.Point(205, 57); this.lblScoreRange.AutoSize = true;
            this.numMinScore.Location = new System.Drawing.Point(245, 54); this.numMinScore.Size = new System.Drawing.Size(45, 20); this.numMinScore.DecimalPlaces = 1; this.numMinScore.Maximum = 10;
            this.lblScoreTo.Text = "-"; this.lblScoreTo.Location = new System.Drawing.Point(295, 57); this.lblScoreTo.AutoSize = true;
            this.numMaxScore.Location = new System.Drawing.Point(305, 54); this.numMaxScore.Size = new System.Drawing.Size(45, 20); this.numMaxScore.DecimalPlaces = 1; this.numMaxScore.Maximum = 10; this.numMaxScore.Value = 10;
            this.btnFilter.Text = "Lọc điểm"; this.btnFilter.Location = new System.Drawing.Point(355, 52); this.btnFilter.Size = new System.Drawing.Size(70, 24); this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            this.lblSort.Text = "Sắp xếp:"; this.lblSort.Location = new System.Drawing.Point(435, 57); this.lblSort.AutoSize = true;
            this.cboSortColumn.Location = new System.Drawing.Point(485, 54); this.cboSortColumn.Size = new System.Drawing.Size(80, 21);
            this.cboSortDirection.Location = new System.Drawing.Point(570, 54); this.cboSortDirection.Size = new System.Drawing.Size(75, 21);
            this.btnSort.Text = "Sắp xếp"; this.btnSort.Location = new System.Drawing.Point(650, 52); this.btnSort.Size = new System.Drawing.Size(65, 24); this.btnSort.Click += new System.EventHandler(this.btnSort_Click);

            this.lblAgeRange.Text = "Tuổi:"; this.lblAgeRange.Location = new System.Drawing.Point(725, 57); this.lblAgeRange.AutoSize = true;
            this.numMinAge.Location = new System.Drawing.Point(760, 54); this.numMinAge.Size = new System.Drawing.Size(45, 20); this.numMinAge.Value = 18;
            this.lblAgeTo.Text = "-"; this.lblAgeTo.Location = new System.Drawing.Point(810, 57); this.lblAgeTo.AutoSize = true;
            this.numMaxAge.Location = new System.Drawing.Point(820, 54); this.numMaxAge.Size = new System.Drawing.Size(45, 20); this.numMaxAge.Value = 30;
            this.btnFilterAge.Text = "Lọc tuổi"; this.btnFilterAge.Location = new System.Drawing.Point(870, 52); this.btnFilterAge.Size = new System.Drawing.Size(75, 24); this.btnFilterAge.Click += new System.EventHandler(this.btnFilterAge_Click);

            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(12, 210);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(980, 425);
            this.dgvSinhVien.TabIndex = 2;
            this.dgvSinhVien.SelectionChanged += new System.EventHandler(this.dgvSinhVien_SelectionChanged);
            this.dgvSinhVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSinhVien_CellFormatting);

            // 
            // pnlPhanTrang
            // 
            this.pnlPhanTrang.Controls.Add(this.btnPrevPage);
            this.pnlPhanTrang.Controls.Add(this.lblPageInfo);
            this.pnlPhanTrang.Controls.Add(this.btnNextPage);
            this.pnlPhanTrang.Controls.Add(this.lblTrangThai);
            this.pnlPhanTrang.Location = new System.Drawing.Point(12, 640);
            this.pnlPhanTrang.Name = "pnlPhanTrang";
            this.pnlPhanTrang.Size = new System.Drawing.Size(980, 35);
            this.pnlPhanTrang.TabIndex = 3;

            this.btnPrevPage.Text = "< Trang Trước"; this.btnPrevPage.Location = new System.Drawing.Point(5, 4); this.btnPrevPage.Size = new System.Drawing.Size(100, 26); this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            this.lblPageInfo.Text = "Trang 1"; this.lblPageInfo.Location = new System.Drawing.Point(115, 9); this.lblPageInfo.AutoSize = true;
            this.btnNextPage.Text = "Trang Sau >"; this.btnNextPage.Location = new System.Drawing.Point(175, 4); this.btnNextPage.Size = new System.Drawing.Size(100, 26); this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            this.lblTrangThai.Text = "Trạng thái: Sẵn sàng"; this.lblTrangThai.Location = new System.Drawing.Point(320, 9); this.lblTrangThai.AutoSize = true; this.lblTrangThai.ForeColor = System.Drawing.Color.Blue;

            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.pnlPhanTrang);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý & Tra Cứu Sinh Viên (Lab 7, 8, 9)";
            this.Load += new System.EventHandler(this.FormMain_Load);

            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.pnlPhanTrang.ResumeLayout(false);
            this.pnlPhanTrang.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.GroupBox grpChiTiet;
        public System.Windows.Forms.GroupBox grpTimKiem;
        public System.Windows.Forms.Panel pnlPhanTrang;
        public System.Windows.Forms.DataGridView dgvSinhVien;

        public System.Windows.Forms.Label lblMaSV;
        public System.Windows.Forms.TextBox txtMaSV;
        public System.Windows.Forms.Label lblHoTen;
        public System.Windows.Forms.TextBox txtHoTen;
        public System.Windows.Forms.Label lblNgaySinh;
        public System.Windows.Forms.DateTimePicker dtpNgaySinh;
        public System.Windows.Forms.Label lblGioiTinh;
        public System.Windows.Forms.ComboBox cboGioiTinh;
        public System.Windows.Forms.Label lblKhoa;
        public System.Windows.Forms.ComboBox cboKhoa;
        public System.Windows.Forms.Label lblDiemTB;
        public System.Windows.Forms.TextBox txtDiemTB;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtEmail;

        public System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.Button btnSua;
        public System.Windows.Forms.Button btnXoa;
        public System.Windows.Forms.Button btnLamMoi;

        public System.Windows.Forms.Label lblSearchName;
        public System.Windows.Forms.TextBox txtSearchName;
        public System.Windows.Forms.Button btnSearchName;
        public System.Windows.Forms.Label lblSearchMaSV;
        public System.Windows.Forms.TextBox txtSearchMaSV;
        public System.Windows.Forms.Label lblKhoaFilter;
        public System.Windows.Forms.ComboBox cboKhoaFilter;
        public System.Windows.Forms.Label lblScoreRange;
        public System.Windows.Forms.NumericUpDown numMinScore;
        public System.Windows.Forms.Label lblScoreTo;
        public System.Windows.Forms.NumericUpDown numMaxScore;
        public System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.RadioButton radNam;
        public System.Windows.Forms.RadioButton radNu;
        public System.Windows.Forms.CheckBox chkScore;
        public System.Windows.Forms.Button btnMultiSearch;
        public System.Windows.Forms.Label lblSort;
        public System.Windows.Forms.ComboBox cboSortColumn;
        public System.Windows.Forms.ComboBox cboSortDirection;
        public System.Windows.Forms.Button btnSort;
        public System.Windows.Forms.Label lblAgeRange;
        public System.Windows.Forms.NumericUpDown numMinAge;
        public System.Windows.Forms.Label lblAgeTo;
        public System.Windows.Forms.NumericUpDown numMaxAge;
        public System.Windows.Forms.Button btnFilterAge;
        public System.Windows.Forms.Button btnExportCSV;

        public System.Windows.Forms.Button btnPrevPage;
        public System.Windows.Forms.Label lblPageInfo;
        public System.Windows.Forms.Button btnNextPage;
        public System.Windows.Forms.Label lblTrangThai;
    }
}