using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Diplom.Data;
using Diplom.Data.Enums;
using Models.JqGridModels;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;
using Repository;
using Repository.Filters;

namespace Helpers
{
    public static class ConferenceHeper
    {
        private static DataManager dataManager = new DataManager();

        public static ConferenceViewModel ConferenceViewModelById(int id)
        {
            dataManager = new DataManager();

            var model = dataManager.ConferenceRepository.GetAll().ConferenceById(id);
            var organizingCommitteeForConference = model.OrganizingCommittee.First();

            var gridModel = new KeyDatesJqGridModel();

            if (model != null)
            {
                return new ConferenceViewModel
                {
                    Summary = new SummaryViewModel
                    {
                        ConferenceId = model.ConferenceId,
                        NameOfTheConference = model.Name,
                        BriefInformation = model.BriefInformation,
                        StartDate = model.StartDate.ToString(),
                        Venue = model.MeetingPoint
                    },
                    //todo: deleted
                    KeyDatesModel = gridModel,
                    OrganizingCommittee = new OrganizingCommitteeViewModel
                    {
                        OrganizingCommitteeId = organizingCommitteeForConference.OrganizingCommitteeId,
                        Address = organizingCommitteeForConference.Address,
                        Email = organizingCommitteeForConference.Email,
                        Phone = organizingCommitteeForConference.Phone
                    },
                    FormOfParticipation = new FormOfParticipationViewModel
                    {
                        ConferenceId = model.ConferenceId,
                        ConditionsOfParticipation = model.ConditionsOfParticipation,
                        ArrangementFee = model.ArrangementFee
                    },
                    FinanceAndLayout = new FinanceAndLayoutViewModel
                    {
                        ConferenceId = model.ConferenceId,
                        FinancialConditions = model.FinancialConditions,
                        RequirementsForRegistration = model.RequirementsForTheMaterials
                    }
                };
            }
            return null;
        }

        public static Conferences AddConference(SummaryViewModel model)
        {
            dataManager = new DataManager();
            if (!model.IsValid()) return null;
            var conferenceModel = new Conferences
            {
                Name = model.NameOfTheConference,
                BriefInformation = model.BriefInformation,
                //todo: testing
                StartDate = DateTime.Parse(model.StartDate),
                MeetingPoint = model.Venue
            };
            return dataManager.ConferenceRepository.Add(conferenceModel);
        }

        public static bool EditConference(SummaryViewModel model)
        {
            if (!model.IsValid()) return false;
            var conference = dataManager.ConferenceRepository.GetAll().ConferenceById(model.ConferenceId);
            conference.Name = model.NameOfTheConference;
            conference.BriefInformation = model.BriefInformation;
                //todo: testing
            conference.StartDate = DateTime.Parse(model.StartDate);
            conference.MeetingPoint = model.Venue;
            dataManager.ConferenceRepository.Update(conference);
            return true;
        }

        public static bool EditFormOfParticipation(FormOfParticipationViewModel model)
        {
            var conferenceDataModel = dataManager.ConferenceRepository.GetAll().ConferenceById(model.ConferenceId);
            if (conferenceDataModel == null) return false;
            conferenceDataModel.ConditionsOfParticipation = model.ConditionsOfParticipation;
            conferenceDataModel.ArrangementFee = model.ArrangementFee;
            dataManager.ConferenceRepository.Update(conferenceDataModel);
            return true;
        }

        public static bool EditFinanceAndLayout(FinanceAndLayoutViewModel model)
        {
            var conferenceDataModel = dataManager.ConferenceRepository.GetAll().ConferenceById(model.ConferenceId);
            if (conferenceDataModel == null) return false;
            conferenceDataModel.FinancialConditions = model.FinancialConditions;
            conferenceDataModel.RequirementsForTheMaterials = model.RequirementsForRegistration;
            dataManager.ConferenceRepository.Update(conferenceDataModel);
            return true;
        }

        public static List<string> ValidateAndPublicateConference(int conferenceId)
        {
            var listError = new List<string>();
            var conference = dataManager.ConferenceRepository.GetAll().ConferenceById(conferenceId);
            if (String.IsNullOrEmpty(conference.Name))
            {
                listError.Add("Error1");
            }
            if (String.IsNullOrEmpty(conference.BriefInformation))
            {
                listError.Add("Error2");
            }

            //todo: add all checks
            if (!conference.KeyDates.Any())
            {
                listError.Add("Error3");
            }

            if (!listError.Any())
            {
                conference.ConferenceStatus = new Collection<ConferenceStatus>
                {
                    new ConferenceStatus
                    {
                        ConferenceStatusId = Guid.NewGuid(),
                        StatusesId = (int)ConferenceStatusType.Active,
                        DateChange = DateTime.Now
                    }
                };
                   
                dataManager.ConferenceRepository.Update(conference);
            }
            return listError;
        }

        public static ViewActiveConferencesViewModel GetActiveConferenceViewModel()
        {
             var activeConferences =
                dataManager.ConferenceRepository.GetAll().GetActiveConferenceses();
            if (activeConferences.Any())
            {
                var activeConferencesViewModel =
                    activeConferences.ToList().Select(activeConference => new SummaryForActiveConferenceViewModel
                    {
                        ConferenceId = activeConference.ConferenceId,
                        NameOfTheConference = activeConference.Name,
                        BriefInformation = activeConference.BriefInformation,
                        StartDate = activeConference.StartDate.ToString(),
                        Venue = activeConference.MeetingPoint
                    });
                return  new ViewActiveConferencesViewModel
                {
                    ActiveConferences = activeConferencesViewModel
                };
            }
            return new ViewActiveConferencesViewModel();
        }
    }
}
