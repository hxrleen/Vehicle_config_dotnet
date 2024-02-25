using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02.Models
{
    public class SegmentServiceImpl : ISegmentService
    {
        private readonly ScottDbContext context;

        public SegmentServiceImpl(ScottDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Segment>>> GetAllSegment()
        {
            if(context.Segments==null)
            {
                return null;
            }
            return await context.Segments.ToListAsync();
        }
    }
}
