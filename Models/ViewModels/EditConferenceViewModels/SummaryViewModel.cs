using System.ComponentModel.DataAnnotations;
using Models.Properties;

namespace Models.ViewModels.EditConferenceViewModels
{
    public class SummaryViewModel
    {
        public int ConferenceId { get; set; }

        [Display(Name = "Summary_NameOfTheConference", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string NameOfTheConference { get; set; }

        [Display(Name = "Summary_BriefInformation", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string BriefInformation { get; set; }

        [Display(Name = "Summary_StartDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string StartDate { get; set; }

        [Display(Name = "Summary_Venue", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string Venue { get; set; }

        public bool IsValid()
        {
            return StartDate != null;
        }
    }
}