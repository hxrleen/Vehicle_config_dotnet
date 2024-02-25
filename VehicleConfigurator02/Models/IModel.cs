using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;


namespace VehicleConfigurator02.Models
{
    public interface IModel
    {
        Task<ActionResult<IEnumerable<Model>>> GetAllModel();

        Task<Model> GetById(int id);

        Task<List<Model>> GetVariantList(int Seg_id, int Mfg_id);
    }
}
