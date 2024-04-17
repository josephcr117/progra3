USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spSearchBook]    Script Date: 4/16/2024 7:32:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spSearchBook]
    @ISBN varchar(255) = NULL,
    @nombreLibro varchar(255) = NULL
AS
BEGIN
    SELECT *
    FROM Libros
    WHERE (ISBN = @ISBN)
    OR (nombreLibro LIKE '%' + @nombreLibro + '%');
END
