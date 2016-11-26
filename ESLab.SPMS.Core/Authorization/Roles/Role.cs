using Abp.Authorization.Roles;
using ESLab.SPMS.MultiTenancy;
using ESLab.SPMS.Users;

namespace ESLab.SPMS.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}