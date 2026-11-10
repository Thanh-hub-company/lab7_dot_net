CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

-- 1. Bảng Khoa
CREATE TABLE Khoa (
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- 2. Bảng SinhVien (Có RowVersion hỗ trợ Optimistic Concurrency)
CREATE TABLE SinhVien (
    MaSV VARCHAR(15) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    NgaySinh DATETIME NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    MaKhoa VARCHAR(10) FOREIGN KEY REFERENCES Khoa(MaKhoa),
    RowVersion TIMESTAMP
);

-- 3. Bảng HocPhan
CREATE TABLE HocPhan (
    MaHP VARCHAR(10) PRIMARY KEY,
    TenHP NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL
);

-- 4. Bảng DangKy
CREATE TABLE DangKy (
    MaSV VARCHAR(15) FOREIGN KEY REFERENCES SinhVien(MaSV),
    MaHP VARCHAR(10) FOREIGN KEY REFERENCES HocPhan(MaHP),
    HocKy INT NOT NULL,
    Diem DECIMAL(4,2) NULL,
    PRIMARY KEY (MaSV, MaHP, HocKy)
);

-- 5. Bảng LichSuChuyenKhoa
CREATE TABLE LichSuChuyenKhoa (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSV VARCHAR(15) NOT NULL,
    MaKhoaCu VARCHAR(10) NOT NULL,
    MaKhoaMoi VARCHAR(10) NOT NULL,
    NgayChuyen DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(250) NULL
);

-- Dữ liệu mẫu
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES 
('CNTT', N'Công nghệ Thông tin'),
('DTVT', N'Điện tử Viễn thông'),
('QTKD', N'Quản trị Kinh doanh');

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa) VALUES
('SV001', N'Nguyễn Văn A', '2003-05-15', N'Nam', 'CNTT'),
('SV002', N'Trần Thị B', '2003-08-20', N'Nữ', 'CNTT'),
('SV003', N'Lê Văn C', '2002-11-10', N'Nam', 'DTVT');

INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES
('IT3212', N'Lập trình .NET', 3),
('IT3213', N'Cơ sở dữ liệu', 3),
('IT3214', N'Phân tích thiết kế hệ thống', 3);

INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem) VALUES
('SV001', 'IT3212', 1, 8.5),
('SV001', 'IT3213', 1, 7.0),
('SV002', 'IT3212', 1, 9.0);