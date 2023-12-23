using CountryVote.Interfaces;
using CountryVoteModels.DBModel;
using CountryVoteRepositories.Implementation;
using CountryVoteRepositories.Interfaces;

namespace CountryVote.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepository countryRepository;
        public CountryService(ICountryRepository countryRepository) {
            this.countryRepository = countryRepository;
        }
        public async Task<Country> AddCountry(Country country)
        {
            try
            {
                var addedCountry = await this.countryRepository.Add(country);
                return addedCountry;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Country>> Get10Favourites()
        {
            try
            {
                var countries = await this.countryRepository.Get10Favourites();
                return countries;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> GetCountryByName(Country country)
        {
            try
            {
                var _country = await this.countryRepository.GetCountryByName(country);
                return _country;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> createUpdateCountry(Country country)
        {
            try
            {
                var foundedCountry = await GetCountryByName(country);
                if (foundedCountry != null)
                {
                    foundedCountry.Votes++;
                    var updatedCountry = await Update(foundedCountry);
                    return updatedCountry;
                }
                else
                {
                    var newCountry = new Country { Name = country.Name, Votes = 1 };
                    var addedCountry = await AddCountry(newCountry);
                    return addedCountry;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); };

        }

        public async Task<Country> Update(Country country)
        {
            try
            {
                var countryAdded = await this.countryRepository.Update(country);
                return countryAdded;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
