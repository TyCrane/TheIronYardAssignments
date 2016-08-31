/***********************************************************************************************************
Description: Stored Procedure that inserts information into the Albums Table
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.11.16
Change History:
	
************************************************************************************************************/
CREATE PROCEDURE [dbo].[ins_Album]
	@albumName varchar(25),
	@amountInStock int,
	@normalPrice decimal,
	@salePrice decimal,
	@artistID int


AS
	BEGIN
		BEGIN TRY
			IF EXISTS (SELECT * FROM Albums WHERE @albumName = albumName)
				BEGIN
					RETURN
				END
			ELSE
				BEGIN
					INSERT Albums (albumName,
									amountInStock,
									normalPrice,
									sellPrice)
									
					VALUES (@albumName, @amountInStock, @normalPrice, @salePrice)	

					DECLARE @albumID int

					SET @albumID = (SELECT albumsID FROM Albums WHERE albumName = @albumName AND amountInStock = @amountInStock
																	AND normalPrice = @normalPrice
																	AND sellPrice = @salePrice)

					INSERT LnkArtistAlbums (albumsID, artistsID)
					VALUES (@albumID, @artistID)
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



