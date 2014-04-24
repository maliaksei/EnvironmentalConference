using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class FilesOfConferenceFilters
    {
        public static IQueryable<FilesConference> FilesOfConferenceByConferenceId(this IQueryable<FilesConference> keyDateses, int conferenceId)
        {
            return keyDateses.Where(x => x.ConferenceId == conferenceId);
        }

        public static FilesConference FilesOfConferenceId(this IQueryable<FilesConference> keyDateses, Guid fileOfConferenceId)
        {
            return keyDateses.SingleOrDefault(x => x.FileConferenceId == fileOfConferenceId);
        }
    }
}
