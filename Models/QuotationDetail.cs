namespace ElementMaterialsTechnology.Models;

public partial class QuotationDetail
{
    public long QuotationNo { get; set; }

    public string ProdCode { get; set; } = null!;

    public string? ProdName { get; set; }

    public decimal? Price { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Amount { get; set; }

    public decimal? RowNo { get; set; }

    public int Id { get; set; }

    public virtual Quotation QuotationNoNavigation { get; set; } = null!;
}
