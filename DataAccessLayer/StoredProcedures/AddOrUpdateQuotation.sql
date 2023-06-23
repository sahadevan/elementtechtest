CREATE PROCEDURE AddOrUpdateQuotation
                    @QuotationNo BIGINT,
                    @CustomerId varchar(15),
			        @ProdCode varchar(20),
			        @Status varchar(20),
			        @Qty numeric(18, 3),
                    @QuotationDate DATE,
                    @QuotationDetailId int
AS
BEGIN

    -- Check if the quotation already exists
    IF EXISTS (SELECT 1 FROM Quotation WHERE QuotationNo = @QuotationNo)
    BEGIN
        -- Update existing quotation
        UPDATE Quotation
        SET CustomerId = @CustomerId,
            QuotationDate = @QuotationDate,
            Status = @Status
        WHERE QuotationNo = @QuotationNo
    END
    ELSE
    BEGIN
        -- Insert new quotation
        INSERT INTO Quotation (CustomerId, QuotationDate, Status)
        VALUES (@CustomerId, @QuotationDate, @Status)

		SET @QuotationNo = SCOPE_IDENTITY()
    END

    -- Delete existing quotation details
    DELETE FROM QuotationDetails WHERE QuotationNo = @QuotationNo AND Id = @QuotationDetailId

    -- Select Prod Name using Prod Code
    DECLARE @ProdName varchar(150), @Price numeric(18, 3)
    SELECT TOP 1 @ProdName = Prod_Name, @Price = Price FROM Products WHERE Prod_Code = @ProdCode

    -- Insert new quotation details from JSON
    INSERT INTO QuotationDetails (QuotationNo, Prod_code, Prod_Name, Qty, Price, Amount)
    VALUES (@QuotationNo, @ProdCode, @ProdName, @Qty, @Price, @Price * @Qty)

    -- Update the Quotation Value
    DECLARE @Value numeric(18, 3)
    SELECT @Value = SUM(Amount) FROM QuotationDetails WHERE QuotationNo = @QuotationNo

    UPDATE Quotation SET Value = @Value WHERE QuotationNo = @QuotationNo

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