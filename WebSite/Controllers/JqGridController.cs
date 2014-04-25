using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Diplom.Data;
using Helpers;
using Microsoft.Ajax.Utilities;
using Models.JqGridModels;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;
using Repository;
using Repository.Filters;
using Trirand.Web.Mvc;


namespace WebSite.Controllers
{
    public class JqGridController : Controller
    {
        private readonly DataManager dataManager = new DataManager();

        #region Key Dates
        public JsonResult KeyDatesDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var gridModel = new KeyDatesJqGridModel();
            return gridModel.OrdersGrid.DataBind(dataManager.KeyDatesRepositories.GetAll().KeyDatesByConferenceId(conferenceId).AsEnumerable()
                .Select(evnt =>
                    new
                    {
                        DateId = evnt.KeyDateId,
                        StartDate = evnt.StaDate,
                        EndDate = evnt.EndDate,
                        Description = evnt.Description,
                        ConferenceId = evnt.ConferenceId
                    }).AsQueryable());
        }


        public JsonResult KeyDatesAddEditJsonResult(KeyDatesViewModel item)
        {
            var gridModel = new KeyDatesJqGridModel();
            var keyDatesDataModel = KeyDatesHelper.KeyDatesViewModelToDataModel(item);
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                try
                {
                    dataManager.KeyDatesRepositories.Update(keyDatesDataModel);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        keyDatesDataModel.ConferenceId = conferenceId;
                        dataManager.KeyDatesRepositories.Add(keyDatesDataModel);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.ToString());
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                dataManager.KeyDatesRepositories.Delete(keyDatesDataModel);
            }
            return null;
        }

        #endregion

        #region Research Areas

        public JsonResult ResearchAreasDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                var gridModel = new ResearchAreasJqGridModel();
                return gridModel.OrdersGrid.DataBind(dataManager.ResearchAreasRepository.GetAll().ResearchAreasByConferenceId(conferenceId).AsEnumerable()
                         .Select(evnt =>
                             new
                             {
                                 Id = evnt.ResearchAreasId,
                                 Name = evnt.Name,
                                 DateTime = evnt.DateAndTime,
                                 Description = evnt.Description,
                                 Venue = evnt.Venue,
                                 ConferenceId = evnt.ConferenceId
                             }).AsQueryable());
            }
            return null;
        }

        public JsonResult ResearchAreasAddEditJsonResult(ResearchAreasViewModel item)
        {
            var gridModel = new ResearchAreasJqGridModel();
            var researchAreasDataModel = ResearchAreasHelper.ResearchAreasViewModelToDataModel(item);
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                try
                {
                    dataManager.ResearchAreasRepository.Update(researchAreasDataModel);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        researchAreasDataModel.ConferenceId = conferenceId;
                        dataManager.ResearchAreasRepository.Add(researchAreasDataModel);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.ToString());
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                dataManager.ResearchAreasRepository.Delete(researchAreasDataModel);
            }
            return null;
        }

        #endregion

        #region Organizing Committee Members

        public JsonResult OrganizingCommitteeMembersDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                var gridModel = new OrganizingCommitteeMembersJqGridModel();
                return
                    gridModel.OrdersGrid.DataBind(
                        dataManager.OrganizingCommitteeMembersRepositories.GetAll()
                            .OrganizingCommitteeMembersByConferenceIdId(conferenceId)
                            .AsEnumerable()
                            .Select(evnt =>
                                new
                                {
                                    OrganizingCommitteeMembersId = evnt.OrganizingCommitteeMemberId,
                                    FullName = evnt.Surname + " " + evnt.Name + " " + evnt.Patronymic,
                                    evnt.Post,
                                    evnt.Name,
                                    evnt.Surname,
                                    evnt.Patronymic,
                                    evnt.AdditionalInformation,
                                    evnt.OrganizingCommitteeId
                                }).AsQueryable());
            }
            return null;
        }


        public JsonResult OrganizingCommitteeMembersAddEditJsonResult(OrganizingCommitteeMembersViewModel item)
        {
            var gridModel = new OrganizingCommitteeMembersJqGridModel();
            var organizingCommitteeMembersDataModel = OrganizingCommitteeMembersHelper.OrganizingCommitteeMembersViewModelToDataModel(item);
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                try
                {
                    dataManager.OrganizingCommitteeMembersRepositories.Update(organizingCommitteeMembersDataModel);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        var organizingCommittee =
                            dataManager.OrganizingCommitteeRepositories.GetAll()
                                .OrganizingCommitteeByConferenceIdId(conferenceId);
                        if (organizingCommittee != null)
                        {
                            organizingCommitteeMembersDataModel.OrganizingCommitteeId =
                                organizingCommittee.OrganizingCommitteeId;
                            dataManager.OrganizingCommitteeMembersRepositories.Add(organizingCommitteeMembersDataModel);
                        }

                    }
                }
                catch (Exception e)
                {
                    return Json(e.ToString());
                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                dataManager.OrganizingCommitteeMembersRepositories.Delete(organizingCommitteeMembersDataModel);
            }
            return null;
        }

        #endregion

        #region Files Of Conference

        public JsonResult FilesOfConferenceDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var gridModel = new FilesOfConferenceJqGridModel();
            return gridModel.OrdersGrid.DataBind(dataManager.FilesOfConferenceRepositories.GetAll().FilesOfConferenceByConferenceId(conferenceId).AsEnumerable()
                .Select(evnt =>
                    new
                    {
                        evnt.FileConferenceId,
                        evnt.Name,
                        evnt.Path,
                        evnt.Description,
                        evnt.ConferenceId
                    }).AsQueryable());
        }

        public JsonResult FilesOfConferenceAddEditJsonResult(FilesOfConferenceViewModel item)
        {
            var gridModel = new FilesOfConferenceJqGridModel();
            //todo: chanfe patch to ~/Files/FilesOfConference/
            var serverPath = Server.MapPath("~/Files/");
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        item.ConferenceId = conferenceId;

                        var filesOfConferencedataModel = FilesOfConferenceHelper.CreateFilesOfConferenceByViewModel(item, serverPath);
                        dataManager.FilesOfConferenceRepositories.Add(filesOfConferencedataModel);
                    }
                }
                catch (Exception e)
                {

                }
            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                var dataModel = dataManager.FilesOfConferenceRepositories.GetAll().FilesOfConferenceId(item.FileConferenceId);
                if (FilesOfConferenceHelper.DeleteFilesOfConference(dataModel, serverPath))
                {
                    dataManager.FilesOfConferenceRepositories.Delete(dataModel);
                }

            }
            return null;
        }

        #endregion

        #region Form Of Participation
        public JsonResult FormOfParticipationDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var gridModel = new FormOfParticipationJqGridModel();
            return gridModel.OrdersGrid.DataBind(dataManager.FormOfParticipationRepositories.GetConferenceFormsByConferenceId(conferenceId).AsEnumerable()
                .Select(evnt =>
                    new
                    {
                        evnt.ConferenceFormId,
                        evnt.ConferenceId,
                        FormOfParticipationName = evnt.ParticipationForms.Name
                    }).AsQueryable());
        }

        public JsonResult FormOfParticipationEditJsonResult(FormOfParticipationEditJsonModel model)
        {

            var gridModel = new FormOfParticipationJqGridModel();
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        var conferenceForm = new ConferenceForms
                        {
                            ConferenceId = conferenceId,
                            ParticipationFormId = model.FormOfParticipationName
                        };
                        dataManager.FormOfParticipationRepositories.AddForConference(conferenceForm);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.ToString());
                }

            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                dataManager.FormOfParticipationRepositories.DeleteForConference(model.ConferenceFormId);
            }
            return null;
        }

        #endregion

        #region Languages Of Conference

        public JsonResult LanguagesConferenceDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var gridModel = new LanguagesConferenceJqGridModel();
            return
                gridModel.OrdersGrid.DataBind(
                    dataManager.LanguagesConferenceRepositories.GetLanguagesConferenceByConferenceId(conferenceId)
                        .AsEnumerable()
                        .Select(evnt =>
                            new
                            {
                                evnt.LanguagesConferenceId,
                                evnt.ConferenceId,
                                Language = evnt.Languages.Name
                            }).AsQueryable());
        }

        public JsonResult LanguagesConferenceEditJsonResult(LanguagesConferenceEditJsonModel model)
        {

            var gridModel = new FormOfParticipationJqGridModel();
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                try
                {
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
                        var conferenceForm = new LanguagesConference
                        {
                            LanguagesConferenceId = Guid.NewGuid(),
                            ConferenceId = conferenceId,
                            LanguagesId = model.Language
                        };
                        dataManager.LanguagesConferenceRepositories.AddForConference(conferenceForm);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.ToString());
                }

            }
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                dataManager.LanguagesConferenceRepositories.DeleteForConference(model.LanguagesConferenceId);
            }
            return null;
        }

        #endregion

        #region User Reports
        [Authorize]
        public JsonResult UserReportsDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var userName =
                 Request.GetOwinContext().Authentication.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var gridModel = new UserReportsJqGridModel();
            return
                gridModel.OrdersGrid.DataBind(
                    dataManager.UserReportsRepository.GetAll().GeReportsByUserNameAndConferenceId(userName, conferenceId)
                        .AsEnumerable()
                        .Select(evnt =>
                            new
                            {
                                Id = evnt.ReportId,
                                ResearchAreas = evnt.ResearchAreas.Name,
                                PathToReport = !evnt.PathReport.IsEmpty(),
                                PathToCheck = evnt.Check.Any(x => x.ReportId == evnt.ReportId),
                                NameOfReport = evnt.NameReport,
                                AuthorsReport = evnt.AuthorsReport,
                                ConferenceId = conferenceId
                            }).AsQueryable());
        }

        public JsonResult UserReportsEditJsonResult(Guid id)
        {
            var serverPathToReports = Server.MapPath("~/Files/UserReports/");
            var gridModel = new UserReportsJqGridModel();
            if (gridModel.OrdersGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                UserReportsHelper.RemoveAllFilesFromReport(id, serverPathToReports);
                dataManager.UserReportsRepository.DeleteForId(id);
            }
            return null;
        }
        #endregion

        #region Participations of the conference
        public JsonResult ParticipationConferenceDataBindJsonResult()
        {
            if (HttpContext.Request.UrlReferrer == null) return null;
            var conferenceId = int.Parse(HttpContext.Request.UrlReferrer.Segments[3]);
            var gridModel = new ParticipantsConferenceJqGridModel();
            return
                gridModel.OrdersGrid.DataBind(
                    dataManager.ConferenceRepository.GetAll().ConferenceById(conferenceId).Application.AsEnumerable()
                        .Select(evnt =>
                            new
                            {
                                DateId = evnt.UserId,
                                FullName = evnt.Users.Name + " " + evnt.Users.Surname + " " + evnt.Users.Patronymic,
                                IsHostel = evnt.IsHotel,
                                ConferenceId = evnt.ConferenceId,
                                FormOfParticipation = evnt.ParticipationForms.Name,
                                Comment = evnt.Comment,
                                ArrivalTime = evnt.ArrivalTime
                            }).AsQueryable());
        }

        #endregion
    }
}