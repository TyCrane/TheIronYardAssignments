/***********************************************************************************************************
Description: initializes the database 
			
Author: 
	Tyrell Powers-Crane 
Date: 
	7.31.2016
Change History:
	
************************************************************************************************************/
CREATE TABLE Students (
	studentsID int identity (1,1) primary key,
	firstName varchar(25),
	lastName varchar(25),
	gender varchar(25),
	age int 
	)