using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UdemProject.Data.IRepository
{
    public class Repository<T> : IRepository.IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        protected DbSet<T> Dbset { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _db = context;
            Dbset = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> table = Dbset;
            table = table.Where(expression);
            return table.First();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> table = Dbset;
           return table.ToList();
        }

        public void RamoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }
    }
}
