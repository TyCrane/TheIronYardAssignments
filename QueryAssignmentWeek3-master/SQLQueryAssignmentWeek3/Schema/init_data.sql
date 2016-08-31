/***********************************************************************************************************
Description: Script that inserts initial data into database
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.03.2016
Change History:
	
************************************************************************************************************/

INSERT SalesPeople 

SELECT 'James', 'Deacon'
UNION
SELECT 'Emily', 'Eadon'
UNION
SELECT 'Hannah', 'Yardley'
UNION
SELECT 'John', 'Farrarah'
UNION
SELECT 'Jessie', 'Jesamine'
UNION
SELECT 'Izzy', 'Izzabella'
UNION
SELECT 'Judath', 'Judah'

INSERT INTO Sales (salesPeopleID, saleDate, preTaxAmount)
SELECT 1, '10/15/2015', 2846.0
UNION
SELECT 1, '09/21/15', 8852
UNION
SELECT 2, '12/07/15', 5255
UNION
SELECT 2, '02/27/16', 5259
UNION
SELECT 3, '11/23/15', 7244
UNION
SELECT 4, '12/21/15', 8711
UNION
SELECT 1, '10/02/15' ,740
UNION
SELECT 5, '04/02/15' ,9970
UNION
SELECT 6, '12/25/15' ,6009
UNION
SELECT 7, '07/03/14', 9703
		