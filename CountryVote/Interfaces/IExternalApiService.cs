using CountryVoteModels.DTO;
using System.Collections.ObjectModel;

namespace CountryVote.Interfaces
{
    public interface IExternalApiService
    {
        public Task<List<CountryDTO>> GetCountriesInfo(List<string> countryNames);
    }
}
