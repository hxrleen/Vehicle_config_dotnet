using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Conf.Models
{
    public class VehicleDetailRepository : IVehicleDetailRepository
    {
        private readonly ScottDbContext _context;

        public VehicleDetailRepository(ScottDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByModelId(int modelId)
        {
            return await _context.VehicleDetails
                                  .Where(v => v.ModelId == modelId)
                                  .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByInterior(int modelId, string interiorComponent)
        {
            var vehicleDetails = await _context.VehicleDetails
                                                .Where(v => v.ModelId == modelId && v.CompType == interiorComponent)
                                                .ToListAsync();
            return vehicleDetails;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByExterior(int modelId, string exteriorComponent)
        {
            var vehicleDetails = await _context.VehicleDetails
                                                .Where(v => v.ModelId == modelId && v.CompType == exteriorComponent)
                                                .ToListAsync();
            return vehicleDetails;
        }

        public async Task<ActionResult<double?>> GetPriceByModelId(int modelId)
        {
            var model = await _context.Models.FindAsync(modelId);
            if (model == null)
            {
                return new NotFoundResult();
            }

            return model.Price;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByCore(int modelId, string coreComponent)
        {
            var vehicleDetails = await _context.VehicleDetails
                                                .Where(v => v.ModelId == modelId && v.CompType == coreComponent)
                                                .ToListAsync();

            if (vehicleDetails == null || !vehicleDetails.Any())
            {
                return new NotFoundResult();
            }

            return vehicleDetails;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByStandard(int modelId, string standardComponent)
        {
            var vehicleDetails = await _context.VehicleDetails
                                               .Where(v => v.ModelId == modelId && v.CompType == standardComponent)
                                               .ToListAsync();

            if (vehicleDetails == null || !vehicleDetails.Any())
            {
                return new NotFoundResult();
            }

            return vehicleDetails;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetComponentByModelId(int modelId)
        {
            return await _context.VehicleDetails
                                 .Where(v => v.ModelId == modelId && v.CompId != null)
                                 .ToListAsync();
        }

        
    }
}

