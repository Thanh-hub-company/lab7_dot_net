========================================================================
TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á - KHOA CÔNG NGHỆ THÔNG TIN
BỘ MÔN CÔNG NGHỆ PHẦN MỀM
HỌC PHẦN: LẬP TRÌNH .NET (IT3212)
BÁO CÁO KẾT QUẢ THỰC HÀNH LAB 10: DATAADAPTER, DATATABLE, DATASET
========================================================================

Họ và tên sinh viên : Lê Tuấn Thành
Mã sinh viên        : 24003852
Lớp                 : Lap Trình .NET N03 - 24003852

1. DANH SÁCH BÀI TẬP ĐÃ HOÀN THÀNH (10/10):
------------------------------------------------------------------------
[x] Bài 1: Fill DataTable bằng SqlDataAdapter và hiển thị lên DataGridView.
[x] Bài 2: Nạp DataSet chứa nhiều bảng (Khoa, SinhVien) với tên định danh rõ ràng.
[x] Bài 3: Thiết lập DataRelation FK_Khoa_SinhVien và lấy các dòng con bằng GetChildRows.
[x] Bài 4: Lọc và sắp xếp dữ liệu động bằng DataView (RowFilter và Sort).
[x] Bài 5: Cập nhật dữ liệu từ DataGridView về SQL Server bằng SqlCommandBuilder.
[x] Bài 6: Tạo DataTable thủ công và thêm cột Expression tự động tính Xếp loại.
[x] Bài 7: Theo dõi trạng thái DataRowState (Added, Modified, Deleted) bằng GetChanges().
[x] Bài 8: Xử lý AcceptChanges/RejectChanges và phân tích chi tiết ảnh hưởng tới adapter.Update().
[x] Bài 9: Ghi và đọc DataSet XML kèm Schema ngắt kết nối CSDL.
[x] Bài 10: Merge hai DataTable xử lý trùng khóa chính (PrimaryKey).

2. HƯỚNG DẪN CHẠY DỰ ÁN:
------------------------------------------------------------------------
Step 1: Khởi tạo database bằng cách chạy tệp QLSinhVien.sql trong SSMS.
Step 2: Mở Solution Lab10_DisconnectedData.sln bằng Visual Studio.
Step 3: Kiểm tra và thay đổi chuỗi kết nối trong DbConnectionFactory.cs (nếu cần).
Step 4: Nhấn F5 để Build và khởi chạy chương trình.
========================================================================