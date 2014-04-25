using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;
using Models.ViewModels.RegisterForConference;
using Repository;
using Repository.Filters;

namespace Helpers
{
    public static class UserReportsHelper
    {
        private static  DataManager dataManager = new DataManager();
        private static string _directoryForReport;

        public static void RemoveAllFilesFromReport(Guid reportId, string serverPathToReports)
        {
            var report = dataManager.UserReportsRepository.GetAll().GeReportsByReportId(reportId);
            if (report == null) return;

            var pathToReport =
                Path.Combine(serverPathToReports, report.ApplicationId.ToString(), report.ReportId.ToString());
            Directory.Delete(pathToReport, true);

        }

        public static void CreateReport(UserReportsViewModel viewModel, string serverPathToReports)
        {
            dataManager = new DataManager();
            var reportId = Guid.NewGuid();
            try
            {
                _directoryForReport = Path.Combine(serverPathToReports, viewModel.ApplicationId.ToString(),
                    reportId.ToString());
                if (!Directory.Exists(_directoryForReport))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_directoryForReport);
                }
                string pathForReport = String.Empty;
                string pathForCheck = String.Empty;

                if (viewModel.PathToReport != null)
                {
                    var fileOfReport = viewModel.PathToReport.Split(',');
                    byte[] dataForReport = Convert.FromBase64String(fileOfReport[1]);

                    pathForReport = Path.Combine(_directoryForReport, fileOfReport[2]);
                    System.IO.File.WriteAllBytes(pathForReport, dataForReport);
                }

                //------
                var report = new Report
                {
                    ReportId = reportId,
                    NameReport = viewModel.NameOfReport,
                    UploadDate = DateTime.Now,
                    PathReport = pathForReport,
                    ApplicationId = viewModel.ApplicationId,
                    ResearchAreasId = viewModel.ResearchAreasId,
                    AuthorsReport = viewModel.AuthorsReport,
                };

                if (viewModel.PathToCheck != null)
                {
                    var fileOfCheck = viewModel.PathToCheck.Split(',');
                    byte[] dataForCheck = Convert.FromBase64String(fileOfCheck[1]);

                    pathForCheck = Path.Combine(_directoryForReport, fileOfCheck[2]);
                    System.IO.File.WriteAllBytes(pathForCheck, dataForCheck);

                    report.Check = new List<Check>
                    {
                        new Check
                        {
                            CheckId = Guid.NewGuid(),
                            StatusId = 1, //todo: add enum
                            PathCheck = pathForCheck
                        }
                    };
                }

                dataManager.UserReportsRepository.Add(report);

            }
                //todo: add return message exeption
            catch (DataException)
            {
                RemoveAllFoldersAndFiles();
                throw;
            }
            catch (SystemException)
            {
                dataManager.UserReportsRepository.DeleteForId(reportId);
                throw;
            }
        }

        private static void RemoveAllFoldersAndFiles()
        {
            Directory.Delete(_directoryForReport, true);
        }
    }
}
