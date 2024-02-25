using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfig.Models
{
    public class VehicleDetailRepository: IVehicleDetailRepository
    {
        private readonly ScottDbContext _context;

        public VehicleDetailRepository(ScottDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>?>> GetAllVehicleDetail()
        {
            // Retrieve all vehicle details asynchronously
            return await _context.VehicleDetails.ToListAsync();
        }

        public async Task<ActionResult<VehicleDetail>?> GetVehicleDetailById(int id)
        {
            // Find the vehicle detail by ID asynchronously
            var vehicleDetail = await _context.VehicleDetails.FindAsync(id);

            if (vehicleDetail == null)
            {
                // If the vehicle detail is not found, return null
                return null;
            }

            // Return the vehicle detail
            return vehicleDetail;
        }
    }
}