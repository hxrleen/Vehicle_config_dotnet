using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Configuration.Models;
using VehicleConfigurator02.DbRepos;

// internally system.Text.json serialization is used

namespace REST_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _repository;

        public ManufacturerController(IManufacturerService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>?>> GetManufacturer()
        {
            if(await _repository.GetAllManufacturer()==null)
            {
                return NotFound();
            }
            return await _repository.GetAllManufacturer();
        }

        [HttpGet("segment/{segmentId}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>?>> GetManufacturersBySegmentId(int segmentId)
        {
            var manufacturers = await _repository.GetManufacturersBySegmentId(segmentId);
            if (manufacturers==null)
            {
                return NotFound();
            }
            return Ok(manufacturers);
        }

    }
}
