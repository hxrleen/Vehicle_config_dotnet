using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Configuration.Models
{
    public interface IManufacturerService
    {
        Task<ActionResult<IEnumerable<Manufacturer>>> GetAllManufacturer();
        Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturersBySegmentId(int segmentId);
    }
}
