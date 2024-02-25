using System.Threading.Tasks;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> ValidateUser(string username, string password);
    }

    
}
