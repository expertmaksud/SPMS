using Abp.Web.Mvc.Views;

namespace ESLab.SPMS.Web.Views
{
    public abstract class SPMSWebViewPageBase : SPMSWebViewPageBase<dynamic>
    {

    }

    public abstract class SPMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SPMSWebViewPageBase()
        {
            LocalizationSourceName = SPMSConsts.LocalizationSourceName;
        }
    }
}