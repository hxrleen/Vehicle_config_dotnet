using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfigurator02.Models
{
    public interface IAlternateComponentRepository
    {

            Task<List<AlternateComponent>> FindByModelIdAndCompId(int modelId, int compId);
            Task<AlternateComponent> FindAlternateCompByModelIdAndCompId(int modelId, int compId);

    }
}
