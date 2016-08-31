/***********************************************************************************************************
Description: stored proc that inserts a blog into the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	8.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[ins_NewBlog]
	@author varchar(100),
	@body varchar(max),
	@title varchar(100),
	@pic varchar(100)

AS
	BEGIN

		INSERT Blog (author, body, title, pic)

		VALUES (@author, @body, @title, @pic)

	END
