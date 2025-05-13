using MimeKit;

namespace Mini_Theatre.Utils
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateVerificationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        public async Task SendVerificationEmailAsync(string email, string verificationCode)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mini Theatre", _configuration["Authentication:Email:EmailAddress"]));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Xác thực email Mini Theatre";
            message.Body = new TextPart("plain")
            {
                Text = $"Mã xác thực của bạn là: {verificationCode}"
            };

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_configuration["Authentication:Email:SmtpServer"], 
                                              int.Parse(_configuration["Authentication:Email:SmtpPort"]),
                                              MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_configuration["Authentication:Email:EmailAddress"],
                                                   _configuration["Authentication:Email:AppPassword"]);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sending mail: " + ex.Message);
                throw;
            }
        }
    }
}
