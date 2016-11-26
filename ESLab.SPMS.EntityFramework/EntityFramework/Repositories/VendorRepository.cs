using ESLab.SPMS.Vendors;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class VendorRepository : SPMSRepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
