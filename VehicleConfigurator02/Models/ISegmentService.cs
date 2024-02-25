using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02.Models
{
    public interface ISegmentService
    {
        Task<ActionResult<IEnumerable<Segment>>> GetAllSegment();
    }
}
