-- ============================================================
-- Tạo database QLSinhVien
-- ============================================================
USE master;
GO

IF DB_ID('QLSinhVien') IS NOT NULL
    DROP DATABASE QLSinhVien;
GO

CREATE DATABASE QLSinhVien;
GO

USE QLSinhVien;
GO

-- ============================================================
-- Bảng LopHoc
-- ============================================================
CREATE TABLE LopHoc (
    MaID    INT IDENTITY(1,1) PRIMARY KEY,
    MaLop   NVARCHAR(20) NOT NULL UNIQUE,
    TenLop  NVARCHAR(100) NOT NULL,
    GhiChu  NVARCHAR(200) NULL
);
GO

-- ============================================================
-- Bảng SinhVien
-- ============================================================
CREATE TABLE SinhVien (
    MaSV      NVARCHAR(20) PRIMARY KEY,
    HoTen     NVARCHAR(100) NOT NULL,
    GioiTinh  NVARCHAR(10)  NOT NULL,
    NgaySinh  DATE          NOT NULL,
    MaLop     NVARCHAR(20)  NOT NULL,
    CONSTRAINT FK_SinhVien_LopHoc FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
);
GO

-- ============================================================
-- Dữ liệu mẫu
-- ============================================================
INSERT INTO LopHoc (MaLop, TenLop, GhiChu) VALUES
    (N'68PM1', N'Lớp 68PM1', N'abc'),
    (N'68PM2', N'Lớp 68PM2', N'xyz');
GO

INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, MaLop) VALUES
    (N'1', N'Nguyễn Văn An',  N'Nam', '2005-01-15', N'68PM1'),
    (N'2', N'Trần Thị Bích',  N'Nữ',  '2005-03-22', N'68PM1'),
    (N'3', N'Lê Hoàng Nam',   N'Nam', '2005-07-10', N'68PM2'),
    (N'4', N'Phạm Thị Lan',   N'Nữ',  '2005-09-05', N'68PM2'),
    (N'5', N'Võ Minh Tuấn',   N'Nam', '2005-11-30', N'68PM1');
GO
