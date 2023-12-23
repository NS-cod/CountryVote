using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace CountryVoteModels.DBModel
{
    public class Country : BaseModel
    {
        [Required]
        public  string Name { get; set; }
        public int Votes { get; set; }
        public Collection<User> User { get; set; }
    }
}
