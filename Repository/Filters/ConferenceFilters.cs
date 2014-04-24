using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Data.Enums;

namespace Repository.Filters
{
    public static class ConferenceFilters
    {
        public static Conferences ConferenceById(this IQueryable<Conferences> conferenceses, int id)
        {
            return conferenceses.SingleOrDefault(x => x.ConferenceId == id);
        }

        public static IQueryable<Conferences> GetActiveConferenceses(this IQueryable<Conferences> conferenceses)
        {
            var activeConferenceses = from conferencese in conferenceses
                let currentStatus =
                    conferencese.ConferenceStatus.OrderByDescending(x => x.DateChange).FirstOrDefault().StatusesId
                where currentStatus == (int) ConferenceStatusType.Active
                select conferencese;

            return
                activeConferenceses;
        }
    }
}
