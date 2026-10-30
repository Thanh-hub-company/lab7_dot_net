namespace Lab08_SqlCommand.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhatDiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLocTheoKhoa = new System.Windows.Forms.Button();
            this.btnDiemMax = new System.Windows.Forms.Button();
            this.btnThemSpOutput = new System.Windows.Forms.Button();

            this.lblDanhSach = new System.Windows.Forms.Label();
            this.lstSinhVien = new System.Windows.Forms.ListBox();
            this.lblTongSoSV = new System.Windows.Forms.Label();
            this.lblMaxDiem = new System.Windows.Forms.Label();

            this.gbThongTin.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            this.SuspendLayout();

            // gbThongTin
            this.gbThongTin.Controls.Add(this.lblMaSV);
            this.gbThongTin.Controls.Add(this.txtMaSV);
            this.gbThongTin.Controls.Add(this.lblHoTen);
            this.gbThongTin.Controls.Add(this.txtHoTen);
            this.gbThongTin.Controls.Add(this.lblNgaySinh);
            this.gbThongTin.Controls.Add(this.dtpNgaySinh);
            this.gbThongTin.Controls.Add(this.lblGioiTinh);
            this.gbThongTin.Controls.Add(this.radNam);
            this.gbThongTin.Controls.Add(this.radNu);
            this.gbThongTin.Controls.Add(this.lblKhoa);
            this.gbThongTin.Controls.Add(this.cboKhoa);
            this.gbThongTin.Controls.Add(this.lblDiemTB);
            this.gbThongTin.Controls.Add(this.txtDiemTB);
            this.gbThongTin.Controls.Add(this.lblEmail);
            this.gbThongTin.Controls.Add(this.txtEmail);
            this.gbThongTin.Location = new System.Drawing.Point(12, 12);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(380, 280);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin sinh viên";

            // lblMaSV
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(15, 30);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(77, 15);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã sinh viên:";

            // txtMaSV
            this.txtMaSV.Location = new System.Drawing.Point(110, 27);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(245, 23);
            this.txtMaSV.TabIndex = 1;

            // lblHoTen
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 65);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(61, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ và tên:";

            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(110, 62);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(245, 23);
            this.txtHoTen.TabIndex = 3;

            // lblNgaySinh
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 100);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(63, 15);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";

            // dtpNgaySinh
            this.dtpNgaySinh.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(110, 97);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(245, 23);
            this.dtpNgaySinh.TabIndex = 5;

            // lblGioiTinh
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 135);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(55, 15);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính:";

            // radNam
            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(110, 133);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(51, 19);
            this.radNam.TabIndex = 7;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;

            // radNu
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(180, 133);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(41, 19);
            this.radNu.TabIndex = 8;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;

            // lblKhoa
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(15, 170);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(37, 15);
            this.lblKhoa.TabIndex = 9;
            this.lblKhoa.Text = "Khoa:";

            // cboKhoa
            this.cboKhoa.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(110, 167);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(245, 23);
            this.cboKhoa.TabIndex = 10;

            // lblDiemTB
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Location = new System.Drawing.Point(15, 205);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(54, 15);
            this.lblDiemTB.TabIndex = 11;
            this.lblDiemTB.Text = "Điểm TB:";

            // txtDiemTB
            this.txtDiemTB.Location = new System.Drawing.Point(110, 202);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(245, 23);
            this.txtDiemTB.TabIndex = 12;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(110, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 23);
            this.txtEmail.TabIndex = 14;

            // gbChucNang
            this.gbChucNang.Controls.Add(this.btnTimKiem);
            this.gbChucNang.Controls.Add(this.btnThem);
            this.gbChucNang.Controls.Add(this.btnCapNhatDiem);
            this.gbChucNang.Controls.Add(this.btnXoa);
            this.gbChucNang.Controls.Add(this.btnLocTheoKhoa);
            this.gbChucNang.Controls.Add(this.btnDiemMax);
            this.gbChucNang.Controls.Add(this.btnThemSpOutput);
            this.gbChucNang.Location = new System.Drawing.Point(12, 298);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(380, 195);
            this.gbChucNang.TabIndex = 1;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Thao tác thực thi";

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(15, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 30);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm theo mã";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(135, 25);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 30);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // btnCapNhatDiem
            this.btnCapNhatDiem.Location = new System.Drawing.Point(255, 25);
            this.btnCapNhatDiem.Name = "btnCapNhatDiem";
            this.btnCapNhatDiem.Size = new System.Drawing.Size(110, 30);
            this.btnCapNhatDiem.TabIndex = 2;
            this.btnCapNhatDiem.Text = "Cập nhật điểm";
            this.btnCapNhatDiem.UseVisualStyleBackColor = true;
            this.btnCapNhatDiem.Click +=
                new System.EventHandler(this.btnCapNhatDiem_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(15, 65);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa sinh viên";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            // btnLocTheoKhoa
            this.btnLocTheoKhoa.Location = new System.Drawing.Point(135, 65);
            this.btnLocTheoKhoa.Name = "btnLocTheoKhoa";
            this.btnLocTheoKhoa.Size = new System.Drawing.Size(110, 30);
            this.btnLocTheoKhoa.TabIndex = 4;
            this.btnLocTheoKhoa.Text = "Lọc theo khoa";
            this.btnLocTheoKhoa.UseVisualStyleBackColor = true;
            this.btnLocTheoKhoa.Click +=
                new System.EventHandler(this.btnLocTheoKhoa_Click);

            // btnDiemMax
            this.btnDiemMax.Location = new System.Drawing.Point(255, 65);
            this.btnDiemMax.Name = "btnDiemMax";
            this.btnDiemMax.Size = new System.Drawing.Size(110, 30);
            this.btnDiemMax.TabIndex = 5;
            this.btnDiemMax.Text = "Điểm cao nhất";
            this.btnDiemMax.UseVisualStyleBackColor = true;
            this.btnDiemMax.Click +=
                new System.EventHandler(this.btnDiemMax_Click);

            // btnThemSpOutput
            this.btnThemSpOutput.Location = new System.Drawing.Point(15, 110);
            this.btnThemSpOutput.Name = "btnThemSpOutput";
            this.btnThemSpOutput.Size = new System.Drawing.Size(350, 35);
            this.btnThemSpOutput.TabIndex = 6;
            this.btnThemSpOutput.Text = "Thêm SV và trả tổng số";
            this.btnThemSpOutput.UseVisualStyleBackColor = true;
            this.btnThemSpOutput.Click +=
                new System.EventHandler(this.btnThemSpOutput_Click);

            // lblDanhSach
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.lblDanhSach.Location = new System.Drawing.Point(405, 12);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(120, 15);
            this.lblDanhSach.TabIndex = 2;
            this.lblDanhSach.Text = "Danh sách sinh viên:";

            // lstSinhVien
            this.lstSinhVien.Font = new System.Drawing.Font(
                "Consolas",
                9.75F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.lstSinhVien.FormattingEnabled = true;
            this.lstSinhVien.ItemHeight = 15;
            this.lstSinhVien.Location = new System.Drawing.Point(405, 32);
            this.lstSinhVien.Name = "lstSinhVien";
            this.lstSinhVien.Size = new System.Drawing.Size(420, 394);
            this.lstSinhVien.TabIndex = 3;

            // lblTongSoSV
            this.lblTongSoSV.AutoSize = true;
            this.lblTongSoSV.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.lblTongSoSV.ForeColor = System.Drawing.Color.Blue;
            this.lblTongSoSV.Location = new System.Drawing.Point(405, 435);
            this.lblTongSoSV.Name = "lblTongSoSV";
            this.lblTongSoSV.Size = new System.Drawing.Size(128, 15);
            this.lblTongSoSV.TabIndex = 4;
            this.lblTongSoSV.Text = "Tổng số sinh viên: 0";

            // lblMaxDiem
            this.lblMaxDiem.AutoSize = true;
            this.lblMaxDiem.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.lblMaxDiem.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMaxDiem.Location = new System.Drawing.Point(405, 462);
            this.lblMaxDiem.Name = "lblMaxDiem";
            this.lblMaxDiem.Size = new System.Drawing.Size(160, 15);
            this.lblMaxDiem.TabIndex = 5;
            this.lblMaxDiem.Text = "Điểm cao nhất khoa: -";

            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 505);
            this.Controls.Add(this.lblMaxDiem);
            this.Controls.Add(this.lblTongSoSV);
            this.Controls.Add(this.lstSinhVien);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.gbChucNang);
            this.Controls.Add(this.gbThongTin);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAB 8: SQLCOMMAND, SQLPARAMETER VÀ PHƯƠNG THỨC THỰC THI";
            this.Load += new System.EventHandler(this.FrmMain_Load);

            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhatDiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLocTheoKhoa;
        private System.Windows.Forms.Button btnDiemMax;
        private System.Windows.Forms.Button btnThemSpOutput;

        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.ListBox lstSinhVien;
        private System.Windows.Forms.Label lblTongSoSV;
        private System.Windows.Forms.Label lblMaxDiem;
    }
}