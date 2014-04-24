using System;
using System.Linq;
using Diplom.Data;

namespace Repository.Filters
{
    public static class UserFilters
    {
        public static Users GetUserForId(this IQueryable<Users> userses, Guid id)
        {
            return userses.SingleOrDefault(x => x.UserId == id);
        }

        public static string GetUserNameByEmail(this IQueryable<Users> userses, string email)
        {
            var user = userses.SingleOrDefault(x => x.Email == email);
            return user != null ? user.Name : String.Empty;
        }

        public static string GetUserFullNameByEmail(this IQueryable<Users> userses, string email)
        {
            var user = userses.SingleOrDefault(x => x.Email == email);
            return user != null ? user.Surname + " " + user.Name : String.Empty;
        }

        public static Users GetByEmail(this IQueryable<Users> userses, string email)
        {
            return userses.SingleOrDefault(x => x.Email == email);
        }
    }
}
