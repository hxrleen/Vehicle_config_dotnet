using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfig.Models
{
    public interface IVehicleDetailRepository
    {
        Task<ActionResult<VehicleDetail>?> GetVehicleDetailById(int Id);
        Task<ActionResult<IEnumerable<VehicleDetail>>> GetAllVehicleDetail();
    }
}