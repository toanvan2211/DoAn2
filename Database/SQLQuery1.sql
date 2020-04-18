create database danhGiaDoanVien
go

use danhGiaDoanVien
go

create table nam
(
	id varchar(10) primary key,
	ten nvarchar(100)
)
go

create table ChiDoan
(
	id varchar(10) primary key,
	ten nvarchar(100),
	soDoanVien tinyint not null default 0,
	tongSV tinyint not null default 0,
	tongGV tinyint not null default 0,
)
go

create table KetQuaChiDoan
(
	idNamHoc varchar(10) primary key references Nam(id),
	xepLoai nvarchar(100),
	xuatXac tinyint,
	kha tinyint,
	trungBinh tinyint,
	yeuKem tinyint,
	tongDoanVien tinyint not null default 0,
	tongSV tinyint not null default 0,
	tongGV tinyint not null default 0,
	tongDVUT tinyint not null default 0
)

create table SinhVien
(
	id varchar(10) primary key,
	ten nvarchar(100),
	gioiTinh bit not null default 1, -- 0 là nữ 1 là nam
	chiDoan varchar(10) references ChiDoan(id),
	doanVien bit not null default 0 -- 0 là chưa phải đoàn viên, 1 = đã là đoàn viên
)
go

create table KetQuaSinhVien
(
	idNamHoc varchar(10) primary key references Nam(id),
	idSinhVien varchar(10) references SinhVien(id),
	diemHK1 float,
	diemHK2 float,
	tongHK float,
	DRLHK1 tinyint,
	DRLHK2 tinyint,
	DRL tinyint,
	xepLoai nvarchar(100),
	thanhTichTieuBieu nvarchar(200),
	doanVienUuTu bit not null default 0 -- 0 false 1 true
)
go

create table GiangVien
(
	id varchar(10) primary key,
	ten nvarchar(100),
	gioiTinh bit not null default 1, -- 0 nữ 1 nam
	chiDoan varchar(10) references ChiDoan(id),
	doanVien bit not null default 0 -- 0 false 1 true
)
go

create table KetQuaGiangVien
(
	idNamHoc varchar(10) primary key references Nam(id),
	idGiangVien varchar(10) references GiangVien(id),
	ketQuaDanhGia nvarchar(100),
	xepLoai nvarchar(20),
	thanhTichTieuBieu nvarchar(200),
	doanVienUuTu bit not null default 0 -- 0 false 1 true
)
go