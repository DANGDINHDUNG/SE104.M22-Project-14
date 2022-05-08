﻿CREATE DATABASE QUANLYKHACHSAN

CREATE TABLE PHONG
(
	MAPHONG INT IDENTITY(1,1) PRIMARY KEY,
	MALP VARCHAR(4),
	TENPHONG NVARCHAR(20),
	GHICHU NVARCHAR(40),
	TRANGTHAI NVARCHAR(20),
)

CREATE TABLE LOAIPHONG
(
	MALP VARCHAR(4) PRIMARY KEY,
	TENLOAIPHONG NVARCHAR(20),
	DONGIA MONEY
)

CREATE TABLE CHITIETPTP
(
	MACTPTP INT IDENTITY(1,1) PRIMARY KEY,
	MAPTP INT,
	MAKH VARCHAR(5),
)

CREATE TABLE PHIEUTHUEPHONG
(
	MAPTP INT IDENTITY(1,1) PRIMARY KEY,
	MAPHONG INT,
	NGAYLAP DATETIME,
	SOLUONG INT,
	DONGIA MONEY
)

CREATE TABLE KHACHHANG
(
	MAKH VARCHAR(5) PRIMARY KEY,
	MALK VARCHAR(4),
	TENKH NVARCHAR(40),
	CMND VARCHAR(12),
	DIACHI NVARCHAR(144),
)

CREATE TABLE LOAIKHACH
(
	MALK VARCHAR(4) PRIMARY KEY,
	TENLOAIKHACH NVARCHAR(20)
)

CREATE TABLE HOADON
(
	MAHD INT IDENTITY(1,1) PRIMARY KEY,
	MAKH VARCHAR(5),
	NGAYLAP DATETIME,
	TONGTIEN MONEY	
)

CREATE TABLE CHITIETHD
(
	MACTHD INT IDENTITY(1,1) PRIMARY KEY,
	MAPTP INT,
	MAHD INT,
	MADV INT,
	SONGAYTHUE INT
)

CREATE TABLE DICHVU
(
	MADV INT IDENTITY(1,1) PRIMARY KEY,
	TENDV NVARCHAR(20),
	DONGIA MONEY
)

CREATE TABLE CHITIETTHANHTOAN
(
	MAHD INT,
	MAKH VARCHAR(5),
	MALHTT INT,
	CONSTRAINT PK_KHACHDAT PRIMARY KEY(MAHD, MAKH, MALHTT)
)

CREATE TABLE LOAIHINHTHANHTOAN
(
	MALHTT INT IDENTITY(1,1) PRIMARY KEY,
	TENLHTT NVARCHAR(20),
)

CREATE TABLE CTBAOCAODOANHTHU
(
	MACTBCDT INT IDENTITY(1,1) PRIMARY KEY,
	MALP VARCHAR(4),
	MABCDT INT,
	DOANHTHU MONEY,
	TYLE FLOAT
)

CREATE TABLE BAOCAODOANHTHU
(
	MABCDT INT IDENTITY(1,1) PRIMARY KEY,
	TENBAOCAO NVARCHAR(20),
	NGAYLAP DATETIME,
	THANGBAOCAO INT
)

CREATE TABLE TAIKHOAN
(
	MATK INT IDENTITY(1,1) PRIMARY KEY,
	MALOAITK INT,
	TENCHUTAIKHOAN NVARCHAR(20),
	TENDANGNHAP VARCHAR(20),
	MATKHAU VARCHAR(50),
)

CREATE TABLE PHANLOAITAIKHOAN
(
	MALOAITK INT IDENTITY(1,1) PRIMARY KEY,
	TENLOAITK NVARCHAR(20),
	QUYENHAN NVARCHAR(50)
)

CREATE TABLE THAMSO
(
	MATHAMSO VARCHAR(5) PRIMARY KEY,
	TENTHAMSO NVARCHAR(20),
	GIATRI INT
)

-- Thêm ràng buộc khóa ngoại ở các bảng
ALTER TABLE PHONG ADD CONSTRAINT FK_PHONG_MALP FOREIGN KEY (MALP) REFERENCES LOAIPHONG(MALP)

ALTER TABLE CHITIETPTP ADD CONSTRAINT FK_CHITIETPTP_MAPTP FOREIGN KEY (MAPTP) REFERENCES PHIEUTHUEPHONG(MAPTP)
ALTER TABLE CHITIETPTP ADD CONSTRAINT FK_CHITIETPTP_MAKH FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE PHIEUTHUEPHONG ADD CONSTRAINT FK_PHIEUTHUEPHONG_MAPHONG FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG)

ALTER TABLE KHACHHANG ADD CONSTRAINT FK_KHACHHANG_MALK FOREIGN KEY (MALK) REFERENCES LOAIKHACH(MALK)

ALTER TABLE HOADON ADD CONSTRAINT FK_HOADON_MAKH FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE CHITIETHD ADD CONSTRAINT FK_CHITIETHD_MAPTP FOREIGN KEY (MAPTP) REFERENCES PHIEUTHUEPHONG(MAPTP)
ALTER TABLE CHITIETHD ADD CONSTRAINT FK_CHITIETHD_MAHD FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD)
ALTER TABLE CHITIETHD ADD CONSTRAINT FK_CHITIETHD_MADV FOREIGN KEY (MADV) REFERENCES DICHVU(MADV)

ALTER TABLE CHITIETTHANHTOAN ADD CONSTRAINT FK_THANHTOAN_MAHD FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD)
ALTER TABLE CHITIETTHANHTOAN ADD CONSTRAINT FK_THANHTOAN_MAKH FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)
ALTER TABLE CHITIETTHANHTOAN ADD CONSTRAINT FK_THANHTOAN_MALHTT FOREIGN KEY (MALHTT) REFERENCES LOAIHINHTHANHTOAN(MALHTT)

ALTER TABLE CTBAOCAODOANHTHU ADD CONSTRAINT FK_CTBAOCAODOANHTHU_MALP FOREIGN KEY (MALP) REFERENCES LOAIPHONG(MALP)
ALTER TABLE CTBAOCAODOANHTHU ADD CONSTRAINT FK_CTBAOCAODOANHTHU_MABCDT FOREIGN KEY (MABCDT) REFERENCES BAOCAODOANHTHU(MABCDT)

ALTER TABLE TAIKHOAN ADD CONSTRAINT FK_TAIKHOAN_MALOAITK FOREIGN KEY (MALOAITK) REFERENCES PHANLOAITAIKHOAN(MALOAITK)

INSERT INTO THAMSO(MATHAMSO,TENTHAMSO, GIATRI) VALUES ('ADM', N'áhfbnkcvbasdjfgbvndvb2132133','1')

set dateformat DMY

insert into LOAIKHACH(MALK, TENLOAIKHACH) values ('ND', N'Nội địa')
insert into LOAIKHACH(MALK, TENLOAIKHACH) values ('NN', N'Nước ngoài')

insert into KHACHHANG(MAKH, MALK, TENKH, CMND, DIACHI) VALUES ('KH001', 'ND', N'Huy', 'CMND', '123')
insert into KHACHHANG(MAKH, MALK, TENKH, CMND, DIACHI) VALUES ('KH002', 'ND', N'Dũng', 'CMND', '123')
insert into KHACHHANG(MAKH, MALK, TENKH, CMND, DIACHI) VALUES ('KH003', 'ND', N'Bảo', 'CMND', '123')


delete from LOAIPHONG
insert into LOAIPHONG(MALP, TENLOAIPHONG, DONGIA) values ('RST', N'Phòng tổng thống', 150000)

delete from PHONG
insert into PHONG(MALP, TENPHONG, GHICHU, TRANGTHAI) values ('RST', N'Phòng tổng thống 1', '', N'Trống')

delete from PHIEUTHUEPHONG
insert into PHIEUTHUEPHONG(MAPHONG, NGAYLAP, SOLUONG, DONGIA) values (1, '20/11/2022', 3, 150000)

delete from CHITIETPTP
insert into CHITIETPTP(MAPTP, MAKH) 
select MAPTP, MAKH
from PHIEUTHUEPHONG, KHACHHANG
where NGAYLAP = '20/11/2022' and MAKH = 'KH001'

insert into CHITIETPTP(MAPTP, MAKH) 
select MAPTP, MAKH
from PHIEUTHUEPHONG, KHACHHANG
where NGAYLAP = '20/11/2022' and MAKH = 'KH002'

insert into CHITIETPTP(MAPTP, MAKH) 
select MAPTP, MAKH
from PHIEUTHUEPHONG, KHACHHANG
where NGAYLAP = '20/11/2022' and MAKH = 'KH003'


insert into HOADON(MAKH, NGAYLAP) 
select top 1 MAKH, NGAYLAP = '30/11/2022'
from CHITIETPTP
where MAPTP = 4

insert into CHITIETHD(MAPTP, MAHD, MADV, SONGAYTHUE) 
select 

select top 1 C.MAKH, TENKH, NGAYLAP
from PHIEUTHUEPHONG A
inner join CHITIETPTP B on A.MAPTP = B.MAPTP
inner join KHACHHANG C on B.MAKH = C.MAKH
where TENKH = 'Huy'

	MACTHD INT IDENTITY(1,1) PRIMARY KEY,
	MAPTP INT,
	MAHD INT,
	MADV INT,
	SONGAYTHUE INT
	
select distinct DONGIA, SOLUONG
from PHIEUTHUEPHONG A
inner join CHITIETPTP B on A.MAPTP = B.MAPTP
inner join KHACHHANG C on B.MAKH = C.MAKH
where A.MAPTP = 4

select SOLUONG 
from PHIEUTHUEPHONG A
inner join CHITIETPTP B on A.MAPTP = B.MAPTP
inner join KHACHHANG C on B.MAKH = C.MAKH
where TENKH = 'Huy'

select MALK
from KHACHHANG A
inner join CHITIETPTP B on A.MAKH = B.MAKH
where MAPTP = 4
--INSERT INTO table2 (column1, column2, column3, ...)
--SELECT column1, column2, column3, ...
--FROM table1
--WHERE condition;