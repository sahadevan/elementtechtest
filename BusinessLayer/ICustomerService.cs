using ElementMaterialsTechnology.DataAccessLayer.Models;

namespace ElementMaterialsTechnology.Service
{
    public interface ICustomerService
	{
		IList<Customer> GetCustomers();
	}
}
