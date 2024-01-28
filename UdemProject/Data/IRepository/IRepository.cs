using System.Linq.Expressions;

namespace UdemProject.Data.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void RamoveRange(IEnumerable<T> entities);

    }
}
