using System.Linq;

namespace Repository.Repositories
{
    public abstract class IRepository<T>
    {
        #region Methods

        public abstract IQueryable<T> GetAll();

        public abstract T Add(T entity);

        public abstract void Update(T entity);

        public abstract bool Delete(T entity);

        #endregion
    }
}
