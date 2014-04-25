using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Data.Enums;

namespace Repository.Filters
{
    public static class UserReportsFilters
    {
        public static IQueryable<Report> GeReportsByUserNameAndConferenceId(this IQueryable<Report> reports, string userName, int conferenceId)
        {
            return reports.Where(x => x.Application.ConferenceId == conferenceId && x.Application.Users.Email == userName && x.Application.ApplicationStatusId != (int)ApplicationStatuses.Delete);
        }

        public static Report GeReportsByReportId(this IQueryable<Report> reports, Guid reportId)
        {
            return reports.SingleOrDefault(x => x.ReportId == reportId);
        }

    }
}
