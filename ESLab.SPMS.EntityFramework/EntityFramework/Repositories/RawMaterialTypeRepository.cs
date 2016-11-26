using ESLab.SPMS.RawMaterialTypes;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class RawMaterialTypeRepository : SPMSRepositoryBase<RawMaterialType>, IRawMaterialTypeRepository
    {
        public RawMaterialTypeRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}