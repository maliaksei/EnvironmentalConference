using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class OrganizingCommitteeRepositories : IRepository<OrganizingCommittee>
    {
        #region Memebers

        protected ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public OrganizingCommitteeRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<OrganizingCommittee> GetAll()
        {
            return _dataContext.OrganizingCommittee;
        }

        public override OrganizingCommittee Add(OrganizingCommittee entity)
        {
            _dataContext.OrganizingCommittee.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(OrganizingCommittee entity)
        {
            var organizingCommitteeMembers = _dataContext.OrganizingCommittee.SingleOrDefault(x => x.OrganizingCommitteeId == entity.OrganizingCommitteeId);
            if (organizingCommitteeMembers != null)
            {
                organizingCommitteeMembers.Address = entity.Address;
                organizingCommitteeMembers.Email = entity.Email;
                organizingCommitteeMembers.Phone = entity.Phone;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(OrganizingCommittee entity)
        {
            var model = _dataContext.OrganizingCommittee.SingleOrDefault(x => x.OrganizingCommitteeId == entity.OrganizingCommitteeId);
            try
            {
                if (model != null)
                {
                    _dataContext.OrganizingCommittee.Remove(model);
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
