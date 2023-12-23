using CountryVoteModels.DBModel;

namespace CountryVote.Interfaces
{
    public interface IAutheticatorService
    {
        public Task<bool> AuthenticateUser(string mail);
        public Task<bool> AuthenticateCountry(Country country);
    }
}
