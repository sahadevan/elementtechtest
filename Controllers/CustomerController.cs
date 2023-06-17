using ElementMaterialsTechnology.Models;
using ElementMaterialsTechnology.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElementMaterialsTechnology.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ILogger<QuotationController> _logger;

		private readonly ICustomerService _customerService;

		public CustomerController(ILogger<QuotationController> logger, ICustomerService customerService)
		{
			_logger = logger;
			_customerService = customerService;
		}

		public IEnumerable<Customer> Read()
		{
			return _customerService.GetCustomers();
		}
	}
}
