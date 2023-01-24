using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace AlphaWebApp.Services

{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            _logger = logger;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string messagecontent)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Alpha News", "alphanews@dreammaker-it.se"));
            message.To.Add(new MailboxAddress("Alpha News", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = messagecontent
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.socketlabs.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("server46880", "Pc4g2Q9Bys7WGd");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }


        //public async Task SendEmailAsync(string toEmail, string subject, string message)
        //{
        //    if (string.IsNullOrEmpty(Options.SendGridKey))
        //    {
        //        throw new Exception("Null SendGridKey");
        //    }
        //    await Execute(Options.SendGridKey, subject, message, toEmail);
        //}

        //public async Task Execute(string apiKey, string subject, string message, string toEmail)
        //{
        //    using var client2 = new SmtpClient();
        //    await client2.ConnectAsync("smtp.socketlabs.com");
        //    await client2.AuthenticateAsync("server46880", "Pc4g2Q9Bys7WGd");

        //    var message = new MimeMessage();
        //    message.From = new MailboxAddress("Name", "alpha.team23@outlook.com");

        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("alpha.team23@outlook.com", "Password Recovery"),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };
        //    msg.AddTo(new EmailAddress(toEmail));

        //    // Disable click tracking.
        //    // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        //    msg.SetClickTracking(false, false);
        //    var response = await client.SendEmailAsync(msg);
        //    _logger.LogInformation(response.IsSuccessStatusCode
        //                           ? $"Email to {toEmail} queued successfully!"
        //                           : $"Failure Email to {toEmail}");
        //}
    }
