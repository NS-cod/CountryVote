using CountryVote.Interfaces;
using CountryVoteModels.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using NuGet.Protocol;
using System.Collections.ObjectModel;

namespace CountryVote.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryDTO>> GetCountriesInfo(List<string> countryNames)
        {
            try
            {
            List<CountryDTO> countryInfos = new List<CountryDTO>();

            foreach (var countryName in countryNames)
            {
                string apiUrl = $"https://restcountries.com/v3.1/name/{countryName}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string countryInfoJson = await response.Content.ReadAsStringAsync();

                    var countryDto = MapJsonToCountryDto(countryInfoJson, countryName);

                    countryInfos.Add(countryDto);

                }
                else
                {
                    countryInfos.Add(new CountryDTO { Name = countryName, ErrorMessage = "Country not found" });
                }
               
            }
            return countryInfos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private CountryDTO MapJsonToCountryDto(string countryInfoJson, string countryName)
        {
            try
            {
                var jsonArray = JArray.Parse(countryInfoJson);
                var firstObject = jsonArray.FirstOrDefault() as JObject;
                if (firstObject != null)
                {
                    return MapObjectToCountryDto(firstObject, countryName);
                }
            }
            catch (JsonReaderException)
            {
                return new CountryDTO { Name = countryName, ErrorMessage = "Error processing JSON response" };
            }

            return new CountryDTO { Name = countryName, ErrorMessage = "Error processing JSON response" };

        }

        private CountryDTO MapObjectToCountryDto(JObject jsonObject, string countryName)
        {
            try
            {
            var countryDto = new CountryDTO
            {
                Name = countryName,
                OfficialName = jsonObject.SelectToken("name.official")?.ToString(),
                CapitalCity = jsonObject.SelectToken("capital")?.ToString(),
                Region = jsonObject.SelectToken("region")?.ToString(),
                SubRegion = jsonObject.SelectToken("subregion")?.ToString()
            };

            return countryDto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
