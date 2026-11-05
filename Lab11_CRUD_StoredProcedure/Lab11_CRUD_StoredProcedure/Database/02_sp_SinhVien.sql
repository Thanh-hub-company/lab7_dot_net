USE QLSinhVien;
GO

-- Thêm mới sinh viên (Kiểm tra trùng mã & trùng Email)
CREATE OR ALTER PROCEDURE sp_SinhVien_Insert
    @MaSV VARCHAR(15), 
    @HoTen NVARCHAR(100), 
    @NgaySinh DATE,
    @GioiTinh BIT, 
    @MaKhoa VARCHAR(10), 
    @DiemTB DECIMAL(4,2),
    @Email VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
        THROW 50001, N'Mã sinh viên đã tồn tại.', 1;
        
    IF @Email IS NOT NULL AND TRIM(@Email) <> '' AND EXISTS (SELECT 1 FROM SinhVien WHERE Email = @Email AND IsActive = 1)
        THROW 50003, N'Email đã được sử dụng bởi sinh viên khác.', 1;

    INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email, IsActive)
    VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email, 1);
END;
GO

-- Cập nhật sinh viên
CREATE OR ALTER PROCEDURE sp_SinhVien_Update
    @MaSV VARCHAR(15), 
    @HoTen NVARCHAR(100), 
    @NgaySinh DATE,
    @GioiTinh BIT, 
    @MaKhoa VARCHAR(10), 
    @DiemTB DECIMAL(4,2),
    @Email VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
        THROW 50002, N'Không tìm thấy sinh viên.', 1;

    IF @Email IS NOT NULL AND TRIM(@Email) <> '' AND EXISTS (SELECT 1 FROM SinhVien WHERE Email = @Email AND MaSV <> @MaSV AND IsActive = 1)
        THROW 50003, N'Email đã được sử dụng bởi sinh viên khác.', 1;

    UPDATE SinhVien 
    SET HoTen = @HoTen, 
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh, 
        MaKhoa = @MaKhoa, 
        DiemTB = @DiemTB, 
        Email = @Email
    WHERE MaSV = @MaSV;
END;
GO

-- Xóa mềm sinh viên (Cập nhật IsActive = 0)
CREATE OR ALTER PROCEDURE sp_SinhVien_Delete
    @MaSV VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SinhVien SET IsActive = 0 WHERE MaSV = @MaSV AND IsActive = 1;
    IF @@ROWCOUNT = 0 
        THROW 50002, N'Không tìm thấy sinh viên hoặc sinh viên đã bị xóa.', 1;
END;
GO

-- Tìm kiếm sinh viên theo từ khóa và mã khoa (Lọc IsActive = 1)
CREATE OR ALTER PROCEDURE sp_SinhVien_Search
    @Keyword NVARCHAR(100) = NULL,
    @MaKhoa VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
    FROM SinhVien sv
    INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
    WHERE sv.IsActive = 1
      AND (@MaKhoa IS NULL OR TRIM(@MaKhoa) = '' OR sv.MaKhoa = @MaKhoa)
      AND (@Keyword IS NULL OR TRIM(@Keyword) = '' OR sv.MaSV LIKE '%' + @Keyword + '%' OR sv.HoTen LIKE '%' + @Keyword + '%');
END;
GO