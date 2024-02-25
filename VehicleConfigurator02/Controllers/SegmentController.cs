using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
       /* public IActionResult Index()
        {
            return View();
        }*/

        private readonly ISegmentService _service;
        public SegmentController(ISegmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segment>?>> GetSegment()
        {
            if (await _service.GetAllSegment() == null)
            {
                return NotFound();
            }

            return await _service.GetAllSegment();
        }

    }
}
