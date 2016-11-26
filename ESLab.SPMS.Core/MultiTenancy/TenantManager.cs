using Abp.MultiTenancy;
using ESLab.SPMS.Authorization.Roles;
using ESLab.SPMS.Editions;
using ESLab.SPMS.Users;

namespace ESLab.SPMS.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}