/***********************************************************************************************************
Description: stored proc that retrieves a student from the database 
			
Author: 
	Tyrell Powers-Crane 
Date: 
	7.31.2016
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[get_StudentByID]
	@studentID int

AS
	BEGIN
			
				SELECT	Students.*

				FROM Students 

				WHERE Students.studentsID = @studentID

	END
