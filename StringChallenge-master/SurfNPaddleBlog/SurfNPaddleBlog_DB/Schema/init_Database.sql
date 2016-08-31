/***********************************************************************************************************
Description: 
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	
Change History:
	
************************************************************************************************************/
CREATE TABLE BlogUser (
	blogUserID INT IDENTITY (1,1) PRIMARY KEY,
	author VARCHAR(100)
	)

CREATE TABLE Blog (
	blogID INT IDENTITY (1,1) PRIMARY KEY,
	blogUserID INT FOREIGN KEY REFERENCES BlogUser(blogUserID),
	title VARCHAR(100),
	body VARCHAR(MAX),
	author VARCHAR(100),
	pic VARCHAR(MAX)
	)