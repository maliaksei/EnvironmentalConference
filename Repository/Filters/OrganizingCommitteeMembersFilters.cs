using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class OrganizingCommitteeMembersFilters
    {
        public static IQueryable<OrganizingCommitteeMembers> OrganizingCommitteeMembersByOrganizingCommitteeId(this IQueryable<OrganizingCommitteeMembers> model,
            int organizingCommitteeId)
        {
            return model.Where(x => x.OrganizingCommitteeId == organizingCommitteeId);
        }

        public static IQueryable<OrganizingCommitteeMembers> OrganizingCommitteeMembersByConferenceIdId(this IQueryable<OrganizingCommitteeMembers> model,
           int conferenceId)
        {
            return model.Where(x => x.OrganizingCommittee.ConferenceId == conferenceId);
        }
    }
}
