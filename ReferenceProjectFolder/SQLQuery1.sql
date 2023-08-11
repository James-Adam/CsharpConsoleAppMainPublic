USE [NORTHWND]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CustOrderHist]
		@CustomerID = N'ALFKI'

SELECT	@return_value as 'Return Value'

GO
