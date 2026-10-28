USE master;
GO

-- 1. Tạo Login cấp SQL Server
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'app_student')
BEGIN
    CREATE LOGIN app_student WITH PASSWORD = 'Password123!', CHECK_POLICY = OFF;
END
GO

USE QLSinhVien;
GO

-- 2. Tạo User tương ứng trong CSDL
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'app_student')
BEGIN
    CREATE USER app_student FOR LOGIN app_student;
END
GO

-- 3. Cấp quyền đọc/ghi dữ liệu
ALTER ROLE db_datareader ADD MEMBER app_student;
ALTER ROLE db_datawriter ADD MEMBER app_student;
GO