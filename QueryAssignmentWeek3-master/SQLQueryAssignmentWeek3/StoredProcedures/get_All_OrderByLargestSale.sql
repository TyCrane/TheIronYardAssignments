/***********************************************************************************************************
Description: Script that retrieves all information from Sales and SalesPeople and orders it by largest sale
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[get_All_OrderByLargestSale]
	
AS
	SELECT *
			

	FROM SalesPeople sp
	LEFT JOIN Sales sl
		ON sp.salesPeopleID = sl.salesPeopleID

	ORDER BY preTaxAmount ASC


