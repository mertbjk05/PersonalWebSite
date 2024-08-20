using Microsoft.EntityFrameworkCore;
using PersonalWebSite.DAL.Repository.Abstract;
using PersonalWebSite.Entities.DbContexts;
using System.Linq.Expressions;

namespace PersonalWebSite.DAL.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PersonalWebContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PersonalWebContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
