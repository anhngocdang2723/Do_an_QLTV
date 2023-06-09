USE [Quan_ly_thu_vien]
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTaiKhoan]    Script Date: 4/11/2023 12:16:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_ThemTaiKhoan]
	@uname NVARCHAR(50),
	@upass NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Accounts WHERE username = @uname)
    BEGIN
        THROW 51000, 'Tai Khoan da ton tai.', 1;
        RETURN;
    END
	INSERT INTO Accounts(username,password,role) VALUES (@uname,@upass,'user')
END