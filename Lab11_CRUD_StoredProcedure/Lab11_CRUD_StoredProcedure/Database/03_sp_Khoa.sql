USE QLSinhVien;
GO

CREATE OR ALTER PROCEDURE sp_Khoa_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKhoa, TenKhoa FROM Khoa;
END;
GO

CREATE OR ALTER PROCEDURE sp_Khoa_Insert
    @MaKhoa VARCHAR(10),
    @TenKhoa NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = @MaKhoa)
        THROW 50001, N'Mã khoa đã tồn tại.', 1;
    INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@MaKhoa, @TenKhoa);
END;
GO

CREATE OR ALTER PROCEDURE sp_Khoa_Delete
    @MaKhoa VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    -- Ràng buộc không cho xóa Khoa đang có sinh viên hoạt động
    IF EXISTS (SELECT 1 FROM SinhVien WHERE MaKhoa = @MaKhoa AND IsActive = 1)
        THROW 50004, N'Không thể xóa khoa đang có sinh viên theo học.', 1;

    DELETE FROM Khoa WHERE MaKhoa = @MaKhoa;
    IF @@ROWCOUNT = 0 THROW 50002, N'Không tìm thấy khoa.', 1;
END;
GO