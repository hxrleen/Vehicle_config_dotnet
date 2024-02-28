using MailKit;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configuration.DbRepos;
using Vehicle_Configuration.Models;

namespace Vehicle_Configuration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService _mailService;

        public SendMailController(IEmailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok("Sent Successfully");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (log, return error response, etc.)
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
