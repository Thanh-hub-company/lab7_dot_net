USE master;
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = 'app_student'
)
BEGIN
    CREATE LOGIN app_student
    WITH PASSWORD = 'Password123!',
         CHECK_POLICY = OFF;
END
ELSE
BEGIN
    ALTER LOGIN app_student
    WITH PASSWORD = 'Password123!',
         CHECK_POLICY = OFF;
END
GO

USE QLSinhVien;
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_principals
    WHERE name = 'app_student'
)
BEGIN
    CREATE USER app_student
    FOR LOGIN app_student;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members drm
    INNER JOIN sys.database_principals role_principal
        ON drm.role_principal_id = role_principal.principal_id
    INNER JOIN sys.database_principals user_principal
        ON drm.member_principal_id = user_principal.principal_id
    WHERE role_principal.name = 'db_datareader'
      AND user_principal.name = 'app_student'
)
BEGIN
    ALTER ROLE db_datareader ADD MEMBER app_student;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members drm
    INNER JOIN sys.database_principals role_principal
        ON drm.role_principal_id = role_principal.principal_id
    INNER JOIN sys.database_principals user_principal
        ON drm.member_principal_id = user_principal.principal_id
    WHERE role_principal.name = 'db_datawriter'
      AND user_principal.name = 'app_student'
)
BEGIN
    ALTER ROLE db_datawriter ADD MEMBER app_student;
END
GO