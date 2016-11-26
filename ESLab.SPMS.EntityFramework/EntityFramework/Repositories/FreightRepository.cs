using ESLab.SPMS.Freights;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class FreightRepository : SPMSRepositoryBase<Freight>, IFreightRepository
    {
        public FreightRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
