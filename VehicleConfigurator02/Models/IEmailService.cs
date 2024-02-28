using Vehicle_Configuration.DbRepos;

namespace Vehicle_Configuration.Models
{
    public interface IEmailService
    {
        public Task SendEmailAsync(MailRequest mailRequest);
    }
}
