using System;
using System.IO;
using Diplom.Data;
using Models.ViewModels;
using Models.ViewModels.EditConferenceViewModels;

namespace Helpers
{
    public static class FilesOfConferenceHelper
    {
        public static FilesConference CreateFilesOfConferenceByViewModel(FilesOfConferenceViewModel viewModel, string serverPath)
        {
            if (viewModel.Path == null)
                return null;
            var file = viewModel.Path.Split(',');
            byte[] data = Convert.FromBase64String(file[1]);
            var directory = serverPath + viewModel.ConferenceId;
            if (!Directory.Exists(directory))
            {
                DirectoryInfo di = Directory.CreateDirectory(directory);
            }
            var path = Path.Combine(directory, file[2]);
            System.IO.File.WriteAllBytes(path, data);

            return new FilesConference
            {
                ConferenceId = viewModel.ConferenceId,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Path = path
            };
        }

        public static bool DeleteFilesOfConference(FilesConference fileConference, string serverPath)
        {
            try
            {
                File.Delete(fileConference.Path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
