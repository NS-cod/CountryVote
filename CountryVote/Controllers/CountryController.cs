using CountryVote.Interfaces;
using CountryVoteModels.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace CountryVote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IExternalApiService _externalApiService;
        private readonly ICountryService _countryService; // Agrega tu interfaz y su implementación

        public CountryController(IExternalApiService externalApiService, ICountryService countryService)
        {
            _externalApiService = externalApiService;
            _countryService = countryService;
        }

        [HttpGet("GetTopTenVotedCountries")]
        public async Task<ActionResult<List<CountryDTO>>> GetTopTenCountries()
        {
            try
            {
                var favouritesCountries = await _countryService.Get10Favourites();
                List<String> countriesNames = new List<String>();
                foreach (var f in favouritesCountries)
                {
                    countriesNames.Add(f.Name);
                }
                List<CountryDTO> countriesInfo = await _externalApiService.GetCountriesInfo(countriesNames);
                return Ok(countriesInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
