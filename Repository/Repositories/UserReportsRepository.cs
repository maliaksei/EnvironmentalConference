using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class UserReportsRepository : IRepository<Report>
    {

        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        private const string TooManyUser = "User already exists";

        #endregion

        #region Constructors

        public UserReportsRepository()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        #region Override Methods

        public override IQueryable<Report> GetAll()
        {
            return _dataContext.Report;
        }

        public override Report Add(Report entity)
        {
            _dataContext.Report.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(Report entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Report entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteForId(Guid id)
        {
            var report = _dataContext.Report.SingleOrDefault(x => x.ReportId == id);
            if (report == null)
            {
                return false;
            }
            _dataContext.Report.Remove(report);
            _dataContext.SaveChanges();
            return true;
        }

        #endregion
    }
}
