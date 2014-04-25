using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.JqGridModels;
using Models.Properties;

namespace Models.ViewModels.RegisterForConference
{
    public class UserReportsViewModel : UserReportsJqGridModel
    {
        public Guid ApplicationId { get; set; }

        public List<SelectListItem> ResearchAreas { get; set; }

        [Display(Name = "UserReportsViewModel_ResearchAreas", ResourceType = typeof(Resources))]
        public int ResearchAreasId { get; set; }

        [Display(Name = "UserReportsViewModel_PathToReport", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string PathToReport { get; set; }

        [Display(Name = "UserReportsViewModel_PathToCheck", ResourceType = typeof(Resources))]
        public string PathToCheck { get; set; }

        [Display(Name = "UserReportsViewModel_NameOfReport", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string NameOfReport { get; set; }

        [Display(Name = "UserReportsViewModel_AuthorsReport", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = "FieldLong")]
        public string AuthorsReport { get; set; }
    }
}
