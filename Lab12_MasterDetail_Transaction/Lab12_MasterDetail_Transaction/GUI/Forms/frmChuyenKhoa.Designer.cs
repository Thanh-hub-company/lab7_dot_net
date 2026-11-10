namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmChuyenKhoa
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblKhoaCu;
        private System.Windows.Forms.Label lblKhoaMoi;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtMaKhoaCu;
        private System.Windows.Forms.ComboBox cboKhoaMoi;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnChuyenKhoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaSV = new System.Windows.Forms.Label();
            this.lblKhoaCu = new System.Windows.Forms.Label();
            this.lblKhoaMoi = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtMaKhoaCu = new System.Windows.Forms.TextBox();
            this.cboKhoaMoi = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnChuyenKhoa = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblMaSV.Text = "Mã Sinh Viên:";
            this.lblMaSV.Location = new System.Drawing.Point(30, 30);
            this.txtMaSV.Location = new System.Drawing.Point(150, 30);
            this.txtMaSV.Size = new System.Drawing.Size(200, 22);

            this.lblKhoaCu.Text = "Mã Khoa Cũ:";
            this.lblKhoaCu.Location = new System.Drawing.Point(30, 70);
            this.txtMaKhoaCu.Location = new System.Drawing.Point(150, 70);
            this.txtMaKhoaCu.Size = new System.Drawing.Size(200, 22);

            this.lblKhoaMoi.Text = "Khoa Mới:";
            this.lblKhoaMoi.Location = new System.Drawing.Point(30, 110);
            this.cboKhoaMoi.Location = new System.Drawing.Point(150, 110);
            this.cboKhoaMoi.Size = new System.Drawing.Size(200, 24);

            this.lblGhiChu.Text = "Ghi Chú:";
            this.lblGhiChu.Location = new System.Drawing.Point(30, 150);
            this.txtGhiChu.Location = new System.Drawing.Point(150, 150);
            this.txtGhiChu.Size = new System.Drawing.Size(200, 22);

            this.btnChuyenKhoa.Text = "Thực Hiện Chuyển Khoa";
            this.btnChuyenKhoa.Location = new System.Drawing.Point(150, 195);
            this.btnChuyenKhoa.Size = new System.Drawing.Size(200, 35);
            this.btnChuyenKhoa.Click += new System.EventHandler(this.btnChuyenKhoa_Click);

            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnChuyenKhoa);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.cboKhoaMoi);
            this.Controls.Add(this.lblKhoaMoi);
            this.Controls.Add(this.txtMaKhoaCu);
            this.Controls.Add(this.lblKhoaCu);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblMaSV);
            this.Name = "frmChuyenKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6: Chuyển Khoa Sinh Viên";
            this.Load += new System.EventHandler(this.frmChuyenKhoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}