USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spValidateUser]    Script Date: 4/17/2024 2:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spValidateUser]
    @Email varchar(100),
    @Password varchar(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Personas WHERE email = @Email AND password = @Password)
        SELECT 1 AS IsValidUser;
    ELSE
        SELECT 0 AS IsValidUser;
END