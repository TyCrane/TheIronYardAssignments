/***********************************************************************************************************
Description: Creates the initial tables for the database
				
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.2016
Change History:
	
************************************************************************************************************/

CREATE TABLE Artists(
	artistsID int IDENTITY (1,1) PRIMARY KEY,
	ArtistName varchar(25),

)

CREATE TABLE Albums(
	albumsID int IDENTITY(1,1) PRIMARY KEY,
	albumName varchar(25),
	amountInStock int,
	normalPrice money,
	sellPrice money
)

CREATE TABLE LnkArtistAlbums (
	artistsID int FOREIGN KEY REFERENCES Artists(artistsID),
	albumsID int FOREIGN KEY REFERENCES Albums(albumsID),
	PRIMARY KEY (artistsID, albumsID)
	)

CREATE TABLE ErrorLog (
	errorLog int IDENTITY (1,1) PRIMARY KEY,
	errorTime datetime,
	errorMessage varchar (500),
	errorProcedure varchar (500)
	)