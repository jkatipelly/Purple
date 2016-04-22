using System;
using System.Web.Http;
using System.Web.Mvc;
using Purple.WebAPI.Areas.HelpPage.ModelDescriptions;
using Purple.WebAPI.Areas.HelpPage.Models;

namespace Purple.WebAPI.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {        

        protected static HttpConfiguration Configuration
        {
            get { return GlobalConfiguration.Configuration; }
        }

        public ActionResult Index()
        {
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View("Error");
        }

    }
}