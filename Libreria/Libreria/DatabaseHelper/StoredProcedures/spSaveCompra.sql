USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spSaveCompra]    Script Date: 4/17/2024 11:25:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spSaveCompra]
	@Email varchar(100),
    @ISBN varchar(20),
    @FechaCompra DATETIME
AS
BEGIN
    INSERT INTO [dbo].[Compras] ([email],[ISBN],[fechaCompra])
    VALUES (@Email,@ISBN,@FechaCompra)
END