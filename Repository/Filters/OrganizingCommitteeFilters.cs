using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class OrganizingCommitteeFilters
    {
        public static IQueryable<OrganizingCommittee> OrganizingCommitteeByOrganizingCommitteeId(this IQueryable<OrganizingCommittee> model,
            int organizingCommitteeId)
        {
            return model.Where(x => x.OrganizingCommitteeId == organizingCommitteeId);
        }

        public static OrganizingCommittee OrganizingCommitteeByConferenceIdId(this IQueryable<OrganizingCommittee> model,
           int conferenceId)
        {
            return model.SingleOrDefault(x => x.ConferenceId == conferenceId);
        }
    }
}
