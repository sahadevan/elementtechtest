namespace ElementMaterialsTechnology.DataAccessLayer.Models;

public partial class Product
{
    public string ProdCode { get; set; } = null!;

    public string DivId { get; set; } = null!;

    public string CompanyId { get; set; } = null!;

    public string? ProdName { get; set; }

    public decimal? Price { get; set; }

    public string? TestingMethod { get; set; }

    public string? GroupId { get; set; }

    public string? GroupName { get; set; }

    public int? Tat { get; set; }

    public string? DepartmentId { get; set; }

    public string? Status { get; set; }
}
