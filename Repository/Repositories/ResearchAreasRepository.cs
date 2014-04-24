using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class ResearchAreasRepository : IRepository<ResearchAreas>
    {
        protected readonly ECDatabaseEntities _dataContext;

        public ResearchAreasRepository()
        {
            this._dataContext = new ECDatabaseEntities();
        }
        public override IQueryable<ResearchAreas> GetAll()
        {
            return _dataContext.ResearchAreas;
        }

        public override ResearchAreas Add(ResearchAreas entity)
        {
            _dataContext.ResearchAreas.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(ResearchAreas entity)
        {
            var model = _dataContext.ResearchAreas.SingleOrDefault(x => x.ResearchAreasId == entity.ResearchAreasId);
            if (model != null)
            {
                model.Name = entity.Name;
                model.DateAndTime = entity.DateAndTime;
                model.Venue = entity.Venue;
                model.Description = entity.Description;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(ResearchAreas entity)
        {
            var model = _dataContext.ResearchAreas.SingleOrDefault(x => x.ResearchAreasId == entity.ResearchAreasId);
            try
            {
                if (model != null)
                {
                    _dataContext.ResearchAreas.Remove(model);
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
