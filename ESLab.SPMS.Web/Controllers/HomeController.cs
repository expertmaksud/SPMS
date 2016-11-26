using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ESLab.SPMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SPMSControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}