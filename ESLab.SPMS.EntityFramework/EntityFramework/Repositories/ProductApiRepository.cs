using ESLab.SPMS.ProductApis;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class ProductApiRepository : SPMSRepositoryBase<ProductApi>, IProductApiRepository
    {
        public ProductApiRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
