CREATE TYPE dbo.QuotationVM AS TABLE
(
  QuotationNo BIGINT PRIMARY KEY,
  CustomerId NVARCHAR(50),
  ProdCode NVARCHAR(20),
  ProdName NVARCHAR(150),
  Qty numeric(18, 3),
  QuotationDate DATE
);