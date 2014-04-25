
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Diplom.Data;
using Diplom.Data.Enums;

namespace Repository.Repositories
{
    public class ConferenceRepository : IRepository<Conferences>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        private const string ComferenceWithIdExist = "Conference with this ID already exists. Contact the administrator.";
        #endregion

        #region Constructors

        public ConferenceRepository()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        #region Override Methods
        public override IQueryable<Conferences> GetAll()
        {
            return _dataContext.Conferences;
        }

        public override Conferences Add(Conferences entity)
        {
            if (ConferenceExists(entity))
            {
                throw new ArgumentException(ComferenceWithIdExist);
            }

            entity.ConferenceStatus = new Collection<ConferenceStatus>
            {
                new ConferenceStatus
                {
                    ConferenceStatusId = Guid.NewGuid(),
                    DateChange = DateTime.Now,
                    StatusesId = (int)ConferenceStatusType.New
                }
            };
            
            entity.OrganizingCommittee = new List<OrganizingCommittee>
            {
                new OrganizingCommittee()
            };

            _dataContext.Conferences.Add(entity);

            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(Conferences entity)
        {
            var conference = GetAll().SingleOrDefault(x => x.ConferenceId == entity.ConferenceId);
            if (conference != null)
            {
                conference.Name = entity.Name;
                conference.BriefInformation = entity.BriefInformation;
                conference.StartDate = entity.StartDate;
                conference.MeetingPoint = entity.MeetingPoint;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(Conferences entity)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Public Methods

      
        #endregion
        
        #region Private Methods


        private bool ConferenceExists(Conferences conference)
        {
            return conference != null && GetAll().Any(x => x.ConferenceId == conference.ConferenceId);
        }

        #endregion
    }
}
