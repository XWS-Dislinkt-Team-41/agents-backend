using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agents.Repository
{
    public interface IGenericRepository<T> where T : class
    {

        List<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Save(T entity);
    }
}
