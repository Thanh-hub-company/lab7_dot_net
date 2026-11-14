using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLSinhVien.Common;

namespace QLSinhVien.GUI.Helpers
{
    public static class UiExceptionHandler
    {
        public static void Handle(Exception ex, string userActionContext)
        {
            if (ex == null)
            {
                return;
            }

            BusinessException bizEx = ex as BusinessException;
            if (bizEx != null)
            {
                Logger.Warn(string.Format("Vi phạm nghiệp vụ khi [{0}]: {1}", userActionContext, bizEx.Message));
                MessageBox.Show(
                    bizEx.Message,
                    "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SqlException sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                if (!ex.Data.Contains("Logged"))
                {
                    Logger.Error(string.Format("Lỗi CSDL khi [{0}] (SQL Error #{1})", userActionContext, sqlEx.Number), sqlEx);
                    ex.Data["Logged"] = true;
                }

                MessageBox.Show(
                    MapSqlErrorToFriendlyMessage(sqlEx),
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string errorId = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            if (!ex.Data.Contains("Logged"))
            {
                Logger.Error(string.Format("Lỗi không xác định [Mã sự cố: {0}] khi [{1}]", errorId, userActionContext), ex);
                ex.Data["Logged"] = true;
            }

            MessageBox.Show(
                string.Format(
                    "Ứng dụng gặp sự cố kỹ thuật ngoài dự kiến.\r\n" +
                    "Mã sự cố đã được ghi nhận: {0}\r\n" +
                    "Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ.",
                    errorId),
                "Lỗi hệ thống",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static string MapSqlErrorToFriendlyMessage(SqlException sqlEx)
        {
            switch (sqlEx.Number)
            {
                case -1:
                case 2:
                case 53:
                case 4060:
                    return "Không thể kết nối đến máy chủ cơ sở dữ liệu. Vui lòng kiểm tra dịch vụ SQL Server và cấu hình mạng.";
                case 18456:
                    return "Tài khoản kết nối cơ sở dữ liệu không hợp lệ. Vui lòng liên hệ quản trị viên.";
                case 2627:
                case 2601:
                    return "Dữ liệu bị trùng khóa duy nhất (mã đã tồn tại trong hệ thống).";
                case 547:
                    return "Không thể thực hiện thao tác do vi phạm ràng buộc dữ liệu liên quan.";
                default:
                    return "Không thể cập nhật hoặc truy xuất dữ liệu. Vui lòng thử lại sau.";
            }
        }
    }
}