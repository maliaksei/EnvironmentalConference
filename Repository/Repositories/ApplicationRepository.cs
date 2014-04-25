using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public ApplicationRepository()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        #region Override Methods
        public override IQueryable<Application> GetAll()
        {
            return _dataContext.Application;
        }

        public override Application Add(Application entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Application entity)
        {
            var model = _dataContext.Application.SingleOrDefault(x => x.ApplicationId == entity.ApplicationId);
            if (model != null)
            {
                model.ApplicationStatus = entity.ApplicationStatus;
                model.ParticipationFormId = entity.ParticipationFormId;
                model.Comment = entity.Comment;
                model.IsHotel = entity.IsHotel;
                model.ArrivalTime = entity.ArrivalTime;

                _dataContext.SaveChanges();
            }
        }

        public override bool Delete(Application entity)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
