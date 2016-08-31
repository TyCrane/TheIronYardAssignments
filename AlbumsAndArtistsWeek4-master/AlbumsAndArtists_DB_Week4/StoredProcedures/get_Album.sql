/***********************************************************************************************************
Description: Stored Procedure to pull information from Albums
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.16.16
Change History:
	
************************************************************************************************************/
ALTER PROCEDURE [dbo].[get_Album]
	@albumName varchar(25),
	@artistName varchar(25)

AS
	BEGIN
		BEGIN TRY
			
				SELECT ISNULL(albumsID, 1) AS albumID,
						ISNULL(albumName, ' ') AS albumName,
						ISNULL(amountInStock, 0) AS amountInStock,
						ISNULL(normalPrice, 1) AS normalPrice,
						ISNULL(sellPrice, 1) AS sellPrice,
						ISNULL(art.artistName, ' ') AS artistName

				FROM Albums alb
				LEFT JOIN Artists art ON
					art.artistName = @artistName

				WHERE @albumName = albumName

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


