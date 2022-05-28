DROP TABLE CHITIETHD;
DROP TABLE HOADON;
DROP TABLE NHANVIEN;
DROP TABLE KHACHHANG;
DROP TABLE HANGHOA;
DROP TABLE NHACUNGCAP;
DROP TABLE LOAI;
DROP TABLE CHUCVU;
DROP TABLE CHINHANH;



CREATE TABLE CHINHANH
(
	MaChiNhanh NUMBER(10) NOT NULL,
	TenChiNhanh NVARCHAR2(50) NOT NULL,
    	CONSTRAINT FK_Chi_Nhanh PRIMARY KEY (MaChiNhanh)
);


INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (1, N'Cửa hàng tiện lợi Miền Đông');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (2, N'Cửa hàng tiện lợi Âu Cơ');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (3, N'Cửa hàng tiện lợi Phú Thạnh');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (4, N'Cửa hàng tiện lợi Trường Chinh');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (5, N'Cửa hàng tiện lợi Gò Vấp');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (6, N'Cửa hàng tiện lợi Nguyễn Thị Thập');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (7, N'Cửa hàng tiện lợi Thảo Điền');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (8, N'Cửa hàng tiện lợi An Phú');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (9, N'Cửa hàng tiện lợi An Lạc');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (10, N'Cửa hàng tiện lợi Bình Dương');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (11, N'Cửa hàng tiện lợi Bắc Giang');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (12, N'Cửa hàng tiện lợi Quy Nhơn');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (13, N'Cửa hàng tiện lợi Lê Trọng Tấn');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (14, N' Cửa hàng tiện lợi Long Biên');
INSERT INTO CHINHANH (MaChiNhanh, TenChiNhanh) VALUES (15, N' Cửa hàng tiện lợi Mê Linh');



CREATE TABLE CHUCVU
(
	MaChucVu NUMBER(10) NOT NULL,
	TenChucVu NVARCHAR2(50) NOT NULL,
     	CONSTRAINT FK_Chuc_Vu PRIMARY KEY (MaChucVu)
);


INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('1', N'Admin');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('2', N'Nhân Viên Quản Lí');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('3', N'Nhân Viên Thu Ngân');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('4', N'Nhân Viên Bảo Vệ');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('5', N'Nhân Viên Tư Vấn');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('6', N'Nhân Viên Kế Toán');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('7', N'Nhân Viên Kiêm Kê');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('8', N'Tổ Trưởng Quản Lí');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('9', N'Tổ Phó Quản Lí');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('10', N'Tổ Trưởng Bán Hàng');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('11', N'Tổ Phó Bán Hàng');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('12', N'Tổ Trưởng Thu Ngân');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('13', N'Tổ Phó Thu Ngân');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('14', N'Tổ Trưởng An Ninh');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('15', N'Tổ Phó An Ninh');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('16', N'Kế Tóan Trưởng');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('17', 'Kế Tóan Lương');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('18', N'Nhân Viên Kho');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('19', N'Giám Đốc Chi Nhánh');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('20', N'Quản Lý Chi Nhánh');
INSERT INTO CHUCVU (MaChucVu, TenChucVu ) VALUES ('21', N'Nhân Viên Bán Hàng');


CREATE TABLE NHANVIEN
(
	MaNV NUMBER(10) NOT NULL,
	HoTen NVARCHAR2(100) NOT NULL,
  	GioiTinh NUMBER(1) NOT NULL,
	NgaySinh DATE ,
	SDT VARCHAR2(24),
	DiaChi NVARCHAR2(100) ,
  	TenDN VARCHAR2(20) NOT NULL,
  	MatKhau LONG RAW ,
  	Luong CLOB,
  	Email varchar2(100),
	MaChiNhanh NUMBER(10) NOT NULL,
	MaChucVu NUMBER(10) NOT NULL,
 	CONSTRAINT FK_NV PRIMARY KEY (MaNV),
  	CONSTRAINT FK_NV_CN FOREIGN KEY (MaChiNhanh) REFERENCES ChiNhanh(MaChiNhanh),
  	CONSTRAINT FK_NV_CV FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu)
);
-- INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (43 , N'Admin ', 1 , TO_TIMESTAMP ('2009-07-12','YYYY-MM-DD'), '0612905938', N'355   TP.Thủ Đức. ', N'nqcuong20', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee472667@gmail.com', 1 , '1');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (43 , N'Admin ', 1 , TO_TIMESTAMP ('2009-07-12','YYYY-MM-DD'), '0612905938', N'355   TP.Thủ Đức. ', N'lylong123', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee472667@gmail.com', 1 , '1');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (1, N'Nguyễn Quốc Cường', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL1', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee01@gmail.com',  1,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (1, N'Nguyễn Quốc Cường', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL1', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee01@gmail.com',  1,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (2, N'Nguyễn Thị Kim Anh', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL2', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee02@gmail.com',2,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (3, N'Nguyễn Duy Minh', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL3', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee03@gmail.com',3,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (4, N'Nguyễn Minh Quốc', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL4', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee04@gmail.com', 4,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (5, N'Dương Thái Nhật', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL5', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee05@gmail.com',5,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (6, N'Võ Lê Ngọc Diệp', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL6', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==','employee06@gmail.com',6,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (7, N'Dương Tấn Thiên', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL7', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==','employee07@gmail.com',7,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (8, N'Ngô Đức Anh', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quân 11','NGQL8', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee08@gmail.com',8,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (9, N'Trần Văn Nhật Tân', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '121 Đường số 6 P Linh Tây','NGQL9', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee09@gmail.com',9,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (10, N'Đỗ Thị Bảo Quyên', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '291/12/5 Nguyễn Quốc Toàn P7 ','NGQL10', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee10@gmail.com', 10,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (11, N'Hồ Ngọc Hà', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '45 Thảo Điền Q10','NGQL11', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee11@gmail.com',11,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (12, N'Nguyễn Hoành Anh', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quân 11','NGQL12', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==' ,'employee12@gmail.com',12,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu )  VALUES (13, N'Lý Hoàng Mai', 0, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '230 An Dường Vương P11 A5','NGQL13', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee13@gmail.com', 13,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (14 , N' Hồng Đại ', 0 , TO_TIMESTAMP ('1953-02-05','YYYY-MM-DD'), '0669501295', N'191 Đường số 96 Quận  Bình Chánh TP.HCM. ', N'NGQL14', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee110834@gmail.com', 14, '20' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (15 , N'Hồ Kim Hoàng ', 0 , TO_TIMESTAMP ('1975-03-18','YYYY-MM-DD'), '0294961558', N'92  Quận Bình Thạnh  TP.Thủ Đức. ', N'NGQL15', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee54214@gmail.com', 15, '20' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (16, N'Nguyễn Quốc Cường', 1, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'), '0377077630', '351A Lạc Long Quân P5 Quận 11','NGQL1', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C','ZhAUSvIL8i7Q07+sGscTCQ==','employee01@gmail.com',  1,'20');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (17 , N'Lý Quốc Linh ', 1 , TO_TIMESTAMP ('1994-12-07','YYYY-MM-DD'), '0314591996', N'366  Quận 9 TP.Thủ Đức. ', N'NV1491322', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee800428@gmail.com', 9 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (18 , N'  Quang ', 1 , TO_TIMESTAMP ('1960-08-21','YYYY-MM-DD'), '0747157884', N'63  Quận 5 TP.Thủ Đức. ', N'NV9478952', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee789615@gmail.com', 4 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (19 , N'Hoàng Diệu Hùng ', 0 , TO_TIMESTAMP ('1961-10-13','YYYY-MM-DD'), '0612285495', N'10 Phường 33 Quận Bình Thạnh  TP.HCM. ', N'NV0832803', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee134753@gmail.com', 9 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (20 , N'Lý Uyển Đức Anh ', 0 , TO_TIMESTAMP ('1995-05-19','YYYY-MM-DD'), '0181510599', N'861   TP.Thủ Đức. ', N'NV5912480', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee239949@gmail.com', 14 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (21 , N'Võ  Uyển Hoa ', 0 , TO_TIMESTAMP ('1996-04-05','YYYY-MM-DD'), '0158301314', N'71  Quận 5 TP.HCM. ', N'NV7855664', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee11[722@gmail.com', 7 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (22 , N'Phạm  Ngọc Thiện ', 1 , TO_TIMESTAMP ('2001-06-25','YYYY-MM-DD'), '0719132816', N'673  Quận Bình Thạnh  TP.HCM. ', N'NV7121483', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee116553@gmail.com', 1 , '21' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (23 , N'Trần Viết Hoàng ', 1 , TO_TIMESTAMP ('1963-12-17','YYYY-MM-DD'), '0793239219', N'55  Quận 1 TP.HCM. ', N'NV7518833', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee75598@gmail.com', 2 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (24 , N'Võ  Hoài Thịnh ', 0 , TO_TIMESTAMP ('1999-04-27','YYYY-MM-DD'), '0288040292', N'62 Đường số 49  TP.Thủ Đức. ', N'NV0647575', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee24881@gmail.com', 2, '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (25 , N'Dương Hoài Quang ', 1 , TO_TIMESTAMP ('1977-06-27','YYYY-MM-DD'), '0125270992', N'59  Quận 7 TP.Thủ Đức. ', N'NV5788411', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee358257@gmail.com', 4 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (26 , N'Hoàng Diệu Đức Anh ', 1 , TO_TIMESTAMP ('1970-01-21','YYYY-MM-DD'), '0233562169', N'187 Đường số 16 Quận  TP.HCM. ', N'NV5122872', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee76698@gmail.com', 5 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (27 , N' Kim Trung ', 0 , TO_TIMESTAMP ('2008-10-06','YYYY-MM-DD'), '0922098287', N'57   TP.Thủ Đức. ', N'NV7013207', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee39017@gmail.com', 6 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (28 , N'Hoàng Thái Huy ', 1 , TO_TIMESTAMP ('1967-08-05','YYYY-MM-DD'), '0999935414', N'39  Quận  Bình Chánh TP.HCM. ', N'NV4046577', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee901572@gmail.com', 7 , '21' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (29 , N'Võ  Hồng Đắc ', 0 , TO_TIMESTAMP ('2009-10-15','YYYY-MM-DD'), '0938919534', N'485  Quận 7 TP.HCM. ', N'NV1070992', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee61073@gmail.com', 8 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (30 , N'Phùng Duy  Trâm ', 0 , TO_TIMESTAMP ('1993-11-20','YYYY-MM-DD'), '0859079052', N'277  Quận 3 TP.HCM. ', N'NV3320612', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee58|749@gmail.com', 9 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (31 , N'Hồ  Vĩ ', 0 , TO_TIMESTAMP ('2004-08-11','YYYY-MM-DD'), '0712002342', N'63  Quận Bình Tân TP.HCM. ', N'NV4859502', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee756316@gmail.com', 10 , '21' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (32 , N'Hoàng Duy  Diệu ', 0 , TO_TIMESTAMP ('1983-02-07','YYYY-MM-DD'), '0701625328', N'392  Quận 9 TP.Thủ Đức. ', N'NV5343771', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee15822@gmail.com', 11 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (33 , N'Dương Viết Đức ', 0 , TO_TIMESTAMP ('1979-08-08','YYYY-MM-DD'), '0394533991', N'31  Quận 9 TP.Thủ Đức. ', N'NV7428443', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee614109@gmail.com',12 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (34 , N'Dương Uyển Phương ', 1 , TO_TIMESTAMP ('1993-01-28','YYYY-MM-DD'), '0488558189', N'461  Quận 7 TP.HCM. ', N'NV0419804', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee519783@gmail.com', 13 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (35 , N'Lê Viết Đắc ', 0 , TO_TIMESTAMP ('1975-03-05','YYYY-MM-DD'), '0600248338', N'410   TP.Thủ Đức. ', N'NV7825859', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee30325@gmail.com', 14 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (36 , N' Hoài Bảo ', 1 , TO_TIMESTAMP ('2010-04-20','YYYY-MM-DD'), '0577267666', N'99 Đường số 57 Quận 2 TP.HCM. ', N'NV1860746', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee744484@gmail.com', 15 , '21' );
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (37 , N'Nguyễn Duy  Thiện ', 1 , TO_TIMESTAMP ('2006-06-25','YYYY-MM-DD'), '0343869260', N'44   TP.Thủ Đức. ', N'NV7371115', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee581285@gmail.com', 12 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (38 , N'Lê Hoài Bảo ', 1 , TO_TIMESTAMP ('2002-09-10','YYYY-MM-DD'), '0443942911', N'90  Quận Bình Tân TP.HCM. ', N'NV8021683', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee436775@gmail.com', 11 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (39 , N'Lý  Ngọc Hoa ', 1 , TO_TIMESTAMP ('1976-11-03','YYYY-MM-DD'), '0960986169', N'93   Quận Tân Bình TP.Thủ Đức. ', N'NV3407088', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee46784@gmail.com', 8 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (40 , N'Hoàng Hồng Tân ', 1 , TO_TIMESTAMP ('1994-01-22','YYYY-MM-DD'), '0141251726', N'704  Quận 2 TP.Thủ Đức. ', N'NV5278115', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee83115@gmail.com', 15 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (41 , N'Lê Viết Bảo ', 1 , TO_TIMESTAMP ('1974-09-28','YYYY-MM-DD'), '0673471488', N'702  Quận 1 TP.Thủ Đức. ', N'NV6687073', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee93288@gmail.com', 11 , '21');
INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh,NgaySinh,SDT, DiaChi,TenDN, MatKhau, Luong, Email, MaChiNhanh, MaChucVu ) VALUES (42 , N'Trần Viết Vĩ ', 1 , TO_TIMESTAMP ('1959-07-08','YYYY-MM-DD'), '0855167340', N'636  Quận 2 TP.Thủ Đức. ', N'NV1376888', 'C35A37F0BCA08AFA583247CC461CAD9C8082A47C', 'ZhAUSvIL8i7Q07+sGscTCQ==' , N'employee586795@gmail.com', 9 , '21');


CREATE TABLE LOAI(
  MaLoai NUMBER(10) NOT NULL,
  TenLoai NVARCHAR2(30) NOT NULL,
  CONSTRAINT pk_loai PRIMARY KEY (MaLoai)
);

INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (1, N'Thực Phẩm');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (2, N'Khăn giấy, giấy vệ sinh');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (3, N'Mỹ Phẩm');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (4, N'Văn Phòng Phẩm');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (5, N'Bàn Chải, Kem Đánh Răng');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (6, N'Thực Phẩm Khô');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (7, N'Nước Giải Khát');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (8, N'Sữa');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (9, N'Bánh Kẹo');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (10, N'Mì Gói');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (11, N'Dầu Ăn');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (12, N'Nước xả vải');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (13, N'Đồ gia dụng');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (14, N'Nước rửa tay');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (15, N'Bột giặt');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (16, N'Sữa tắm');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (17, N'Dầu gội');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (18, N'Nước tăng lực');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (19, N'Sữa');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (20, N'Thiết bị y tế');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (21, N'Rau xanh');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (22, N'Hoa Quả');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (23, N'Mứt');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (24, N'Bánh');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (25, N'Kẹo');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (26, N'Khẩu trang');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (27, N'Quần áo người lớn');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (28, N'Quần áo trẻ em');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (29, N'Thiết bị điện tử');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (30, N'Đồ công nghệ');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (31, N'Đồ trang sức');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (32, N'Đồ chơi');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (33, N'Thức ăn đóng hộp');
INSERT INTO LOAI (MaLoai, TenLoai ) VALUES (34, N'Thức ăn có sẵn');

CREATE TABLE NHACUNGCAP(
  MaNCC NUMBER(10) NOT NULL,
  TenCongTy NVARCHAR2(50),
  Email VARCHAR2(50),
  DienThoai VARCHAR2(24),
  DiaChi NVARCHAR2(100),
  CONSTRAINT pk_ncc PRIMARY KEY (MaNCC)
);

INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (1, N'ESHOP', N'eshop@gmail.com', N'1654651326', N'TPHCM');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (2, N'KENTA', N'kenta@gmail.com', N'653256565', N'TPHCM');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (3, N'SENDO', N'sendo@gmail.com', N'2356562323', N'TPHCM');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (4, N'YAME', N'yame@gmail.com', N'32565365323', N'BÌNH D??NG');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (5, N'Cp Nước Giải Khát Chương Dương', N' info@cdbeco.com.vn', N'( 84-8) 3836 7518', N'577 Hùng Vương, P. 12, Quận 6 ');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (6, N'Công Ty Tnhh Nước Giải Khát Delta', N'delta@gmail.com', N'0723827010', N'	Số 42, Võ Ngọc Quận, Phường 6, , Việt Nam');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (7, N'Thực Phẩm Đóng Hộp KTC Kiên Giang', N'sale@ktcfood.com.vn', N' 0297.3617724', N'Khu Cảng cá Tắc Cậu, Châu Thành, Kiên Giang');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (8, N'Công Ty Xuất Khẩu Rau Quả Tiền Giang', N'info@vegetigi.com', N' (84.273) 3834 677', N' Kilômét số 1977, , Tiền Giang');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (9, N'Công Ty CP Thực Phẩm Xuất Khẩu Đồng Giao', N'sales@doveco.com.vn', N'(+84) 229 3770 353', N' Phường Trung Sơn,Tam Điệp, Ninh Bình');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (10, N'Công Ty TNHH Thực Phẩm Dinh Dưỡng Sài Gòn', N'yame@gmail.com', N'(84. 0650) 3737 692', N' KCN Sóng Thần 2, Dĩ An, Bình Dương');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (11, N'Công Ty TNHH Saigon Ve Wong', N'yame@gmail.com', N'(028) 37195550, 37195554', N'1707 Quốc Lộ 1A, P. An Phú Đông, Q. 12, Tp. Hồ Chí Minh (TPHCM)');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (12, N'CÔNG TY CỔ PHẦN RAU QUẢ BÌNH THUẬN', N'hoangrauqua@fruitsandgreens.com', N'0913 932 446', N'107 Đặng Văn Lãnh, Phường Phú Tài, , Tỉnh Bình Thuận');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (13, N'CÔNG TY CỔ PHẦN PHÂN PHỐI ĐIỆN TỬ JVS', N'info@jvs.vn', N'32565365323', N'24 Giai Phóng, P.4, Q. Tân Bình, Tp HCM');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (14, N'Công ty TNHH Panasonic Việt Nam', N' customer@vn.panasonic.com', N'(+84) 024 3955 0111', N'	Lô J1-J2 Khu công nghiệp Thăng Long,  Hà Nội, Việt Nam.');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (15, N'Công ty TNHH Thaipro', N'thaipro@gmail.com', N'32565365323', N'GD2-14, Khu Công nghiệp Ngọc Hồi, Thanh Trì, Hà Nội.');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (16, N'Công ty TNHH Điện Tử Samsung', N'samsung@gmail.com', N' +84-2839157310', N'Số 2, đường Hải Triều, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (17, N'Công ty Cổ phần Thực phẩm Thiên Hương', N' contact@thienhuongfood.com.vn', N'028 37171449', N'Số 1 Lê Đức Thọ, Khu Phố 02, Tân Thới Hiệp, Quận 12, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (18, N'Công ty Cổ phần Kỹ nghệ thực phẩm Việt Nam ', N'vifon@vifon.com.vn', N'028 38153933', N'913 Trường Chinh, P. Tây Thạnh, Q. Tân Phú, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (19, N'Công ty Cổ phần Acecook Việt Nam', N'acecook@gmail.com', N'028 3 815 4064', N' Lô II-3, Đường số 11, , P.Tây Thạnh, Q. Tân Phú, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (20, N'Công ty Cổ phần Hàng tiêu dùng MaSan', N'danielle@msn.masangroup.com', N' 0286 2555 660', N'Tầng 12, tòa nhà MPlaza Saigon, Quận 1, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (21, N'Công ty TNHH Sản xuất thương mại Phúc Hảo', N'info@phuchaonoodles.com.vn', N'0932.704.724', N' 347 Hồ Văn Tắng, Huyện Củ Chi, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (22, N'Công ty Cổ phần công nghệ thực phẩm Châu Á', N'micoem@micoem.vn', N'02223 714 146', N'Số 4 Bạch Đằng, P.Thạch Thang, Q. Hải Châu, TP Đà Nẵng');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (23, N'Cty CP Thực phẩm Á Châus', N'info@asiafoods.vn', N'028 4450 0588 ', N'801-804 Tầng 8, Saigon Trade Center, TP. Hồ Chí Minh');
INSERT INTO NHACUNGCAP (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (24, N'Công ty Cổ phần lương thực thực phẩm Colusa', N'colusa@comifood.com', N'028 3896 6835', N'1230 Kha Vạn Cân, Linh Trung, Thủ Đức, TP. Hồ Chí Minh');


CREATE TABLE HANGHOA (
  MaHH NUMBER(10) NOT NULL,
  TenHH NVARCHAR2(60) NOT NULL,
  MaLoai NUMBER(10) NOT NULL,
  SoLuong NUMBER(10),
  DonGia FLOAT ,
  GiamGia FLOAT ,
  MoTa NVARCHAR2(1000),
  MaNCC NUMBER(10) NOT NULL,
  CONSTRAINT pk_hh PRIMARY KEY (MaHH),
  CONSTRAINT fk_hh_loai FOREIGN KEY (MaLoai) REFERENCES LOAI(MaLoai),
  CONSTRAINT fk_hh_ncc FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (1, N'MÌ ĂN LIỀN MILIKET', 10, 1500, 10, 0, N' VẮT MÌ - Bột mì, shortening, tinh bột khoai mì, muối, đường, chất ổn định (501(i), 452(i), 466), chất tạo xốp (500(i)), phẩm màu tự nhiên (160a(ii), 160c, 100(i)), bột tôm, chất chống oxy hoá (321). ', 21);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (2, N'MÌ ĂN LIỀN HẢO HẢO', 10,  3500, 10, 0, N'ẮT MÌ - Bột mì (bổ sung vi chất (kẽm, sắt)), dầu thực vật (dầu cọ, chất chống oxy hoá (BHA (320), BHT (321))), tinh bột, muối, đường, nước mắm, chất điều vị (mononatri glutamat (621)), chất ổn định (pentanatri triphosphat (451(i), ', 21);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (3 ,N'MÌ ĂN LIỀN TÔM CHUA CAY', 10, 2500, 10, 0, N'Sợi mì 3 Miền được làm bột khoai tây, bột mì, màu tự nhiên, vitamin B1, B2, B3, B6, B9… trở nên dai, mềm hấp dẫn. ', 22);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (4, N'MÌ ĂN LIỀN OMAICHI BÒ HẦM', 10 , 5000, 10, 0, N'Mì Omachi Xốt Bò Hầm sinh ra từ lúa mì và tinh chất khoai tây, hòa quyện với trứng, từng sợi mì Omachi vàng ươm dai ngon nay còn được đắm mình trong nước cốt từ thịt và xương nên càng đậm đà hấp dẫn ', 21);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (5 ,N'MÌ ĂN LIỀN OMACHI TRỘN', 10, 5000, 10, 0, N'Mì Omachi xốt Spaghetti vị bò với sợi mì mềm, dai, được làm từ khoai tây tươi chọn lọc, kết hợp với nước xốt được chế biến từ thịt bò bằm và cà chua tươi làm nên hương vị đặc trưng của nước Ý. ', 22);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (6, N'MÌ ĂN LIỀN A ONE', 10, 3000, 10, 0, N'Bột mì, dầu shortening, muối, chất điều vị: Monosodium glumate (E621), đường , bột tiêu đen, bột ớt, dầu thực vật, hành lá sấy, khô, hương thịt xào tổng hợp. ', 22);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (7, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT16', 27 , 350000, 10, 0.15, N'Sơ mi tay dài trắng phong cách tinh ', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (11, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT12', 27, 280000, 10, 0.12, N'Áo sơ mi nam Cổ Bẻ Vải Lụa Thái chống nhăn (CAM KẾT ẢNH THẬT)-Dáng ôm Body Hàn Quốc đẹp', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (17, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT16', 27, 280000, 10, 0, N'SKU: SMT16 Category: Áo Sơ Mi Nam Tags: áo sơ mi, áo sơ mi đen, áo sơ mi trắng', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (18, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT0001', 27,  300000, 10, 0.2, N'Mua ngay Áo sơ mi nam Vải Lụa Thái Trắng chống nhăn SMT001-Dáng ôm Body Hàn quốc chính hãng ', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (19, N'ÁO SƠ MI NAM DÀI TAY SỌC ĐEN TRẮNG SMT0004', 27, 320000, 10, 0.2, N'Áo sơ mi sọc đen tim đen- UNISEX cao cấp giá rẻ. Sơ mi nam dài tay màu trắng sành điệu thoáng mát không nhăn.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (20, N'ÁO SƠ MI NAM DÀI TAY SỌC SMT0006',27, 300000, 10, 0.2, N'áo sơ mi nam trung niên đẹp, lịch sự với chất liệu cao cấp : cotton, sợi tre, nano. Đủ size từ 38-43.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (21, N'ÁO SƠ MI NAM DÀI TAY SỌC XÁM SMT0018', 27,  300000, 10, 0.2, N'Áo sơ mi nam dài tay, Áo sơ mi nam công sở họa tiết kẻ sọc có túi ngực, Kiểu sơ mi thoáng mát bền đẹp sang', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (22, N'ÁO SƠ MI NAM DÀI TAY  XANH SỌC DEN  SMT0026',27, 300000, 10, 0.2, N'Áo sơ mi nam dài tay thương hiệu Anton kẻ sọc xanh dương ', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (23, N'ÁO SƠ MI NAM  NGẮN TAY SMT0001', 27,  300000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (24, N'ÁO SƠ MI NAM  NGẮN TAY HỌA TIẾT SMT0065', 27, 300000, 10, 0.2, N'Các mẫu áo sơ mi nam ngắn tay cao cấp, giá cả hợp lý.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (25, N'ÁO SƠ MI NAM  NGẮN TAY SMT0069', 27,  300000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (26, N'ÁO SƠ MI NAM  NGẮN TAY SMT0005', 27,  110000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (27, N'ÁO SƠ MI NAM  NGẮN TAY SMT0001', 27, 110000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (28, N'ÁO SƠ MI NAM  NGẮN TAY SMT0010',27,  110000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (29, N'ÁO SƠ MI NAM  NGẮN TAY SMT0041', 27, 110000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (30, N'ÁO SƠ MI NAM  NGẮN TAY   SMT0073',27,  110000, 10, 0.2, N'Áo sơ mi nam tay ngắn cho quý ông trẻ trung. Áo sơ mi cộc tay lịch sự mà vẫn năng động thể hiện bản lĩnh đàn ông đích thực.', 9);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (31, N'Dầu ăn Neptune',11, 45000, 10, 0.2, N'Dầu ăn Neptune 1:1:1 là loại dầu thực vật thế hệ mới tốt cho sức khỏe của công ty dầu thực vật Cái Lân. Đây cũng là loại dầu thực vật duy nhất trên thị trường được sản xuất từ hỗn hợp dầu gạo, dầu hạt cải, dầu đậu nành và dầu Olein, không chứa a-xít béo cấu hình trans, không cholesterol rất tốt cho sức khỏe tim mạch…', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (32, N'Dầu ăn hướng dương Nga',11, 52000, 10, 0.2, N'Dầu ăn hướng dương Nga được làm từ 100% hạt hướng dương nguyên chất, được sản xuất dựa trên công nghệ ép lạnh không tinh chế. Vì vậy, giữ được đầy đủ các thành phần vitamin và khoáng chất có lợi cho sức khỏe như: vitamin A, B,E và các axit không bão hòa đa (Omega 3, 6, 9) và có màu vàng tự nhiên.i', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (33, N'Dầu ăn Meizan',11,  41000, 10, 0.2, N'Dầu ăn Meizan cũng là một sự lựa chọn thông minh cho các bà nội trợ. Meizan có đa dạng các loại dầu ăn đều có lợi cho sức khỏe như: Dầu thực vật Meizan, Dầu đậu nành Meizan, Bơ thực vật Meizan, Dầu mè thơm hảo hạng Meizan. ', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (34, N'Dầu ăn Simply',11, 49000, 10, 0.2, N'dầu đậu nành Simply được làm từ 100% đậu nành nguyên chất, là một trong những loại dầu thực vật được sử dụng rộng rãi nhất trên thế giới bởi những lợi ích sức khỏe, thành phần và chất chống oxi hóa vẫn còn lưu lại trong dầu ngay cả sau khi được tinh luyện.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (35, N' Dầu ăn olive',11, 221000, 10, 0.2, N'là một người mẹ đảm đang thì không thể không quan tâm đến sức khỏe của con cái đặc biệt là trẻ nhỏ từ 3 - 5 tuổi. Đây là giai đoạn phát triển của trẻ. Trẻ cần những thức ăn đầy đủ dinh dưỡng.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (36, N'Dầu ăn Cái Lân',11,  28000, 10, 0.2, N'Dầu ăn Cái Lân là một thương hiệu dầu ăn nổi tiếng, lâu đời mang thương hiệu Việt Nam. Dầu ăn hảo hạng Cái Lân được sản xuất theo quy trình hiện đại, hợp vệ sinh an toàn thực phẩm. Những nguyên liệu để tinh chế được chọn lọc một cách sát sao. ', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (37, N'Dầu ăn Tường An',11,  95000, 10, 0.2, N'Hãng dầu ăn Tường An với kinh nghiệm sản xuất gần 35 năm cùng những thiết bị máy móc, chế biến hiện đại, ngày càng được cải tiến và nâng cấp. Đối với Tường An, mục tiêu quan trọng nhất là không ngừng cải tiến nâng cao chất lượng và an toàn thực phẩm, đáp ứng tốt nhất mọi yêu cầu của khách hàng.', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (38, N'Dầu ăn cao cấp Ranee ',11, 24000, 10, 0.2, N'Dầu ăn cao cấp Ranee 100% từ cá được sản xuất với dây chuyền công nghệ vật lý tinh luyện từ Châu Âu, giúp xử lý mùi tối ưu nhưng vẫn lưu giữ tron vẹn các dưỡng chất tự nhiên từ cá như omega 3-6-9, DHA/EPA và Vitamin E', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (39, N'Dầu ăn Marvela',11,  35000, 10, 0.2, N'Dầu ăn Marvela là thương hiệu nổi tiếng ở Việt Nam. Được mọi người tin dùng và sử dụng suốt những năm qua. Cũng giống các thương hiệu khác, Marvela cho ra đời nhiều loại dầu ăn với những nguyên liệu, thành phần khác nhau. Kéo theo đó là những công dụng khác nhau.', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (40, N'Bộ Mỹ phẩm dưỡng trắng da Ohui White Extreme',3, 110000, 10, 0.2, N'Về tổng quan bộ mỹ phẩm Hàn Quốc Ohui Extreme White là dòng sản phẩm dưỡng trắng da cao cấp được Ohui phát triển nhằm giúp phái đẹp nuôi dưỡng, tái tạo vẻ tươi sáng cho làn da, mong muốn đem đến cho phái đẹp một sự thay đổi đột phá, thú vị, làn da đẹp, sáng trong không tì vết cùng tâm trạng vui vẻ và cuộc sống hạnh phúc.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (41, N'Kem chống nắng Ohui Black',3,  310000, 10, 0.2, N'Ohui Perfect Sun Black có chỉ số chống nắng ở mức phù hợp (SPF50+/PA++++) giúp chống nắng hiệu quả. Ngoài tác dụng của kem chống nắng thì sản phẩm này còn giúp dưỡng sáng da và cấp ẩm hiệu quả. ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (42, N'Kem dưỡng Innisfree balancing cream',3,  310000, 10, 0.2, N'Đây được xem như dòng sản phẩm dưỡng chủ đạo và được đánh giá cao nhất của hãng. Green tea balancing cream – Kem dưỡng ẩm cân bằng Với chiết xuất từ trà xanh sẽ cung cấp, bổ sung dưỡng chất cho da mặt.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (43, N'Mặt nạ ngủ Laneige Water Sleeping Mask',3,  110000, 10, 0.2, N'Sản phẩm có dạng gel lỏng mịn chứa “nước từ băng tuyết tan”, tinh chất từ quả mơ Hunza và tinh chất hạt dẻ thấm nhanh vào da và giúp cung cấp dinh dưỡng cho tế bào da cũng như làm hydrat hóa làn da để giữ ẩm và thay đổi sắc tố da để làm trắng.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (44, N'Phấn nước dưỡng trắng Laneige BB',3,  310000, 10, 0.2, N'Laneige whitening là một sản phẩm 5 trong 1 mang tính “cách mạng” của hãng trong công cuộc làm đẹp, với độ che phủ chống nắng SPF 50, lượng nước khoáng tối ưu, hiệu chỉnh màu sắc tất cả trong một', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (45, N'Son môi Mamonde Highlight Lip Tint',3,  110000, 10, 0.2, N'Thỏi son tint Mamonde này có thiết kế cực đơn giản nhưng đáng yêu với thân son nhựa có màu tương ứng với màu son bên trong.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (46, N'Mỹ phẩm Sulwhasoo',3, 110000, 10, 0.2, N'Sulwhasoo được đón nhận nhiệt tình nhờ các sản phẩm chất lượng cao, được nghiên cứu và chiết xuất từ hơn 3,000 loại thảo mộc và các loại dược liệu quý.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (47, N'Sữa rửa mặt Herb Day 365',3,  300000, 10, 0.2, N'Một trong những sản phẩm nổi bật nhất của hãng chính là dòng sữa rửa mặt tạo bọt Herb Day 365 Cleansing Foam TheFaceShop, dòng sản phẩm gồm 6 mùi hương tươi trẻ có thể dùng như một loại kem tẩy trang dùng sau khi trang điểm', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (48, N'Son Etude house dear darling tint',3, 110000, 10, 0.2, N'Đây là một sản phẩm đang làm mưa làm gió tại thị trường Việt Nam thời gian gần đây bởi độ “cute” vô đối của thiết kế hình que kem bé bé xinh xinh.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (49, N'Mặt nạ đường đen dâu skinfood',3,  110000, 10, 0.2, N'Là một hãng mỹ phẩm Hàn Quốc chất lượng đa dạng các sản phẩm từ chăm sóc da đến trang điểm giá thành hợp lí và đáng để thử khi bạn muốn tìm một hãng mỹ phẩm bình dân chất lượng.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (50, N'Me Cay Rồng Con',6,  51000, 10, 0.2, N'ME XÍ MUÔI CHUA CAY vừa là món ăn vặt hấp dẫn và lạ miệng, vị chua của me, mặn, ngọt của đường và muối kết hợp với một ít cay của ớt tạo nên một sản phẩm rất đặc biệt', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (51, N'Đậu Phộng Nước Cốt Dừa',6, 51000, 10, 0.2, N'Khách ăn vào sẽ cảm nhận được độ giòn, béo, độ xốp. Sản phẩm hoàn toàn không thêm chất bảo quản, giữ nguyên hương vị tự nhiên của sản phẩm. Dùng được cho người ăn chay.', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (52 ,N'Đậu Hà Lan Sấy Muối',6,  51000, 10, 0.2, N'Đậu Hà Lan Sấy vị phô mai ăn vào vừa xốp, vừa giòn, vừa có độ béo của phô mai, hạt đậu Hà Lan không cứng, không chai.', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (53, N' táo đỏ tân cương',6, 110000, 10, 0.2, N'TÁO ĐỎ CỦA NGƯỜI HÀN QUỐC khác hẳn những loại táo đỏ được trồng ở Trung Quốc hay nơi khác vì trái to, ngọt, hạt rất nhỏ, thơm', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (54, N'Hạt macca ',6,  290000, 10, 0.2, N'Có xuất xứ tại châu Úc, khu vực có khí hậu nhiệt đới và cận nhiệt đới cùng với đặc trưng nơi đây các loại khoáng sản phong phú nên hàm lượng dinh dưỡng có trong hạt mắc ca từ đó cũng xếp hạng cao nhất trong các loại hạt dinh dưỡng', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (55, N'Quả óc chó mỹ đã sấy chín',6,  110000, 10, 0.2, N'Quả óc chó có tên tiếng Anh là Walnuts hay tên khác quả Hồ Đào (Juglans regiaL) là một họ thực vật có hoa bao gồm các loại cây thân gỗ trong bộ Dẻ (Fagales). Loại quả này có hơn 20 loại khác nhau và được trồng chủ yếu ở California walnuts – Mỹ (USA) ', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (56, N'HẠT CHIA TÍM NHẬP KHẨU ÚC',6, 69000, 10, 0.2, N'Hạt Chia hay còn gọi là Salvia là thực phẩm chứa nhiều chất dinh dưỡng hiếm có trong thế giới thực phẩm, đặc biệt là những vi chất mà chúng ta khó có thể bổ sung được bằng thuốc bổ ', 7);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (57, N'1kg hạt sen khô',6,  169000, 10, 0.2, N'Hạn sử dụng: 6 tháng.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (58, N' Khô cá chỉ vàng ',6,  210000, 10, 0.2, N'Cá chỉ vàng là một loại cá bổ dưỡng và thơm ngon vì trong thịt cá có chứa rất nhiều protein, lipid và cực kỳ nhiều omega 3 tốt cho tim mạch và mắt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (59, N'Khô cá sặc Việt Hà',6,  100000, 10, 0.2, N'Khô cá sặc ngon ở chỗ bụng khô cá rất béo và thơm. Nhưng cũng chính vì bụng cá rất ngon nên khi chế biến cần làm sạch mùi tanh và khi phơi phải bảo quản cẩn thận khỏi ruồi đậu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (60, N'Khô cá lưỡi trâu Song Phương',6,  450000, 10, 0.2, N'Cá lưỡi trâu là một loài cá sạch, ít xương, thịt ngọt, lành tính và sống trong thiên nhiên. Khô cá lưỡi trâu được đánh giá là khô ngon nhất tuy đạm bạc nhưng độc đáo nhờ thịt ngọt, mềm và mùi vị thơm ngon không chê được', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai, DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (61, N'Khô cá cơm sữa Phong Phương',6,  110000, 10, 0.2, N'Cá cơm sữa là một loại cá cơm rất nhỏ, dài chỉ khoảng 3 phân, thịt trong suốt. Cá cơm sữa có hương vị rất đậm đà, thịt cá ngon ngọt và cực kỳ giàu chất dinh dưỡng, không hề thua kém các loại cá khác.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (62, N'Khô cá đù Song Phương',6, 110000, 10, 0.2, N'Khô cá đù nhiều thịt và ít xương hơn hẳn các loại cá khác. Cá đù ngon ở chỗ phần thân sau của cá cực kỳ béo và nhiều mỡ. Thịt cá khá là ngọt, bùi bùi và với điểm nhấn là vị béo ở phần đuôi làm chúng ta ăn hoài không thấy ngán.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (63, N'Giấy vệ sinh CAT Premium',2, 20000, 10, 0, N'10 cuộn/ túi, 3 lớp. Nơi sản xuất:Việt Nam, Bảo hành:5 Năm', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (64, N'GIẤY VỆ SINH CUỘN LỚN CHUYÊN CHO KS, TÒA NHÀ, VP, NHÀ HÀNG',2, 24500, 10, 0, N'Phân hủy trong nước nhanh giảm thiểu nguy cơtắc nghẽn. Dai vừa phải, hơi bông xốp, êm nhẹ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (65, N'GIẤY CUỘN DÀI THẤM HÚT DẦU ĂN',2, 17000, 10, 0, N'Thành phần: 100% Bột giấy.Đặc điểm: Không lẫn giấy tái chế, không hóa chất độc hại', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (66, N'Bộ khăn sữa Mollis 100% bamboo ',2, 209000, 10, 0, N'Được làm từ 100% sợi bamboo, cực kỳ mềm mại và thoáng mát, giúp cho mẹ vệ sinh mặt, mũi cho em bé mà không sợ khô, rát bé', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (67, N'Khăn lạnh Wuna không mùi ',2, 180000, 10, 0, N'Thành phần Vải không dệt, nước tinh khiết R.O, Quaternary Ammonium Salts, Citric Acid, hương thơm', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (68, N'Khăn giấy ướt dạng nén Nikkori 50 cái',2, 85000, 10, 0, N'Khăn giấy nén mềm mại, hợp vệ sinh, tiêu hủy nhanh, không ảnh hưởng đến môi trường, an toàn mọi loại da. Đặc biệt làn da trẻ sơ sinh', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (69, N'Khăn ướt Hensley không mùi ',2, 48500, 10, 0, N'Không có chất tăng trắng quang học, không chứa cồn, không chất tạo màu, không hoá chất bảo quản, không hương liệu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (70, N'Khăn ướt em bé Bobby',2,39000, 10, 0, N'Chăm sóc vệ sinh da, thích hợp khi thay tã cho bé, tăng cường khả năng kháng khuẩn nhờ công nghệ Nano Bạc', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (81, N'Bàn chải cho bé từ 4 tuổi Splat',5, 89000, 10, 0, N'Lông bàn chải làm bằng vật liệu cao cấp chứa ion bạc ngăn ngừa sự phát triển của vi khuẩn và làm sạch hiệu quả Không chứa', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (82, N'Bộ 3 bàn chải Oral-B Pro-Health',5, 80000, 10, 0, N'Chải răng theo hướng dẫn của nha sĩ. Rửa sạch bàn chải sau khi sử dụng. Cắm thẳng và giữ nơi khô ráo', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (83, N'Bộ 2 bàn chải Oral-Clean Spiral Carbon Gold',5, 69000, 10, 0, N' Chải răng theo hướng dẫn của nha sĩ. Rửa sạch bàn chải sau khi sử dụng. Cắm thẳng và giữ nơi khô ráo', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (84, N'Bàn chải đánh răng người lớn Bamboo Salt',5, 49000, 10, 0, N'Bàn chải đánh răng người lớn Bamboo Salt muối hồng Himalaya lông tơ mềm mại HSD hơn 3 năm', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (85, N'Kem đánh răng Splat Special thảo mộc',5, 127000, 10, 0, N'Nên chải răng 2 lần/ngày sau khi ăn. Sử dụng trong vòng 12 tháng sau khi mở nắp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (86, N'Kem đánh răng Splat Special than hoạt tính',5, 127000, 10, 0.5, N'Nên chải răng 2 lần/ngày sau khi ăn. Sử dụng trong vòng 12 tháng sau khi mở nắp', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (87, N'Kem đánh răng Splat phục hồi men & trắng răng',5, 84000, 10, 0, N' Nên chải răng 2 lần/ngày sau khi ăn. Sử dụng trong vòng 12 tháng sau khi mở nắp', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (88, N'Kem đánh răng Colgate Sensitive Pro Relief Complete',5, 69000, 10, 0, N' Giảm ê buốt nhanh chóng và lâu dài, ngừa sâu răng, chăm sóc nướu, giúp trắng răng, giảm mảng bám, bảo vệ men răng, hơi thở thơm mát', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (89, N'Kem đánh răng Perioe Pumping hương bạc hà',5, 169000, 10, 0, N'Trẻ dưới 2-6 tuổi chỉ sử dụng một lượng kem nhỏ bằng hạt đậu và cần sự hướng dẫn của người lớn. Trẻ em dưới 2 tuổi cần có sự tư vấn của nha sĩ hoặc bác sĩ', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (90, N'Bột đánh trắng răng Eucryl Toothpowder',5 , 55000, 10, 0, N'Loại bỏ mảng bám bẩn, giúp trắng răng, ngăn hôi miệng, răng sáng bóng, chắc khỏe', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (91, N'Nước ngọt có ga Coca Cola Zero chai 390ml',7, 6500, 10, 0, N'Nước bão hòa CO2, màu tự nhiên, chất điều chỉnh độ acid, chất tạo ngọt tổng hợp, chất bảo quản, hương cola tự nhiên và caffeine.', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (92, N'24 lon nước tăng lực Monster Energy Ultra 355ml',7, 696000, 10, 0, N'Lắc nhẹ trước khi uống, dùng ngay sau khi mở nắp. Ngon hơn khi uống lạnh.', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (93, N'Trà xanh hương chanh C2 Plus Immunity ít đường 500ml',7, 12000, 10, 0, N'Để nơi khô ráo, thoáng mát, tránh ánh sáng trực tiếp hoặc nơi có nhiệt độ cao.', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (94, N'nước ngọt Mirinda vị cam 330ml',7, 8000, 10, 0, N'Nước bão hoà CO2, đường mía, đường HFCS, chất điều chỉnh độ acid, tinh bột biến tính, chất bảo quản, chất nhũ hoá, hương cam tự nhiên, màu tổng hợp', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (95, N'nước tăng lực Wake Up 247 vị cà phê 330ml',7, 7800, 10, 0, N' Nước, đường, C02 thực phẩm, màu tổng hợp caramen, hương vani, hương cà phê, caffeine, taurine, inositol, vitamin B3, vitamin B6, chất điều chỉnh độ axit, muối', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (96, N'tăng lực Compact vị cherry 330ml',7, 9100, 10, 0, N'Nước, đường, glucose syrup, chất điều chỉnh độ acid (330, 500ii), chất tạo khí carbonic (290), hương liệu (hương mật hoa tự nhiên, hương cherry tổng hợp, giống tự nhiên)', 10);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (97, N'trà xanh matcha Tea Plus 455ml',7, 82000, 10, 0, N' Để nơi khô ráo, thoáng mát, tránh ánh sáng trực tiếp hoặc nơi có nhiệt độ cao.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (98, N'Revive chanh muối 390ml',7, 78000, 10, 0, N'Lắc nhẹ trước khi uống, dùng ngay sau khi mở nắp. Ngon hơn khi uống lạnh.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (99, N'Cà phê đen TNI King Coffee Espresso 250g ( 100 gói x 2.5g )',7, 295000, 10, 0, N'UỐNG NÓNG dùng 1 gói pha với 70ml nước nóng. Có thể thêm sữa hoặc đường tuỳ sở thích', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (100, N'Strongbow dâu đen 330ml',7, 21000, 10, 0, N' Sản phẩm dành cho người trên 18 tuổi và không dành cho phụ nữ mang thai. Thưởng thức có trách nhiệm, đã uống đồ uống có cồn thì không lái xe!', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (101, N'bia Heineken 0.0% độ cồn 330ml',7, 15000, 10, 0, N' Sản phẩm dành cho người trên 18 tuổi và không dành cho phụ nữ mang thai. Thưởng thức có trách nhiệm, đã uống đồ uống có cồn thì không lái xe!', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (102, N'bia Tiger Crystal 330ml',7, 11000, 10, 0, N'Bia Tiger Crystal 330ml không chỉ đạt đến chất lượng rạng danh trên toàn thế giới mà còn mang đến cảm giác thật sảng khoái và rất dễ uống cho người dùng.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (103, N'chai trà sữa Kirin Tea Break 345ml',7, 10000, 10, 0, N'Trà sữa Tea Break chai 345ml với nguyên liệu tự nhiên kết hợp với nhau tạo nên hương vị của sữa rất đặc trưng.  không quá béo giúp người dùng cảm thấy ngon miệng không bị ngậy.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (104, N'hộp sữa tươi nguyên chất không đường Vinamilk 100% Organic 1 lít',8, 52000, 10, 0, N'Sữa tươi tiệt trùng Vinamilk có hương vị sữa tươi 100% hữu cơ thơm ngon, hấp dẫn.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (105, N'hộp sữa tươi tiệt trùng đường đen Nutimilk 1 lít',8, 38000, 10, 0, N'Sữa bò tươi, đường tinh luyện, si-rô, đường đen, chất ổn định, hương liệu tổng hợp dành cho thực phẩm,...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (106, N'sữa tươi tiệt trùng hương dâu TH true MILK 180ml',8, 32000, 10, 0, N'thơm ngon, dễ uống, được làm hoàn toàn từ nguồn sữa tươi sạch. Trong sữa chứa nhiều dưỡng chất thiết yếu tốt cho sức khoẻ như Vitamin A, D, B1, B2, Canxi, kẽm...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (107, N'Thùng 12 hộp sữa tươi tiệt trùng TH true MILK Organic',8, 378000, 10, 0, N'Sản phẩm hữu cơ không chứa chất bảo quản, rất an toàn cho sức khoẻ, trong sữa còn chứa nhiều dưỡng chất thiết yếu cũng như hương vị thơm ngon, béo ngậy đặc trưng.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (108, N'Thùng 12 hộp sữa đậu đen óc chó hạnh nhân Sahmyook',8, 950000, 10, 0, N' Nước đậu đen, bột đậu nành, đường trắng, siro ngô fructose cao, chất nhũ hóa, bột quả óc chó, bột đậu đen, bột hạnh nhân, muối, bơ hạt thông, dầu thực vật.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (109, N'sữa đậu nành hạnh nhân Vinamilk 180ml',8, 12000, 10, 0, N'Phù hợp Dùng cho trẻ từ 4 tuổi trở lên', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (110, N'Thùng 16 hộp sữa đậu nành vị hạnh nhân và óc chó Vegemil',8, 216000, 10, 0, N'Sữa đậu nành (nước tinh khiết, đậu nành 7%), đường, maltooligosacarit, xi rô ngô hàm lượng cao fructose, nước, quả óc chó và hỗn hợp các loại hạt ', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (111, N'Ngôi sao Phương Nam xanh lá ',8, 60000, 10, 0, N'Thích hợp Pha cà phê, xay sinh tố, làm sữa chua, bánh flan...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (112, N'Kem đặc có đường DeliPure lon 1kg',8, 35000, 10, 0, N'Pha một lượng creamer theo khẩu vị sản phẩm với khoảng 60ml nước đun sôi, sau đó để nguội rồi uống.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (113, N'Sữa đặc có đường Ông Thọ trắng nhãn vàng lon 380g',8, 29000, 10, 0, N'Pha một phần sữa với 3 phần nước ấm để uống hoặc pha cùng cà phê, ăn cùng bánh mì,...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (114, N'Thùng 24 chai sữa chua uống nha đam Vinamilk Yomilk 150ml',8, 139000, 10, 0, N'Thành phần Nước, đường tinh luyện, chất béo sữa,...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (115, N'Lốc 8 hộp sữa lúa mạch Milo Active Go 115ml',8, 34000, 10, 0, N'Nước, sữa - milk 35% nước, sữa bột, chất béo sữa, bột whey từ sữa), PROTOMALT 3,3% (chiết xuất từ mầm lúa mạch - extract from malted barley), đường 33%),', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (116, N'Sữa bột Ensure Gold lúa mạch ít ngọt hộp 850g',8, 732000, 10, 0, N'Để đáp ứng nhu cầu dinh dưỡng cho người lớn tuổi, hỗ trợ tăng cường sức khỏe, thể chất và chất lượng cuộc sống', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (117, N'Sữa bột Frisomum Gold hương cam lon 900g',8, 561000, 10, 0, N'Phù hợp Phụ nữ mang thai và cho con bú', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (118, N'Rong biển hữu cơ ăn liền cho bé Alvins hộp 20g',9, 118000, 10, 0, N'Thành phần Rong biển (chứng nhận hữu cơ Hàn Quốc), dầu Canola, muối biển', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (119, N'Snack khoai tây Slide vị phô mai lon 160g',9, 48000, 10, 0, N'Thành phần Vẩy khoai tây (70%), bột gia vị phô mai, tinh bột khoai tây, tinh bột khoa mìi ', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (110, N'Snack que nhân cà phê moka và sữa dừa Akiko Oishi lon 240g',9, 46000, 10, 0, N'Không dùng cho người dị ứng với sữa, trứng, đậu nành, lúa mì từ bột gia vị. Sản phẩm có thể chứa cá từ sản phẩm khác, sản xuất trên cùng dây chuyền', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (111, N'Snack da cá vị ớt xanh Pati gói 50g',9, 41000, 10, 0, N' Da cá 85%, gia vị ớt xanh (maltodextrin, đường, dextrose, muối, chất điều vị, protein thực vật thuỷ phân, gia vị - tỏi, ớt cựa gà, thì là, bột tỏi, bột giấm, hương tự nhiên', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (112, N'Snack que nhân sữa và phô mai Akiko Oishi lon 240g',9, 39000, 10, 0, N'Không dùng cho người dị ứng với sữa, trứng, đậu nành, lúa mì từ bột gia vị. Sản phẩm có thể chứa cá từ sản phẩm khác, sản xuất trên cùng dây chuyền', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (113, N'Bánh quy bơ Danisa hộp 681g',9, 191000, 10, 0, N' Bột lúa mì, đường, bơ (18.67%), dầu thực vật (chứa chất chống oxy hóa tocopherol), glucose syrup, trứng, dừa sấy, nho kho, bột sữa tách béo, muối, chất tạo xốp E503, hương vani tổng hợp.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (114, N'Bánh quy bơ thập cẩm LU hộp 708g',9, 235000, 10, 0, N'Bột mì, đường, bơ Pháp (12%), shortening, nhân sôcôla hỗn hợp (đường, chất béo thực vật hydro hóa, bột cacao, dextrose, chất nhũ hóa (322(i)), hương thực phẩm tổng hợp, muối)', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (115, N'Bánh quy ngũ cốc không đường Vitamia gói 330g',9, 112000, 10, 0, N'Bột mì (35,4%), ngũ cốc dạng bột và vẩy (24,6%), chất tạo ngọt tổng hợp, dầu hướng dương, bơ, muối, chất tạo xốp,...', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (116, N'Bánh gấu 3 vị Assortment Meiji Hello Panda ',9, 108000, 10, 0, N' Sản phẩm có chứa bột mì, lúa mạch (ngũ cốc chứa gluten), sữa và đậu nành, có thể chứa hạt mè.', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (117, N'Kẹo Ferrero Confetteria Raffaello ',9, 180000, 10, 0, N' Dừa khô 25.5%, chất béo thực vật, đường, hạt hạnh nhân nguyên hạt 8%, sữa bột gầy, whey bột, bột mì, tinh bột sắn, hương liệu tự nhiên và giống tự nhiên, chất nhũ hoá, chất tạo xốp', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (118, N'Bánh gạo vị ngọt Richy gói 315g',9, 40000, 10, 0, N'Gạo thơm, dầu thực vật, đường tinh luyện, tinh bột khoai tây, muối, gelatin, monosodium glutamate, chất điều vị', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (119, N'Bánh que Glico Pocky dâu và socola',9, 100000, 10, 0, N'Thành phần Bột mì, đường, dầu thực vật, bột sữa tách béo,..', 14);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (120, N'Socola Ferrero hộp 375g',9, 360000, 10, 0, N'Socola sữa 30% (đường, bơ, ca cao, bột ca cao, sữa bột gầy, chất béo sữa dạng khan, chất nhũ hoá, chất tạo xốp, hương liệu giống tự nhiên, hạt phỉ 28.5%, muối,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (121, N'Thùng 30 gói mì Mama hương thịt bò hầm 60g',10, 190000, 10, 0, N' Bột mì 79%, dầu cọ, muối, đường, gia vị, chất điều vị (E621, E35), hương liệu (cần tây) 0.75%, nước tương (đậu tương, muối, chiết xuất mạch nha, lúa mì, nấm men, dầu cọ), hành tây sấy khô', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (122, N'Thùng 40 gói mì bò cay Samyang Sutah Ramen 120g',10, 840000, 10, 0, N'ho mì, gói súp, gói rau vào trong 550ml nước sôi và nấu khoảng 4-5 phút. Để hương vị ngon hơn, có thể thêm kim chi, trứng, tỏi và hành lá.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (123, N'Thùng 10 túi mì Koreno Jumbo vị kim chi 1kg',10, 760000, 10, 0, N'Đun sôi 400ml ~ 450ml nước. Cho vắt mì, gói gia vị, gói rau vào nồi cùng một lúc, nấu trong 4 phút. Sau đó tắt bếp, múc ra bát và dùng được ngay. Sẽ ngon hơn khi bạn cho thêm trứng, hành, rau thơm.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (124, N'Thùng 50 gói mì Udon Hanil Bongojang 200g',10, 745000, 10, 0, N' Nước 64%, bột mì 34.16%, tinh bột sắn 0.95%, muối 0.79%, chất điều chỉnh vị chua (axit lactic, axit acetic, sodium laclate, axit adipic, nước) 0.1%.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (125, N'Thùng 36 ly mì Mama vịt tiềm 60g',10, 610000, 10, 0, N'Bột mì 75,48%, dầu cọ 6,25%, dầu nành 1,75%, gia vị 1,21%, hương vịt 0,75%, bột tỏi, bột ớt, bột ngọt,...', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (126, N'Thùng 20 gói mì cay hải sản Paldo 120g',10, 399000, 10, 0, N' Cho mì, gói gia vị vào 560ml nước sôi và nấu trong 4 phút cho mì mềm. Khuấy đều mì để ăn.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (127, N'Thùng 18 gói mì thịt bằm Vifon Hoàng Gia 120g',10, 250000, 10, 0, N' Cho vắt mì và các gói gia vị vào tô. Rót vào tô khoảng 400ml nước sôi. Đậy kín nắp tô và chờ khoảng 3 phút. Mở nắp, cắt gói thịt hầm cho vào tô, khuấy đều là có thể dùng được.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (128, N'gói mì Vị Hương giấy vàng 60g',10, 2500, 10, 0, N'Cho vắt mì và các gói gia vị vào tô. Chế nước sôi vào khoảng 350ml, đậy nắp lại và chờ trong 3 phút. Mở nắp, trộn đều và dùng được ngay.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (129, N' mì thịt bằm Vifon Hoàng Gia 120g',10, 3000, 10, 0, N'Cho vắt mì và các gói gia vị vào tô. Rót vào tô khoảng 400ml nước sôi. Đậy kín nắp tô và chờ khoảng 3 phút. Mở nắp, cắt gói thịt hầm cho vào tô, khuấy đều là có thể dùng được.', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (130, N'mì rong biển Jin Ottogi 120g',10, 12000, 10, 0, N'1/Trước tiên cho 550ml nước vào nồi và gói rau củ sấy khô vào đun sôi.2/Khi nước sôi thì cho gói súp gia vị và mì vào rồi đun sôi khoảng 5 phút là được', 24);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (131, N'Cây đánh trứng Silicone 25cm Shika',13, 52000, 10, 0, N'Dài 25 cm cầm gọn tay người lớn, trọng lượng nhẹ tiện thao tác, dùng lâu không sợ mỏi tay', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (132, N'Khuôn làm kem nhựa Hofaco HPL64',13, 35000, 10, 0, N'Kích thước 14.5cm x 13cm x 8.8cm', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (133, N'Phin cà phê inox Tithafac 7cm',13, 31000, 10, 0, N'Công dụng Sử dụng pha chế cà phê truyền thống, chắt lọc giọt cà phê sạch cặn, thơm ngon', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (134, N'Vỉ hấp nhựa Điện máy XANH LD-SU616 24cm',13, 80000, 10, 0, N'Vỉ hấp thiết kế nâu xám, đường kính viền 24.5 cm gọn đẹp tiện dụng. Vỉ hấp có thể điều chỉnh phù hợp với từng loại nồi chảo có đường kính khác nhau ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (135, N'Bếp cồn inox Rainy hoa mai 23 BCI',13, 65000, 10, 0, N' Bếp được làm bằng inox có độ bền cao, có ưu điểm tỏa nhiệt đều, nóng nhanh, tiết kiệm nhiên liệu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (136, N'Bếp cồn inox Rainy tráng men 23 BCM',13, 70000, 10, 0, N'Bếp được làm bằng inox tráng men có độ bền cao, có ưu điểm tỏa nhiệt đều, nóng nhanh, tiết kiệm nhiên liệu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (137, N'Gel rửa tay khô Kleen hương trà xanh chai 630ml',14, 110000, 10, 0, N'Sử dụng cồn 96% và dưỡng chất giúp kháng khuẩn hiệu quả và dưỡng ẩm da tay', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (138, N'Gel rửa tay khô Kleen hương oải hương chai 630ml',14, 110000, 10, 0, N'Cho một lượng nhỏ vào lòng bàn tay và xoa đều. Không cần rửa tay lại với nước', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (139, N'Gel rửa tay khô Dr. Clean hương lavender chai 500ml',14, 106000, 10, 0, N'Làm sạch 99.9% vi khuẩn. Đôi tay luôn mềm mại, sạch sẽ, tươi mát và bay bổng', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (140, N'Gel rửa tay khô Lifebuoy bảo vệ vượt trội chai 235ml',14, 72000, 10, 0, N' Tiện dụng rửa tay mà không cần dùng nước. Vệ sinh, diệt khuẩn, khử sạch mùi rất tốt để bảo sức khỏe, giữ cho đôi tay luôn sạch sẽ và mềm mai', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (141, N'Nước rửa tay Kirei Kirei hương chanh chai 250ml',14, 74000, 10, 0, N'Bọt rửa tay Kirei Kirei Hương chanh Chai 250 ml với chiết xuất 100% tinh chất từ thảo dược thiên nhiên cùng công thức diệt khuẩn đặc biệt cho bạn ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (142, N'Nước rửa tay Lifebuoy bảo vệ vượt trội túi 443ml',14, 53000, 10, 0, N'Làm ướt tay. Cho một lượng vừa đủ vào lòng bàn tay, xoa đều trên tay và rửa sạch với nước', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (143, N'Sữa rửa tay Goodlook dưỡng da hương táo 500ml',14, 45000, 10, 0, N' Dưỡng da và ngăn ngừa vi khuẩn, giữ cho da tay luôn mềm mại, mịn màng', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (144, N'Nước rửa tay Aqua Vera dưỡng da hoa tử đinh hương 500ml',14, 39000, 10, 0, N'Giúp làm sạch vi khuẩn và bổ sung glycerin dưỡng ẩm mịn màng, cho da tay bạn trở nên mềm mại sau khi sử dụng', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (145, N'Nước giặt xả Act',15, 420000, 10, 0, N'Loại bỏ vết bẩn, diệt trừ vi khuẩn và các tác nhân gây hại như bụi bẩn, bọ, ve, rệp và các tác nhân gây dị ứng, ngạt mũi khác. Khử mùi ngay cả khi phơi trong điều kiện ẩm ướt, phơi trong nhà.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (146, N'Nước giặt Essence hương floral 3.5 lít',15, 309000, 10, 0, N'Hòa tan kỹ nước giặt Essence với nước trước khi cho quần áo vào nước với tỷ lệ 1 nắp đầy hòa với 3 - 4 lít nước ngâm quần áo trong 5 phút, vò nhẹ, xả qua với nước. Đối với máy giặt theo tỷ lệ 4 - 6 nắp cho 1 lần giặt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (147, N'Bột giặt Tide chuyên dụng 9kg',15, 300000, 10, 0, N'Công thức trắng đột phá chăm sóc sợi vải cho các cơ sở chuyên nghiệp. Đánh bay và loại bỏ các vết bẩn ở cổ tay, cổ áo, vết dầu mỡ, hay bùn đất bám dính lâu ngày.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (148, N'Nước giặt xả hữu cơ sinh học Giel 2 in 1',15, 300000, 10, 0, N'Chà xanh, chanh, lô gội, hỗ cây liễu kết hợp tinh chất hương hoa tự nhiên thơm mát,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (149, N'Nước giặt xả Sanzoft ',15, 259000, 10, 0, N'Giặt sạch quần áo, chăn màn, vải vóc. Phù hợp với mọi loại vải. Lưu lại hương thơm nhẹ nhàng quyến rũ. Giữ sắc màu quần áo luôn tươi mới', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (150, N'Nước giặt Ariel Matic sạch nhanh 3.64 lít',15, 239000, 10, 0, N'Thấm sâu vào từng sợi vải dễ dàng tẩy sạch các vết bẩn tốt hơn gấp 2 lần', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (151, N'Bột giặt Mỹ Hảo 5X diệt khuẩn 6kg',15, 220000, 10, 0, N'Loại bỏ các vết bẩn khó giặt, không tái bám vết bẩn. Diệt khuẩn hiệu quả, khử mùi mồ hôi.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (152, N'Nước giặt Attack hương hoa anh đào 2.4kg',15, 180000, 10, 0, N'Giặt sạch các vết bẩn khó giặt như vết dầu mỡ, dầu xe, vết bẩn từ thúc ăn, đồ uống, vết mực, vết bẩn cổ tay, cổ áo cho áo quần sachh thơm toàn diện.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (153, N'Sữa tắm hạt ON THE BODY Veilment Spa Lavender 600g',16, 316000, 10, 0, N'Nhẹ nhàng làm sạch lớp tế bào chết trên da nhờ thành phần từ thực vật, dịu nhẹ và an toàn giúp da ngày càng sáng mịn', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (154, N'Sữa tắm tinh chất thảo mộc Body Shower 750ml',16, 237000, 10, 0, N'Kháng khuẩn, cân bằng ẩm, bảo vệ da khỏi tác hại của môi trường', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (155, N'Sữa tắm Purité dưỡng ẩm sữa ong chúa và hoa anh đào 850ml',16, 210000, 10, 0, N'Dưỡng ẩm sâu từ sữa ong chúa nhẹ nhàng làm sạch da, đồng thời cung cấp độ ẩm sâu cho da', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (156, N'Sữa tắm nước hoa Enchanteur Deluxe Charming 900g',16, 216000, 10, 0, N'Làm sạch da, giúp làn da mềm mịn, hương thơm dài lâu quyến rũ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (157, N'Sữa tắm Cathy Doll White Tofu 750ml',16, 180000, 10, 0, N'Làm sạch bụi bẩn và cặn bã dư thừa triệt để, dưỡng da mịn màng trắng sáng', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (158, N'Sữa tắm detox',16, 117000, 10, 0, N'Lấy một lượng sản phẩm vừa đủ ra bông tắm hoặc miếng bọt biển đã được làm ướt và tạo bọt. Xoa bọt khắp cơ thể và làm sạch lại với nước', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (159, N'Sữa tắm bảo vệ khỏi vi khuẩn Lifebuoy',16, 153000, 10, 0, N' Công thức ion bạc và bạc hà giúp bảo vệ cơ thể khỏi vi khuẩn gấp 10 lần, cho da mát lạnh sảng khoái', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (160, N'Sữa tắm dưỡng sáng Hazeline matcha',16, 140000, 10, 0, N' Dưỡng da trắng sáng rạng ngời, dưỡng ẩm da', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (161, N'Sữa tắm nước hoa Romano Attitude sạch sảng khoái 650g',16, 134000, 10, 0, N'Giữ ẩm cho da sạch đầy sức sống cùng mùi hương nam tính mạnh mẽ mang lại dấu ấn của người đàn ông lịch lãm, đầy quyến rũ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (162, N'Dầu gội sạch gàu Head & Shoulders',17, 347000, 10, 0, N'Làm ướt tóc, xoa dầu gội nhẹ nhàng lên tóc và da đầu, mát-xa và xả sạch lại với nước. Gội thêm lần nữa nếu muốn.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (163, N'Dầu gội Dove phục hồi hư tổn 1.36 lít',17, 273000, 10, 0, N'Phục hồi bề mặt tóc tức thì và nuôi dưỡng sâu giúp tái cấu trúc sợi tóc từ sâu bên trong, cho mái tóc bạn chắc khoẻ dài lâu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (164, N'Dầu gội Sunsilk mềm mượt diệu kỳ 1.36 lít',17, 248000, 10, 0, N' Công thức độc quyền với công nghệ khoá ẩm và 5 tinh dầu tự nhiên giúp lưu giữ độ ẩm cần thiết cho mái tóc luôn mềm mượt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (165, N'Dầu gội TRESemmé Salon Detox',17, 221000, 10, 0, N' Bù đắp dưỡng chất cho tóc, làm sạch sâu, nuôi dưỡng tóc chắc khoẻ và bóng mượt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (166, N'Dầu gội Head & Shoulders Classic Clean 700ml',17,2150000, 10, 0, N'Trị gàu, làm sạch da đầu, giúp tóc luôn mềm mượt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (167, N'Dầu gội nước hoa Elastine Kiss The Rose 1000ml',17,1680000, 10, 0, N' Làm ướt tóc, lấy một lượng dầu gội vừa đủ thoa lên tóc, tạo bọt mát xa nhẹ nhàng để mùi hương tỏa đều trên tóc. Gội sạch lại với nước.', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (168, N'Dầu gội nước hoa X-Men For Boss Intense 650g',17, 186000, 10, 0, N'Để xa tầm tay trẻ em. Tránh để sản phẩm dính vào mắt. Nếu dính vào mắt hãy rửa sạch với nước', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (169, N'Dầu gội TRESemmé Salon Detox gừng và trà xanh 631ml',17, 187000, 10, 0, N'Bù đắp dưỡng chất cho tóc, làm sạch sâu, nuôi dưỡng tóc chắc khoẻ và bóng mượt', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (170, N'Dầu xả phục hồi hư tổn Tsubaki 500ml',17, 179000, 10, 0, N' Hợp chất đặc biệt bổ sung Protein, Lipit, hợp chất hoa trà lên men và chiết xuất tinh dầu hoa trà Nhật Bản', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (171, N'Rau Dền 4KFarm túi 200-300g',21, 4000, 5, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (172, N'Rau Mùng Tơi 4KFarm túi 200-300g',21, 8000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (173, N'Cải Dúng 4KFarm túi 300g',21, 9000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (174, N'Cải xoăn túi 500g',21, 27000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (175, N'Khoai mỡ túi 1kg',21, 47000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (176, N'Nấm mỡ trắng hộp 150g',21, 45000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (177, N'Xà lách Romaine thủy canh túi 300g',21, 25000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (178, N'Bí đỏ hồ lô túi 700g',21, 23000, 10, 0, N'Sạch như rau nhà', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (179, N'Táo Envy hộp 1kg',22, 242000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (180, N'Nho đỏ không hạt hộp 1kg',22, 186000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (181, N'Lê Nam Phi nhập khẩu hộp 1kg (5 - 6 trái)',22, 86000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (182, N'Xoài cát Hoà Lộc túi 1kg',22, 39000, 10, 0, N'đặc sản của miền Tây bởi hương vị thơm ngon, màu sắc bắt mắt, nguồn dinh dưỡng cao. Không chỉ nổi tiếng ở trong nước, xoài cát Hoà Lộc còn là loại trái cây xuất khẩu top đầu trong các loại hoa quả sạch trên thế giới. ', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (183, N'Bơ túi 1kg',22, 34000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (184, N'Lê Singo nhập khẩu Trung Quốc hộp 1kg',22, 58000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (185, N'Mãng cầu na túi 500g',22, 31000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (186, N'Thanh long hồng túi 1kg',22, 44000, 10, 0, N'Hoa quả tươi nhập khẩu', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (187, N'Mứt phúc bồn tử La Fresh hũ 210g',23,65000, 10, 0, N'Phúc bồn tử (40%), đường mía (50%), pectin quả, chất bảo quản (202) và nước (10%)', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (188, N'Mứt cam Preserves Golden Farm hũ 450g',23, 60000, 10, 0, N'Trái cam (45 - 60%), đường mía RE, siro bắp, nước, chất ổn định, chất điều chỉnh độ acid, chất bảo quản, hương cam tổng hợp, màu thực phẩm tổng hợp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (189, N'Mứt nho Preserves Golden Farm hũ 450g',23, 70000, 10, 0, N'Trái nho (45 - 60%), đường mía RE, siro bắp, nước, chất ổn định, chất điều chỉnh độ chua, chất bảo quản, hương nho tổng hợp, chất tạo màu tổng hợp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (180, N'Mứt dâu tằm Golden Farm hũ 450g',23, 56000, 10, 0, N'Thương hiệu Golden Farm (Việt Nam)', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (191, N'Mứt thơm Preserves Golden Farm hũ 210g',23, 29000, 10, 0, N'Trái thơm (45 - 60%), đường mía RE, siro bắp, nước, chất ổn định, chất điều chỉnh độ chua, chất bảo quản, hương thơm tổng hợp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (192, N'Lốc 3 hũ mứt dâu Preserves Golden Farm 30g',23, 30000, 10, 0, N' Ăn kèm kem, sinh tố, bánh mì, trà nóng', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (193, N'Mứt việt quất Preserves Golden Farm hũ 210g',23, 40000, 10, 0, N' Bảo quản ở nơi khô ráo, thoáng mát. Giữ lạnh sau khi mở nắp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (194, N'Hộp quà Orion An hộp 703.8g',24, 135000, 10, 0, N' Bánh Choco.pie Bánh Cutas kem trứng Bánh Tok vị tảo biển Bánh Tok vị phô mai Bánh gạo nướng An vị tảo biển Bánh quy sô cô la Miz Thực phẩm bổ sung - Bánh Marine Boy vị rong biển tuyết xanh Kẹo họng vị quất - mật ong', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (195, N'Bánh kem trứng Custas hộp 470g (20 cái)',24, 99000, 10, 0, N'Trứng, bột mì, đường, chất béo thực vật, chất giữ ẩm, chất nhũ hoá, sữa bột nguyên kem, bột lòng đỏ trứng, chất ổn định,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (196, N'Bánh bông lan kem hỗn hợp 3 mùi Solo hộp 336g',24, 71000, 10, 0, N'Bột mì, đường, chất béo thực vật, trứng gà, mạch nha, chất giữ ẩm, bột bắp, chất nhũ hoá, sữa béo,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (197, N'Bánh bông lan  Solite hộp 324g (18 cái)',24, 50000, 10, 0, N' Để nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (198, N'Bánh bông lan Hura Deli hộp 336g (12 cái)',24,47000, 10, 0, N'Bột mì, đường, trứng, chất béo thực vật, mạch nha, bơ, sữa bột, chất giữ ẩm, chất nhũ hoá, nước, tinh bột bắp, chất tạo xốp, muối, sô cô la compound trắng, hương tổng hợp,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (199, N'Bánh bông lan  Quasure Light hộp 126g (7 cái)',24, 29000, 10, 0, N'Bột mì, trứng, isomalt, chất béo thực vật, mạch nha, chất giữ ẩm, đường, sữa bột, chất nhũ hoá, chất tạo xốp, muối, chất xơ hoà tan, vitamin, hương tổng hợp,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (200, N'Bánh bông lan tròn kem vị dâu Solite hộp 36g (2 cái)',24, 8000, 10, 0, N'Để nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (201, N'Thịt heo hầm Master T hộp 180g',33, 26000, 10, 0, N'Nạc heo, nước, hành tây, dầu thực vật, muối, đường, chất điều vị (621), chất ổn định (451i) và (1422), hương thịt tổng hợp, chất bảo quản (250)', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (202, N'Thịt heo hầm 3 Bông Mai Vissan hộp 150g',33, 22000, 10, 0, N'Thịt heo 50%, đường, muối, hành, tỏi, nước mắm,...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (203, N'Thịt vai heo Picnic Shoulder Categoria Extra Tulip hộp 454g',33, 212000, 10, 0, N'Ăn trực tiếp hoặc ăn kèm cơm, bánh mì, trộn salad', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (204, N'Heo hai lát Vissan hộp 150g',33, 26000, 10, 0, N'Nạc heo 55%, mỡ heo, nước, protein đậu nành, đường..', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (205, N'Cá ngừ sốt cà ri Dongwon lon 100g',33, 33000, 10, 0, N'Dùng trực tiếp hoặc hâm nóng trước khi dùng, ăn nhanh sau khi mở', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (206, N'Cá kho thịt 3 Bông mai Vissan hộp 150g',33, 17000, 10, 0, N'Cá nục (30%), thịt heo (25%), nước, ớt, hành, muối i-ốt, đường, chất điều vị (621), chất giữ ẩm (451i, 452i), tiêu đen xay, chất ổn định (1422), nước mắm, phẩm màu tổng hợp (150a)', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (207, N'Bò hầm Vissan hộp 150g',33, 35000, 10, 0, N'Thịt bò 55%, muối, đường, tỏi, hành...', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (208, N'Cá trích sốt cà Sea Crown hộp 155g',33, 12000, 10, 0, N'Cá trích 60%, sốt cà 27%, nước 11.7%, muối 1%, chất điều vị 0.3%', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (209, N'Cá mòi xốt cà chua nắp giật 3 Cô Gái hộp 155g (vị đậm đà)',33, 17000, 10, 0, N'Cá biển (cá mòi, cá ngân, cá nục,...) 60%, xốt cà chua 35%, dầu nành, đường, muối i-ốt, chất làm dày (1442, 1414, 412), chất điều vị 621, màu thực phẩm 160d', 3);
INSERT INTO HANGHOA (MaHH, TenHH, MaLoai,  DonGia, SoLuong, GiamGia, MoTa, MaNCC) values (210, N'Lốc 3 hộp Cá saba xốt nước tương Norlake 150g',33, 102000, 10, 0, N' Để nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp', 3);

CREATE TABLE KHACHHANG (
  MaKH NUMBER(10) NOT NULL,
  HoTen NVARCHAR2(50) ,
  DiaChi NVARCHAR2(60),
  DienThoai VARCHAR2(24),
  Email VARCHAR2(50) ,
  GioiTinh NUMBER(1) NOT NULL,
  NgaySinh DATE,
  CONSTRAINT pk_kh PRIMARY KEY (MaKH)
);

INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (1 , N'Không có thông tin' , N'Không có thông tin ', N'Không có thông tin', N'Không có thông tin', 1, NULL);
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (2 , N' Dương Viết Huy ', N'38  Quận 3 TP.Thủ Đức. ', N'0787755959', N'vmjv2710@gmail.com',1, TO_TIMESTAMP(N'2002-03-04' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (3 , N' Phạm Duy  Quốc ', N'44  Quận Tân Bình TP.Thủ Đức. ', N'0834476668', N'qsslscnk30@gmail.com',1, NULL);
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (4 , N' Nguyễn Uyển Huy ', N'631 Phường 69 Quận  TP.HCM. ', N'0020932763', N'kbefexd41@gmail.com',1, TO_TIMESTAMP(N'1994-12-31' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (5 , N' Lê Hoài Anh ', N'784  Quận 9 TP.Thủ Đức. ', N'0671941926', N'kaaeje.roqvka1@gmail.com',1, TO_TIMESTAMP(N'1985-11-19' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (6 , N' Hồ Kim Hoa ', N'684  Quận Tân Bình TP.Thủ Đức. ', N'0398966021', N'khdne390@gmail.com',1, TO_TIMESTAMP(N'1963-01-08' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (7 , N' Lê Hoài Anh ', N'240   TP.HCM. ', N'0655554774', N'fidyh.ibnf1@gmail.com', 0, TO_TIMESTAMP(N'1993-08-13' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (8 , N' Phạm Kim Đắc ', N'168 Đường số 57 Quận 5 TP.Thủ Đức. ', N'0732380140', N'mrrwkj.enrkhhkjqr0@gmail.com',1, TO_TIMESTAMP(N'1957-10-25' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (9 , N' Hoàng Duy  Quyên ', N'230   TP.Thủ Đức. ', N'0740700312', N'nqhopix.rcemq0@gmail.com',1, TO_TIMESTAMP(N'1962-05-30' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (10 , N' Hoàng Quốc Đại ', N'20   TP.Thủ Đức. ', N'0244590264', N'joyqgn0@gmail.com',1, TO_TIMESTAMP(N'1983-12-27' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (11 , N' Dương Hồng Khánh ', N'92   TP.HCM. ', N'0417320740', N'apmylw01@gmail.com', 0, TO_TIMESTAMP(N'2001-09-04' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (12 , N' Nguyễn Quốc Quyên ', N'69  Quận 9 TP.HCM. ', N'0451502575', N'cgblhkm960@gmail.com', 0, TO_TIMESTAMP(N'1978-10-21' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (13 , N' Hoàng Diệu Bảo ', N'72  Quận 1 TP.HCM. ', N'0065893874', N'abso5510@gmail.com', 0, TO_TIMESTAMP(N'1984-12-05' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (14 , N' Nguyễn Hồng Linh ', N'91   Quận Bình Tân TP.Thủ Đức. ', N'0859115665', N'hbufgey.dgiwezcpj1@gmail.com',1, TO_TIMESTAMP(N'1971-10-11' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (15 , N' Phùng Viết Khánh ', N'605 Đường số 90 Quận Bình Tân TP.HCM. ', N'0280617294', N'kipxk500@gmail.com', 0, TO_TIMESTAMP(N'1955-05-23' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (16 , N' Lý Duy  Tân ', N'46    TP.Thủ Đức. ', N'0541987693', N'aetd20@gmail.com',1, TO_TIMESTAMP(N'1973-06-11' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (17 , N' Đặng Quốc Lý ', N'68  Quận 3 TP.Thủ Đức. ', N'0200379503', N'zactutw8910@gmail.com',1, TO_TIMESTAMP(N'1992-04-01' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (18 , N' Phùng Diệu Trung ', N'18 Đường số 58  TP.Thủ Đức. ', N'0582512687', N'xylwvd.pwggdca1@gmail.com',1, TO_TIMESTAMP(N'1960-01-19' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (19 , N' Hồ Duy  Thiện ', N'77 Phường 43 Quận  Bình Chánh TP.Thủ Đức. ', N'0092623403', N'ifqqjg.qgcmciswsw0@gmail.com', 0, TO_TIMESTAMP(N'1980-09-20' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (20 , N'  Uyển Huy ', N'18  Quận 5 TP.Thủ Đức. ', N'0973672779', N'tlbqo5561@gmail.com', 0, TO_TIMESTAMP(N'1960-12-28' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (21 , N' Lê Diệu Nhung ', N'368   Quận  TP.HCM. ', N'0125927267', N'gkqynvn.tewpym1@gmail.com',1, TO_TIMESTAMP(N'2010-05-31' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (22 , N'  Uyển Thịnh ', N'30   TP.Thủ Đức. ', N'0072083741', N'jkgvzt.zbybioant0@gmail.com',1, TO_TIMESTAMP(N'1980-12-21' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (23 , N' Võ  Kim Phương ', N'24  Quận Bình Tân TP.HCM. ', N'0456957457', N'sujwi9210@gmail.com',1, TO_TIMESTAMP(N'1972-08-18' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (24 , N' Hoàng Viết Quyên ', N'46  Quận  Bình Chánh TP.HCM. ', N'0499517334', N'xrzee.grtunup1@gmail.com', 0, TO_TIMESTAMP(N'2002-02-12' ,'YYYY-MM-DD'));
INSERT INTO KHACHHANG (MaKH, HoTen, DiaChi, DienThoai, Email, GioiTinh, NgaySinh)VALUES (25 , N' Đặng  Ngọc Khánh ', N'79  Quận Bình Tân TP.HCM. ', N'0082731528', N'edivsuw.oxiwtqzyla0@gmail.com', 0, TO_TIMESTAMP(N'1957-11-13' ,'YYYY-MM-DD'));



CREATE TABLE HOADON (
  MaHD NUMBER(10) NOT NULL ,
  MaNV NUMBER(10) NOT NULL,
  MaChiNhanh NUMBER(10) NOT NULL,
  MaKH NUMBER(10),
  HoTen NVARCHAR2(50),
  DiaChi NVARCHAR2(60),
  SDT VARCHAR2(20),
  GhiChu NVARCHAR2(50),
  NgayTao Date NOT NULL,
  TongTienHang FLOAT,
  TongThucThu FLOAT,
  CONSTRAINT pk_hd PRIMARY KEY (MaHD),
  CONSTRAINT fk_hd_kh FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
  CONSTRAINT fk_hd_nv FOREIGN KEY (MANV) REFERENCES NHANVIEN(MaNV),
  CONSTRAINT fk_hd_cn FOREIGN KEY (MaChiNhanh) REFERENCES CHINHANH(MaChiNhanh)
);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (1, 17,1,1,N'Nguyẽn Thanh Sang',N'Bình Dương', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),135100,135000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (2, 18,2,2,N'Minh Cao', N'TPHCM', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),236800,237000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (3, 19,3,3,N'Nguyễn Thanh Sang', N'Q11', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),34500,345000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (4, 20,4,4,N'Nguyễn Ngọc Hiền', N'Gò Vấp', N'',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),1135100,1135000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (5, 21,5,5,N'Hồ  Quỳnh Nga', N'280 ADV', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),6800,6800);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (6, 22,6,6, N'Lê Thị Hiền', N'Bình Thạnh', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),135100,135000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (7, 23,7,7,N'Lê Thanh Sang', N'Thủ Đức', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),356100,256000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (8, 24,8,8,N'Hồ Viết Thọ', N'Q11', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),115100,115000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (9, 25,9,9,N'Nguyễn Quốc Hoàn', N'Q12', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),679000,679000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (10,26,10,19, N'Đinh Văn Thanh', N'Bình Thạnh', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),127800,127800);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (11,27,11,11,N'Ngô Đức Anh', N'Khu CN sóng Thần', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),13500,13500);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (12,28,12,12,N'Nguyễn Thị Ngọc Huyền', N' Vũng Tàu', N'0904877306',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),34200,34000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (13,29,13,13, N'Hồ Diệu Huyền', N'Q5', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),50000,50000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh, MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (14,30,14,14,N'Nguyễn Thị Uyển Cương', N'Thủ Đức', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),234000,234000);
INSERT INTO HOADON (MaHD, MANV,MaChiNhanh , MaKH,HoTen, DiaChi,SDT,GhiChu,NgayTao,TongTienHang,TongThucThu) VALUES (15,31,15,15, N'Lê Văn Hậu', N'Bình Tân', N'0971890712',N'',TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3'),135100,135000);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (16 , 32 , 1 , 1 , N'Lý Kim Khánh ', N'373 Phường 85 Quận Tân Bình TP.Thủ Đức. ', N'0918957075', N'Khẩu trang', TO_TIMESTAMP ('2010-10-15','YYYY-MM-DD'),  1377603.9045348782, 627021.17622551566);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (17 , 33 , 13 , 2 , N'Hoàng  Ngọc Lý ', N'30  4 TP.Thủ Đức. ', N'0191147336', N'Nước Khoáng', TO_TIMESTAMP ('2010-04-06','YYYY-MM-DD'),  873269.82775436237, 1713567.608970016);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (18 , 34 , 15 , 3 , N'Phạm Quốc Lý ', N'543  Quận 9 TP.HCM. ', N'0881220193', N'Kẹo mút', TO_TIMESTAMP ('2015-03-31','YYYY-MM-DD'),  186076.69316002945, 1425455.3479414692);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (19 , 35 , 11 , 5 , N'Trần  Thịnh ', N'66  Quận 2 TP.HCM. ', N'0182997729', N'Muối trắng', TO_TIMESTAMP ('2018-07-15','YYYY-MM-DD'),  1602433.0972518926, 1656546.7995612633);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (20 , 36 , 5 , 4 , N'Hồ  Ngọc Nhung ', N'24   TP.HCM. ', N'0841080316', N'Áo', TO_TIMESTAMP ('2014-06-29','YYYY-MM-DD'),  1581477.4844401877, 356500.044364715);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (21 , 37 , 13 , 6 , N'Phùng Diệu Quyên ', N'81    TP.Thủ Đức. ', N'0034011057', N'Kẹo mềm', TO_TIMESTAMP ('2011-05-16','YYYY-MM-DD'),  501684.15331080748, 767292.35921674047);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (22 , 38 , 13 , 7 , N'Trần Quốc Bảo ', N'87 Phường 59 Quận 1 TP.HCM. ', N'0503072721', N'Nước Hoa', TO_TIMESTAMP ('2017-11-01','YYYY-MM-DD'),  1910435.2655915706, 401863.32399624551);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (23 , 39 , 15 , 8 , N'Dương Thái Hoa ', N'40   TP.HCM. ', N'0913693704', N'Khẩu trang', TO_TIMESTAMP ('2016-07-05','YYYY-MM-DD'),  1515181.9015849298, 1853022.9172860379);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (24 , 40 , 1 , 9 , N'Lý Quốc Đắc ', N'925  Quận 1 TP.Thủ Đức. ', N'0702147427', N'Nước', TO_TIMESTAMP ('2018-04-02','YYYY-MM-DD'),  195822.20560210859, 894164.6183753222);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (25 , 41 , 11 , 1 , N'Phùng Uyển Đắc ', N'356  Quận Bình Tân TP.Thủ Đức. ', N'0624447012', N'Bim Bim', TO_TIMESTAMP ('2020-01-29','YYYY-MM-DD'),  27778.200999264696, 223691.62223566865);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (26 , 42 , 8 , 1 , N'Đặng Hồng Hùng ', N'65  Quận Bình Tân TP.Thủ Đức. ', N'0300929970', N'Nước khử trùng', TO_TIMESTAMP ('2011-09-20','YYYY-MM-DD'),  1585291.6538889015, 872014.49180674483);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (27 , 17 , 15 , 1 , N'Đặng  Ngọc Quyên ', N'585   Quận 9 TP.Thủ Đức. ', N'0301575725', N'Dầu ăn', TO_TIMESTAMP ('2014-07-22','YYYY-MM-DD'),  539120.82887260278, 258790.9914864185);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (28 , 18 , 11 , 1 , N'Hồ Thái Thịnh ', N'799  Quận 7 TP.Thủ Đức. ', N'0844307682', N'Kẹo cứng', TO_TIMESTAMP ('2016-03-08','YYYY-MM-DD'),  357411.38120899507, 1596007.6926429791);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (29 , 19 , 9 , 1 , N'Hồ Kim Đức ', N'253   TP.HCM. ', N'0257986039', N'Bim Bim', TO_TIMESTAMP ('2011-06-15','YYYY-MM-DD'),  802926.86879864288, 1355076.6478036887);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (30 , 20 , 2 , 1 , N'Lê Uyển Tân ', N'625   TP.HCM. ', N'0761846097', N'Nước Hoa', TO_TIMESTAMP ('2013-02-09','YYYY-MM-DD'),  165377.38249095966, 1775291.2043162116);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (31 , 21 , 3 , 1 , N'Phùng  Hoàng ', N'877  Quận 3 TP.Thủ Đức. ', N'0986268669', N'Kẹo ngậm', TO_TIMESTAMP ('2013-04-13','YYYY-MM-DD'),  1323846.2270693136, 62832.532599956045);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (32 , 22, 7 , 1 , N'Đặng Thái Phượng ', N'19    TP.Thủ Đức. ', N'0314868226', N'Đồ chơi', TO_TIMESTAMP ('2015-04-10','YYYY-MM-DD'),  1476925.6018562827, 4475.8392639811336);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (33 , 23 , 5 , 1 , N'Lý Hồng Thịnh ', N'833  Quận Bình Thạnh  TP.Thủ Đức. ', N'0543921358', N'Đồ chơi', TO_TIMESTAMP ('2016-10-15','YYYY-MM-DD'),  33092.162453146724, 836937.97136980016);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (34 , 24 , 15 , 1 , N'Trần Duy  Quang ', N'602  Quận 2 TP.HCM. ', N'0671423942', N'Kẹo mút', TO_TIMESTAMP ('2019-09-04','YYYY-MM-DD'),  1807003.0921720914, 1857119.2685613032);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (35 , 25 , 10 , 1 , N'Lý Quốc Đắc ', N'86 Đường số 37 Quận 1 TP.Thủ Đức. ', N'0034426222', N'Bút', TO_TIMESTAMP ('2017-06-02','YYYY-MM-DD'),  42873.51381726261, 740881.58233504824);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (36 , 26 , 12 , 1 , N' Duy  Vĩ ', N'271   TP.HCM. ', N'0382535560', N'Nước có ga', TO_TIMESTAMP ('2016-11-17','YYYY-MM-DD'),  1331378.1627013246, 1418010.857938794);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (37 , 27 , 1 , 1 , N' Quốc Diệu ', N'658  Quận 2 TP.HCM. ', N'0408585005', N'Muối trắng', TO_TIMESTAMP ('2016-05-16','YYYY-MM-DD'),  809187.93061943166, 466058.19364965806);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (38 , 28 , 6 , 11 , N'Hồ Hoài Cường ', N'70  Quận 2 TP.Thủ Đức. ', N'0979611097', N'Nước có ga', TO_TIMESTAMP ('2012-11-03','YYYY-MM-DD'),  1867370.7408320021, 1230686.877916421);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (39 , 29 , 6 , 12 , N'Dương Quốc Bảo ', N'839   TP.Thủ Đức. ', N'0903297450', N'Kẹo mềm', TO_TIMESTAMP ('2011-11-05','YYYY-MM-DD'),  665123.98788850941, 1007456.5538910481);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (40 , 30 , 15 , 13 , N'Lý Diệu Diệu ', N'50 Đường số 44  TP.HCM. ', N'0824769585', N'Bột ngọt', TO_TIMESTAMP ('2012-07-03','YYYY-MM-DD'),  1578396.5072321689, 714434.86134448787);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (41 , 31 , 8 , 14 , N'Dương  Ngọc Lý ', N'71  Quận Tân Bình TP.HCM. ', N'0617966863', N'Thước', TO_TIMESTAMP ('2011-07-02','YYYY-MM-DD'),  1794074.646695086, 1329698.8419083406);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (42 , 32 , 11 , 15 , N'Võ  Diệu Quyên ', N'599 Đường số 26  TP.Thủ Đức. ', N'0468453755', N'Nước Khoáng', TO_TIMESTAMP ('2019-12-19','YYYY-MM-DD'),  366468.92243924964, 921838.773808367);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (43 , 33 , 2 , 16 , N'Lý Hồng Tân ', N'343 Phường 85 Quận 2 TP.Thủ Đức. ', N'0149846329', N'Bột ngọt', TO_TIMESTAMP ('2012-05-15','YYYY-MM-DD'),  1562530.08185538, 707251.33242330118);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (44 , 34 , 5 , 17 , N'Phạm Quốc Cường ', N'49   TP.Thủ Đức. ', N'0613198336', N'Nước có ga', TO_TIMESTAMP ('2017-09-17','YYYY-MM-DD'),  1623537.2980984568, 1849752.1355607323);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (45 , 35 , 14 , 18 , N'Đặng Uyển Đức ', N'589 Đường số 91 Quận Bình Tân TP.Thủ Đức. ', N'0981921391', N'Dép', TO_TIMESTAMP ('2017-07-19','YYYY-MM-DD'),  422361.18698975124, 1476305.9062065117);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (46 , 36 , 12 , 19 , N'Lý Diệu Diệu ', N'439  Quận  TP.Thủ Đức. ', N'0293552184', N'Quần', TO_TIMESTAMP ('2020-05-11','YYYY-MM-DD'),  1643586.1268870467, 1404985.359458246);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (47 , 37 , 6 , 20 , N'Trần Thái Phương ', N'363   TP.HCM. ', N'0256143375', N'Vở', TO_TIMESTAMP ('2016-09-11','YYYY-MM-DD'),  1891530.4236465741, 572632.871126585);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (48 , 38 , 7 , 21 , N'Lý Kim Quyên ', N'848  Quận 3 TP.Thủ Đức. ', N'0939112205', N'Muối tây ninh', TO_TIMESTAMP ('2018-04-10','YYYY-MM-DD'),  1531648.5639785642, 1562964.6877781323);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (49 , 39 , 3 , 22 , N'Lê Quốc Quốc ', N'88   Quận  TP.HCM. ', N'0330707876', N'Kẹo mềm', TO_TIMESTAMP ('2010-12-25','YYYY-MM-DD'),  359823.41019707895, 555113.13496069668);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (50 , 40 , 4 , 23 , N'Hồ Thái Đức ', N'96    TP.HCM. ', N'0648613195', N'Nước khử trùng', TO_TIMESTAMP ('2017-02-13','YYYY-MM-DD'),  1553389.3536661703, 1817595.9264284913);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (51 , 41 , 7 , 22 , N'Hoàng Duy  Thịnh ', N'89  Quận 7 TP.HCM. ', N'0864528914', N'', TO_TIMESTAMP ('2012-05-19','YYYY-MM-DD'),  653420.38348662679, 885662.9374202633);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (52 , 42 , 11 , 1 , N'Đặng Hồng Linh ', N'47  4 TP.Thủ Đức. ', N'0912168591', N'Kẹo cứng', TO_TIMESTAMP ('2014-05-20','YYYY-MM-DD'),  1688338.212385, 590288.42024704826);
INSERT INTO HOADON (MaHD, MANV, MaChiNhanh , MaKH, HoTen, DiaChi, SDT, GhiChu, NgayTao, TongTienHang, TongThucThu) VALUES (53 , 17 , 10 , 1 , N'Nguyễn Hoài Hoàng ', N'46  Quận 7 TP.Thủ Đức. ', N'0550804420', N'Nước khử trùng', TO_TIMESTAMP ('2012-08-17','YYYY-MM-DD'),  1919010.8779952913, 1372799.1776642387);


CREATE TABLE CHITIETHD(
  MaHD NUMBER(10) NOT NULL,
  MaHH NUMBER(10) NOT NULL,
  DonGia NUMBER(10,1) ,
  GiamGia NUMBER(10,1) NULL,
  SoLuong NUMBER(10) ,
  CONSTRAINT pk_cthd PRIMARY KEY (MaHD, MAHH),
  CONSTRAINT fk_cthd_hd FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
  CONSTRAINT fk_cthd_hh FOREIGN KEY (MaHH) REFERENCES HANGHOA(MaHH)
);
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (1 , 1, 1282207.6 , 2.0 , 382 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (2 , 2, 943016.5 , 3.7 , 653 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (3 , 3, 28077.6 , 4.2 , 463 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (4 , 4, 1952539.0 , 3.5 , 847 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (5 , 5 , 447250.8 , 5.0 , 990 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (6 , 6 , 67025.4 , 4.9 , 987 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (7 , 7 , 162949.2 , 2.8 , 423 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (8 , 8 , 817827.0 , 2.6 , 860 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (9 , 9 , 88087.7 , 3.4 , 475 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (10 , 20 , 266743.8 , 2.7 , 990 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (11 , 21 , 287947.8 , 3.3 , 281 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (12 , 22 , 589428.5 , 4.8 , 999 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (13 , 23 , 1556475.7 , 1.3 , 528 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (14 , 24 , 362289.1 , 1.2 , 968 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (15 , 25 , 1508319.1 , 1.3 , 371 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (16 , 1 , 1856226.2 , 1.4 , 311 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (17 , 2 , 1414540.6 , 1.4 , 262 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (18 , 3 , 968548.8 , 2.1 , 180 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (19 , 4 , 1200610.9 , 2.3 , 952 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (20 , 5 , 1665734.2 , 1.8 , 689 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (21 , 6 , 1408457.8 , 3.9 , 861 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (22 , 7 , 93322.5 , 1.3 , 657 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (23 , 8 , 1585686.8 , 2.2 , 652 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (24 , 9 , 944710.7 , 2.5 , 472 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (25 , 1 , 672738.2 , 5.0 , 240 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (26 , 1 , 1580081.7 , 2.0 , 605 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (27 , 1 , 353690.2 , 1.7 , 739 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (28 , 1 , 1827362.8 , 2.7 , 603 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (29 , 1 , 1438305.9 , 1.9 , 863 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (30 , 1 , 850990.9 , 2.0 , 815 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (31 , 1 , 1577824.4 , 2.6 , 134 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (32 , 1 , 804722.4 , 1.1 , 949 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (33 , 1 , 923533.3 , 4.3 , 244 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (34 , 1 , 1054503.2 , 2.1 , 376 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (35 , 1 , 170366.1 , 4.9 , 380 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (36 , 1 , 1436714.4 , 3.5 , 554 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (37 , 1 , 1463723.4 , 1.6 , 219 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (38 , 11 , 1301774.4 , 4.8 , 720 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (39 , 11 , 541441.4 , 4.1 , 563 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (40 , 17 , 1189393.7 , 3.2 , 549 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (41 , 17 , 1899066.8 , 2.2 , 292 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (42 , 17 , 434365.7 , 1.5 , 297 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (43 , 17 , 1487999.4 , 4.6 , 899 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (44 , 17 , 1208123.6 , 3.8 , 449 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (45 , 18 , 1742390.6 , 4.0 , 100 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (46 , 19 , 837614.7 , 2.0 , 396 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (47 , 20 , 774575.9 , 1.2 , 267 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (48 , 21 , 1634272.3 , 5.0 , 564 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (49 , 22 , 1214592.4 , 4.0 , 147 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (50 , 23 , 96223.3 , 1.6 , 909 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (51 , 22 , 875807.0 , 4.5 , 992 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (52 , 1 , 134818.7 , 3.8 , 576 );
INSERT INTO CHITIETHD ( MaHD, MaHH, DonGia, GiamGia, SoLuong) VALUES (53 , 1 , 1781211.4 , 3.5 , 155 );

