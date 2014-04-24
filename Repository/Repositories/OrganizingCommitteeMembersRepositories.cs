using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class OrganizingCommitteeMembersRepositories : IRepository<OrganizingCommitteeMembers>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        #region Constructors

        public OrganizingCommitteeMembersRepositories()
        {
            this._dataContext = new ECDatabaseEntities();
        }

        #endregion

        public override IQueryable<OrganizingCommitteeMembers> GetAll()
        {
            return _dataContext.OrganizingCommitteeMembers;
        }

        public override OrganizingCommitteeMembers Add(OrganizingCommitteeMembers entity)
        {
            entity.OrganizingCommitteeMemberId = Guid.NewGuid();
            _dataContext.OrganizingCommitteeMembers.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public override void Update(OrganizingCommitteeMembers entity)
        {
            var organizingCommitteeMembers = _dataContext.OrganizingCommitteeMembers.SingleOrDefault(x => x.OrganizingCommitteeMemberId == entity.OrganizingCommitteeMemberId);
            if (organizingCommitteeMembers != null)
            {
                organizingCommitteeMembers.Post = entity.Post;
                organizingCommitteeMembers.Surname = entity.Surname;
                organizingCommitteeMembers.Name = entity.Name;
                organizingCommitteeMembers.Patronymic = entity.Patronymic;
                organizingCommitteeMembers.AdditionalInformation = entity.AdditionalInformation;
            }
            _dataContext.SaveChanges();
        }

        public override bool Delete(OrganizingCommitteeMembers entity)
        {
            var model = _dataContext.OrganizingCommitteeMembers.SingleOrDefault(x => x.OrganizingCommitteeMemberId == entity.OrganizingCommitteeMemberId);
            try
            {
                if (model != null)
                {
                    _dataContext.OrganizingCommitteeMembers.Remove(model);
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
