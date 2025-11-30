using System;
using MimeKit;
using MimeKit.Text;
using System.Runtime;
using ttn_hub.Repository.Interfaces;
using ttn_hub.Models;
using Microsoft.Extensions.Options;
using MailKit.Security;
using MailKit.Net.Smtp;
using ttn_hub.Models.Payloads;

namespace ttn_hub.Repository
{
    public class MailRepository : IMailRepository
    {

        private readonly EmailSettings _settings;

        public MailRepository(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendMail(MailPayload payload)
        {
            try
            {
                var message = BuildMessageBase(payload.to, payload.subject, payload.body);

                using var client = new SmtpClient();
                await client.ConnectAsync(
                    _settings.SmtpServer,
                    _settings.Port,
                    _settings.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto);

                await client.AuthenticateAsync(_settings.UserName, _settings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Mail no enviado, intente de nuevo más tarde - {ex.Message}");
            }
        }

        private MimeMessage BuildMessageBase(string to, string subject, string htmlBody)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.FromName, to));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlBody
            };

            return email;
        }

    }
}

