using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Data.Enums;

namespace Repository.Filters
{
    public static class ApplicationFilters
    {
        public static bool IsApplicationApplyAndConfirmed(this IQueryable<Application> applications, Guid userId,
            int conferenceId)
        {
            return
                applications.Any(
                    x =>
                        (x.ConferenceId == conferenceId && x.UserId == userId) &&
                        (x.ApplicationStatusId == (int) ApplicationStatuses.Apply ||
                         x.ApplicationStatusId == (int) ApplicationStatuses.Confirmed));
        }

        public static IQueryable<Application> GetActiveApplicationByUserId(this IQueryable<Application> applications, Guid userId)
        {
            return
                applications.Where(
                    x =>
                        x.UserId == userId &&
                        (x.ApplicationStatusId == (int) ApplicationStatuses.Apply ||
                         x.ApplicationStatusId == (int) ApplicationStatuses.Confirmed));
        }

        public static IQueryable<Application> GetActiveApplications(this IQueryable<Application> applications)
        {
            return
                applications.Where(
                    x =>
                       x.ApplicationStatusId == (int)ApplicationStatuses.Apply ||
                         x.ApplicationStatusId == (int)ApplicationStatuses.Confirmed);
        }

        public static IQueryable<Application> GetNewApplicationByUserId(this IQueryable<Application> applications, Guid userId)
        {
            return
                applications.Where(
                    x =>
                        x.UserId == userId && x.ApplicationStatusId == (int) ApplicationStatuses.New);
        }

        public static Application GetNewApplicationByUserIdAndConferenceId(this IQueryable<Application> applications, Guid userId, int conferenceId)
        {
            return
                applications.SingleOrDefault(
                    x =>
                        x.ConferenceId == conferenceId && x.UserId == userId &&
                        x.ApplicationStatusId == (int) ApplicationStatuses.New);
        }

        public static Application GetActiveApplicationByUserIdAndConferenceId(this IQueryable<Application> applications, Guid userId, int conferenceId)
        {
            return
                applications.SingleOrDefault(
                    x =>
                        x.ConferenceId == conferenceId && x.UserId == userId &&
                        (x.ApplicationStatusId == (int) ApplicationStatuses.Apply ||
                         x.ApplicationStatusId == (int) ApplicationStatuses.Confirmed));
        }

        public static Application GetApplicationById(this IQueryable<Application> applications, Guid applicationId)
        {
            return applications.SingleOrDefault(x => x.ApplicationId == applicationId);
        }
    }
}
