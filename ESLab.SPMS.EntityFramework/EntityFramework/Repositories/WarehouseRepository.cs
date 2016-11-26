using Abp.EntityFramework;
using ESLab.SPMS.Warehouses;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class WarehouseRepository : SPMSRepositoryBase<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
