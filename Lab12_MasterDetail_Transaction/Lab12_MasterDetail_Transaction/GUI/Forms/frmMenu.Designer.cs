namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    partial class frmMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBai1;
        private System.Windows.Forms.Button btnBai2345;
        private System.Windows.Forms.Button btnBai6;
        private System.Windows.Forms.Button btnBai7;
        private System.Windows.Forms.Button btnBai8;
        private System.Windows.Forms.Button btnBai9;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBai1 = new System.Windows.Forms.Button();
            this.btnBai2345 = new System.Windows.Forms.Button();
            this.btnBai6 = new System.Windows.Forms.Button();
            this.btnBai7 = new System.Windows.Forms.Button();
            this.btnBai8 = new System.Windows.Forms.Button();
            this.btnBai9 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(40, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 28);
            this.lblTitle.Text = "MENU THỰC HÀNH LAB 12 (10 BÀI)";

            // btnBai1
            this.btnBai1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai1.Location = new System.Drawing.Point(40, 65);
            this.btnBai1.Name = "btnBai1";
            this.btnBai1.Size = new System.Drawing.Size(320, 42);
            this.btnBai1.Text = "Bài 1: Master-Detail Khoa - SinhVien";
            this.btnBai1.UseVisualStyleBackColor = true;
            this.btnBai1.Click += new System.EventHandler(this.btnBai1_Click);

            // btnBai2345
            this.btnBai2345.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai2345.Location = new System.Drawing.Point(40, 115);
            this.btnBai2345.Name = "btnBai2345";
            this.btnBai2345.Size = new System.Drawing.Size(320, 42);
            this.btnBai2345.Text = "Bài 2,3,4,5: SV - DangKy & Transaction";
            this.btnBai2345.UseVisualStyleBackColor = true;
            this.btnBai2345.Click += new System.EventHandler(this.btnBai2345_Click);

            // btnBai6
            this.btnBai6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai6.Location = new System.Drawing.Point(40, 165);
            this.btnBai6.Name = "btnBai6";
            this.btnBai6.Size = new System.Drawing.Size(320, 42);
            this.btnBai6.Text = "Bài 6: Transaction Chuyển Khoa SV";
            this.btnBai6.UseVisualStyleBackColor = true;
            this.btnBai6.Click += new System.EventHandler(this.btnBai6_Click);

            // btnBai7
            this.btnBai7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai7.Location = new System.Drawing.Point(40, 215);
            this.btnBai7.Name = "btnBai7";
            this.btnBai7.Size = new System.Drawing.Size(320, 42);
            this.btnBai7.Text = "Bài 7: Transaction Xóa Khoa An Toàn";
            this.btnBai7.UseVisualStyleBackColor = true;
            this.btnBai7.Click += new System.EventHandler(this.btnBai7_Click);

            // btnBai8
            this.btnBai8.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai8.Location = new System.Drawing.Point(40, 265);
            this.btnBai8.Name = "btnBai8";
            this.btnBai8.Size = new System.Drawing.Size(320, 42);
            this.btnBai8.Text = "Bài 8: Cập Nhật Điểm Hàng Loạt";
            this.btnBai8.UseVisualStyleBackColor = true;
            this.btnBai8.Click += new System.EventHandler(this.btnBai8_Click);

            // btnBai9
            this.btnBai9.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBai9.Location = new System.Drawing.Point(40, 315);
            this.btnBai9.Name = "btnBai9";
            this.btnBai9.Size = new System.Drawing.Size(320, 42);
            this.btnBai9.Text = "Bài 9 & 10: Xung Đột Concurrency & 3 Lớp";
            this.btnBai9.UseVisualStyleBackColor = true;
            this.btnBai9.Click += new System.EventHandler(this.btnBai9_Click);

            // frmMenu
            this.ClientSize = new System.Drawing.Size(400, 385);
            this.Controls.Add(this.btnBai9);
            this.Controls.Add(this.btnBai8);
            this.Controls.Add(this.btnBai7);
            this.Controls.Add(this.btnBai6);
            this.Controls.Add(this.btnBai2345);
            this.Controls.Add(this.btnBai1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đào Tạo - Lab 12";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}