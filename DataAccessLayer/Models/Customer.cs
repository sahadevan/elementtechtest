namespace ElementMaterialsTechnology.DataAccessLayer.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? CompanyId { get; set; }

    public string? CustomerName { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Address4 { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? CreatedUser { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Type { get; set; }

    public string? PayTerms { get; set; }

    public string? Status { get; set; }

    public string? ModifiedUser { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
