using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;
using WebApp11.Repository;

namespace WebApp11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

    
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> ValidateUser(User user)
        {
            var isValid = await _userRepository.ValidateUser(user.Username, user.Password);
            return Ok(isValid);
        }


        [HttpPost("signup")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.Add(user);
            return CreatedAtAction("PostUser", new { id = user.Id }, user);
        }   
    }

}
