using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.ViewModels;
using Models.ViewModels.UserAccount;
using Repository;
using Repository.Filters;

namespace Helpers
{
    public static class UserManageHelper
    {
        private static DataManager dataManager = new DataManager();

        public static PersonalInfoViewModel GetAtiveConferencesForUserViewModel(string emailForAuthenticationUser)
        {
            dataManager = new DataManager();
            var currentUser = dataManager.UserRepository.GetAll().GetByEmail(emailForAuthenticationUser);


                var activeConferencesViewModelForUser =
                    dataManager.ApplicationRepository.GetAll()
                        .GetActiveApplicationByUserId(currentUser.UserId)
                        .Select(x => x.Conferences)
                        .GetActiveConferenceses().ToList().Select(activeConference => new SummaryForActiveConferenceViewModel
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
                        UserId = currentUser.UserId,
                        AcademicDegree = currentUser.AcademicDegree,
                        AcademicTitle = currentUser.AcademicTitle,
                        Address = currentUser.Address,
                        Email = currentUser.Email,
                        Name = currentUser.Name,
                        Organization = currentUser.Organization,
                        Patronymic = currentUser.Patronymic,
                        Phone = currentUser.Phone.ToString(),
                        Surname = currentUser.Surname
                    }
                };
            return model;
        }

        public static DetailsInfoForRegisterConferenceViewModel GetDetailsInfoForRegisterConferenceViewModel(int conferenceId, string emailForAuthenticationUser)
        {
            var currentUserId = dataManager.UserRepository.GetAll().GetByEmail(emailForAuthenticationUser).UserId;

            var application =
                dataManager.ApplicationRepository.GetAll()
                    .GetActiveApplicationByUserIdAndConferenceId(currentUserId, conferenceId);

            var participationFormsSelectLIstItem =
                dataManager.FormOfParticipationRepositories.GetByConferenceId(conferenceId).ToList()
                    .Select(
                        x => new SelectListItem { Text = x.Name, Value = x.ParticipationFormId.ToString(), Selected = x.ParticipationFormId == application.ParticipationFormId })
                    .ToList();

            var namesOfParticipationForms =
                dataManager.FormOfParticipationRepositories.GetByConferenceId(conferenceId).Select(x => x.Name);

            var detailsInfoForRegisterConferenceViewModel = new DetailsInfoForRegisterConferenceViewModel
            {
                ConferenceSummaryInfo = new ConferenceSummaryInfoViewModel
                {
                    ConferenceId = application.ConferenceId,
                    BriefInformation = application.Conferences.BriefInformation,
                    MeetingPoint = application.Conferences.MeetingPoint,
                    NameOfConference = application.Conferences.Name,
                    ParticipationForms = namesOfParticipationForms,
                    StartDate = application.Conferences.StartDate
                },
                ActiveApplicationInfoViewModel = new SummaryApplicationInfoViewModel
                {
                    ApplicationId = application.ApplicationId,
                    ApplicationStatusId = application.ApplicationStatusId,
                    IsHotel = application.IsHotel ?? false,
                    ArrivalTime = application.ArrivalTime,
                    Comment = application.Comment,
                    ParticipationFormId = application.ParticipationFormId,
                    ParticipationFormsListItems = participationFormsSelectLIstItem
                },

            };
            return detailsInfoForRegisterConferenceViewModel;
        }
    }
}
