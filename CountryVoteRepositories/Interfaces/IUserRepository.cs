using CountryVoteModels.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CountryVoteRepositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetByEmailAsync(String email);
    }
}
