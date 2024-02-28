using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfigurator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModel model;

        public ModelController(IModel model)
        {
            this.model = model;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>?>> GetModel()
        {
            if (await model.GetAllModel() == null)
            {
                return NotFound();
            }

            return await model.GetAllModel();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Assuming you have a method in your repository to get a model by id
                var _model = await model.GetById(id);

                if (_model == null)
                {
                    return NotFound(); // Return 404 if model with given id is not found
                }

                return Ok(_model); // Return 200 with the model if found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Return 500 if any error occurs
            }
        }

        [HttpGet("api/Model/{Seg_id}/{Mfg_id}")]
        public async Task<ActionResult<List<Model>>> GetVariantList(int Seg_id, int Mfg_id)
        {
            var models = await model.GetVariantList(Seg_id, Mfg_id);

            if (models == null)
            {
                return NotFound();
            }

            return models;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
