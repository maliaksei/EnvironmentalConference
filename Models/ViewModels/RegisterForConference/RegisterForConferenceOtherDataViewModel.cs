using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.Properties;

namespace Models.ViewModels.RegisterForConference
{
    public class RegisterForConferenceOtherDataViewModel
    {
       
        public Guid ApplicationId { get; set; }

        [Display(Name = "ApplicationOtherData_FormOfParticipation", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                 ErrorMessageResourceName = "FieldRequired")]
        public int FormOfParticipationId { get; set; }

        public List<SelectListItem> FormOfParticipations { get; set; }

        [Display(Name = "ApplicationOtherData_NeedForReservation", ResourceType = typeof(Resources))]
        public bool NeedForReservation { get; set; }

        [Display(Name = "ApplicationOtherData_EstimatedTimeOfArrival", ResourceType = typeof(Resources))]
        public string EstimatedTimeOfArrival { get; set; }

        [Display(Name = "ApplicationOtherData_Comment", ResourceType = typeof(Resources))]
        public string Comment { get; set; }
    }
}
