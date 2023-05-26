using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(mshopContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User?> GetByEP(string email, string password)
        {
            var result = await base.FindByCondition(ded => ded.Login == email && ded.UPassword == password);

            if (result == null || result.Count == 0) { return null; }

            return result[0];
        }

    }
}
