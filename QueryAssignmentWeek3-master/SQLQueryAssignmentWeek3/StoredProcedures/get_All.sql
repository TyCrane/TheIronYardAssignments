/***********************************************************************************************************
Description: Script that retrieves all information from Sales and SalesPeople
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[get_All]
	
AS
	SELECT *
			

	FROM SalesPeople sp
	LEFT JOIN Sales sl
		ON sp.salesPeopleID = sl.salesPeopleID

