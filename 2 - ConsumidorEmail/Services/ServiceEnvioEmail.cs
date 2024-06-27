using _2___ConsumidorEmail.Extensions;
using _2___ConsumidorEmail.Model;
using MailKit.Net.Smtp;
using MimeKit;

namespace _2___ConsumidorEmail.Services
{
    public class ServiceEnvioEmail : IServiceEnvioEmail
    {
        MimeMessage? _mailMessage;
        BodyBuilder? _bodyBuilder;
        ParametrosEmail _parametrosEmail;
        List<string>? arquivosTemporarios;

        public IServiceEnvioEmail Criar()
        {
            _mailMessage = new MimeMessage();
            _bodyBuilder = new BodyBuilder();
            arquivosTemporarios = new List<string>();
            _parametrosEmail = new ParametrosEmail();

            return this;
        }

        public IServiceEnvioEmail AdicionarRemetente()
        {
            var email = FazerLeituraAppSettings("email");

            _mailMessage.From.Add(MailboxAddress.Parse(email));

            return this;
        }

        public IServiceEnvioEmail AdicionarDestinatario(string emailDestinatario)
        {
            if (_mailMessage is null || !emailDestinatario.IsValidEmailAddress())
                return this;

            _mailMessage.To.Add(MailboxAddress.Parse(emailDestinatario));
            return this;
        }


        public IServiceEnvioEmail AdicionarAnexo(List<IFormFile> anexos)
        {
            if (_bodyBuilder is null || arquivosTemporarios is null)
                return this;


            foreach (var anexo in anexos)
            {
                var tempPath = Path.GetTempPath();
                var tempFile = Path.Combine(tempPath, anexo.FileName);

                anexo.MoveTo(tempPath);

                _bodyBuilder.Attachments.Add(tempFile);
                arquivosTemporarios.Add(tempFile);
            }


            return this;
        }

        public IServiceEnvioEmail AdicionarAssunto(string assunto)
        {
            if (_mailMessage is null || assunto.IsNull())
                return this;

            _mailMessage.Subject = assunto;

            return this;
        }

        public IServiceEnvioEmail AdicionarCorpo(string corpo)
        {
            if (_mailMessage is null || _bodyBuilder is null || corpo.IsNull())
                return this;


            _bodyBuilder.TextBody = corpo;

            return this;
        }


        public IServiceEnvioEmail MontarCorpoEmail()
        {
            if (_mailMessage is null || _bodyBuilder is null)
                return this;

            _mailMessage.Body = _bodyBuilder.ToMessageBody();

            return this;
        }

        public bool Enviar()
        {
            try
            {
                var email = FazerLeituraAppSettings("email");
                var senha = FazerLeituraAppSettings("senha");


                using var client = new SmtpClient();


                client.Connect(_parametrosEmail.Host, _parametrosEmail.Port, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(email, senha);
                client.Send(_mailMessage);
                client.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar o e-mail. {ex.Message}");
            }
            finally
            {
                if (arquivosTemporarios != null && arquivosTemporarios.Any())
                {
                    foreach (var anexo in arquivosTemporarios)
                    {
                        try
                        {
                            if (File.Exists(anexo))
                            {
                                File.Delete(anexo);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }


        private string FazerLeituraAppSettings(string section)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                         .AddJsonFile("appsettings.json")
                                                         .Build();

            return configuration.GetSection(section).Value;
        }
    }
}
