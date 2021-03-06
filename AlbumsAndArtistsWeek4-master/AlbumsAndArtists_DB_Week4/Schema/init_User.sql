﻿USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [new_Dev]    Script Date: 6/24/16 4:00:55 PM ******/
CREATE LOGIN [new_Dev] WITH PASSWORD=N'so416MEZvXKjLx0NvQkYQwgQRoc6rjX5if/kPmGoGU4=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [new_Dev] ENABLE
GO

USE [AlbumsAndArtists_DB_Week4]
GO
/****** Object:  User [new_Dev]    Script Date: 6/24/16 3:58:51 PM ******/
CREATE USER [new_Dev] FOR LOGIN [new_Dev] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [new_Dev]
GO