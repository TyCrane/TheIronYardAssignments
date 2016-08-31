/***********************************************************************************************************
Description: Script that inserts the initial tables into the database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.3.2016
Change History:
	
************************************************************************************************************/

CREATE TABLE SalesPeople (
	salesPeopleID int IDENTITY (1,1) PRIMARY KEY,
	firstName varchar(25),
	lastName varchar(25)
	)

CREATE TABLE Sales (
	salesID int IDENTITY (1,1) PRIMARY KEY,
	salesPeopleID int FOREIGN KEY REFERENCES SalesPeople(salesPeopleID),
	saleDate date,
	preTaxAmount money
	)


