using ElementMaterialsTechnology.DataAccessLayer.Models;

namespace ElementMaterialsTechnology.Service
{
    public class ProductService : AbstractServiceBase, IProductService
	{
		public ProductService(TechTestContext techTestContext) : base(techTestContext) { }		

		public IList<Product> GetProducts()
		{
			return _techTestContext.Products.Select(p => p).ToList();
		}
	}
}
