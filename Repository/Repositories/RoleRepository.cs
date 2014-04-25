using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Repositories
{
    public class RoleRepository : IRepository<UserRoles>
    {
        #region Memebers

        protected readonly ECDatabaseEntities _dataContext;

        #endregion

        public override IQueryable<UserRoles> GetAll()
        {
            return _dataContext.UserRoles;
        }

        public override UserRoles Add(UserRoles entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(UserRoles entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(UserRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
