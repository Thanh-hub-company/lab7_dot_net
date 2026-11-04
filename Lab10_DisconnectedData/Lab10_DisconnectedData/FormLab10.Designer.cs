namespace Lab10_DisconnectedData
{
    public partial class FormLab10
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
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.btnBai1 = new System.Windows.Forms.Button();
            this.btnBai2 = new System.Windows.Forms.Button();
            this.btnBai3 = new System.Windows.Forms.Button();
            this.btnBai4 = new System.Windows.Forms.Button();
            this.btnLoadBai5 = new System.Windows.Forms.Button();
            this.btnSaveBai5 = new System.Windows.Forms.Button();
            this.btnBai6 = new System.Windows.Forms.Button();
            this.btnBai7 = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnExportXml = new System.Windows.Forms.Button();
            this.btnImportXml = new System.Windows.Forms.Button();
            this.btnBai10 = new System.Windows.Forms.Button();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.numMinDiem = new System.Windows.Forms.NumericUpDown();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblGridKhoa = new System.Windows.Forms.Label();
            this.lblGridSV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDiem)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvKhoa
            // 
            this.dgvKhoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Location = new System.Drawing.Point(12, 30);
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.Size = new System.Drawing.Size(320, 180);
            this.dgvKhoa.TabIndex = 0;

            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(345, 30);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.Size = new System.Drawing.Size(585, 180);
            this.dgvSinhVien.TabIndex = 1;

            // 
            // lblGridKhoa
            // 
            this.lblGridKhoa.AutoSize = true;
            this.lblGridKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridKhoa.Location = new System.Drawing.Point(12, 10);
            this.lblGridKhoa.Name = "lblGridKhoa";
            this.lblGridKhoa.Size = new System.Drawing.Size(73, 13);
            this.lblGridKhoa.Text = "Bảng Khoa:";

            // 
            // lblGridSV
            // 
            this.lblGridSV.AutoSize = true;
            this.lblGridSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSV.Location = new System.Drawing.Point(342, 10);
            this.lblGridSV.Name = "lblGridSV";
            this.lblGridSV.Size = new System.Drawing.Size(98, 13);
            this.lblGridSV.Text = "Bảng Sinh Viên:";

            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(12, 230);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(63, 13);
            this.lblKhoa.Text = "Chọn Khoa:";

            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(85, 226);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(220, 21);
            this.cboKhoa.TabIndex = 2;

            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(335, 230);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(75, 13);
            this.lblDiem.Text = "Điểm tối thiểu:";

            // 
            // numMinDiem
            // 
            this.numMinDiem.DecimalPlaces = 1;
            this.numMinDiem.Location = new System.Drawing.Point(415, 226);
            this.numMinDiem.Name = "numMinDiem";
            this.numMinDiem.Size = new System.Drawing.Size(70, 20);
            this.numMinDiem.TabIndex = 3;
            this.numMinDiem.Value = new decimal(new int[] { 50, 0, 0, 65536 });

            // 
            // HÀNG NÚT BẤM 1 (Top Y = 270)
            // 
            this.btnBai1.Location = new System.Drawing.Point(12, 270);
            this.btnBai1.Name = "btnBai1";
            this.btnBai1.Size = new System.Drawing.Size(170, 32);
            this.btnBai1.TabIndex = 4;
            this.btnBai1.Text = "1. Fill DataTable";
            this.btnBai1.UseVisualStyleBackColor = true;
            this.btnBai1.Click += new System.EventHandler(this.btnBai1_Click);

            this.btnBai2.Location = new System.Drawing.Point(197, 270);
            this.btnBai2.Name = "btnBai2";
            this.btnBai2.Size = new System.Drawing.Size(170, 32);
            this.btnBai2.TabIndex = 5;
            this.btnBai2.Text = "2. Nạp DataSet";
            this.btnBai2.UseVisualStyleBackColor = true;
            this.btnBai2.Click += new System.EventHandler(this.btnBai2_Click);

            this.btnBai3.Location = new System.Drawing.Point(382, 270);
            this.btnBai3.Name = "btnBai3";
            this.btnBai3.Size = new System.Drawing.Size(170, 32);
            this.btnBai3.TabIndex = 6;
            this.btnBai3.Text = "3. DataRelation";
            this.btnBai3.UseVisualStyleBackColor = true;
            this.btnBai3.Click += new System.EventHandler(this.btnBai3_Click);

            this.btnBai4.Location = new System.Drawing.Point(567, 270);
            this.btnBai4.Name = "btnBai4";
            this.btnBai4.Size = new System.Drawing.Size(170, 32);
            this.btnBai4.TabIndex = 7;
            this.btnBai4.Text = "4. Lọc DataView";
            this.btnBai4.UseVisualStyleBackColor = true;
            this.btnBai4.Click += new System.EventHandler(this.btnBai4_Click);

            this.btnLoadBai5.Location = new System.Drawing.Point(752, 270);
            this.btnLoadBai5.Name = "btnLoadBai5";
            this.btnLoadBai5.Size = new System.Drawing.Size(170, 32);
            this.btnLoadBai5.TabIndex = 8;
            this.btnLoadBai5.Text = "5. Load Sửa DB";
            this.btnLoadBai5.UseVisualStyleBackColor = true;
            this.btnLoadBai5.Click += new System.EventHandler(this.btnLoadBai5_Click);

            // 
            // HÀNG NÚT BẤM 2 (Top Y = 315)
            // 
            this.btnSaveBai5.Location = new System.Drawing.Point(12, 315);
            this.btnSaveBai5.Name = "btnSaveBai5";
            this.btnSaveBai5.Size = new System.Drawing.Size(170, 32);
            this.btnSaveBai5.TabIndex = 9;
            this.btnSaveBai5.Text = "5. Lưu về SQL";
            this.btnSaveBai5.UseVisualStyleBackColor = true;
            this.btnSaveBai5.Click += new System.EventHandler(this.btnSaveBai5_Click);

            this.btnBai6.Location = new System.Drawing.Point(197, 315);
            this.btnBai6.Name = "btnBai6";
            this.btnBai6.Size = new System.Drawing.Size(170, 32);
            this.btnBai6.TabIndex = 10;
            this.btnBai6.Text = "6. Bảng Thủ Công";
            this.btnBai6.UseVisualStyleBackColor = true;
            this.btnBai6.Click += new System.EventHandler(this.btnBai6_Click);

            this.btnBai7.Location = new System.Drawing.Point(382, 315);
            this.btnBai7.Name = "btnBai7";
            this.btnBai7.Size = new System.Drawing.Size(170, 32);
            this.btnBai7.TabIndex = 11;
            this.btnBai7.Text = "7. Xem RowState";
            this.btnBai7.UseVisualStyleBackColor = true;
            this.btnBai7.Click += new System.EventHandler(this.btnBai7_Click);

            this.btnAccept.Location = new System.Drawing.Point(567, 315);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(170, 32);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "8. AcceptChanges";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);

            this.btnReject.Location = new System.Drawing.Point(752, 315);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(170, 32);
            this.btnReject.TabIndex = 13;
            this.btnReject.Text = "8. RejectChanges";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // 
            // HÀNG NÚT BẤM 3 (Top Y = 360)
            // 
            this.btnExportXml.Location = new System.Drawing.Point(12, 360);
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Size = new System.Drawing.Size(170, 32);
            this.btnExportXml.TabIndex = 14;
            this.btnExportXml.Text = "9. Xuất XML";
            this.btnExportXml.UseVisualStyleBackColor = true;
            this.btnExportXml.Click += new System.EventHandler(this.btnExportXml_Click);

            this.btnImportXml.Location = new System.Drawing.Point(197, 360);
            this.btnImportXml.Name = "btnImportXml";
            this.btnImportXml.Size = new System.Drawing.Size(170, 32);
            this.btnImportXml.TabIndex = 15;
            this.btnImportXml.Text = "9. Đọc XML";
            this.btnImportXml.UseVisualStyleBackColor = true;
            this.btnImportXml.Click += new System.EventHandler(this.btnImportXml_Click);

            this.btnBai10.Location = new System.Drawing.Point(382, 360);
            this.btnBai10.Name = "btnBai10";
            this.btnBai10.Size = new System.Drawing.Size(170, 32);
            this.btnBai10.TabIndex = 16;
            this.btnBai10.Text = "10. Merge Bảng";
            this.btnBai10.UseVisualStyleBackColor = true;
            this.btnBai10.Click += new System.EventHandler(this.btnBai10_Click);

            // 
            // FormLab10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 411);
            this.Controls.Add(this.lblGridKhoa);
            this.Controls.Add(this.lblGridSV);
            this.Controls.Add(this.dgvKhoa);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.numMinDiem);
            this.Controls.Add(this.btnBai1);
            this.Controls.Add(this.btnBai2);
            this.Controls.Add(this.btnBai3);
            this.Controls.Add(this.btnBai4);
            this.Controls.Add(this.btnLoadBai5);
            this.Controls.Add(this.btnSaveBai5);
            this.Controls.Add(this.btnBai6);
            this.Controls.Add(this.btnBai7);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnExportXml);
            this.Controls.Add(this.btnImportXml);
            this.Controls.Add(this.btnBai10);
            this.Name = "FormLab10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 10 - Disconnected Data ADO.NET";
            this.Load += new System.EventHandler(this.FormLab10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Button btnBai1;
        private System.Windows.Forms.Button btnBai2;
        private System.Windows.Forms.Button btnBai3;
        private System.Windows.Forms.Button btnBai4;
        private System.Windows.Forms.Button btnLoadBai5;
        private System.Windows.Forms.Button btnSaveBai5;
        private System.Windows.Forms.Button btnBai6;
        private System.Windows.Forms.Button btnBai7;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnExportXml;
        private System.Windows.Forms.Button btnImportXml;
        private System.Windows.Forms.Button btnBai10;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.NumericUpDown numMinDiem;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblGridKhoa;
        private System.Windows.Forms.Label lblGridSV;
    }
}