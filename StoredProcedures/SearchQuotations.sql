CREATE PROCEDURE SearchQuotations
    @CustomerId INT = NULL,
    @FromDate DATE = NULL,
    @ToDate DATE = NULL
AS
BEGIN
    SELECT
        Q.QuotationNo,
        Q.CustomerId,
        Q.QuotationDate,
        QD.Prod_code,
        QD.Qty,
        QD.Price
    FROM Quotation Q
    INNER JOIN QuotationDetails QD ON Q.QuotationNo = QD.QuotationNo
    WHERE
        (@CustomerId IS NULL OR Q.CustomerId = @CustomerId) AND
        (@FromDate IS NULL OR Q.QuotationDate >= @FromDate) AND
        (@ToDate IS NULL OR Q.QuotationDate <= @ToDate)
END