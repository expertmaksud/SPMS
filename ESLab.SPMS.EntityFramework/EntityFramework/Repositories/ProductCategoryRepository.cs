using Abp.EntityFramework;
using ESLab.SPMS.Brands;
using ESLab.SPMS.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public class ProductCategoryRepository : SPMSRepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
