using Microsoft.AspNetCore.Mvc;
using VehicleConfiguration02;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;

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

        [HttpPost("createUser")]
        public IActionResult CreateUser(User user)
        {
            // Implement the logic to create user
            _userRepository.CreateUser(user);
            return Ok("User created successfully");
        }

        [HttpPost("validateUser")]
        public async Task<IActionResult> ValidateUser(User user)
        {
            // Implement the logic to validate user
            if (await _userRepository.ValidateUser(user.Username, user.Password))
            {
                return Ok("User validated successfully");
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }
    }
}
