namespace ElementMaterialsTechnology.Models;

public partial class Quotation
{
    public long QuotationNo { get; set; }

    public DateTime? QuotationDate { get; set; }

    public string? CustomerId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public decimal? Value { get; set; }

    public string? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedUser { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<QuotationDetail> QuotationDetails { get; set; } = new List<QuotationDetail>();
}
