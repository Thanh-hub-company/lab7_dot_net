USE master;
GO

IF DB_ID(N'QLSinhVien') IS NULL
BEGIN
    CREATE DATABASE QLSinhVien;
END
GO

USE QLSinhVien;
GO

IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
BEGIN
    CREATE TABLE Khoa
    (
        MaKhoa VARCHAR(10) NOT NULL PRIMARY KEY,
        TenKhoa NVARCHAR(100) NOT NULL
    );
END
GO

IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
BEGIN
    CREATE TABLE SinhVien
    (
        MaSV VARCHAR(15) NOT NULL PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL,
        GioiTinh BIT NOT NULL,
        MaKhoa VARCHAR(10) NOT NULL,
        DiemTB DECIMAL(4, 2) NOT NULL,
        Email VARCHAR(100) NULL,

        CONSTRAINT FK_SinhVien_Khoa
            FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa),

        CONSTRAINT CK_SinhVien_DiemTB
            CHECK (DiemTB >= 0 AND DiemTB <= 10)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'CNTT')
BEGIN
    INSERT INTO Khoa (MaKhoa, TenKhoa)
    VALUES ('CNTT', N'Công nghệ thông tin');
END

IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'QTKD')
BEGIN
    INSERT INTO Khoa (MaKhoa, TenKhoa)
    VALUES ('QTKD', N'Quản trị kinh doanh');
END

IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'NNA')
BEGIN
    INSERT INTO Khoa (MaKhoa, TenKhoa)
    VALUES ('NNA', N'Ngôn ngữ Anh');
END
GO

IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = 'SV001')
BEGIN
    INSERT INTO SinhVien
        (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
    VALUES
        ('SV001', N'Nguyễn Văn An', '2003-05-10', 1, 'CNTT', 8.50, 'an@example.com'),
        ('SV002', N'Trần Thị Bình', '2003-08-20', 0, 'CNTT', 7.80, 'binh@example.com'),
        ('SV003', N'Lê Văn Cường', '2002-12-15', 1, 'QTKD', 6.90, 'cuong@example.com');
END
GO