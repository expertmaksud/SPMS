using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Runtime.Session;
using ESLab.SPMS.MultiTenancy;
using ESLab.SPMS.Users;

namespace ESLab.SPMS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SPMSAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SPMSAppServiceBase()
        {
            LocalizationSourceName = SPMSConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }
    }
}