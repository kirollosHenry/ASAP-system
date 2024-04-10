using ASAP_Application.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ASAP_Application.Services.EmailService
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;
        private readonly IClientRepo _clientRepo;

        public Email(IClientRepo clientRepo, IConfiguration configuration)
        {
            _clientRepo = clientRepo;
            _configuration = configuration;
        }


        public async Task SendEmailsToClients()
        {
            var emails = await _clientRepo.GetAllEMail();

        }


        private async Task SendEmailToCustomerAsync()
        {
            string emailContent = "Hello,This is a formatted email message.";
            // Retrieve email settings from configuration
            var emailAddresses = await _clientRepo.GetAllEMail();
            // Retrieve email settings from configuration
            var emailSettings = _configuration.GetSection("EmailSettings");

            // Get values from configuration
            var host = emailSettings["Host"];
            var port = int.Parse(emailSettings["Port"]);
            var senderEmail = emailSettings["SenderEmail"];
            var username = emailSettings["Username"];
            var password = emailSettings["Password"];

            // Use retrieved settings to send the email
            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(username, password);

                foreach (var emailAddress in emailAddresses)
                {
                    // Create and send the email message
                    using (var message = new MailMessage(senderEmail, emailAddress))
                    {
                        message.Subject = "the New";
                        message.Body = emailContent;
                        await client.SendMailAsync(message);
                    }
                }
            }
        }

        Task IEmail.SendEmailToCustomerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
