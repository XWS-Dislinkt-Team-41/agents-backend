using System.Collections.Generic;
using Agents.Model;

namespace Agents.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetByUsername(string username);
        public List<User> GetAllUnconfirmed();
    }
}
