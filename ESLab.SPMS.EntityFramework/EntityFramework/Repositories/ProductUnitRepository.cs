using ESLab.SPMS.ProductUnits;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class ProductUnitRepository : SPMSRepositoryBase<ProductUnit>, IProductUnitRepository
    {
        public ProductUnitRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
