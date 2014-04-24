using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Diplom.Data;
using Diplom.Data.Enums;
using Models.ViewModels.RegisterForConference;
using Repository;
using Repository.Filters;

namespace Helpers
{
    public static class RegisterForConferenceHelper
    {
        private static DataManager dataManager = new DataManager();

        public static RegisterForConferenceViewModel GetRegisterForConferenceViewModel(int conferenceId, Claim emailForAuthenticationUser)
        {
            dataManager = new DataManager();

            var email = emailForAuthenticationUser.Value;
            var currentUser = dataManager.UserRepository.GetAll().GetByEmail(email);

            if (dataManager.ApplicationRepository.GetAll()
                .IsApplicationApplyAndConfirmed(currentUser.UserId, conferenceId))
            {
                return null;
            }

            var activeApplication =
                dataManager.ApplicationRepository.GetAll()
                    .GetNewApplicationByUserIdAndConferenceId(currentUser.UserId, conferenceId) ??
                CreateApplication(conferenceId, email);


            return createRegisterForConferenceViewModel(conferenceId, activeApplication);
        }

        

        public static void SaveOtherApplicationData(RegisterForConferenceOtherDataViewModel viewModel)
        {
            dataManager = new DataManager();
            if (viewModel.ApplicationId == null)
            {
                throw new ArgumentException("Application id not be null.");
            }

            try
            {
                var application = new Application
                {
                    ApplicationId = viewModel.ApplicationId,
                    ApplicationStatusId = (int)ApplicationStatuses.New,
                    ParticipationFormId = viewModel.FormOfParticipationId,
                    Comment = viewModel.Comment,
                    IsHotel = viewModel.NeedForReservation,
                    ArrivalTime =
                        viewModel.EstimatedTimeOfArrival != null
                            ? DateTime.Parse(viewModel.EstimatedTimeOfArrival)
                            : (DateTime?)null
                };
                dataManager.ApplicationRepository.Update(application);
            }
            catch (DataException)
            {
                throw new Exception("No data is update.");
            }
        }

        public static void ApplyApplication(RegisterForConferenceOtherDataViewModel viewModel)
        {
            dataManager = new DataManager();

            SaveOtherApplicationData(viewModel);
            var application = dataManager.ApplicationRepository.GetAll().GetApplicationById(viewModel.ApplicationId);
            var reports = application != null ? application.Report : null;

            if (reports == null || !reports.Any())
            {
                throw new Exception("Reports not be null");
            }
            application.ApplicationStatusId = (int) ApplicationStatuses.Apply;
            dataManager.ApplicationRepository.Update(application);
        }

        private static Application CreateApplication(int conferenceId, string email)
        {
            dataManager = new DataManager();

            var partisipationForm =
                dataManager.FormOfParticipationRepositories.GetByConferenceId(conferenceId).FirstOrDefault();
            var user = new Users
            {
                Application = new List<Application>
                    {
                        new Application
                        {
                            ApplicationId = Guid.NewGuid(),
                            ApplicationStatusId = (int) ApplicationStatuses.New,
                            ConferenceId = conferenceId,
                            ParticipationFormId = partisipationForm != null ? partisipationForm.ParticipationFormId : 0,
                        }
                    },
                Email = email
            };
            dataManager.UserRepository.Update(user);//todo: use the ApplicationRepository
            return
                dataManager.ApplicationRepository.GetAll()
                    .GetApplicationById(user.Application.FirstOrDefault().ApplicationId);
        }

        private static RegisterForConferenceViewModel createRegisterForConferenceViewModel(int conferenceId, Application activeApplication)
        {
            var conference = dataManager.ConferenceRepository.GetAll().ConferenceById(conferenceId);

            //todo: add check in active conference!

            var model = new RegisterForConferenceViewModel
            {
                ConferenceId = conferenceId,

                UserReportsViewModel = new UserReportsViewModel
                {
                    ApplicationId = activeApplication.ApplicationId,
                    ResearchAreas = conference.ResearchAreas.ToList()
                           .Select(
                               x => new SelectListItem { Text = x.Name, Value = x.ResearchAreasId.ToString() })
                           .ToList()
                },

                RegisterForConferenceOtherData = new RegisterForConferenceOtherDataViewModel
                {
                    ApplicationId = activeApplication.ApplicationId,
                    EstimatedTimeOfArrival = activeApplication.ArrivalTime.ToString(),
                    Comment = activeApplication.Comment,
                    NeedForReservation = activeApplication.IsHotel ?? false,
                    FormOfParticipations = conference.ConferenceForms.ToList()
                           .Select(
                               x => new SelectListItem { Text = x.ParticipationForms.Name, Value = x.ParticipationForms.ParticipationFormId.ToString() })
                           .ToList()
                }
            };
            return model;
        }
    }
}
