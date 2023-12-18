using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Notification.API;

namespace Notification.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly SmtpService _smtpService;

        public NotificationController(IConfiguration configuration)
        {
            var fromEmail = configuration["appsettings:FromEmail"];
            var fromName = configuration["appsettings:FromName"];
            var smtpServer = configuration["appsettings:Host"];
            var smtpPort = int.Parse(configuration["appsettings:Port"]);
            var sender = configuration["appsettings:Username"];
            var senderPassword = configuration["appsettings:Password"];

            _smtpService = new SmtpService(fromEmail, fromName, smtpServer, smtpPort, sender, senderPassword);
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendEmail(string recipient, string subject, string body)
        {
            if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return BadRequest("Все поля обязательны для заполнения.");
            }

            try
            {
                await _smtpService.SendEmailAsync(recipient, subject, body);
                return Ok("Сообщение отправлено.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка отправки сообщения.");
            }
        }
    }
}
