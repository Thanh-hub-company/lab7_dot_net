namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmSuaSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaSV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblMaSV.Text = "Mã SV:";
            this.lblMaSV.Location = new System.Drawing.Point(30, 25);
            this.txtMaSV.Location = new System.Drawing.Point(120, 22);
            this.txtMaSV.Size = new System.Drawing.Size(200, 22);

            this.lblHoTen.Text = "Họ Tên:";
            this.lblHoTen.Location = new System.Drawing.Point(30, 65);
            this.txtHoTen.Location = new System.Drawing.Point(120, 62);
            this.txtHoTen.Size = new System.Drawing.Size(200, 22);

            this.lblNgaySinh.Text = "Ngày Sinh:";
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 105);
            this.dtpNgaySinh.Location = new System.Drawing.Point(120, 102);
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 22);

            this.lblGioiTinh.Text = "Giới Tính:";
            this.lblGioiTinh.Location = new System.Drawing.Point(30, 145);
            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cboGioiTinh.Location = new System.Drawing.Point(120, 142);
            this.cboGioiTinh.Size = new System.Drawing.Size(200, 24);

            this.lblMaKhoa.Text = "Mã Khoa:";
            this.lblMaKhoa.Location = new System.Drawing.Point(30, 185);
            this.txtMaKhoa.Location = new System.Drawing.Point(120, 182);
            this.txtMaKhoa.Size = new System.Drawing.Size(200, 22);

            this.btnLuu.Text = "Lưu Thay Đổi (Check RowVersion)";
            this.btnLuu.Location = new System.Drawing.Point(120, 225);
            this.btnLuu.Size = new System.Drawing.Size(200, 35);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.ClientSize = new System.Drawing.Size(360, 280);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtMaKhoa);
            this.Controls.Add(this.lblMaKhoa);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblMaSV);
            this.Name = "frmSuaSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 9: Kiểm Soát Xung Đột Dữ Liệu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}