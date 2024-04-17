USE [LibreriaInternacional]
GO
CREATE PROCEDURE [dbo].[spDeleteFavBook]
    @ISBN INT
AS
BEGIN
    DELETE FROM [dbo].[LibrosFavs] WHERE ISBN = @ISBN;
END
GO