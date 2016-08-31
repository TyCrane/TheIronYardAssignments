
/***********************************************************************************************************
Description: stored proc that inserts a blog into the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	8.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[upd_Blog]
	@blogID int,
	@author varchar(100),
	@body varchar(max),
	@title varchar(100),
	@pic varchar(100)

AS
	BEGIN

		Update Blog 

		SET author = @author,
			body = @body,
			title = @title,
			pic = @pic

	END
