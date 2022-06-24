using System.Collections.Generic;

namespace Agents.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(long id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
