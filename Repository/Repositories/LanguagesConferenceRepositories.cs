using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class LanguagesConferenceRepositories : IRepository<Languages>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public LanguagesConferenceRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<Languages> GetAll()
        {
            return _dataContext.Languages;
        }

        public override Languages Add(Languages entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Languages entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Languages entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Languages> GetByConferenceId(int conferenceId)
        {
           return _dataContext.LanguagesConference.Where(x => x.ConferenceId == conferenceId).Select(y => y.Languages);
        }

        public IQueryable<LanguagesConference> GetLanguagesConferenceByConferenceId(int conferenceId)
        {
            return _dataContext.LanguagesConference.Where(x => x.ConferenceId == conferenceId);
        }

        public LanguagesConference AddForConference(LanguagesConference model)
        {
            _dataContext.LanguagesConference.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public bool DeleteForConference(Guid languagesConferenceId)
        {
            var conferenceFormModel =
                _dataContext.LanguagesConference.SingleOrDefault(x => x.LanguagesConferenceId == languagesConferenceId);
            if (conferenceFormModel == null) return false;
            _dataContext.LanguagesConference.Remove(conferenceFormModel);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
