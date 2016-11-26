using Abp.EntityFramework;
using ESLab.SPMS.FinishProductFormulas;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class FinishProductFormulaRepository : SPMSRepositoryBase<FinishProductFormula>, IFinishProductFormulaRepository
    {
        public FinishProductFormulaRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
