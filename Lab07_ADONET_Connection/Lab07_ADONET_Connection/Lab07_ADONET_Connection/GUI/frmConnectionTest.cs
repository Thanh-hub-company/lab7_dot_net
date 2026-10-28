using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DTO;
using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmConnectionTest : Form
    {
        private readonly ConnectionBUS _connectionBUS = new ConnectionBUS();

        public frmConnectionTest()
        {
            InitializeComponent();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfoDTO info = _connectionBUS.CheckConnection();

                txtDataSource.Text = info.DataSource;
                txtDatabase.Text = info.Database;
                txtServerVersion.Text = info.ServerVersion;
                txtState.Text = info.State;
                txtResponseTime.Text = $"{info.ResponseTimeMs} ms";

                lblStatusMsg.Text = "Kết nối CSDL thành công!";
                lblStatusMsg.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Kết nối CSDL SQL Server thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                lblStatusMsg.Text = "Kết nối thất bại!";
                lblStatusMsg.ForeColor = System.Drawing.Color.Red;

                MessageBox.Show($"Lỗi kết nối CSDL SQL Server:\n{ex.Message}\nMã lỗi: {ex.Number}",
                                "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "Lỗi hệ thống!";
                lblStatusMsg.ForeColor = System.Drawing.Color.Red;

                MessageBox.Show($"Lỗi hệ thống:\n{ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}