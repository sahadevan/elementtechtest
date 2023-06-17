using ElementMaterialsTechnology.Models;

namespace ElementMaterialsTechnology.Service
{
	public class CustomerService : AbstractServiceBase, ICustomerService
	{
		public CustomerService(TechTestContext techTestContext) : base(techTestContext)	{ }

		public IList<Customer> GetCustomers()
		{
			return _techTestContext.Customers.Select(p => p).ToList();
		}
	}
}
