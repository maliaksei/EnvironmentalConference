using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class KeyDatesFilters
    {
        public static IQueryable<KeyDates> KeyDatesByConferenceId(this IQueryable<KeyDates> keyDateses, int conferenceId)
        {
            return keyDateses.Where(x => x.ConferenceId == conferenceId);
        }
    }
}
