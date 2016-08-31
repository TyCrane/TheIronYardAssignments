/***********************************************************************************************************
Description: Stored Procedure to delete information from the Album Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[del_Album]
	@albumID int
	
AS
	BEGIN
		BEGIN TRY

			DELETE FROM Albums
			WHERE albumsID = @albumID

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

