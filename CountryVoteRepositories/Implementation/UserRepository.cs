using CountryVoteDataBaseContext;
using CountryVoteModels.DBModel;
using CountryVoteRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryVoteRepositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly CountryVoteDbContext countryVoteDbContext;
        public UserRepository(CountryVoteDbContext countryVoteDbContext) : base (countryVoteDbContext)
        {
            this.countryVoteDbContext = countryVoteDbContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await this.countryVoteDbContext.Set<User>().Where(x => x.Email == email).FirstOrDefaultAsync();

            return user; 
        }
    }
}
