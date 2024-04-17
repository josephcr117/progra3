USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spGetCart]    Script Date: 4/16/2024 4:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetCart]
	@email VARCHAR(50)
AS
BEGIN
	SELECT
	ISBN,
	nombreLibro,
	autorLibro,
	precio,
	fechaPublicacion,
	rutaFoto,
	email

	FROM [LibreriaInternacional].[dbo].[Libros]
	WHERE email = @email
END