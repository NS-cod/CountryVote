using CountryVote.Interfaces;
using CountryVote.Services;
using CountryVoteModels.DBModel;
using CountryVoteModels.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace CountryVote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IAutheticatorService _autheticatorService;
        private readonly ICountryService _countryService;

        public UserController( IUserServices userService, IAutheticatorService autheticatorService, ICountryService webServices)
        {
            _userService = userService;
            _autheticatorService = autheticatorService;
            _countryService = webServices;
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDto>> AddUser([FromBody]UserDto userDto){
            try
            {
               
            if (string.IsNullOrEmpty(userDto.Name) || string.IsNullOrEmpty(userDto.CountryName) || string.IsNullOrEmpty(userDto.Email)) {
                return BadRequest();
            }
            var user = new User { Name = userDto.Name, Email = userDto.Email};
            bool authenticate = await this._autheticatorService.AuthenticateUser(user.Email);
            if (authenticate)
            {
                var country = new Country { Name = userDto.CountryName };
                var updatedOrCreatedCountry = await _countryService.createUpdateCountry(country);
                    user.idCountry = updatedOrCreatedCountry.ID;
                var userAded = await _userService.AddUser(user);
                if (userAded != null && updatedOrCreatedCountry != null) {
                    userDto.Name= userAded.Name;
                    userDto.Email= userAded.Email;
                    userDto.CountryName= updatedOrCreatedCountry.Name;
                    return CreatedAtAction(nameof(AddUser), userDto);
                }
                else
                {

                    return StatusCode(500, "Internal error");
                }
            } else {
                return BadRequest();
            }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
