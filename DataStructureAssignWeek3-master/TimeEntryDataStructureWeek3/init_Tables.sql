/***********************************************************************************************************
Description:  Script that creates initial tables for the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	6.30.2016
Change History:
	7.3.2016 -tpc- Added all linking tables
************************************************************************************************************/
CREATE TABLE Groups (
		groupsID int IDENTITY (1,1) PRIMARY KEY,
		groupDescription varchar (25)
		)

CREATE TABLE Industry (
		industryID int IDENTITY (1,1) PRIMARY KEY,
		industryDescription varchar (25)
		)

CREATE TABLE Developers (
		developersID int IDENTITY (1,1) PRIMARY KEY,
		firstName varchar(25),
		lastName varchar(25),
		Email varchar(25),
		StartDate Date,
		groupsID int FOREIGN KEY REFERENCES Groups(groupsID),
		
		)

CREATE TABLE Clients (
		clientsID int IDENTITY (1,1) PRIMARY KEY,
		industryID int FOREIGN KEY REFERENCES Industry(industryID),
		firstName varchar(25),
		lastName varchar(25),
		)

CREATE TABLE Project (
		projectID int IDENTITY (1,1) PRIMARY KEY,
		clientsID int FOREIGN KEY REFERENCES Clients(clientsID),
		name varchar(25),
		startDate date
		)

CREATE TABLE LnkDeveloperProjects (
		developerID int FOREIGN KEY REFERENCES Developers(developersID),
		projectsID int FOREIGN KEY REFERENCES Project(projectID),
		commentsDevToProjects varchar (255),
		PRIMARY KEY (developerID, projectsID)
		)

CREATE TABLE LnkDeveloperClints (
		developerID int FOREIGN KEY REFERENCES Developers(developersID),
		clientsID int FOREIGN KEY REFERENCES Clients(clientsID),
		commentsDevToClient varchar (255),
		PRIMARY KEY (developerID, clientsID)
		)

CREATE TABLE LnkDeveloperIndustry (
		developersID int FOREIGN KEY REFERENCES Developers(developersID),
		industryID int FOREIGN KEY REFERENCES Industry(industryID),
		commentsDevToIndustry varchar(255),
		PRIMARY KEY (developersID, industryID)
		)