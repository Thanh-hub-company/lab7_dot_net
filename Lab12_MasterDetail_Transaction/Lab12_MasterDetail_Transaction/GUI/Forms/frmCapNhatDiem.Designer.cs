namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmCapNhatDiem
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Button btnLuuDiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.btnLuuDiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.SuspendLayout();

            this.lblMaSV.Text = "Nhập MaSV:";
            this.lblMaSV.Location = new System.Drawing.Point(12, 15);
            this.txtMaSV.Location = new System.Drawing.Point(100, 12);
            this.txtMaSV.Size = new System.Drawing.Size(150, 22);

            this.btnTaiDanhSach.Text = "Tải Danh Sách";
            this.btnTaiDanhSach.Location = new System.Drawing.Point(260, 10);
            this.btnTaiDanhSach.Size = new System.Drawing.Size(120, 26);
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);

            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Location = new System.Drawing.Point(12, 50);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.Size = new System.Drawing.Size(560, 250);

            this.btnLuuDiem.Text = "Lưu Điểm Hàng Loạt (Transaction)";
            this.btnLuuDiem.Location = new System.Drawing.Point(320, 310);
            this.btnLuuDiem.Size = new System.Drawing.Size(252, 35);
            this.btnLuuDiem.Click += new System.EventHandler(this.btnLuuDiem_Click);

            this.ClientSize = new System.Drawing.Size(584, 360);
            this.Controls.Add(this.btnLuuDiem);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblMaSV);
            this.Name = "frmCapNhatDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 8: Cập Nhật Điểm Hàng Loạt";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}