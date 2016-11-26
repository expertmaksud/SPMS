using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESLab.SPMS
{
   public class SPMSAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var administration = context.CreatePermission("Administration", new LocalizableString("Administration", SPMSConsts.LocalizationSourceName));

            var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            userManagement.CreateChildPermission("Administration.UserManagement.CreateUser");

            var roleManagement = administration.CreateChildPermission("Administration.RoleManagement");

            var settings = context.CreatePermission("Settings", new LocalizableString("Settings", SPMSConsts.LocalizationSourceName));

        }
    }
}
