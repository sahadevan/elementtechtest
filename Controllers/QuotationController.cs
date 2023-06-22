using ElementMaterialsTechnology.Models;
using ElementMaterialsTechnology.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace ElementMaterialsTechnology.Controllers
{
	public class QuotationController : Controller
    {
        private readonly ILogger<QuotationController> _logger;

        private readonly IQuotationService _quotationService;

		public QuotationController(ILogger<QuotationController> logger, IQuotationService quotationService)
        {
            _logger = logger;
            _quotationService = quotationService;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IEnumerable<QuotationViewModel> Read()
		{
			return _quotationService.GetQuotations();
		}

        [HttpPost]
		public async Task<IEnumerable<QuotationViewModel>> Create()
		{
			var quotations = JsonConvert.DeserializeObject<List<QuotationViewModel>>(await GetRawBodyAsync(Request));
			foreach (var quotation in quotations)
			{
				_ = _quotationService.AddQuotation(quotation);
			}

			return _quotationService.GetQuotations();
		}

        [HttpPost]
		public async Task<IEnumerable<QuotationViewModel>> Update()
		{
			var quotations = JsonConvert.DeserializeObject<List<QuotationViewModel>>(await GetRawBodyAsync(Request));	
			
			foreach (var quotation in quotations) {
				_ = _quotationService.UpdateQuotation(quotation);
			}

			return _quotationService.GetQuotations();
		}

		[HttpPost]
		public async Task<IEnumerable<long>> SearchQuotationsByDate()
		{
			var dateRange = JsonConvert.DeserializeObject<QuotationDateRange>(await GetRawBodyAsync(Request));

			var quotationNos = new List<long>();

			try
			{
				quotationNos = _quotationService.SearchQuotationsByDate(dateRange.FromDate, dateRange.ToDate).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return quotationNos;
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		private async Task<string> GetRawBodyAsync(HttpRequest request)
		{
			if (!request.Body.CanSeek)
			{
				request.EnableBuffering();
			}
			request.Body.Position = 0;
			var reader = new StreamReader(request.Body, Encoding.UTF8);

			var body = await reader.ReadToEndAsync().ConfigureAwait(false);

			request.Body.Position = 0;

			return body;

		}
    }

	public struct QuotationDateRange
	{
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set;}
	}
}