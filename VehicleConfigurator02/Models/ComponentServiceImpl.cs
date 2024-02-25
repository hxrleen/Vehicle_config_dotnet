using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02.Models
{
    public class ComponentServiceImpl : IComponentService
    {
        private readonly ScottDbContext _context;

        public ComponentServiceImpl(ScottDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Component>>> GetAllComponents()
        {
            var components = await _context.Components.ToListAsync();
            if (components == null)
            {
                return null;
            }
            return components;
        }
    }
}
