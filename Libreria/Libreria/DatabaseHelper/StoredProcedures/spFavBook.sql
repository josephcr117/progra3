USE [LibreriaInternacional]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spFavBook]
	@ISBN VARCHAR(50),
    @nombreLibro VARCHAR(255),
    @autorLibro VARCHAR(255),
    @precio VARCHAR(25),
    @fechaPublicacion DATE,
    @rutaFoto VARCHAR(255),
	@email VARCHAR(100)
AS
BEGIN
	DECLARE @bookcount INT;

	SET @bookcount = (SELECT COUNT(*) FROM LibrosFavs
						WHERE (ISBN = @ISBN))

	IF (@bookcount = 0)
		INSERT INTO [dbo].[LibrosFavs] ([ISBN],[nombreLibro],[autorLibro],[precio],[fechaPublicacion],[rutaFoto],[email])
		VALUES (@ISBN, @nombreLibro, @autorLibro, @precio, GETDATE(), @rutaFoto, @email)
	ELSE
		RAISERROR ('You cannot save the same book more than once', 16, 1);	
END