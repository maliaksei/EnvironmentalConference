using System;
using Diplom.Data;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;

namespace Helpers
{
    public static class ResearchAreasHelper
    {
        public static ResearchAreas ResearchAreasViewModelToDataModel(ResearchAreasViewModel viewModel)
        {
            return new ResearchAreas
            {
                ResearchAreasId = viewModel.Id,
                ConferenceId = viewModel.ConferenceId,
                Name = viewModel.Name,
                DateAndTime = viewModel.DateTime == null? (DateTime?)null:DateTime.Parse(viewModel.DateTime),
                Description = viewModel.Description,
                Venue = viewModel.Venue
            };
        }
    }
}
