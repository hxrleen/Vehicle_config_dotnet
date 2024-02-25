using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Configuration.Models
{
    public class ManufacturerServiceImpl : IManufacturerService
    {
        private readonly ScottDbContext context;

        public ManufacturerServiceImpl(ScottDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAllManufacturer()
        {
            if(context.Manufacturers==null)
            {
                return null;
            }
            return await context.Manufacturers.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturersBySegmentId(int segmentId)
        {
            return await context.Manufacturers.Where(m => m.SegId == segmentId).ToListAsync();  
        }
    }
}
