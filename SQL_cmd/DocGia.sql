USE Quan_ly_thu_vien

CREATE TABLE DocGia(
DocGiaID INT NOT NULL IDENTITY(1,1) Primary Key,
HoTen NVARCHAR(40) NOT NULL,
MaSV Char(30) NOT NULL ,
DiaChi NVARCHAR(50) NOT NULL,
SoDT CHAR(30) NOT NULL,
--TaiKhoanID INT FOREIGN KEY REFERENCES QuanLyTaiKhoan(TaiKhoanID) 
)

Drop table DocGia
SELECT * FROM DocGia