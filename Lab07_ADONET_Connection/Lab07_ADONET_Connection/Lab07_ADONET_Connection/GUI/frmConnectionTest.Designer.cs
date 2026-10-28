namespace Lab07_ADONET_Connection.GUI
{
    partial class frmConnectionTest
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
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtResponseTime = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtServerVersion = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lblResponseTime = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKiemTra.Location = new System.Drawing.Point(145, 20);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(180, 40);
            this.btnKiemTra.TabIndex = 0;
            this.btnKiemTra.Text = "Kiểm Tra Kết Nối";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtResponseTime);
            this.grpInfo.Controls.Add(this.txtState);
            this.grpInfo.Controls.Add(this.txtServerVersion);
            this.grpInfo.Controls.Add(this.txtDatabase);
            this.grpInfo.Controls.Add(this.txtDataSource);
            this.grpInfo.Controls.Add(this.lblResponseTime);
            this.grpInfo.Controls.Add(this.lblState);
            this.grpInfo.Controls.Add(this.lblVersion);
            this.grpInfo.Controls.Add(this.lblDatabase);
            this.grpInfo.Controls.Add(this.lblDataSource);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpInfo.Location = new System.Drawing.Point(20, 80);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(430, 220);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông Tin Trạng Thái Kết Nối SQL Server";
            // 
            // txtResponseTime
            // 
            this.txtResponseTime.ReadOnly = true;
            this.txtResponseTime.Location = new System.Drawing.Point(150, 175);
            this.txtResponseTime.Name = "txtResponseTime";
            this.txtResponseTime.Size = new System.Drawing.Size(250, 23);
            this.txtResponseTime.TabIndex = 9;
            // 
            // txtState
            // 
            this.txtState.ReadOnly = true;
            this.txtState.Location = new System.Drawing.Point(150, 140);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(250, 23);
            this.txtState.TabIndex = 8;
            // 
            // txtServerVersion
            // 
            this.txtServerVersion.ReadOnly = true;
            this.txtServerVersion.Location = new System.Drawing.Point(150, 105);
            this.txtServerVersion.Name = "txtServerVersion";
            this.txtServerVersion.Size = new System.Drawing.Size(250, 23);
            this.txtServerVersion.TabIndex = 7;
            // 
            // txtDatabase
            // 
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Location = new System.Drawing.Point(150, 70);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(250, 23);
            this.txtDatabase.TabIndex = 6;
            // 
            // txtDataSource
            // 
            this.txtDataSource.ReadOnly = true;
            this.txtDataSource.Location = new System.Drawing.Point(150, 35);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(250, 23);
            this.txtDataSource.TabIndex = 5;
            // 
            // lblResponseTime
            // 
            this.lblResponseTime.AutoSize = true;
            this.lblResponseTime.Location = new System.Drawing.Point(20, 178);
            this.lblResponseTime.Name = "lblResponseTime";
            this.lblResponseTime.Size = new System.Drawing.Size(107, 15);
            this.lblResponseTime.TabIndex = 4;
            this.lblResponseTime.Text = "Thời gian phản hồi:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(20, 143);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(106, 15);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "Trạng thái kết nối:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(20, 108);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(95, 15);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Phiên bản Server:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(20, 73);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(79, 15);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "Cơ sở dữ liệu:";
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(20, 38);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(117, 15);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "Máy chủ (DataSource):";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusMsg.Location = new System.Drawing.Point(20, 310);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(430, 25);
            this.lblStatusMsg.TabIndex = 2;
            this.lblStatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConnectionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 350);
            this.Controls.Add(this.lblStatusMsg);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnKiemTra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmConnectionTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAB 7: Kiểm Tra Kết Nối CSDL ADO.NET";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblResponseTime;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtServerVersion;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtResponseTime;
        private System.Windows.Forms.Label lblStatusMsg;
    }
}