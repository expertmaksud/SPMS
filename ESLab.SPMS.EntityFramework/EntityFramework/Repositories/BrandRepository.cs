using ESLab.SPMS.Brands;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class BrandRepository : SPMSRepositoryBase<Brand>,IBrandRepository
    {
        public BrandRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
