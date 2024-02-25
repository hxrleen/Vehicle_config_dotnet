using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace Vehicle_Configuration.Models
{
    public interface IFeedbackRepository
    {
        Task<ActionResult<FeedbackEntity>> Add(FeedbackEntity feedback);
    }
}
