using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Helpers;
using Membership;
using Microsoft.AspNet.Identity;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;
using Models.ViewModels.UserAccount;
using Repository;
using Diplom.Data;
using Repository.Filters;
using Trirand.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManageController : Controller
    {
        private readonly DataManager dataManager = new DataManager();
        #region Culture
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
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        #region Create and Edit Conference(Summary)
        //
        // GET: /AdminManage/
        public ActionResult CreateConference()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateConference(SummaryViewModel model)
        {
            try
            {
                var conference = ConferenceHeper.AddConference(model);
                var redirectUrl = new UrlHelper(Request.RequestContext).Action("EditConference", new { id = conference.ConferenceId });
                return Json(new { Url = redirectUrl });
            }
            catch (Exception e)
            {
                return Json("Конференция не создана.");
            }

        }


        public ActionResult EditConference(int conferenceId)
        {
            var confererenceViewModel = ConferenceHeper.ConferenceViewModelById(conferenceId);
            return View(confererenceViewModel);
        }



        [HttpPost]
        public JsonResult SaveSummaryData(SummaryViewModel model)
        {

            try
            {
                ConferenceHeper.EditConference(model);
                return Json("Ok");
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        #endregion

        #region Edit Organizing Committee (Contact infornmation)
        [HttpPost]
        public JsonResult EditOrganizingCommitteeContactInformation(OrganizingCommitteeViewModel model)
        {
            //todo: add send exeption
            OrganizingCommitteeHelper.UpdateOrganizingCommittee(model);
            return Json("Ok");
        }

        #endregion

        #region Form Of Participation and Finance And Layout

        [HttpPost]
        public JsonResult SaveFormOfParticipationData(FormOfParticipationViewModel model)
        {
            return ConferenceHeper.EditFormOfParticipation(model) ? Json("Ok") : null;
        }

        [HttpPost]
        public JsonResult SaveFinanceAndLayoutData(FinanceAndLayoutViewModel model)
        {
            return ConferenceHeper.EditFinanceAndLayout(model) ? Json("Ok") : null;
        }

        #endregion

        #region Validate and publicate

        [HttpPost]
        public JsonResult ValidateAndPublicate(int ConferenceId)
        {
            ConferenceHeper.ValidateAndPublicateConference(ConferenceId);
            return Json("Jk");
        }

        #endregion

        #region Admin Account

        public ActionResult PersonalAdminAccount()
        {
            var userEmail = User.Identity.GetUserId();
            var userModel = dataManager.UserRepository.GetAll().GetByEmail(userEmail);

            var activeConferencesViewModelForUser =
                dataManager.ConferenceRepository.GetAll().GetActiveConferenceses().ToList().Select(activeConference => new SummaryForActiveConferenceViewModel
                    {
                        ConferenceId = activeConference.ConferenceId,
                        NameOfTheConference = activeConference.Name,
                        BriefInformation = activeConference.BriefInformation,
                        StartDate = activeConference.StartDate.ToString(),
                        Venue = activeConference.MeetingPoint
                    });


            var model = new PersonalInfoViewModel
            {
                ViewActiveConferences = new ViewActiveConferencesViewModel
                {
                    ActiveConferences = activeConferencesViewModelForUser.ToList()
                },
                UserInfo = new UserInfoViewModel
                {
                    UserId = userModel.UserId,
                    AcademicDegree = userModel.AcademicDegree,
                    AcademicTitle = userModel.AcademicTitle,
                    Address = userModel.Address,
                    Email = userModel.Email,
                    Name = userModel.Name,
                    Organization = userModel.Organization,
                    Patronymic = userModel.Patronymic,
                    Phone = userModel.Phone.ToString(),
                    Surname = userModel.Surname
                }
            };

            return View(model);
        }

        public ActionResult DetailsInfoForConference(int conferenceId)
        {
            return View();
        }

        #endregion

    }
}