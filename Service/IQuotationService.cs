using ElementMaterialsTechnology.Models;

namespace ElementMaterialsTechnology.Service
{
	public interface IQuotationService
	{
		public IEnumerable<QuotationViewModel> GetQuotations();

		public IEnumerable<QuotationViewModel> UpdateQuotation(QuotationViewModel quotation);

		public IEnumerable<QuotationViewModel> AddQuotation(QuotationViewModel quotation);

		public IEnumerable<QuotationViewModel> SearchQuotations(string customerId, DateTime? fromDate, DateTime? toDate);
	}
}
