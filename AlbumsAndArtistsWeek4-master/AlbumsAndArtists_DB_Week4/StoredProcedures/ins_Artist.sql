/***********************************************************************************************************
Description: Stored Procedure that inserts information into the Artitsts Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[ins_Artist]
	@artistName varchar(25)


AS
	BEGIN
		BEGIN TRY
			IF EXISTS (SELECT * FROM Artists WHERE @artistName = artistName)
				BEGIN
					INSERT ErrorLog (errorMessage)
					VALUES ('if')					
				END
			ELSE
				BEGIN
					INSERT Artists (artistName)								
					VALUES (@artistName)	
				END
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



