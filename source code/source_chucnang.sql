﻿--I/CHỨC NĂNG VÀ STORE PROCEDURE CỦA GIAO DIỆN KHÁCH HÀNG
--1/trang khách hàng
--xem thông tin khách hàng 
if OBJECT_ID ('VIEW_TABLE_InfoKH','P') is not null
	drop proc VIEW_TABLE_InfoKH
GO
create proc VIEW_TABLE_InfoKH  
	@TaiKhoan char(15)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		IF NOT EXISTS (SELECT * FROM KHACHHANG WHERE @TaiKhoan = TAIKHOAN) 
		begin
			PRINT N'KHÁCH HÀNG KHÔNG TỒN TẠI'
			ROLLBACK TRANSACTION
			RETURN
		end
		SELECT * FROM KHACHHANG WHERE @TaiKhoan = TAIKHOAN
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
	ELSE IF @LoaiNguoiDung = N'ADMIN'
		SELECT * FROM KHACHHANG
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--CHỈNH SỬA THÔNG TIN MẬT KHẨU ĐĂNG NHẬP, HỌ TÊN, EMAIL, SĐT, ĐỊA CHỈ Ở KHÁCH HÀNG
if OBJECT_ID ('UPDATE_TABLE_InfoKH','P') is not null
	drop proc UPDATE_TABLE_InfoKH
GO
create proc UPDATE_TABLE_InfoKH  
	@TaiKhoan CHAR(15),
	@HOTENMOI NVARCHAR(40),
	@SODIENTHOAIMOI CHAR(12),
	@EMAILMOI CHAR(30),
	@DIACHIMOI NVARCHAR(50),
	@MATKHAUMOI CHAR(15)

AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		UPDATE DANGNHAP SET MATKHAU=@MATKHAUMOI WHERE TAIKHOAN=@TaiKhoan
		UPDATE KHACHHANG SET HOTEN=@HOTENMOI, SODIENTHOAI=@SODIENTHOAIMOI, EMAIL=@EMAILMOI, DIACHI=@DIACHIMOI WHERE TAIKHOAN=@TaiKhoan
		EXEC VIEW_TABLE_InfoKH @TaiKhoan
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI CHỈNH SỬA'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--Tạo 1 shop( mỗi người chỉ có duy nhất 1 shop)
if OBJECT_ID ('ADD_SHOP_KH','P') is not null
	drop proc ADD_SHOP_KH
GO
create proc ADD_SHOP_KH  
	@TaiKhoan CHAR(15),
	@TENSHOP NVARCHAR(30),
	@SODIENTHOAISHOP CHAR(12),
	@DIACHISHOP NVARCHAR(50)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		--LẤY MÃ KHÁCH HÀNG TỪ TÊN ĐĂNG NHẬP
		declare @MACHUSHOP VARCHAR(5)
		set @MACHUSHOP = (select MAKHACHHANG from KHACHHANG where TAIKHOAN=@TaiKhoan)
		--KIỂM TRA KHÁCH HÀNG NÀY ĐÃ TẠO SHOP HAY CHƯA
		IF EXISTS (SELECT * FROM SHOP WHERE MACHUSHOP = @MACHUSHOP) 
		begin
			PRINT N'MỖI TÀI KHOẢN CHỈ ĐƯỢC TẠO 1 SHOP'
			ROLLBACK TRANSACTION
			RETURN
		end
		INSERT INTO SHOP(TENSHOP,MACHUSHOP,DIACHI,SODIENTHOAI) VALUES (@TENSHOP,@MACHUSHOP,@DIACHISHOP,@SODIENTHOAISHOP)
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI TẠO SHOP'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--2/trang shop
--Hiện sản phẩm của shop đang bày bán
if OBJECT_ID ('VIEW_SP_CUASHOP','P') is not null
	drop proc VIEW_SP_CUASHOP
GO
create proc VIEW_SP_CUASHOP  
	@TaiKhoan CHAR(15)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		--LẤY MÃ KHÁCH HÀNG TỪ TÊN ĐĂNG NHẬP
		declare @MACHUSHOP VARCHAR(5)
		set @MACHUSHOP = (select MAKHACHHANG from KHACHHANG where TAIKHOAN=@TaiKhoan)
		--KIỂM TRA KHÁCH HÀNG NÀY ĐÃ TẠO SHOP HAY CHƯA
		IF NOT EXISTS (SELECT * FROM SHOP WHERE MACHUSHOP = @MACHUSHOP) 
		begin
			PRINT N'BẠN CHƯA TẠO SHOP'
			ROLLBACK TRANSACTION
			RETURN
		end
		select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = @TaiKhoan))
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ SHOP'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
EXEC VIEW_SP_CUASHOP 'd'
select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = 'e'))
select *from SANPHAM
select *from DANGNHAP
--ĐĂNG BÁN SẢN PHẨM TỪ SHOP CỦA MÌNH
if OBJECT_ID ('SELL_SP_KH','P') is not null
	drop proc SELL_SP_KH
GO
create proc SELL_SP_KH  
	@TaiKhoan CHAR(15),
	@TENSP NVARCHAR(20),
	@MAMATHANGSP VARCHAR(10),
	@GIATIENSP FLOAT,
	@SOLUONGBAN INT
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	--KIỂM TRA NGƯỜI DÙNG
	IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG THỂ BÁN HÀNG'
		ROLLBACK TRANSACTION
		RETURN
	end
	--KIỂM TRA TẠO SHOP HAY CHƯA
	declare @MACHUSHOP VARCHAR(5)
	set @MACHUSHOP = (select MAKHACHHANG from KHACHHANG where TAIKHOAN=@TaiKhoan)
	IF NOT EXISTS (SELECT * FROM SHOP WHERE MACHUSHOP = @MACHUSHOP) 
	begin
		PRINT N'BẠN CHƯA TẠO SHOP'
		ROLLBACK TRANSACTION
		RETURN
	end
	--KIỂM TRA MẶT HÀNG HỢP LỆ
	IF NOT EXISTS (SELECT * FROM MATHANG WHERE @MAMATHANGSP = MAMATHANG) 
	begin
		PRINT N'MẶT HÀNG KHÔNG TỒN TẠI'
		ROLLBACK TRANSACTION
		RETURN
	end
	declare @MASHOP VARCHAR(9)
	set @MASHOP = (select MASHOP from SHOP where MACHUSHOP=@MACHUSHOP)
	INSERT INTO SANPHAM(TEN, MAMATHANG, MASHOP, GIATIEN, SOLUONGCONLAI, SOLUONGDABAN) VALUES (@TENSP, @MAMATHANGSP, @MASHOP, @GIATIENSP, @SOLUONGBAN, 0)
END TRY
BEGIN CATCH
	PRINT N'LÕI ĐĂNG BÁN'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--SỬA SẢN PHẨM TỪ SHOP CỦA MÌNH (CHỈ ĐƯỢC SỬA GIÁ TIỀN VÀ SỐ LƯỢNG CÒN LẠI)
if OBJECT_ID ('UPDATE_SP_KH','P') is not null
	drop proc UPDATE_SP_KH
GO
create proc UPDATE_SP_KH  
	@TaiKhoan CHAR(15),
	@MaSP CHAR(9),
	@GIATIENMOI FLOAT,
	@SOLUONGCONLAIMOI INT
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		--KIỂM TRA TẠO SHOP HAY CHƯA
		IF NOT EXISTS (SELECT MASHOP FROM SHOP JOIN KHACHHANG ON SHOP.MACHUSHOP=KHACHHANG.MAKHACHHANG AND TAIKHOAN=@TaiKhoan) 
		begin
			PRINT N'BẠN CHƯA TẠO SHOP'
			ROLLBACK TRANSACTION
			RETURN
		end
		--LẤY MÃ SHOP TỪ NGƯỜI DÙNG
		declare @MASHOP VARCHAR(9)
		set @MASHOP = (SELECT MASHOP FROM SHOP JOIN KHACHHANG ON SHOP.MACHUSHOP=KHACHHANG.MAKHACHHANG AND TAIKHOAN=@TaiKhoan)
		IF NOT EXISTS (SELECT * FROM SHOP join SANPHAM on shop.MASHOP=SANPHAM.MASHOP and shop.MASHOP=@MASHOP and SANPHAM.MASANPHAM=@MaSP) 
		begin
			PRINT N'KHÔNG THỂ SỬA SẢN PHẨM BẠN KHÔNG ĐĂNG BÁN'
			ROLLBACK TRANSACTION
			RETURN
		end
		UPDATE SANPHAM SET GIATIEN=@GIATIENMOI WHERE MASHOP=@MASHOP AND MASANPHAM=@MaSP
		UPDATE SANPHAM SET SOLUONGCONLAI=@SOLUONGCONLAIMOI WHERE MASHOP=@MASHOP AND MASANPHAM=@MaSP
	END
	ELSE IF @LoaiNguoiDung = N'GIAOHANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI XÓA SẢN PHẨM'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--XÓA SẢN PHẨM TỪ SHOP CỦA MÌNH
if OBJECT_ID ('DELETE_SP_KH','P') is not null
	drop proc DELETE_SP_KH
GO
create proc DELETE_SP_KH  
	@TaiKhoan CHAR(15),
	@MaSP CHAR(9)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		--KIỂM TRA TẠO SHOP HAY CHƯA
		IF NOT EXISTS (SELECT MASHOP FROM SHOP JOIN KHACHHANG ON SHOP.MACHUSHOP=KHACHHANG.MAKHACHHANG AND TAIKHOAN=@TaiKhoan) 
		begin
			PRINT N'BẠN CHƯA TẠO SHOP'
			ROLLBACK TRANSACTION
			RETURN
		end
		--LẤY MÃ SHOP TỪ NGƯỜI DÙNG
		declare @MASHOP VARCHAR(9)
		set @MASHOP = (SELECT MASHOP FROM SHOP JOIN KHACHHANG ON SHOP.MACHUSHOP=KHACHHANG.MAKHACHHANG AND TAIKHOAN=@TaiKhoan)
		IF NOT EXISTS (SELECT * FROM SHOP join SANPHAM on shop.MASHOP=SANPHAM.MASHOP and shop.MASHOP=@MASHOP and SANPHAM.MASANPHAM=@MaSP) 
		begin
			PRINT N'KHÔNG THỂ XÓA SẢN PHẨM BẠN KHÔNG ĐĂNG BÁN'
			ROLLBACK TRANSACTION
			RETURN
		end
		DELETE FROM SANPHAM WHERE MASHOP=@MASHOP AND MASANPHAM=@MaSP
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI XÓA SẢN PHẨM'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--3/Trang Sản phẩm:
--HIỂN THỊ CÁC MẶT HÀNG ĐANG BÀY BÁN
if OBJECT_ID ('VIEW_SP','P') is not null
	drop proc VIEW_SP
GO
create proc VIEW_SP  
AS
BEGIN TRANSACTION 
BEGIN TRY
	SELECT * FROM SANPHAM
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ SẢN PHẨM'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
EXEC VIEW_SP
--TÌM KIẾM SẢN PHẨM THEO MÃ MẶT HÀNG
if OBJECT_ID ('FIND_SP','P') is not null
	drop proc FIND_SP
GO
create proc FIND_SP  
	@MAMATHANGSP VARCHAR(10)
AS
BEGIN TRANSACTION 
BEGIN TRY
	SELECT * FROM SANPHAM WHERE MAMATHANG=@MAMATHANGSP
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ SẢN PHẨM'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
EXEC FIND_SP 'MATHANG001'
select *from MATHANG
--MUA SẢN PHẨM VÀ THÊM VÀO ĐƠN HÀNG
if OBJECT_ID ('ADD_ĐH_KH','P') is not null
	drop proc ADD_ĐH_KH
GO
create proc ADD_ĐH_KH  
	@TaiKhoan CHAR(15),
	@MASANPHAM VARCHAR(5),
	@SOLUONG INT
AS
BEGIN TRANSACTION 
	DECLARE @LoaiNguoiDung VARCHAR(9)
BEGIN TRY
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		declare @MAKHACHHANG VARCHAR(5)
		set @MAKHACHHANG = (select MAKHACHHANG from KHACHHANG where TAIKHOAN=@TaiKhoan)
		--KIỂM TRA MÃ SP CÓ TỒN TẠI
		IF NOT EXISTS (SELECT * FROM SANPHAM WHERE MASANPHAM=@MASANPHAM) 
		begin
			PRINT N'SẢN PHẨM KHÔNG TỒN TẠI'
			ROLLBACK TRANSACTION
			RETURN
		end
		--KIỂM TRA SL ĐẶT MUA SO VỚI SL SẢN PHẨM ĐANG CÓ
		IF @SOLUONG > (SELECT SOLUONGCONLAI FROM SANPHAM WHERE MASANPHAM = @MASANPHAM)
		begin
			PRINT N'SL ĐẶT MUA VƯỢT MỨC ĐANG CÓ'
			ROLLBACK TRANSACTION
			RETURN
		end
		INSERT INTO DONHANG(MASANPHAM, MAKHACHHANG, NGAYLAPDON, SOLUONG, TIENSHIP, HINHTHUCTHANHTOAN) VALUES (@MASANPHAM, @MAKHACHHANG, GETDATE(), @SOLUONG, 15000, 'Ship cod')
	END
	ELSE IF @LoaiNguoiDung = N'GIAO HANG' OR @LoaiNguoiDung = N'ADMIN'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI MUA SẢN PHẨM'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
EXEC ADD_ĐH_KH 'a', 'SP006', 2
SELECT * FROM DONHANG
SELECT*FROM SANPHAM
--4/Trang mặt hàng:
--Chỉ hiển thị nội dung bảng mặt hàng
if OBJECT_ID ('VIEW_TABLE_MATHANG','P') is not null
	drop proc VIEW_TABLE_MATHANG
GO
create proc VIEW_TABLE_MATHANG
AS
BEGIN TRANSACTION 
SELECT *FROM MATHANG 
COMMIT TRANSACTION
go
EXEC VIEW_TABLE_MATHANG
--5/Trang đơn hàng:
--Hiển thị nội dung các đơn hàng đã và đang mua 
if OBJECT_ID ('VIEW_DONHANG_DAMUA_DANGMUA','P') is not null
	drop proc VIEW_DONHANG_DAMUA_DANGMUA
GO
create proc VIEW_DONHANG_DAMUA_DANGMUA 	
AS
BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT DISTINCT * FROM DONHANG DH JOIN GIAOHANG GH ON DH.MADON = GH.MADONHANG WHERE GH.TINHTRANGGIAO = N'ĐANG GIAO' OR GH.TINHTRANGGIAO = N'ĐÃ NHẬN')
	BEGIN
		PRINT N'KHÔNG CÓ ĐƠN HÀNG NÀO ĐÃ MUA HOẶC ĐANG MUA'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY 
BEGIN CATCH
	PRINT N'LÕI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
	SELECT DISTINCT * FROM DONHANG DH JOIN GIAOHANG GH ON DH.MADON = GH.MADONHANG WHERE GH.TINHTRANGGIAO = N'ĐANG GIAO' OR GH.TINHTRANGGIAO = N'ĐÃ NHẬN'
COMMIT TRANSACTION
go
--PROCEDURE BỔ TRỢ(XÓA ĐƠN HÀNG CỦA KHÁCH HÀNG SỞ HỮU MÀ CHƯA CÓ SHIPPER NHẬN)
if OBJECT_ID ('DELETE_MOTDONHANG_CHUACOSHIPPERNHAN_CUAKHACHHANG','P') is not null
	drop proc DELETE_MOTDONHANG_CHUACOSHIPPERNHAN_CUAKHACHHANG
GO
create proc DELETE_MOTDONHANG_CHUACOSHIPPERNHAN_CUAKHACHHANG 	
	@MADONHANG VARCHAR(10)
AS
BEGIN TRANSACTION 
		DELETE FROM DONHANG WHERE MADON = @MADONHANG AND MADON = ANY (SELECT DH2.MADON FROM DONHANG DH2 JOIN (SELECT DH.MADON FROM DONHANG DH
										EXCEPT 
								             (SELECT DH1.MADON FROM DONHANG DH1 JOIN GIAOHANG GH ON DH1.MADON = GH.MADONHANG)) AS DONHANG1
								              ON DH2.MADON = DONHANG1.MADON)
COMMIT TRANSACTION
go
--hủy đơn hàng (chỉ những đơn chưa có shipper nhận: là những đơn chưa tồn tại trong bảng Giao hàng)
if OBJECT_ID ('DELETE_DONHANG_CHUACOSHIPPERNHAN','P') is not null
	drop proc DELETE_DONHANG_CHUACOSHIPPERNHAN
GO
create proc DELETE_DONHANG_CHUACOSHIPPERNHAN 	
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9),
	@MADONHANG VARCHAR(10)
AS
BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	SELECT *FROM DONHANG
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		ROLLBACK TRANSACTION
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		DELETE FROM DONHANG WHERE MADON = @MADONHANG
	ELSE IF @LOAINGUOIDUNG = 'KHACHHANG'
		EXEC DELETE_MOTDONHANG_CHUACOSHIPPERNHAN_CUAKHACHHANG @MADONHANG
END TRY 
BEGIN CATCH
	PRINT N'LỖI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
IF @@TRANCOUNT > 0
COMMIT TRANSACTION
go
--sửa đơn hàng (chỉ những đơn chưa có shipper nhận: là những đơn chưa tồn tại trong bảng Giao hàng)
if OBJECT_ID ('UPDATE_DONHANG_CHUACOSHIPPERNHAN','P') is not null
	drop proc UPDATE_DONHANG_CHUACOSHIPPERNHAN
GO
create proc UPDATE_DONHANG_CHUACOSHIPPERNHAN 	
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9),
	@MADONHANG VARCHAR(10),
	@SOLUONG INT,
	@HINHTHUCTHANHTOAN NVARCHAR(20)
AS
BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	ELSE IF NOT EXISTS(SELECT *FROM DONHANG WHERE MADON = @MADONHANG)
		BEGIN
			PRINT N'ĐƠN HÀNG NÀY KHÔNG TỒN TẠI'
			ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		ROLLBACK TRANSACTION
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		UPDATE DONHANG SET SOLUONG = @SOLUONG, HINHTHUCTHANHTOAN = @HINHTHUCTHANHTOAN WHERE MADON = @MADONHANG
	ELSE IF @LOAINGUOIDUNG = 'KHACHHANG'
		UPDATE DONHANG SET SOLUONG = @SOLUONG, HINHTHUCTHANHTOAN = @HINHTHUCTHANHTOAN WHERE MADON = @MADONHANG		
	SELECT *FROM DONHANG WHERE MADON = @MADONHANG
END TRY 
BEGIN CATCH
	PRINT N'LỖI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--6/Trang giao hàng:
--Chỉ hiện thị nội dung có những mã đơn hàng của mình 
if OBJECT_ID ('VIEW_DONHANG_CUAKHACHHANG','P') is not null
	drop proc VIEW_DONHANG_CUAKHACHHANG
GO
create proc VIEW_DONHANG_CUAKHACHHANG 
	@TAIKHOAN CHAR(15)
AS
BEGIN TRANSACTION 
	SELECT *FROM DONHANG DH JOIN KHACHHANG KH ON DH.MAKHACHHANG = KH.MAKHACHHANG WHERE KH.TAIKHOAN = @TAIKHOAN
COMMIT TRANSACTION
go
--7/Trang hóa đơn:
--Hiện thị nội dung có mã KH của mình
if OBJECT_ID ('VIEW_HOADON_CUAKHACHHANG','P') is not null
	drop proc VIEW_HOADON_CUAKHACHHANG
GO
create proc VIEW_HOADON_CUAKHACHHANG 
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9)
AS
BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		ROLLBACK TRANSACTION
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		SELECT *FROM HOADON
	ELSE IF @LOAINGUOIDUNG = 'KHACHHANG'
		SELECT *FROM HOADON HD JOIN KHACHHANG KH ON HD.MAKHACHHANG = KH.MAKHACHHANG WHERE KH.TAIKHOAN = @TAIKHOAN
END TRY 
BEGIN CATCH
	PRINT N'LÕI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--sửa thông tin cột tình trạng xác nhận, rating và nhận xét
if OBJECT_ID ('UPDATE_HOADON_TINHTRANGXACNHAN_RATING_NHANXET','P') is not null
	drop proc UPDATE_HOADON_TINHTRANGXACNHAN_RATING_NHANXET
GO
create proc UPDATE_HOADON_TINHTRANGXACNHAN_RATING_NHANXET  
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9),
	@MAHOADON VARCHAR(9),
	@TINHTRANGHOADON NVARCHAR(20),
	@RATING CHAR(5),
	@NHANXET NVARCHAR(30)
AS
BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
	BEGIN
		PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
		ROLLBACK TRANSACTION
	RETURN
	END
	IF NOT EXISTS(SELECT *FROM HOADON WHERE MAHOADON = @MAHOADON)
	BEGIN
		PRINT N'KHÔNG TỒN TẠI HÓA ĐƠN NÀY'
		ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		ROLLBACK TRANSACTION
	ELSE IF @LOAINGUOIDUNG = 'QUANLY' OR @LOAINGUOIDUNG = 'KHACHHANG'
		UPDATE HOADON SET TINHTRANGHOADON = @TINHTRANGHOADON, RATING = @RATING, NHANXET = @NHANXET WHERE MAHOADON = @MAHOADON	
END TRY 
BEGIN CATCH
	PRINT N'LỖI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--II/CHỨC NĂNG VÀ PROCEDURE CỦA GIAO DIỆN SHIPPER:
--Trang shipper: Hiển thị nội dung cá nhân 
if OBJECT_ID ('VIEW_THONGTIN_CUASHIPPER','P') is not null
	drop proc VIEW_THONGTIN_CUASHIPPER
GO
create proc VIEW_THONGTIN_CUASHIPPER 
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9)
AS
BEGIN TRANSACTION
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		SELECT *FROM SHIPPER SHP JOIN DANGNHAP DN ON SHP.TAIKHOAN = DN.TAIKHOAN WHERE DN.TAIKHOAN = @TAIKHOAN
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		SELECT *FROM SHIPPER
END TRY 
BEGIN CATCH
	PRINT N'LÕI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--Trang đơn hàng: Hiện thị nội dung cả bảng 
if OBJECT_ID ('VIEW_DONHANG','P') is not null
	drop proc VIEW_DONHANG
GO
create proc VIEW_DONHANG 
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9)
AS
BEGIN TRANSACTION 
	DECLARE @MAKHACHHANG VARCHAR(5)
	SET @MAKHACHHANG = (SELECT MAKHACHHANG FROM KHACHHANG WHERE TAIKHOAN = @TAIKHOAN)
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		SELECT *FROM DONHANG DH2 JOIN 
		(SELECT DH.MADON FROM DONHANG DH
			EXCEPT 
		(SELECT DH1.MADON FROM DONHANG DH1 JOIN GIAOHANG GH ON DH1.MADON = GH.MADONHANG)) AS DONHANG1
		ON DH2.MADON = DONHANG1.MADON
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		SELECT *FROM DONHANG
	ELSE IF @LOAINGUOIDUNG = 'KHACHHANG'
		SELECT *FROM DONHANG WHERE MAKHACHHANG  = @MAKHACHHANG
END TRY 
BEGIN CATCH
	PRINT N'LÕI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--sửa đơn hàng (chỉ những đơn chưa có shipper nhận: là những đơn chưa tồn tại trong bảng Giao hàng)
if OBJECT_ID ('NHANDONHANG_INSERT_ROW_TABLE_GIAOHANG','P') is not null
	drop proc NHANDONHANG_INSERT_ROW_TABLE_GIAOHANG
GO
create proc NHANDONHANG_INSERT_ROW_TABLE_GIAOHANG 
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9),
	@MADONHANG VARCHAR(10)
AS
BEGIN TRANSACTION 
	DECLARE @MASHIPPER VARCHAR(6)
	DECLARE @GIATIEN FLOAT
	DECLARE @TIENSHIP FLOAT
	DECLARE @SOLUONG INT
	DECLARE @MAKHACHHANG VARCHAR(9)
	DECLARE @MASANPHAM VARCHAR(5)
	SET @MASHIPPER = (SELECT SHP.MASHIPPER FROM SHIPPER SHP WHERE SHP.TAIKHOAN = @TAIKHOAN)
	SET @GIATIEN = (SELECT GIATIEN FROM SANPHAM WHERE MASANPHAM = (SELECT MASANPHAM FROM DONHANG WHERE MADON = @MADONHANG))
	SET @TIENSHIP = (SELECT TIENSHIP FROM DONHANG WHERE MADON = @MADONHANG)
	SET @SOLUONG = (SELECT SOLUONG FROM DONHANG WHERE MADON = @MADONHANG)
	SET @MAKHACHHANG = (SELECT MAKHACHHANG FROM DONHANG WHERE MADON = @MADONHANG)
	SET @MASANPHAM = (SELECT MASANPHAM FROM DONHANG WHERE MADON = @MADONHANG)
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
		RETURN
	END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		BEGIN
			INSERT INTO GIAOHANG(MADONHANG,MASHIPPER,TINHTRANGGIAO,NGAYCAPNHAT) VALUES(@MADONHANG, @MASHIPPER, 'ĐANG GIAO', GETDATE())
			DECLARE @MAGIAOHANG_TEMP VARCHAR(5)
				SET @MAGIAOHANG_TEMP = (SELECT MAGIAOHANG FROM GIAOHANG WHERE MADONHANG = @MADONHANG)
			INSERT INTO HOADON(MAGIAOHANG,MAKHACHHANG,TINHTRANGHOADON, TONGTIEN,RATING,NHANXET) VALUES(@MAGIAOHANG_TEMP, @MAKHACHHANG, N'XÁC NHẬN', @TIENSHIP + @GIATIEN*@SOLUONG, NULL, NULL)
			UPDATE SANPHAM SET SOLUONGCONLAI = SOLUONGCONLAI - @SOLUONG, SOLUONGDABAN = SOLUONGDABAN + @SOLUONG WHERE MASANPHAM = @MASANPHAM
		END
	ELSE IF @LOAINGUOIDUNG = 'QUANLY' OR @LOAINGUOIDUNG = 'ADMIN'
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END
END TRY 
BEGIN CATCH
	PRINT N'LỖI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
IF @@TRANCOUNT > 0
COMMIT TRANSACTION
go 
--Trang giao hàng: Chỉ hiển thị những dòng có mã shipper của mình
if OBJECT_ID ('VIEW_GIAOHANG_CUASHIPPER','P') is not null
	drop proc VIEW_GIAOHANG_CUASHIPPER
GO
create proc VIEW_GIAOHANG_CUASHIPPER 
	@TAIKHOAN CHAR(15),
	@LOAINGUOIDUNG CHAR(9)
AS
BEGIN TRANSACTION 
	DECLARE @MAKHACHHANG VARCHAR(5)
	DECLARE @MASHIPPER VARCHAR(6)
	SET @MAKHACHHANG = (SELECT MAKHACHHANG FROM KHACHHANG WHERE TAIKHOAN = @TAIKHOAN)
	SET @MASHIPPER = (SELECT MASHIPPER FROM SHIPPER WHERE TAIKHOAN = @TAIKHOAN)
BEGIN TRY
	IF NOT EXISTS(SELECT *FROM DANGNHAP WHERE TAIKHOAN = @TAIKHOAN)
		BEGIN
			PRINT N'KHÔNG TỒN TẠI TÀI KHOẢN NÀY'
			ROLLBACK TRANSACTION
			RETURN
		END
	IF @LOAINGUOIDUNG = 'GIAOHANG'
		SELECT *FROM GIAOHANG GH1 WHERE GH1.MAGIAOHANG = ANY (SELECT GH.MAGIAOHANG FROM GIAOHANG GH WHERE MASHIPPER = @MASHIPPER)
	ELSE IF @LOAINGUOIDUNG = 'QUANLY'
		SELECT *FROM GIAOHANG
	ELSE IF @LOAINGUOIDUNG = 'KHACHHANG'
		SELECT *FROM GIAOHANG WHERE MAGIAOHANG = ANY(SELECT GH.MAGIAOHANG FROM GIAOHANG GH JOIN DONHANG DH ON GH.MADONHANG = DH.MADON WHERE DH.MAKHACHHANG = @MAKHACHHANG) 
END TRY 
BEGIN CATCH
	PRINT N'LỖI NHẬP LIỆU'
	ROLLBACK TRANSACTION
END CATCH
IF @@TRANCOUNT > 0
COMMIT TRANSACTION
go
--III/CHỨC NĂNG VÀ PROCEDURE CỦA GIAO DIỆN QUẢN LÝ BÁN HÀNG
--KIỂM TRA DOANH THU SHOP
if OBJECT_ID ('XEMDOANHTHU_ADMIN','P') is not null
	drop proc XEMDOANHTHU_ADMIN
GO
create proc XEMDOANHTHU_ADMIN  
	@TaiKhoan CHAR(15)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = N'QUANLY'
	BEGIN
		SELECT TEMP.TENSHOP, SUM(TEMP.DOANHTHU) FROM (SELECT TENSHOP, TEN, (SOLUONGDABAN*GIATIEN) AS DOANHTHU FROM SANPHAM JOIN SHOP ON SANPHAM.MASHOP=SHOP.MASHOP) AS TEMP GROUP BY TEMP.TENSHOP
	END
	ELSE IF @LoaiNguoiDung = N'GIAOHANG' OR @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ'
	ROLLBACK TRANSACTION
END CATCH
COMMIT TRANSACTION
go
--LẤY CÁC SHOP RATING KÉM
GO
create view HOADON_SHOP as select sh.TENSHOP, sp.TEN, RATING, NHANXET 
from HOADON hd, GIAOHANG gh, DONHANG dh, SANPHAM sp, SHOP sh 
where hd.MAGIAOHANG=gh.MAGIAOHANG and gh.MADONHANG=dh.MADON and dh.MASANPHAM=sp.MASANPHAM and sp.MASHOP=sh.MASHOP AND cast(SUBSTRING(RATING,1,1) as int) <= 3
GO
if OBJECT_ID ('LAYRATINGTHAP_ADMIN','P') is not null
	drop proc LAYRATINGTHAP_ADMIN
GO
create proc LAYRATINGTHAP_ADMIN  
	@TaiKhoan CHAR(15)
AS
BEGIN TRANSACTION 
BEGIN TRY
	declare @LoaiNguoiDung VARCHAR(9)
	set @LoaiNguoiDung = (select LOAINGUOIDUNG from DANGNHAP where TAIKHOAN=@TaiKhoan)
	IF @LoaiNguoiDung = 'QUANLY'
	BEGIN
		 SELECT * FROM HOADON_SHOP where cast(SUBSTRING(RATING,1,1) as int) <= 3
	END
	ELSE IF @LoaiNguoiDung = N'GIAOHANG' OR @LoaiNguoiDung = N'KHACHHANG'
	BEGIN
		PRINT N'BẠN KHÔNG CÓ QUYỀN THỰC HIỆN'
		ROLLBACK TRANSACTION
		RETURN
	END
END TRY
BEGIN CATCH
	PRINT N'LỖI HIỂN THỊ'
	ROLLBACK TRANSACTION
END CATCH
IF @@TRANCOUNT > 0
COMMIT TRANSACTION
go