/***********************************************************************************************************
Description: stored proc to insert a single student into the database 
			
Author: 
	Tyrell Powers-Crane 
Date: 
	7.31.2016
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[ins_Student]
	@firstName varchar(25),
	@lastName varchar(25),
	@gender varchar(25),
	@age int


AS
	BEGIN	
					INSERT Students (firstName,
									lastName,
									gender,
									age)
									
					VALUES (@firstName, @lastName, @gender, @age)
		END
