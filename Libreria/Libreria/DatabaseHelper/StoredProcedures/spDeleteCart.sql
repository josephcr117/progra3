USE [LibreriaInternacional]
GO
CREATE PROCEDURE [dbo].[spDeleteCart]
    @ISBN INT
AS
BEGIN
    DELETE FROM [dbo].[Libros] WHERE ISBN = @ISBN;
END
GO