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
    public class CountryRepository : BaseRepository<Country> , ICountryRepository
    {
        private readonly CountryVoteDbContext countryVoteDbContext;

        public CountryRepository(CountryVoteDbContext countryVoteDbContext): base (countryVoteDbContext)
        {
            this.countryVoteDbContext = countryVoteDbContext;
        }

        public async Task<ICollection<Country>> Get10Favourites()
        {
            var mostVotedCountries = await this.countryVoteDbContext.Set<Country>().OrderByDescending(_country => _country.Votes).Take(10).ToListAsync();
            return mostVotedCountries;
        }

        public async Task<Country> GetCountryByName(Country country)
        {
            var foundedcountry = await this.countryVoteDbContext.Set<Country>().Where(c=>c.Name == country.Name).FirstOrDefaultAsync();
            return foundedcountry;
        }
    }
}
