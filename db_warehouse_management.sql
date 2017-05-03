/*
Navicat SQL Server Data Transfer

Source Server         : MS-SQL
Source Server Version : 120000
Source Host           : ANHQUAN-PC\SQLEXPRESS:1433
Source Database       : db_warehouse_management_simple
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2017-04-21 00:10:10
*/
USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'db_warehouse_management_simple')
DROP DATABASE db_warehouse_management_simple
GO
CREATE DATABASE db_warehouse_management_simple
GO
USE db_warehouse_management_simple

-- ----------------------------
-- Table structure for hang_hoa
-- ----------------------------
GO
CREATE TABLE [dbo].[hang_hoa] (
[ma_hang_hoa] int NOT NULL IDENTITY(1,1) ,
[ten_hang_hoa] nvarchar(255) NOT NULL ,
[so_luong] int NOT NULL ,
[don_gia] float(53) NOT NULL ,
[ma_nha_cung_cap] int NOT NULL 
)

GO

-- ----------------------------
-- Table structure for hang_nhap
-- ----------------------------
GO
CREATE TABLE [dbo].[hang_nhap] (
[ma_nhap] int NOT NULL IDENTITY(1,1) ,
[ngay_nhap] date NOT NULL ,
[don_gia] float(53) NOT NULL ,
[so_luong] int NOT NULL ,
[ma_hang_hoa] int NOT NULL 
)

GO

-- ----------------------------
-- Table structure for hang_xuat
-- ----------------------------
GO
CREATE TABLE [dbo].[hang_xuat] (
[ma_xuat] int NOT NULL IDENTITY(1,1) ,
[ngay_xuat] date NOT NULL ,
[don_gia] float(53) NOT NULL ,
[so_luong] int NOT NULL ,
[ma_hang_hoa] int NOT NULL 
)

GO

-- ----------------------------
-- Table structure for nha_cung_cap
-- ----------------------------
GO
CREATE TABLE [dbo].[nha_cung_cap] (
[ma_nha_cung_cap] int NOT NULL IDENTITY(1,1) ,
[ten_nha_cung_cap] nvarchar(255) NOT NULL ,
[dia_chi] nvarchar(255) NOT NULL ,
[so_dien_thoai] nvarchar(20) NOT NULL 
)

GO

-- ----------------------------
-- Table structure for tai_khoan
-- ----------------------------
GO
CREATE TABLE [dbo].[tai_khoan] (
[tai_khoan] nvarchar(255) NOT NULL ,
[mat_khau] nvarchar(255) NOT NULL 
)


GO

-- ----------------------------
-- Records of tai_khoan
-- ----------------------------
INSERT INTO [dbo].[tai_khoan] ([tai_khoan], [mat_khau]) VALUES (N'admin', N'admin')
GO
GO

-- ----------------------------
-- Indexes structure for table hang_hoa
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table hang_hoa
-- ----------------------------
ALTER TABLE [dbo].[hang_hoa] ADD PRIMARY KEY ([ma_hang_hoa])
GO

-- ----------------------------
-- Indexes structure for table hang_nhap
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table hang_nhap
-- ----------------------------
ALTER TABLE [dbo].[hang_nhap] ADD PRIMARY KEY ([ma_nhap])
GO

-- ----------------------------
-- Indexes structure for table hang_xuat
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table hang_xuat
-- ----------------------------
ALTER TABLE [dbo].[hang_xuat] ADD PRIMARY KEY ([ma_xuat])
GO

-- ----------------------------
-- Indexes structure for table nha_cung_cap
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table nha_cung_cap
-- ----------------------------
ALTER TABLE [dbo].[nha_cung_cap] ADD PRIMARY KEY ([ma_nha_cung_cap])
GO

-- ----------------------------
-- Indexes structure for table tai_khoan
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table tai_khoan
-- ----------------------------
ALTER TABLE [dbo].[tai_khoan] ADD PRIMARY KEY ([tai_khoan])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[hang_hoa]
-- ----------------------------
ALTER TABLE [dbo].[hang_hoa] ADD FOREIGN KEY ([ma_nha_cung_cap]) REFERENCES [dbo].[nha_cung_cap] ([ma_nha_cung_cap]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[hang_nhap]
-- ----------------------------
ALTER TABLE [dbo].[hang_nhap] ADD FOREIGN KEY ([ma_hang_hoa]) REFERENCES [dbo].[hang_hoa] ([ma_hang_hoa]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[hang_xuat]
-- ----------------------------
ALTER TABLE [dbo].[hang_xuat] ADD FOREIGN KEY ([ma_hang_hoa]) REFERENCES [dbo].[hang_hoa] ([ma_hang_hoa]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
