using CleanArch.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CleanArch.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailService( ILogger<EmailService> logger)
        {

        }

    }
}
