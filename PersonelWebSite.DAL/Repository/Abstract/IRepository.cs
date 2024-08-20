using System.Linq.Expressions;

namespace PersonalWebSite.DAL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
