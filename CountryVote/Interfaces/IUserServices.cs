using CountryVoteModels.DBModel;
using Microsoft.VisualBasic;

namespace CountryVote.Interfaces
{
    public interface IUserServices
    {
        public  Task<User> AddUser(User user);

        public  Task<ICollection<User>> GetAll();
       
    }
}
