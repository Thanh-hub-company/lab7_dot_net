namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmXoaKhoa
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblKhoaXoa;
        private System.Windows.Forms.Label lblKhoaChuyen;
        private System.Windows.Forms.ComboBox cboKhoaXoa;
        private System.Windows.Forms.ComboBox cboKhoaChuyenToi;
        private System.Windows.Forms.Button btnXoaKhoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblKhoaXoa = new System.Windows.Forms.Label();
            this.lblKhoaChuyen = new System.Windows.Forms.Label();
            this.cboKhoaXoa = new System.Windows.Forms.ComboBox();
            this.cboKhoaChuyenToi = new System.Windows.Forms.ComboBox();
            this.btnXoaKhoa = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblKhoaXoa.Text = "Khoa Cần Xóa:";
            this.lblKhoaXoa.Location = new System.Drawing.Point(30, 30);
            this.cboKhoaXoa.Location = new System.Drawing.Point(170, 30);
            this.cboKhoaXoa.Size = new System.Drawing.Size(200, 24);

            this.lblKhoaChuyen.Text = "Khoa Nhận Sinh Viên:";
            this.lblKhoaChuyen.Location = new System.Drawing.Point(30, 75);
            this.cboKhoaChuyenToi.Location = new System.Drawing.Point(170, 75);
            this.cboKhoaChuyenToi.Size = new System.Drawing.Size(200, 24);

            this.btnXoaKhoa.Text = "Xóa Khoa An Toàn";
            this.btnXoaKhoa.Location = new System.Drawing.Point(170, 120);
            this.btnXoaKhoa.Size = new System.Drawing.Size(200, 35);
            this.btnXoaKhoa.Click += new System.EventHandler(this.btnXoaKhoa_Click);

            this.ClientSize = new System.Drawing.Size(410, 180);
            this.Controls.Add(this.btnXoaKhoa);
            this.Controls.Add(this.cboKhoaChuyenToi);
            this.Controls.Add(this.lblKhoaChuyen);
            this.Controls.Add(this.cboKhoaXoa);
            this.Controls.Add(this.lblKhoaXoa);
            this.Name = "frmXoaKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 7: Xóa Khoa An Toàn";
            this.Load += new System.EventHandler(this.frmXoaKhoa_Load);
            this.ResumeLayout(false);
        }
    }
}