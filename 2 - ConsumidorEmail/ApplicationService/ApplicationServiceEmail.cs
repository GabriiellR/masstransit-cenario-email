using _2___ConsumidorEmail.Services;

namespace _2___ConsumidorEmail.ApplicationService
{
    public class ApplicationServiceEmail : IApplicationServiceEmail
    {
        readonly IServiceEnvioEmail _serviceEnvioEmail;

        public ApplicationServiceEmail(IServiceEnvioEmail serviceEnvioEmail)
        {
            _serviceEnvioEmail = serviceEnvioEmail;
        }

        public void EnviarEmail(string titulo, string descricao, string destinatario, List<IFormFile> anexos)
        {
            try
            {
                _serviceEnvioEmail.Criar()
                                  .AdicionarRemetente()
                                  .AdicionarDestinatario(destinatario)
                                  .AdicionarAssunto(titulo)
                                  .AdicionarCorpo(descricao)
                                  .AdicionarAnexo(anexos)
                                  .MontarCorpoEmail()
                                  .Enviar();
            }
            catch (Exception ex) { }

        }
    }
}
