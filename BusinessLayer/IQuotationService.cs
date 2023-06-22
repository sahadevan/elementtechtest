using ElementMaterialsTechnology.DataAccessLayer.Models;

namespace ElementMaterialsTechnology.Service
{
    public interface IQuotationService
	{
		public IEnumerable<QuotationViewModel> GetQuotations();

		public IEnumerable<QuotationViewModel> UpdateQuotation(QuotationViewModel quotation);

		public IEnumerable<QuotationViewModel> AddQuotation(QuotationViewModel quotation);

		public IEnumerable<long> SearchQuotationsByDate(DateTime? fromDate, DateTime? toDate);
	}
}
