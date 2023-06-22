using ElementMaterialsTechnology.DataAccessLayer.Models;

namespace ElementMaterialsTechnology.Service
{
    public abstract class AbstractServiceBase
	{
		protected readonly TechTestContext _techTestContext;

		public AbstractServiceBase(TechTestContext techTestContext)
		{
			_techTestContext = techTestContext;
		}
	}
}
