using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class FormOfParticipationRepositories : IRepository<ParticipationForms>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public FormOfParticipationRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<ParticipationForms> GetAll()
        {
            return _dataContext.ParticipationForms;
        }

        public override ParticipationForms Add(ParticipationForms entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ParticipationForms entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(ParticipationForms entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ParticipationForms> GetByConferenceId(int conferenceId)
        {
           return _dataContext.ConferenceForms.Where(x => x.ConferenceId == conferenceId).Select(y => y.ParticipationForms);
        }

        public IQueryable<ConferenceForms> GetConferenceFormsByConferenceId(int conferenceId)
        {
            return _dataContext.ConferenceForms.Where(x => x.ConferenceId == conferenceId);
        }

        public ConferenceForms AddForConference(ConferenceForms model)
        {
            _dataContext.ConferenceForms.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public bool DeleteForConference(int conferenceFormId)
        {
            var conferenceFormModel =
                _dataContext.ConferenceForms.SingleOrDefault(x => x.ConferenceFormId == conferenceFormId);
            if (conferenceFormModel == null) return false;
            _dataContext.ConferenceForms.Remove(conferenceFormModel);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
