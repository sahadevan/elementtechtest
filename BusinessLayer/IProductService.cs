using ElementMaterialsTechnology.DataAccessLayer.Models;

namespace ElementMaterialsTechnology.Service
{
    public interface IProductService
	{
		IList<Product> GetProducts();
	}
}
