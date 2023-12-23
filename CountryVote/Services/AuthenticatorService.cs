using CountryVote.Interfaces;
using CountryVoteModels.DBModel;
using CountryVoteRepositories.Interfaces;

namespace CountryVote.Services
{
    public class AuthenticatorService : IAutheticatorService
    {
        IUserRepository UserRepository { get; set; }
        ICountryRepository CountryRepository { get; set; }
        public AuthenticatorService(IUserRepository userRepository, ICountryRepository countryRepository)
        {
            this.UserRepository = userRepository;
            this.CountryRepository = countryRepository;
        }

        public async Task<bool> AuthenticateUser(string mail)
        {
            try { 
                var existUser = await this.UserRepository.GetByEmailAsync(mail);

                return existUser == null;
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AuthenticateCountry(Country country)
        {
            try{
               var existCountry = await this.CountryRepository.GetCountryByName(country);
               return existCountry == null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
