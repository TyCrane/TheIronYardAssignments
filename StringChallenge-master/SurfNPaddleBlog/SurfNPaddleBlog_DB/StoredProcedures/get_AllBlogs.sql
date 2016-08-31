/***********************************************************************************************************
Description: stored proc that retrieves all blogs from the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	8.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[get_AllBlogs]

AS
	BEGIN

		SELECT *

		FROM Blog

	END
