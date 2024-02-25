using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _service;

        public ComponentController(IComponentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            var components = await _service.GetAllComponents();
            if (components == null)
            {
                return NotFound();
            }
            return Ok(components);
        }
    }
}
