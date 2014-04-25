using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Data;

namespace Repository.Filters
{
    public static class UserRoleFilters
    {
        public static UserRoles GetUserRolesForRoleName(this IQueryable<UserRoles> userRoleses, string roleName)
        {
            return userRoleses.SingleOrDefault(x => x.Role == roleName);
        }
    }
}
