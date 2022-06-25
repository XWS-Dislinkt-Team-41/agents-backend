using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Agents.Model;

namespace Agents.Repository
{
    public class CompanyRepository : GenericRepository<Company> ,ICompanyRepository
    {
        private readonly AgentDbContext _dbContext;

        public CompanyRepository(AgentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
