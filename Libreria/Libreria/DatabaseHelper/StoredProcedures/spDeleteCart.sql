USE [LibreriaInternacional]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCart]    Script Date: 4/17/2024 5:32:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spDeleteCart]
    @ISBN INT
AS
BEGIN
    DELETE FROM [dbo].[Compras] WHERE ISBN = @ISBN;
END
