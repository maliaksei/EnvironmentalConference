using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class KeyDatesRepositories : IRepository<KeyDates>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public KeyDatesRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<KeyDates> GetAll()
        {
            return _dataContext.KeyDates;
        }

        public override KeyDates Add(KeyDates entity)
        {
            _dataContext.KeyDates.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(KeyDates entity)
        {
            var keyDates = _dataContext.KeyDates.SingleOrDefault(x => x.KeyDateId == entity.KeyDateId);
            if (keyDates != null)
            {
                keyDates.StaDate = entity.StaDate;
                keyDates.EndDate = entity.EndDate;
                keyDates.Description = entity.Description;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(KeyDates entity)
        {
            var model = _dataContext.KeyDates.SingleOrDefault(x => x.KeyDateId == entity.KeyDateId);
            try
            {
                if (model != null)
                {
                    _dataContext.KeyDates.Remove(model);
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
