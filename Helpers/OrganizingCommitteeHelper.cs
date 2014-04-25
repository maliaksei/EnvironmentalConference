using System.Text.RegularExpressions;
using Diplom.Data;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;
using Repository;

namespace Helpers
{
    public static class OrganizingCommitteeHelper
    {
        private static readonly DataManager dataManager = new DataManager();

        public static OrganizingCommittee OrganizingCommitteeViewModelToDataModel(OrganizingCommitteeViewModel viewModel)
        {
            return new OrganizingCommittee
                 {
                     OrganizingCommitteeId = viewModel.OrganizingCommitteeId,
                     Address = viewModel.Address,
                     Email = viewModel.Email,
                     Phone = GetPhoneForString(viewModel.Phone)
                 };
        }

        public static void UpdateOrganizingCommittee(OrganizingCommitteeViewModel viewModel)
        {
            var dataModel = OrganizingCommitteeViewModelToDataModel(viewModel);
            dataManager.OrganizingCommitteeRepositories.Update(dataModel);
        }

        private static string GetPhoneForString(string str)
        {
            var pattern = @"[^0-9]";
            var replacement = string.Empty;
            Regex rgx = new Regex(pattern);
            return rgx.Replace(str, replacement);
        }
    }
}
