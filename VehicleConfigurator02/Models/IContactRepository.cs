using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace vehicle_conf_dotnet.Models
{
    public interface IContactRepository
    {
        Task<ActionResult<ContactU>> Add(ContactU contact);


    }
}
