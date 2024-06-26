USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spGetCompra]    Script Date: 4/17/2024 4:02:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetCompra]
    @Email VARCHAR(100)
AS
BEGIN
    SELECT c.[idCompra],
           c.[email],
           c.[ISBN],
           c.[fechaCompra],
           l.[nombreLibro],
		   l.[precio]
    FROM [dbo].[Compras] c
    JOIN [dbo].[Libros] l ON c.[ISBN] = l.[ISBN]
    WHERE c.[email] = @Email;
END