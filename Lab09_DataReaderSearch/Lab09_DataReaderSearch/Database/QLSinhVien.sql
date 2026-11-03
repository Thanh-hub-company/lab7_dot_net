CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

CREATE TABLE Khoa (
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

CREATE TABLE SinhVien (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL, -- 1: Nam, 0: N?
    MaKhoa VARCHAR(10) FOREIGN KEY REFERENCES Khoa(MaKhoa),
    DiemTB DECIMAL(4, 2) NOT NULL,
    Email VARCHAR(100)
);

-- D? li?u m?u
INSERT INTO Khoa VALUES 
('CNTT', N'Công ngh? thông tin'),
('QTKD', N'Qu?n tr? kinh doanh'),
('NNA', N'Ngôn ng? Anh');

INSERT INTO SinhVien VALUES
('SV001', N'Nguy?n V?n An', '2003-05-15', 1, 'CNTT', 8.5, 'an.nv@gmail.com'),
('SV002', N'Tr?n Th? Bích', '2004-02-20', 0, 'CNTT', 4.5, 'bich.tt@gmail.com'),
('SV003', N'Lê Hoàng C??ng', '2002-11-10', 1, 'QTKD', 9.0, 'cuong.lh@gmail.com'),
('SV004', N'Ph?m Thu Dung', '2003-08-25', 0, 'NNA', 3.8, 'dung.pt@gmail.com'),
('SV005', N'Hoàng Minh ??c', '2001-12-05', 1, 'CNTT', 7.2, 'duc.hm@gmail.com'),
('SV006', N'?? H?i Y?n', '2004-04-12', 0, 'QTKD', 8.0, 'yen.dh@gmail.com'),
('SV007', N'V? Anh Tu?n', '2003-09-30', 1, 'NNA', 4.8, 'tuan.va@gmail.com'),
('SV008', N'Ngô B?o Ng?c', '2002-07-18', 0, 'CNTT', 8.8, 'ngoc.nb@gmail.com'),
('SV009', N'Bùi Quang Huy', '2003-01-01', 1, 'QTKD', 6.5, 'huy.bq@gmail.com'),
('SV010', N'??ng Thanh Th?o', '2004-06-14', 0, 'NNA', 9.5, 'thao.dt@gmail.com'),
('SV011', N'Nguy?n Qu?c Hùng', '2002-03-22', 1, 'CNTT', 2.5, 'hung.nq@gmail.com'),
('SV012', N'Tr?n Ph??ng Th?o', '2003-10-10', 0, 'QTKD', 7.8, 'thao.tp@gmail.com');