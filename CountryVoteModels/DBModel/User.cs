using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryVoteModels.DBModel
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int idCountry { get; set; }
        public Country Country { get; set; }
       
    }
}
