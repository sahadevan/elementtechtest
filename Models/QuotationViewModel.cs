using System.ComponentModel.DataAnnotations;

namespace ElementMaterialsTechnology.Models
{
    public class QuotationViewModel
    {
        public long QuotationNo { get; set; }

        public DateTime? QuotationDate { get; set; }

		public string? CustomerId { get; set; }

		public string? CustomerName { get; set; }

		public string? Subject { get; set; }

		public string? Description { get; set; }

		public string? Status { get; set; }

		public decimal? Value { get; set; }

		public string? ProdCode { get; set; }

		public string? ProdName { get; set; }

		public decimal? Price { get; set; }

		public decimal? Qty { get; set; }

		public decimal? Amount { get; set; }

		public int QuotationDetailId { get; set; }
	}
}
