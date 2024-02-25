using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System;
using Vehicle_Configuration.Models;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Configuration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        
        [HttpPost]
        public async Task<ActionResult<FeedbackEntity>> PostFeedback(FeedbackEntity feedback)
        {

            await _feedbackRepository.Add(feedback);


            return CreatedAtAction("PostFeedback", new { Name = feedback.Name}, feedback);
        }



    }
}
