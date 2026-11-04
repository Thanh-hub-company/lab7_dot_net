CREATE DATABASE QLSinhVien;
GO

USE QLSinhVien;
GO

-- 1. Tạo bảng Khoa
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- 2. Tạo bảng SinhVien
CREATE TABLE SinhVien (
    MaSV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DiemTB FLOAT CHECK (DiemTB >= 0 AND DiemTB <= 10),
    MaKhoa NVARCHAR(10) FOREIGN KEY REFERENCES Khoa(MaKhoa) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 3. Chèn dữ liệu mẫu
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES 
('CNTT', N'Công nghệ Thông tin'),
('DTVT', N'Điện tử Viễn thông'),
('QTKD', N'Quản trị Kinh doanh');

INSERT INTO SinhVien (MaSV, HoTen, DiemTB, MaKhoa) VALUES 
('SV001', N'Nguyễn Văn An', 8.5, 'CNTT'),
('SV002', N'Trần Thị Bình', 6.8, 'CNTT'),
('SV003', N'Lê Hoàng Cường', 4.5, 'DTVT'),
('SV004', N'Phạm Minh Đức', 9.0, 'QTKD');
GO