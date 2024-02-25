using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;
namespace Vehicle_Configuration.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ScottDbContext _dbContext;

        public FeedbackRepository(ScottDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<FeedbackEntity>> Add(FeedbackEntity feedback)
        {
            _dbContext.FeedbackEntities.Add(feedback);
            await _dbContext.SaveChangesAsync();
            return feedback;
        }
    }
}
