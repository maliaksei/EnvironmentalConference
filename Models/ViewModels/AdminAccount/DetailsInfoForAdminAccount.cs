using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.JqGridModels;
using Models.ViewModels.UserAccount;

namespace Models.ViewModels.AdminAccount
{
    public class DetailsInfoForAdminAccount
    {
        public DetailsInfoForAdminAccount()
        {
            ParticipantsConferenceJqGrid = new ParticipantsConferenceJqGridModel();
        }

        public  ConferenceSummaryInfoViewModel ConferenceSummaryInfo { get; set; }

        public ParticipantsConferenceJqGridModel ParticipantsConferenceJqGrid { get; set; }
    }
}
