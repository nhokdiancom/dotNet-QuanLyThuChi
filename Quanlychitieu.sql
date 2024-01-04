
create database Quanlychitieu
use Quanlychitieu

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Thunhap'))
	DROP TABLE Thunhap
create table Thunhap
(
	MaTN varchar(10) not null primary key,
	MaNDTN varchar(10) not null,
	MaND varchar(10) not null,
	Sotien int null,
	Ngay datetime null,
	Ghichu nvarchar(100) null,
)


IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Noidungthunhap'))
	DROP TABLE Noidungthunhap
create table Noidungthunhap
(
	MaNDTN varchar(10) not null primary key,
	TenNDTN nvarchar(50) null,
)


IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Lichchitieu'))
	DROP TABLE Lichchitieu
create table Lichchitieu
(
	Malich varchar(10) not null primary key,
	MaND varchar(10) not null,
	MaNDLich varchar(10) null,
	Tenkhoanchi nvarchar(50) null,
	Sotien int null,
)

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Noidunglich'))
	DROP TABLE Noidunglich
create table Noidunglich
(
	MaNDLich varchar(10) not null primary key,
	Tenlich nvarchar(50) null,
	NgayBD datetime null CHECK(NgayBD<=GETDATE()),
	NgayKT datetime null CHECK(NgayKT>GETDATE()),
)

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Thongtinchitieu'))
	DROP TABLE Thongtinchitieu
create table Thongtinchitieu
(
	MaTTCT varchar(10) not null primary key,
	MaNDCT varchar(10) not null,
	MaND varchar(10) not null,
	Ngay datetime not null CHECK(Ngay<=GETDATE()),
	Sotien int null,
	Ghichu nvarchar(100) null,
)

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Nguoidung'))
	DROP TABLE Nguoidung
create table Nguoidung
(
	MaND varchar(10) not null primary key,
	Username varchar(50) not null,
	Hoten nvarchar(50) null,
	Namsinh datetime null CHECK(Namsinh<GETDATE()),
	Gioitinh varchar(3) null
)

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Noidungchitieu'))
	DROP TABLE Noidungchitieu
create table Noidungchitieu
(
	MaNDCT varchar(10) not null primary key,
	TenNDCT nvarchar(50) null,
)

IF (EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Dangnhap'))
	DROP TABLE Dangnhap
create table Dangnhap
(
	Username varchar(50) not null primary key,
	Pass varchar(50) not null,
)


ALTER TABLE Nguoidung
ADD
CONSTRAINT FK_Dangnhap_Nguoidung
FOREIGN KEY(Username)
REFERENCES Dangnhap(Username)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Thunhap
ADD
CONSTRAINT FK_Noidungthunhap_Thunhap
FOREIGN KEY(MaNDTN)
REFERENCES Noidungthunhap(MaNDTN)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Lichchitieu
ADD
CONSTRAINT FK_Lichchitieu_Nguoidung
FOREIGN KEY(MaND)
REFERENCES Nguoidung(MaND)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Lichchitieu
ADD
CONSTRAINT FK_Lichchitieu_Noidunglich
FOREIGN KEY(MaNDLich)
REFERENCES Noidunglich(MaNDLich)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Thunhap
ADD
CONSTRAINT FK_Thunhap_Nguoidung
FOREIGN KEY(MaND)
REFERENCES Nguoidung(MaND)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Thongtinchitieu
ADD
CONSTRAINT FK_Thongtinchitieu_Nguoidung
FOREIGN KEY(MaND)
REFERENCES Nguoidung(MaND)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE Thongtinchitieu
ADD
CONSTRAINT FK_Thongtinchitieu_Noidungchitieu
FOREIGN KEY(MaNDCT)
REFERENCES Noidungchitieu(MaNDCT)
ON DELETE CASCADE
ON UPDATE CASCADE



insert into Noidungchitieu values ('Cv',N'Cho vay'),('Dl',N'Đi du lịch'),('Tn',N'Tiền nhà'),('Td',N'Tiền điện'),('Hp',N'Học phí'),('Au',N'Ăn uống'),('Sx',N'Sửa xe'),('Tdt',N'Tiền điện thoại')
insert into Noidungthunhap values ('Tl',N'Tiền lương'),('Lt',N'Làm thêm')
insert into Noidunglich values   ('Ctt11',N'Chi tiêu tháng 11','11/01/2015','11/30/2015'),('Tkt11',N'Tiết kiệm tháng 11','11/01/2015','11/30/2015')
								