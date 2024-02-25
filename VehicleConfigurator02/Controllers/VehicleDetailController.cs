using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleConfig.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfigurator02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailController : ControllerBase
    {
        private readonly IVehicleDetailRepository _vehicleDetailRepository;

        public VehicleDetailController(IVehicleDetailRepository vehicleDetailRepository)
        {
            _vehicleDetailRepository = vehicleDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetails()
        {
            var vehicleDetails = await _vehicleDetailRepository.GetAllVehicleDetail();
            if (vehicleDetails == null || !vehicleDetails.Value.Any())
            {
                return NotFound();
            }

            return vehicleDetails;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetail>> GetVehicleDetailById(int id)
        {
            var vehicleDetail = await _vehicleDetailRepository.GetVehicleDetailById(id);
            return vehicleDetail == null ? NotFound() : vehicleDetail;
        }
    }
}