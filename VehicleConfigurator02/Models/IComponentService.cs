using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02.Models
{
    public interface IComponentService
    {
        Task<ActionResult<IEnumerable<Component>>> GetAllComponents();
    }
}
