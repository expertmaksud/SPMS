using Abp.MultiTenancy;
using ESLab.SPMS.Users;

namespace ESLab.SPMS.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}