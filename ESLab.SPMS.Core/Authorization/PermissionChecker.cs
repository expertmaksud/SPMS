using Abp.Authorization;
using ESLab.SPMS.Authorization.Roles;
using ESLab.SPMS.MultiTenancy;
using ESLab.SPMS.Users;

namespace ESLab.SPMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
