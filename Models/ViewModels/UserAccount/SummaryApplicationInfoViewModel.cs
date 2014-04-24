using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Diplom.Data.Enums;
using Models.JqGridModels;
using Models.Properties;

namespace Models.ViewModels.UserAccount
{
    public class SummaryApplicationInfoViewModel
    {
        public SummaryApplicationInfoViewModel()
        {
            UserReportsJqGridModel = new UserReportsJqGridModel();
        }

        public Guid ApplicationId { get; set; }

        [Display(Name = "ActiveApplicationInfoViewModel_IsHotel", ResourceType = typeof(Resources))]
        public bool IsHotel { get; set; }

        [Display(Name = "ActiveApplicationInfoViewModel_ArrivalTime", ResourceType = typeof(Resources))]
        public DateTime? ArrivalTime { get; set; }

        [Display(Name = "ActiveApplicationInfoViewModel_Comment", ResourceType = typeof(Resources))]
        public string Comment { get; set; }

        [Display(Name = "ActiveApplicationInfoViewModel_ParticipationFormId", ResourceType = typeof(Resources))]
        public int ParticipationFormId { get; set; }

        public List<SelectListItem> ParticipationFormsListItems { get; set; }

        public int ApplicationStatusId { get; set; }

        public UserReportsJqGridModel UserReportsJqGridModel { get; set; }

    }
}
