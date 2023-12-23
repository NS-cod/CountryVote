using CountryVoteModels.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryVoteRepositories.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        public Task<Country> GetCountryByName(Country country);

        public Task<ICollection<Country>> Get10Favourites();
    }
}
