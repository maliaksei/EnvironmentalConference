using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class FilesOfConferenceRepositories : IRepository<FilesConference>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public FilesOfConferenceRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<FilesConference> GetAll()
        {
            return _dataContext.FilesConference;
        }

        public override FilesConference Add(FilesConference entity)
        {
            entity.FileConferenceId = Guid.NewGuid();
            _dataContext.FilesConference.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(FilesConference entity)
        {
            var fileConference = _dataContext.FilesConference.SingleOrDefault(x => x.FileConferenceId == entity.FileConferenceId);
            if (fileConference != null)
            {
                fileConference.Name = entity.Name;
                fileConference.Path = entity.Path;
                fileConference.Description = entity.Description;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(FilesConference entity)
        {
            var model = _dataContext.FilesConference.SingleOrDefault(x => x.FileConferenceId == entity.FileConferenceId);
            try
            {
                if (model != null)
                {
                    _dataContext.FilesConference.Remove(model);
                    _dataContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
