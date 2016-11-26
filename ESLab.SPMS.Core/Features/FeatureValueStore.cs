using Abp.Application.Features;
using ESLab.SPMS.Authorization.Roles;
using ESLab.SPMS.MultiTenancy;
using ESLab.SPMS.Users;

namespace ESLab.SPMS.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}