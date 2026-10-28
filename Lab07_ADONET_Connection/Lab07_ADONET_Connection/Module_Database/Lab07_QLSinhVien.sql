USE master;
GO

-- 1. T?o C? s? d? li?u QLSinhVien
IF DB_ID(N'QLSinhVien') IS NULL
    CREATE DATABASE QLSinhVien;
GO

USE QLSinhVien;
GO

-- 2. Xóa b?ng c? n?u ?ã t?n t?i (theo th? t? khóa ngo?i)
IF OBJECT_ID('DangKy', 'U') IS NOT NULL DROP TABLE DangKy;
IF OBJECT_ID('SinhVien', 'U') IS NOT NULL DROP TABLE SinhVien;
IF OBJECT_ID('HocPhan', 'U') IS NOT NULL DROP TABLE HocPhan;
IF OBJECT_ID('Khoa', 'U') IS NOT NULL DROP TABLE Khoa;
GO

-- 3. T?o các b?ng d? li?u
CREATE TABLE Khoa
(
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE SinhVien
(
    MaSV VARCHAR(15) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL, -- 1: Nam, 0: N?
    MaKhoa VARCHAR(10) NOT NULL,
    DiemTB DECIMAL(4,2) NOT NULL DEFAULT 0,
    Email VARCHAR(100) NULL,
    CONSTRAINT CK_SinhVien_Diem CHECK (DiemTB BETWEEN 0 AND 10),
    CONSTRAINT UQ_SinhVien_Email UNIQUE (Email),
    CONSTRAINT FK_SinhVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

CREATE TABLE HocPhan
(
    MaHP VARCHAR(10) PRIMARY KEY,
    TenHP NVARCHAR(120) NOT NULL,
    SoTinChi INT NOT NULL CHECK (SoTinChi BETWEEN 1 AND 6)
);

CREATE TABLE DangKy
(
    MaSV VARCHAR(15) NOT NULL,
    MaHP VARCHAR(10) NOT NULL,
    HocKy INT NOT NULL DEFAULT 1 CHECK (HocKy BETWEEN 1 AND 3),
    NgayDangKy DATETIME NOT NULL DEFAULT GETDATE(),
    Diem DECIMAL(4,2) NULL CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSV, MaHP),
    CONSTRAINT FK_DangKy_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) ON DELETE CASCADE,
    CONSTRAINT FK_DangKy_HocPhan FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP) ON DELETE CASCADE
);
GO

-- 4. Thêm d? li?u m?u
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('CNTT', N'Công ngh? thông tin'),
('OTO', N'Công ngh? k? thu?t ô tô'),
('KT', N'Kinh t?');

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email) VALUES
('SV001', N'Nguy?n V?n An', '2005-02-15', 1, 'CNTT', 8.20, 'an.nv@eaut.edu.vn'),
('SV002', N'Tr?n Th? Bình', '2005-07-21', 0, 'CNTT', 7.40, 'binh.tt@eaut.edu.vn'),
('SV003', N'Lê V?n C??ng', '2004-12-03', 1, 'OTO',  6.80, 'cuong.lv@eaut.edu.vn'),
('SV004', N'Ph?m Minh ??c', '2005-05-10', 1, 'CNTT', 9.10, 'duc.pm@eaut.edu.vn'),
('SV005', N'Hoàng Th? Giang', '2005-09-18', 0, 'KT',   8.50, 'giang.ht@eaut.edu.vn'),
('SV006', N'V? Hoàng H?i', '2004-03-25', 1, 'OTO',  5.90, 'hai.vh@eaut.edu.vn'),
('SV007', N'?? Khánh Linh', '2005-11-30', 0, 'KT',   7.80, 'linh.dk@eaut.edu.vn'),
('SV008', N'Bùi Nam Phong', '2005-01-12', 1, 'CNTT', 6.20, 'phong.bn@eaut.edu.vn'),
('SV009', N'??ng Ph??ng Th?o', '2004-08-08', 0, 'KT', 8.90, 'thao.dp@eaut.edu.vn'),
('SV010', N'Ngô Qu?c Tu?n', '2005-04-19', 1, 'OTO',  7.10, 'tuan.nq@eaut.edu.vn');

INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES
('HP01', N'L?p trình .NET', 3),
('HP02', N'C? s? d? li?u SQL Server', 3),
('HP03', N'L?p trình Web ASP.NET Core', 4),
('HP04', N'Kinh t? v? mô', 2),
('HP05', N'??ng c? ??t trong', 3);

INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem) VALUES
('SV001', 'HP01', 1, 8.5),
('SV001', 'HP02', 1, 8.0),
('SV002', 'HP01', 1, 7.5),
('SV002', 'HP03', 2, 7.0),
('SV003', 'HP05', 1, 6.8),
('SV004', 'HP01', 1, 9.5),
('SV004', 'HP02', 1, 9.0),
('SV005', 'HP04', 1, 8.5),
('SV006', 'HP05', 2, 6.0),
('SV007', 'HP04', 1, 8.0);
GO