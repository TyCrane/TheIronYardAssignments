/***********************************************************************************************************
Description: stored proc that retrieves a blog from the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	8.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[get_BlogByID]
	@blogID int

AS
	BEGIN

		SELECT *

		FROM Blog

		WHERE blogID = @blogID

	END
