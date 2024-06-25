using System.Net;
using System.Net.Mail;

namespace _2___ConsumidorEmail.ApplicationService
{
    public class ApplicationServiceEmail : IApplicationServiceEmail
    {
        public void EnviarEmail(string titulo, string descricao)
        {

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json")
                                                          .Build();

            var email = configuration.GetSection("email").Value;
            var senha = configuration.GetSection("senhaEmail").Value;

            MailAddress to = new MailAddress("coordenacao.ti@somalogistica.com.br");
            MailAddress from = new MailAddress(email);
            MailMessage emailAdress = new MailMessage(from, to);

            emailAdress.Subject = titulo;
            emailAdress.Body = descricao;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.office365.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(email, senha);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            try
            {
                smtpClient.Send(emailAdress);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
