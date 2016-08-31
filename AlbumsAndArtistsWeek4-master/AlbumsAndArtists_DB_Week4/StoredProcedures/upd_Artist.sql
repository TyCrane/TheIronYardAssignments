/***********************************************************************************************************
Description: Stored Procedure that updates information into the Artists Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[upd_Artist]
	@artistsID int,
	@artistName varchar(25)



AS
	BEGIN
		BEGIN TRY

			UPDATE Artists

			SET
					ArtistName = @artistName
									
			WHERE artistsID = @artistsID

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



