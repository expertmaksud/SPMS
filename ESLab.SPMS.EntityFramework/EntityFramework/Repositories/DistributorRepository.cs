using ESLab.SPMS.Distributors;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class DistributorRepository : SPMSRepositoryBase<Distributor>, IDistributorRepository
    {
        public DistributorRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
