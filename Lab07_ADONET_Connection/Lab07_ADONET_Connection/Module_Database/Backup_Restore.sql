USE master;
GO

-- 1. Sao lưu CSDL
BACKUP DATABASE QLSinhVien
TO DISK = 'C:\Backup\QLSinhVien.bak'
WITH FORMAT, MEDIANAME = 'QLSinhVien_Backup', NAME = 'Full Backup of QLSinhVien';
GO

-- 2. Xóa thử bản ghi để kiểm tra Restore
USE QLSinhVien;
GO
DELETE FROM SinhVien WHERE MaSV = 'SV010';
GO

-- 3. Phục hồi CSDL
USE master;
GO
ALTER DATABASE QLSinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

RESTORE DATABASE QLSinhVien
FROM DISK = 'C:\Backup\QLSinhVien.bak'
WITH REPLACE;
GO

ALTER DATABASE QLSinhVien SET MULTI_USER;
GO