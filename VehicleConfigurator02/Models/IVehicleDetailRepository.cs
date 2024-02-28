using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Conf.Models
{
    public interface IVehicleDetailRepository
    {
        Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByModelId(int modelId);

        Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByInterior(int modelId, string interiorComponent);

        Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByExterior(int modelId, string exteriorComponent);

        Task<ActionResult<double?>> GetPriceByModelId(int modelId);

        Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByCore(int modelId, string coreComponent);

        Task<ActionResult<IEnumerable<VehicleDetail>?>> GetVehicleDetailsByStandard(int modelId, string standardComponent);
    }
}
