USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [surfUser_Dev]    Script Date: 6/24/16 4:00:55 PM ******/
CREATE LOGIN [surfUser_Dev] WITH PASSWORD=N'so416MEZvXKjLx0NvQkYQwgQRoc6rjX5if/kPmGoGU4=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [surfUser_Dev] ENABLE
GO

USE [SurfNPaddleBlog_DB]
GO
/****** Object:  User [surfUser_Dev]    Script Date: 6/24/16 3:58:51 PM ******/
CREATE USER [surfUser_Dev] FOR LOGIN [surfUser_Dev] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [surfUser_Dev]
GO