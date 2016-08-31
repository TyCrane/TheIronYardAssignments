/***********************************************************************************************************
Description: stored proc to update a single student into the database 
			
Author: 
	Tyrell Powers-Crane 
Date: 
	7.31.2016
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[upd_Student]
	@firstName varchar(25),
	@lastName varchar(25),
	@gender varchar(25),
	@age int


AS
	BEGIN	
					UPDATE Students 
					
					SET firstName = @firstName,
						lastName = @lastName,
						gender = @gender,
						age = @age
									
		END
