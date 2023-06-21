CREATE PROCEDURE AddOrUpdateQuotation
            @QuotationNo BIGINT,
            @CustomerId varchar(15),
			@ProdCode varchar(20),
			@ProdName varchar(150),
			@Qty numeric(18, 3),
            @QuotationDate DATE
AS
BEGIN
   -- DECLARE @QuotationNo BIGINT,
   --         @CustomerId varchar(15),
			--@ProdCode varchar(20),
			--@ProdName varchar(150),
			--@Qty numeric(18, 3),
   --         @QuotationDate DATE

   -- -- Extract values from JSON
   -- SELECT @QuotationNo = JSON_VALUE(@QuotationJSON, '$.QuotationNo'),
   --        @CustomerId = JSON_VALUE(@QuotationJSON, '$.CustomerId'),
   --        @QuotationDate = JSON_VALUE(@QuotationJSON, '$.QuotationDate'),
		 --  @ProdCode = JSON_VALUE(@QuotationJSON, '$.ProdCode'),
		 --  @ProdName  = JSON_VALUE(@QuotationJSON, '$.ProdName'),
		 --  @Qty  = JSON_VALUE(@QuotationJSON, '$.Qty')

    -- Check if the quotation already exists
    IF EXISTS (SELECT 1 FROM Quotation WHERE QuotationNo = @QuotationNo)
    BEGIN
        -- Update existing quotation
        UPDATE Quotation
        SET CustomerId = @CustomerId,
            QuotationDate = @QuotationDate
        WHERE QuotationNo = @QuotationNo
    END
    ELSE
    BEGIN
        -- Insert new quotation
        INSERT INTO Quotation (QuotationNo, CustomerId, QuotationDate)
        VALUES (@QuotationNo, @CustomerId, @QuotationDate)
    END

    -- Delete existing quotation details
    DELETE FROM QuotationDetails WHERE QuotationNo = @QuotationNo

    -- Insert new quotation details from JSON
    INSERT INTO QuotationDetails (QuotationNo, Prod_code, Prod_Name, Qty)
    VALUES (@QuotationNo, @ProdCode, @ProdName, @Qty)

    SELECT
        Q.QuotationNo,
        Q.CustomerId,
        Q.QuotationDate,
        QD.Prod_code,
        QD.Qty,
        QD.Price
    FROM Quotation Q
    INNER JOIN QuotationDetails QD ON Q.QuotationNo = QD.QuotationNo
    WHERE Q.QuotationNo = @QuotationNo

END