using Microsoft.AspNetCore.Mvc;
using vehicle_conf_dotnet.Models;
using VehicleConfigurator02.DbRepos;

namespace vehicle_conf_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        public readonly IContactRepository _repository;


        public ContactUsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<ContactU>> PostContact(ContactU contact)
        {
            await _repository.Add(contact);
            return CreatedAtAction("PostContact", new { id = contact.Id }, contact);
        }
    }
}
