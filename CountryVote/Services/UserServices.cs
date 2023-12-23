using CountryVote.Interfaces;
using CountryVoteModels.DBModel;
using CountryVoteRepositories.Interfaces;
using Microsoft.VisualBasic;
using System.Drawing.Text;

namespace CountryVote.Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _UserRepository { get; set; }
        public UserServices(IUserRepository  userRepository)
        {
            this._UserRepository = userRepository;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                var userAdded = await this._UserRepository.Add(user);

                return userAdded;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<User>> GetAll()
        {
            try
            {
                var allUsers = await _UserRepository.GetAll();
                return allUsers;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
