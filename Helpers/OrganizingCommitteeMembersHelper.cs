using Diplom.Data;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;

namespace Helpers
{
    public static class OrganizingCommitteeMembersHelper
    {
        public static OrganizingCommitteeMembers OrganizingCommitteeMembersViewModelToDataModel(OrganizingCommitteeMembersViewModel viewModel)
        {
            return new OrganizingCommitteeMembers
            {
                OrganizingCommitteeId = viewModel.OrganizingCommitteeId,
                OrganizingCommitteeMemberId = viewModel.OrganizingCommitteeMembersId,
                Surname = viewModel.Surname,
                Name = viewModel.Name,
                Patronymic = viewModel.Patronymic,
                Post = viewModel.Post,
                AdditionalInformation = viewModel.AdditionalInformation
            };
        }
    }
}
