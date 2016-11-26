using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ESLab.SPMS.EntityFramework.Repositories
{
    public abstract class SPMSRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SPMSDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SPMSRepositoryBase(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SPMSRepositoryBase<TEntity> : SPMSRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SPMSRepositoryBase(IDbContextProvider<SPMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
