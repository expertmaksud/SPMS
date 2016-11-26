using ESLab.SPMS.Companies;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class CompanyRepository : SPMSRepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
