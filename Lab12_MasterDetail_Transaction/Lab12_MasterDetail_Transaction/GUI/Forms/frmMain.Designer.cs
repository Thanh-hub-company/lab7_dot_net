namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlMain;

        // Tab 1
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.DataGridView dgvKhoa_B1;
        private System.Windows.Forms.DataGridView dgvSinhVien_B1;
        private System.Windows.Forms.Label lblChiTiet_B1;

        // Tab 2
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.DataGridView dgvSinhVien_B2;
        private System.Windows.Forms.DataGridView dgvDangKy_B2;
        private System.Windows.Forms.Button btnThemHopLe_B3;
        private System.Windows.Forms.Button btnMoPhongRollback_B4;

        // Tab 3
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.TextBox txtMaSV_B6;
        private System.Windows.Forms.TextBox txtKhoaCu_B6;
        private System.Windows.Forms.ComboBox cboKhoaMoi_B6;
        private System.Windows.Forms.TextBox txtGhiChu_B6;
        private System.Windows.Forms.Button btnChuyenKhoa_B6;

        // Tab 4
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.ComboBox cboKhoaXoa_B7;
        private System.Windows.Forms.ComboBox cboKhoaChuyenToi_B7;
        private System.Windows.Forms.Button btnXoaKhoa_B7;

        // Tab 5
        private System.Windows.Forms.TabPage tab5;
        private System.Windows.Forms.TextBox txtMaSV_B8;
        private System.Windows.Forms.Button btnTaiDanhSach_B8;
        private System.Windows.Forms.DataGridView dgvDiem_B8;
        private System.Windows.Forms.Button btnLuuDiem_B8;

        // Tab 6
        private System.Windows.Forms.TabPage tab6;
        private System.Windows.Forms.TextBox txtMaSV_B9;
        private System.Windows.Forms.TextBox txtHoTen_B9;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh_B9;
        private System.Windows.Forms.ComboBox cboGioiTinh_B9;
        private System.Windows.Forms.TextBox txtMaKhoa_B9;
        private System.Windows.Forms.Button btnNapData_B9;
        private System.Windows.Forms.Button btnLuu_B9;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.dgvKhoa_B1 = new System.Windows.Forms.DataGridView();
            this.dgvSinhVien_B1 = new System.Windows.Forms.DataGridView();
            this.lblChiTiet_B1 = new System.Windows.Forms.Label();

            this.tab2 = new System.Windows.Forms.TabPage();
            this.dgvSinhVien_B2 = new System.Windows.Forms.DataGridView();
            this.dgvDangKy_B2 = new System.Windows.Forms.DataGridView();
            this.btnThemHopLe_B3 = new System.Windows.Forms.Button();
            this.btnMoPhongRollback_B4 = new System.Windows.Forms.Button();

            this.tab3 = new System.Windows.Forms.TabPage();
            this.txtMaSV_B6 = new System.Windows.Forms.TextBox();
            this.txtKhoaCu_B6 = new System.Windows.Forms.TextBox();
            this.cboKhoaMoi_B6 = new System.Windows.Forms.ComboBox();
            this.txtGhiChu_B6 = new System.Windows.Forms.TextBox();
            this.btnChuyenKhoa_B6 = new System.Windows.Forms.Button();

            this.tab4 = new System.Windows.Forms.TabPage();
            this.cboKhoaXoa_B7 = new System.Windows.Forms.ComboBox();
            this.cboKhoaChuyenToi_B7 = new System.Windows.Forms.ComboBox();
            this.btnXoaKhoa_B7 = new System.Windows.Forms.Button();

            this.tab5 = new System.Windows.Forms.TabPage();
            this.txtMaSV_B8 = new System.Windows.Forms.TextBox();
            this.btnTaiDanhSach_B8 = new System.Windows.Forms.Button();
            this.dgvDiem_B8 = new System.Windows.Forms.DataGridView();
            this.btnLuuDiem_B8 = new System.Windows.Forms.Button();

            this.tab6 = new System.Windows.Forms.TabPage();
            this.txtMaSV_B9 = new System.Windows.Forms.TextBox();
            this.txtHoTen_B9 = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh_B9 = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh_B9 = new System.Windows.Forms.ComboBox();
            this.txtMaKhoa_B9 = new System.Windows.Forms.TextBox();
            this.btnNapData_B9 = new System.Windows.Forms.Button();
            this.btnLuu_B9 = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa_B1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien_B1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien_B2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy_B2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem_B8)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tab4.SuspendLayout();
            this.tab5.SuspendLayout();
            this.tab6.SuspendLayout();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tab1);
            this.tabControlMain.Controls.Add(this.tab2);
            this.tabControlMain.Controls.Add(this.tab3);
            this.tabControlMain.Controls.Add(this.tab4);
            this.tabControlMain.Controls.Add(this.tab5);
            this.tabControlMain.Controls.Add(this.tab6);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Size = new System.Drawing.Size(840, 530);

            // TAB 1
            this.tab1.Text = "Bài 1: Khoa - SinhVien";
            this.tab1.Controls.Add(this.dgvKhoa_B1);
            this.tab1.Controls.Add(this.lblChiTiet_B1);
            this.tab1.Controls.Add(this.dgvSinhVien_B1);
            this.dgvKhoa_B1.SetBounds(15, 15, 795, 180);
            this.dgvKhoa_B1.SelectionChanged += new System.EventHandler(this.dgvKhoa_B1_SelectionChanged);
            this.lblChiTiet_B1.SetBounds(15, 205, 400, 20);
            this.dgvSinhVien_B1.SetBounds(15, 230, 795, 240);

            // TAB 2
            this.tab2.Text = "Bài 2,3,4,5: SV - DangKy & Tx";
            this.tab2.Controls.Add(this.dgvSinhVien_B2);
            this.tab2.Controls.Add(this.dgvDangKy_B2);
            this.tab2.Controls.Add(this.btnThemHopLe_B3);
            this.tab2.Controls.Add(this.btnMoPhongRollback_B4);
            this.dgvSinhVien_B2.SetBounds(15, 15, 795, 170);
            this.dgvSinhVien_B2.SelectionChanged += new System.EventHandler(this.dgvSinhVien_B2_SelectionChanged);
            this.dgvDangKy_B2.SetBounds(15, 195, 795, 200);
            this.btnThemHopLe_B3.SetBounds(15, 410, 260, 40);
            this.btnThemHopLe_B3.Text = "Thêm SV + Đăng Ký (Hợp lệ)";
            this.btnThemHopLe_B3.Click += new System.EventHandler(this.btnThemHopLe_B3_Click);
            this.btnMoPhongRollback_B4.SetBounds(290, 410, 280, 40);
            this.btnMoPhongRollback_B4.Text = "Thử Nghiệm Lỗi (Rollback Test)";
            this.btnMoPhongRollback_B4.Click += new System.EventHandler(this.btnMoPhongRollback_B4_Click);

            // TAB 3
            this.tab3.Text = "Bài 6: Chuyển Khoa";
            var lbl1 = new System.Windows.Forms.Label { Text = "Mã SV:", Location = new System.Drawing.Point(40, 40) };
            var lbl2 = new System.Windows.Forms.Label { Text = "Khoa Cũ:", Location = new System.Drawing.Point(40, 80) };
            var lbl3 = new System.Windows.Forms.Label { Text = "Khoa Mới:", Location = new System.Drawing.Point(40, 120) };
            var lbl4 = new System.Windows.Forms.Label { Text = "Ghi Chú:", Location = new System.Drawing.Point(40, 160) };
            this.txtMaSV_B6.SetBounds(150, 37, 220, 22);
            this.txtKhoaCu_B6.SetBounds(150, 77, 220, 22);
            this.cboKhoaMoi_B6.SetBounds(150, 117, 220, 24);
            this.txtGhiChu_B6.SetBounds(150, 157, 220, 22);
            this.btnChuyenKhoa_B6.SetBounds(150, 205, 220, 40);
            this.btnChuyenKhoa_B6.Text = "Thực Hiện Chuyển Khoa";
            this.btnChuyenKhoa_B6.Click += new System.EventHandler(this.btnChuyenKhoa_B6_Click);
            this.tab3.Controls.AddRange(new System.Windows.Forms.Control[] { lbl1, lbl2, lbl3, lbl4, txtMaSV_B6, txtKhoaCu_B6, cboKhoaMoi_B6, txtGhiChu_B6, btnChuyenKhoa_B6 });

            // TAB 4
            this.tab4.Text = "Bài 7: Xóa Khoa An Toàn";
            var lbl5 = new System.Windows.Forms.Label { Text = "Khoa Cần Xóa:", Location = new System.Drawing.Point(40, 40), AutoSize = true };
            var lbl6 = new System.Windows.Forms.Label { Text = "Khoa Nhận Sinh Viên:", Location = new System.Drawing.Point(40, 90), AutoSize = true };
            this.cboKhoaXoa_B7.SetBounds(200, 37, 220, 24);
            this.cboKhoaChuyenToi_B7.SetBounds(200, 87, 220, 24);
            this.btnXoaKhoa_B7.SetBounds(200, 140, 220, 40);
            this.btnXoaKhoa_B7.Text = "Xóa Khoa An Toàn";
            this.btnXoaKhoa_B7.Click += new System.EventHandler(this.btnXoaKhoa_B7_Click);
            this.tab4.Controls.AddRange(new System.Windows.Forms.Control[] { lbl5, lbl6, cboKhoaXoa_B7, cboKhoaChuyenToi_B7, btnXoaKhoa_B7 });

            // TAB 5
            this.tab5.Text = "Bài 8: Cập Nhật Điểm";
            var lbl7 = new System.Windows.Forms.Label { Text = "Mã SV:", Location = new System.Drawing.Point(15, 20) };
            this.txtMaSV_B8.SetBounds(80, 17, 150, 22);
            this.txtMaSV_B8.Text = "SV001";
            this.btnTaiDanhSach_B8.SetBounds(240, 15, 120, 26);
            this.btnTaiDanhSach_B8.Text = "Tải Danh Sách";
            this.btnTaiDanhSach_B8.Click += new System.EventHandler(this.btnTaiDanhSach_B8_Click);
            this.dgvDiem_B8.SetBounds(15, 55, 795, 330);
            this.btnLuuDiem_B8.SetBounds(560, 400, 250, 40);
            this.btnLuuDiem_B8.Text = "Lưu Điểm Hàng Loạt (Transaction)";
            this.btnLuuDiem_B8.Click += new System.EventHandler(this.btnLuuDiem_B8_Click);
            this.tab5.Controls.AddRange(new System.Windows.Forms.Control[] { lbl7, txtMaSV_B8, btnTaiDanhSach_B8, dgvDiem_B8, btnLuuDiem_B8 });

            // TAB 6
            this.tab6.Text = "Bài 9 & 10: Concurrency & 3 Lớp";
            var l1 = new System.Windows.Forms.Label { Text = "Mã SV:", Location = new System.Drawing.Point(40, 40) };
            var l2 = new System.Windows.Forms.Label { Text = "Họ Tên:", Location = new System.Drawing.Point(40, 80) };
            var l3 = new System.Windows.Forms.Label { Text = "Ngày Sinh:", Location = new System.Drawing.Point(40, 120) };
            var l4 = new System.Windows.Forms.Label { Text = "Giới Tính:", Location = new System.Drawing.Point(40, 160) };
            var l5 = new System.Windows.Forms.Label { Text = "Mã Khoa:", Location = new System.Drawing.Point(40, 200) };
            this.txtMaSV_B9.SetBounds(140, 37, 200, 22);
            this.txtHoTen_B9.SetBounds(140, 77, 200, 22);
            this.dtpNgaySinh_B9.SetBounds(140, 117, 200, 22);
            this.cboGioiTinh_B9.SetBounds(140, 157, 200, 24);
            this.cboGioiTinh_B9.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.txtMaKhoa_B9.SetBounds(140, 197, 200, 22);
            this.btnNapData_B9.SetBounds(140, 240, 200, 35);
            this.btnNapData_B9.Text = "1. Nạp Mẫu Data & RowVersion";
            this.btnNapData_B9.Click += new System.EventHandler(this.btnNapData_B9_Click);
            this.btnLuu_B9.SetBounds(140, 285, 200, 35);
            this.btnLuu_B9.Text = "2. Lưu Thay Đổi (Check Timestamp)";
            this.btnLuu_B9.Click += new System.EventHandler(this.btnLuu_B9_Click);
            this.tab6.Controls.AddRange(new System.Windows.Forms.Control[] { l1, l2, l3, l4, l5, txtMaSV_B9, txtHoTen_B9, dtpNgaySinh_B9, cboGioiTinh_B9, txtMaKhoa_B9, btnNapData_B9, btnLuu_B9 });

            // frmMain
            this.ClientSize = new System.Drawing.Size(840, 530);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOÀN THÀNH TỔNG HỢP LAB 12 - 10 BÀI TẬP (MÔ HÌNH 3 LỚP & TRANSACTION)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa_B1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien_B1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien_B2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy_B2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem_B8)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            this.tab5.ResumeLayout(false);
            this.tab5.PerformLayout();
            this.tab6.ResumeLayout(false);
            this.tab6.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}