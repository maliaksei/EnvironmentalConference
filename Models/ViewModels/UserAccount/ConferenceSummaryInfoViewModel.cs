using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.Properties;

namespace Models.ViewModels.UserAccount
{
    public class ConferenceSummaryInfoViewModel
    {
        public int ConferenceId { get; set; }

        [Display(Name = "ConferenceSummaryInfoViewModel_NameOfConference", ResourceType = typeof(Resources))]
        public string NameOfConference { get; set; }

        [Display(Name = "ConferenceSummaryInfoViewModel_BriefInformation", ResourceType = typeof(Resources))]
        public string BriefInformation { get; set; }

        [Display(Name = "ConferenceSummaryInfoViewModel_StartDate", ResourceType = typeof(Resources))]
        public DateTime StartDate { get; set; }

        [Display(Name = "ConferenceSummaryInfoViewModel_MeetingPoint", ResourceType = typeof(Resources))]
        public string MeetingPoint { get; set; }

        [Display(Name = "ConferenceSummaryInfoViewModel_ParticipationForms", ResourceType = typeof(Resources))]
        public IEnumerable<string> ParticipationForms { get; set; }

    }
}
