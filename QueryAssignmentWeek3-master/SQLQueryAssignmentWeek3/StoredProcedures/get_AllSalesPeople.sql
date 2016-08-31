/***********************************************************************************************************
Description: Script that retrieves all Distinct SalesPeople from SalesPeople
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.03.2016
Change History:
	
************************************************************************************************************/

CREATE PROCEDURE [dbo].[get_AllSalesPeople]
	
AS
	SELECT DISTINCT firstName, lastName
			

	FROM SalesPeople
	

