using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Vehicle_Configuration.DbRepos;


namespace Vehicle_Configuration.Models
{
    public class EmailServiceImpl : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailServiceImpl(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            // Use the same format for subject and body
            var content = $"Enquiry Of {mailRequest.Name})";

            email.Subject = content;

            var builder = new BodyBuilder();
             if (mailRequest.Attachments != null)
            {
                byte[] filebytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            filebytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            // Include  the user's message
            builder.HtmlBody =
                $"Thanks for reaching out to us. We appreciate your interest in our business." +
                $" any further questions, feel free to call us at 6445 ." +
                $"Sincerely.: {mailRequest.Body}";

            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                    await smtp.SendAsync(email);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }

        }
    }
}
