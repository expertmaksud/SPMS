using Abp.EntityFramework;
using ESLab.SPMS.FinishProducts;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class FinishProductRepository : SPMSRepositoryBase<FinishProduct>, IFinishProductRepository
    {
        public FinishProductRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
