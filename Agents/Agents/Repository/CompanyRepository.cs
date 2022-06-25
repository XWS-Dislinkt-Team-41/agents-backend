using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Agents.Model;

namespace Agents.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Search(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Company entity)
        {
            throw new NotImplementedException();
        }

        public Company Update(Company entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
