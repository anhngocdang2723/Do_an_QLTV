USE [Quan_ly_thu_vien]
GO
/****** Object:  StoredProcedure [dbo].[sp_DoiMatKhau]    Script Date: 4/11/2023 12:34:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_DoiMatKhau]
	@newpass NVARCHAR(50),
	@uname NVARCHAR(50)
AS
BEGIN
	UPDATE Accounts SET password = @newpass WHERE username = @uname
End