﻿using System.Collections.Generic;
using System.Linq;
using Agents.Model;

namespace Agents.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly AgentDbContext _dbContext;

        public UserRepository(AgentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUnconfirmed()
        {
            return _dbContext.Users.Where(u => u.Confirmed == false).ToList();
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
