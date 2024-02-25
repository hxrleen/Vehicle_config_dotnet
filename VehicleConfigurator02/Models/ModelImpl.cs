using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VehicleConfigurator02.DbRepos;

namespace VehicleConfigurator02.Models
{
    public class ModelImpl : IModel
    {
        private readonly ScottDbContext context;

        public ModelImpl(ScottDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Model>>> GetAllModel()
        {
            if(context.Models==null)
            {
                return null;
            }
            return await context.Models.ToListAsync();
        }

        
        public async Task<Model> GetById(int id)
        {
            // Assuming Models is a DbSet<Model> in ScottDbContext
            return await context.Models.FindAsync(id);
        }

        public async Task<List<Model>> GetVariantList(int Seg_id, int Mfg_id)
        {
            return await context.Models
                                .Where(m => m.SegId == Seg_id && m.MfgId == Mfg_id)
                                .ToListAsync();
        }
    }
}
