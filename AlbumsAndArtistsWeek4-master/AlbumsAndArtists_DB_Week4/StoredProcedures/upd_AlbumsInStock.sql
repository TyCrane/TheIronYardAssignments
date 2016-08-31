/***********************************************************************************************************
Description: Stored Procedure that updates information into the Albums Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
ALTER PROCEDURE [dbo].[upd_AlbumsInStock]
	@albumName varchar(25),
	@amountInStock int OUTPUT



AS
	BEGIN
		BEGIN TRY

			UPDATE Albums 

			SET
							amountInStock = (SELECT amountInStock FROM Albums WHERE @albumName = albumName) - 1
									
			WHERE albumName = @albumName 



			SET @amountInStock = (SELECT amountInStock FROM Albums WHERE @albumName = albumName)

			RETURN @amountInStock

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



