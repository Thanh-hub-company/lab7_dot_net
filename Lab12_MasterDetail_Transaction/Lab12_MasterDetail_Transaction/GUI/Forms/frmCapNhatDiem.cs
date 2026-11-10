using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI.Forms
{
    public partial class frmCapNhatDiem : Form
    {
        private readonly DangKyBUS _dkBus = new DangKyBUS();

        public frmCapNhatDiem()
        {
            InitializeComponent();
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (!string.IsNullOrEmpty(maSV))
            {
                dgvDiem.DataSource = _dkBus.GetEnrollmentsByStudent(maSV);
            }
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            List<DangKyDTO> dsCapNhat = new List<DangKyDTO>();

            foreach (DataGridViewRow row in dgvDiem.Rows)
            {
                if (row.IsNewRow) continue;

                decimal? diemVal = null;
                var rawDiem = row.Cells["Diem"].Value;

                if (rawDiem != null && !string.IsNullOrWhiteSpace(rawDiem.ToString()))
                {
                    if (decimal.TryParse(rawDiem.ToString(), out decimal parsedDiem))
                    {
                        diemVal = parsedDiem;
                    }
                    else
                    {
                        MessageBox.Show("Điểm nhập vào phải là định dạng số!", "Lỗi định dạng");
                        return;
                    }
                }

                dsCapNhat.Add(new DangKyDTO
                {
                    MaSV = Convert.ToString(row.Cells["MaSV"].Value),
                    MaHP = Convert.ToString(row.Cells["MaHP"].Value),
                    HocKy = Convert.ToInt32(row.Cells["HocKy"].Value),
                    Diem = diemVal
                });
            }

            try
            {
                // Kiểm tra ràng buộc điểm [0, 10] & thực thi Transaction
                _dkBus.CapNhatDiemHangLoat(dsCapNhat);
                MessageBox.Show("Cập nhật toàn bộ điểm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật điểm thất bại!\nNội dung: " + ex.Message + "\n-> Toàn bộ thay đổi đã được Rollback.",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}