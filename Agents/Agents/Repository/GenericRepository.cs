using System.Collections.Generic;
using System.Linq;
using Agents.Model;
using Microsoft.EntityFrameworkCore;

namespace Agents.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly AgentDbContext _dbContext;
        private readonly DbSet<T> _table;

        public GenericRepository(AgentDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T Get(long id)
        {
            return _table.Find(id);
        }

        public T Insert(T entity)
        {
            var addedEntity = _table.Add(entity);
            Save();
            return addedEntity.Entity;
        }

        public T Update(T entity)
        {
            var updatedEntity = _table.Update(entity);
            Save();
            return updatedEntity.Entity;
        }

        public void Delete(T entity)
        {
            T existing = _table.Find(entity.Id);
            _table.Remove(existing);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
