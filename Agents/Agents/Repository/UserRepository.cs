using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Agents.Model;

namespace Agents.Repository
{
    public class UserRepository : IUserRepository
    {

        private AgentDbContext _dbContext;

        public UserRepository(AgentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public List<User> GetAllUnconfirmed()
        {
            return _dbContext.Users.Where(u => u.Confirmed == false).ToList();
        }

        public IEnumerable<User> Search(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Username.Equals(username));
        }

        public void Insert(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
