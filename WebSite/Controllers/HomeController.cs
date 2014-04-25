using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Helpers;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;
using Repository;
using Repository.Filters;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager dataManager = new DataManager();

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        public ActionResult Index()
        {
          var viewActiveConference = ConferenceHeper.GetActiveConferenceViewModel();
          return View(viewActiveConference);
        }

        public ActionResult DetailsOfTheConference(int id)
        {
            var conference = dataManager.ConferenceRepository.GetAll().ConferenceById(id);
            if (conference != null)
            {
                var model = new DetailsOfTheConferenceViewModel
                { 
                    ConferenceId = conference.ConferenceId,
                    Summary = new SummaryViewModel
                    {
                        ConferenceId = conference.ConferenceId,
                        NameOfTheConference = conference.Name,
                        BriefInformation = conference.BriefInformation,
                        StartDate = conference.StartDate.ToString(),
                        Venue = conference.MeetingPoint
                    }
                };
                return View(model);
            }
            return View(new DetailsOfTheConferenceViewModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetCulture(string culture, string returnUrl)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}