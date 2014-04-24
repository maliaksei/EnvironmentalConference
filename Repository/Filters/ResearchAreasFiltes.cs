using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class ResearchAreasFiltes
    {
        public static IQueryable<ResearchAreas> ResearchAreasByConferenceId(this IQueryable<ResearchAreas> model,
            int conferenceId)
        {
            return model.Where(x => x.ConferenceId == conferenceId);
        }
    }
}
