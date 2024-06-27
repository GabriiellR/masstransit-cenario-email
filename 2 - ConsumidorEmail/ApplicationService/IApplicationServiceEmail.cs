using RabbitMQ.Client;

namespace _2___ConsumidorEmail.ApplicationService
{
    public interface IApplicationServiceEmail
    {
        void EnviarEmail(string titulo, string descricao, string destinatario, List<IFormFile> anexo);
    }
}
