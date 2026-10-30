USE QLSinhVien;
GO

CREATE OR ALTER PROCEDURE sp_SinhVien_TheoKhoa
    @MaKhoa VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaSV, HoTen, NgaySinh, DiemTB
    FROM SinhVien
    WHERE MaKhoa = @MaKhoa
    ORDER BY HoTen;
END
GO