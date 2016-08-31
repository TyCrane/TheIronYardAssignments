USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [VnM_User]    Script Date: 6/24/16 4:00:55 PM ******/
CREATE LOGIN [VnM_User] WITH PASSWORD=N'so416MEZvXKjLx0NvQkYQwgQRoc6rjX5if/kPmGoGU4=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [VnM_User] ENABLE
GO

USE [ViewsAndModels_DB]
GO
/****** Object:  User [VnM_User]    Script Date: 6/24/16 3:58:51 PM ******/
CREATE USER [VnM_User] FOR LOGIN [VnM_User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [VnM_User]
GO