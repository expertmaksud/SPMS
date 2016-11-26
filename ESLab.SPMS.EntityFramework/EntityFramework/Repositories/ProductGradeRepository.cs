using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESLab.SPMS.ProductGrades;
using Abp.EntityFramework;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class ProductGradeRepository : SPMSRepositoryBase<ProductGrade>, IProductGradeRepository
    {
        public ProductGradeRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}