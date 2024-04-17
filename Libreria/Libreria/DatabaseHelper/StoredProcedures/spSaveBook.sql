-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSaveBook]
    @ISBN VARCHAR(50),
    @nombreLibro VARCHAR(255),
    @autorLibro VARCHAR(255),
    @precio VARCHAR(20),
    @fechaPublicacion DATE,
    @rutaFoto VARCHAR(255),
    @email VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Libros (ISBN, nombreLibro, autorLibro, precio, fechaPublicacion, rutaFoto, email)
    VALUES (@ISBN, @nombreLibro, @autorLibro, @precio, @fechaPublicacion, @rutaFoto, @email);
END