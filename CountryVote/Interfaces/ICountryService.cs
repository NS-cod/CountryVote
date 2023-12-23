using CountryVoteModels.DBModel;

namespace CountryVote.Interfaces
{
    public interface ICountryService
    {
        public Task<Country> AddCountry(Country country);
        public Task<Country> createUpdateCountry(Country country);
        public Task<Country> Update(Country country);

        public Task<ICollection<Country>> Get10Favourites();

    }
}
