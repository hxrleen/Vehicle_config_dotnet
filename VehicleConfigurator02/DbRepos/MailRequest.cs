// MailRequest.cs

namespace Vehicle_Configuration.DbRepos
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string ToEmail {  get; set; }
       
        public string Body { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
