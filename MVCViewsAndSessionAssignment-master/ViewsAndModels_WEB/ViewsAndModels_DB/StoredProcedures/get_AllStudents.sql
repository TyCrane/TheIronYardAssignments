/***********************************************************************************************************
Description: stored proc that retrieves all students from the database 
			
Author: 
	Tyrell Powers-Crane 
Date: 
	7.31.2016
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[get_AllStudents]

AS
	BEGIN
			
				SELECT	Students.*

				FROM Students 

	END