/***********************************************************************************************************
Description: Stored Procedure that updates information into the Albums Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[upd_Album]
	@albumsID int,
	@albumName varchar(25),
	@amountInStock int,
	@normalPrice money,
	@salePrice money


AS
	BEGIN
		BEGIN TRY

			UPDATE Albums 

			SET
							albumName = @albumName,
							amountInStock = @amountInStock,
							normalPrice = @normalPrice,
							sellPrice = @salePrice
									
			WHERE albumsID = @albumsID

		END TRY
		BEGIN CATCH

			DECLARE @timeStamp DATETIME,
				@errorMessage VARCHAR(255),
				@errorProcedure VARCHAR(100)	

			SELECT @timeStamp = GETDATE(),
					@errorMessage = ERROR_MESSAGE(),
					@errorProcedure = ERROR_PROCEDURE()
			
			EXECUTE dbo.log_ErrorTimeStamp @timeStamp, @errorMessage, @errorProcedure

		END CATCH
	END



