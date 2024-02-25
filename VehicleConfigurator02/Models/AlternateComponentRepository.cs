using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfigurator02.Models
{
    public class AlternateComponentRepository : IAlternateComponentRepository
    {
            private readonly ScottDbContext _context;

            public AlternateComponentRepository(ScottDbContext context)
            {
                _context = context;
            }

            public async Task<List<AlternateComponent>> FindByModelIdAndCompId(int modelId, int compId)
            {
                return await _context.AlternateComponents
                    .Where(ac => ac.ModelId == modelId && ac.AltCompId == compId)
                    .ToListAsync();
            }

            public async Task<AlternateComponent> FindAlternateCompByModelIdAndCompId(int modelId, int compId)
            {
                return await _context.AlternateComponents
                    .FirstOrDefaultAsync(ac => ac.ModelId == modelId && ac.CompId == compId);
            }
        }

    }
