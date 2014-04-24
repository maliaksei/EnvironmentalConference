using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class FormOfParticipationFilters
    {
        public static IQueryable<ParticipationForms> FormOfParticipationByConferenceId(this IQueryable<ParticipationForms> model, int conferenceId)
        {
            return model.Where(x => x.ConferenceForms.Where(y => y.ConferenceId == conferenceId) != null);
        }
    }
}
