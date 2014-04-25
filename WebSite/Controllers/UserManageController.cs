using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Diplom.Data;
using Diplom.Data.Enums;
using Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Models.ViewModels;
using Models.ViewModels.RegisterForConference;
using Models.ViewModels.UserAccount;
using Repository;
using Repository.Filters;

namespace WebSite.Controllers
{
    public class UserManageController : Controller
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


        //
        // GET: /UserManage/
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult RegisterForConference()
        //{
        //    var asd = HttpContext.Request.QueryString;
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpGet]
        public ActionResult RegisterForConference(int conferenceId)
        {
            var emailForAuthenticationUser =
                Request.GetOwinContext().Authentication.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email);

            if (emailForAuthenticationUser != null)
            {
                var model = RegisterForConferenceHelper.GetRegisterForConferenceViewModel(conferenceId,
                    emailForAuthenticationUser);
                if (model != null)
                {
                    return View(model);
                }
                return RedirectToAction("CurrentApplyConference");
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult CurrentApplyConference()
        {
            return View();
        }

        public ActionResult PersonalUserAccount()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("PersonalAdminAccount", "AdminManage");
            }
            var emailForAuthenticationUser = User.Identity.GetUserId();
            if (!String.IsNullOrEmpty(emailForAuthenticationUser))
            {
                var model = UserManageHelper.GetAtiveConferencesForUserViewModel(emailForAuthenticationUser);
                return View(model);

            }
            return RedirectToAction("Login", "Account");
        }

        //[HttpGet]
        //public ActionResult DetailsInfoForRegisterConference()
        //{
        //    return RedirectToAction("PersonalUserAccount");
        //}

        [HttpGet]
        public ActionResult DetailsInfoForRegisterConference(int conferenceId)
        {
            var emailForAuthenticationUser = User.Identity.GetUserId();
            if (!String.IsNullOrEmpty(emailForAuthenticationUser))
            {
                var model = UserManageHelper.GetDetailsInfoForRegisterConferenceViewModel(conferenceId,
                    emailForAuthenticationUser);
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        public JsonResult AddUserReports(UserReportsViewModel viewModel)
        {
            try
            {
                var serverPathToReports = Server.MapPath("~/Files/UserReports/");
                UserReportsHelper.CreateReport(viewModel, serverPathToReports);

                return Json("Ok");
            }
            catch (Exception)
            {
                return new JsonResult();
            }

        }

        public JsonResult SaveConferenceOtherData(RegisterForConferenceOtherDataViewModel viewModel)
        {
            try
            {
                RegisterForConferenceHelper.SaveOtherApplicationData(viewModel);
                return Json("Ok");
            }
            catch (Exception e)
            {
                return new JsonResult
                {
                    Data = e.Message
                };//todo: verify
            }
        }

        public JsonResult ApplyApplication(RegisterForConferenceOtherDataViewModel viewModel)
        {
            try
            {
                RegisterForConferenceHelper.ApplyApplication(viewModel);
                return Json("Ok");//todo: redirect to user account
            }
            catch (Exception e)
            {
                return ThrowJSONError(e);//todo: Come up with another solution
            }
        }



        private JsonResult ThrowJSONError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            //Log your exception
            return Json(new { Message = e.Message });
        }
    }
}