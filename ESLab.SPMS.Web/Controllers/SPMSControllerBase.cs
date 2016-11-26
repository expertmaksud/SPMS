using Abp.Web.Mvc.Controllers;

namespace ESLab.SPMS.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class SPMSControllerBase : AbpController
    {
        protected SPMSControllerBase()
        {
            LocalizationSourceName = SPMSConsts.LocalizationSourceName;
        }
    }
}