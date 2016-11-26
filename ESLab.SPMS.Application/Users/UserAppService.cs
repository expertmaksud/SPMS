using Abp.Application.Services;
using Abp.Authorization;
using ESLab.SPMS.Users.Dtos;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ESLab.SPMS.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);
            
            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            await _userManager.RemoveFromRoleAsync(userId, roleName);
        }
    }
}
