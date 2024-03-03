using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Conf.Models;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Conf.Controllers
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


        [HttpGet("ByModel/{modelId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByModelId(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.GetVehicleDetailsByModelId(modelId);
            if (vehicleDetails == null || !vehicleDetails.Value.Any())
            {
                return NotFound();
            }

            return vehicleDetails;
        }
        [HttpGet("ByInterior/{modelId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByInterior(int modelId)
        {
            var interiorComponent = "i"; // Assuming "Interior" is the type of interior component
            var vehicleDetails = await _vehicleDetailRepository.GetVehicleDetailsByInterior(modelId, interiorComponent);
            if (vehicleDetails == null || !vehicleDetails.Value.Any())
            {
                return NotFound();
            }

            return vehicleDetails;
        }

        [HttpGet("ByExterior/{modelId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByExterior(int modelId)
        {
            var exteriorComponent = "e"; // Assuming "Exterior" is the type of exterior component
            var vehicleDetails = await _vehicleDetailRepository.GetVehicleDetailsByExterior(modelId, exteriorComponent);
            if (vehicleDetails == null || !vehicleDetails.Value.Any())
            {
                return NotFound();
            }

            return vehicleDetails;
        }

        [HttpGet("Price/{modelId}")]
        public async Task<ActionResult<double?>> GetPriceByModelId(int modelId)
        {
            var priceResult = await _vehicleDetailRepository.GetPriceByModelId(modelId);
            if (priceResult.Result is NotFoundResult)
            {
                return NotFound();
            }

            return priceResult;
        }


        [HttpGet("ByCore/{modelId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByCore(int modelId)
        {
            var coreComponent = "c"; 
            var vehicleDetails = await _vehicleDetailRepository.GetVehicleDetailsByCore(modelId, coreComponent);
            if (vehicleDetails == null || !vehicleDetails.Value.Any())
            {
                return NotFound();
            }

            return vehicleDetails;
        }

        [HttpGet("ByStandard/{modelId}")] 
        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByStandard(int modelId)
        {
            var standardComponent = "s";
            var vehicleDetails = await _vehicleDetailRepository.GetVehicleDetailsByCore(modelId, standardComponent);
            if (vehicleDetails == null )
            {
                return NotFound();
            }

            return vehicleDetails;
        }

      


    }
}