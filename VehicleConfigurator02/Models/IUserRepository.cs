using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace WebApp11.Repository
{
    public interface IUserRepository
    {
        Task<ActionResult<User>> Add(User user);
        Task<bool> ValidateUser(string username, string password);
     
    }
}
