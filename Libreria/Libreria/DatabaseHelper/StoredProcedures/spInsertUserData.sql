use [LibreriaInternacional]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertUserData]
    @nombreCompleto VARCHAR(100),
    @email VARCHAR(100),
    @pais VARCHAR(100),
    @provincia VARCHAR(100),
    @direccion VARCHAR(100),
    @codigoPostal VARCHAR(20),
    @password VARCHAR(100)
AS
BEGIN
    INSERT INTO Personas (nombreCompleto, email, pais, provincia, direccion, codigoPostal, password)
    VALUES (@nombreCompleto, @email, @pais, @provincia, @direccion, @codigoPostal, @password);
END;