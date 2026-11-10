namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmSinhVienDangKy
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Button btnThemHopLe;
        private System.Windows.Forms.Button btnMoPhongRollback;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.btnThemHopLe = new System.Windows.Forms.Button();
            this.btnMoPhongRollback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();

            // dgvSinhVien
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(12, 12);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.Size = new System.Drawing.Size(760, 180);
            this.dgvSinhVien.SelectionChanged += new System.EventHandler(this.dgvSinhVien_SelectionChanged);

            // dgvDangKy
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Location = new System.Drawing.Point(12, 210);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.Size = new System.Drawing.Size(760, 200);

            // btnThemHopLe
            this.btnThemHopLe.Location = new System.Drawing.Point(12, 425);
            this.btnThemHopLe.Name = "btnThemHopLe";
            this.btnThemHopLe.Size = new System.Drawing.Size(250, 35);
            this.btnThemHopLe.Text = "Thêm SV + Học Phần (Hợp lệ)";
            this.btnThemHopLe.Click += new System.EventHandler(this.btnThemHopLe_Click);

            // btnMoPhongRollback
            this.btnMoPhongRollback.Location = new System.Drawing.Point(280, 425);
            this.btnMoPhongRollback.Name = "btnMoPhongRollback";
            this.btnMoPhongRollback.Size = new System.Drawing.Size(280, 35);
            this.btnMoPhongRollback.Text = "Thử Nghiệm Lỗi để kiểm tra Rollback";
            this.btnMoPhongRollback.Click += new System.EventHandler(this.btnMoPhongRollback_Click);

            // frmSinhVienDangKy
            this.ClientSize = new System.Drawing.Size(784, 475);
            this.Controls.Add(this.btnMoPhongRollback);
            this.Controls.Add(this.btnThemHopLe);
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.dgvSinhVien);
            this.Name = "frmSinhVienDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 2, 3, 4: SinhVien - DangKy & SqlTransaction Test";
            this.Load += new System.EventHandler(this.frmSinhVienDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);
        }
    }
}