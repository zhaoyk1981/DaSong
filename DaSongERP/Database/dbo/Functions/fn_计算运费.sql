-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION dbo.fn_计算运费
(
	@OrderID UNIQUEIDENTIFIER
	,@运费 MONEY
)
RETURNS MONEY
AS
BEGIN
	-- Declare the return variable here
	DECLARE @支出运费 MONEY = 0;
	DECLARE @未发货退款 UNIQUEIDENTIFIER = '270D96A8-B765-4EA1-BCE9-1D05801E0612'
		, @退差价 UNIQUEIDENTIFIER = '30B920EE-1D4C-4E20-9900-2AB6166C99A4'
		, @退款拦截 UNIQUEIDENTIFIER = '34389510-5D4E-4528-9F94-576E6A6DA89F'
		, @少件 UNIQUEIDENTIFIER = 'F3A2E746-F6DE-45B4-A30D-6FB442FC2745'
		, @发票 UNIQUEIDENTIFIER = 'E6058389-BACE-4E33-B38F-9159944036C4'
		, @换货 UNIQUEIDENTIFIER = '0F29DA4E-312F-4D3A-B57B-C4B176501214'
		, @退款退货 UNIQUEIDENTIFIER = 'D87B04C5-F8E4-425C-B4EC-D2610803630A'
		, @补发 UNIQUEIDENTIFIER = '8298811D-1F57-4407-ABBE-FB48F64D9EA8';

	-- Add the T-SQL statements to compute the return value here
	SELECT @支出运费 =  CASE o.售后操作ID
		WHEN @退款拦截 THEN @运费
		WHEN @补发 THEN @运费
		WHEN @发票 THEN @运费
		WHEN @退款退货 THEN @运费 * 2
		WHEN @换货 THEN @运费 * 2
		ELSE 0 END
	FROM vw_Orders o
	WHERE o.ID = @OrderID;

	-- Return the result of the function
	RETURN @支出运费;

END