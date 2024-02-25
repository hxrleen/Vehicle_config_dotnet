using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;
using VehicleConfigurator02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace VehicleConfigurator02.Controllers
{
    public class AlternateComponentController : ControllerBase
    {

            private readonly IAlternateComponentRepository _repository;

            public AlternateComponentController(IAlternateComponentRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<ActionResult<List<AlternateComponent>>> GetAlternateComponents(int modelId, int compId)
            {
                var alternateComponents = await _repository.FindByModelIdAndCompId(modelId, compId);

                if (alternateComponents == null || !alternateComponents.Any())
                {
                    return NotFound();
                }

                return alternateComponents;
            }

            [HttpGet("{modelId}/{compId}")]
            public async Task<ActionResult<AlternateComponent>> GetAlternateComponent(int modelId, int compId)
            {
                var alternateComponent = await _repository.FindAlternateCompByModelIdAndCompId(modelId, compId);

                if (alternateComponent == null)
                {
                    return NotFound();
                }

                return alternateComponent;
            }
        }

    }