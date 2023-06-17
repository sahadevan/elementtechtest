using ElementMaterialsTechnology.Models;
using ElementMaterialsTechnology.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElementMaterialsTechnology.Controllers
{
	public class ProductController : Controller
	{
		private readonly ILogger<QuotationController> _logger;

		private readonly IProductService _productService;

		public ProductController(ILogger<QuotationController> logger, IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		public IEnumerable<Product> Read()
		{
			return _productService.GetProducts();
		}
	}
}
