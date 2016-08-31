/***********************************************************************************************************
Description: Stored Procedure to pull information from Albums
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.16.16
Change History:
	
************************************************************************************************************/
ALTER PROCEDURE [dbo].[get_Albums]

AS
	BEGIN
		BEGIN TRY
			
				SELECT	ISNULL(albumName, ' ') AS albumName

				FROM Albums 



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


