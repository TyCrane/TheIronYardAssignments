/***********************************************************************************************************
Description: Stored Procedure to pull type information from Artist
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.16.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[get_Artist]
	@artistName varchar(25),
	@artistID int OUTPUT

AS
	BEGIN
		BEGIN TRY
			
			SET @artistID = (
				SELECT ISNULL(artistsID, 1) AS artistsID
				FROM Artists
				WHERE artistName = @artistName)

			RETURN @artistID

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


