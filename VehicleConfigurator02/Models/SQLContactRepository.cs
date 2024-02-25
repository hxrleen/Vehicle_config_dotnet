using Microsoft.AspNetCore.Mvc;
using VehicleConfigurator02.DbRepos;

namespace vehicle_conf_dotnet.Models
{
    public class SQLContactRepository : IContactRepository
    {
        private readonly ScottDbContext context;
        
        public SQLContactRepository(ScottDbContext context)
        {
            this.context = context;

        }

        public async Task<ActionResult<ContactU>> Add(ContactU contactUs)
        {
            context.ContactUs.Add(contactUs);
            await context.SaveChangesAsync();
            return contactUs;
        }
    }
}
