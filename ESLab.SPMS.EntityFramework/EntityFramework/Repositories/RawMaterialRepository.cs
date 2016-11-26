using ESLab.SPMS.RawMaterials;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class RawMaterialRepository : SPMSRepositoryBase<RawMaterial>, IRawMaterialRepository
    {
        public RawMaterialRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
