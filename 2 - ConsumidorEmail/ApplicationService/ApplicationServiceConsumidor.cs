using _2___ConsumidorEmail.Model;
using _3_Compartilhado;
using MassTransit;

namespace _2___ConsumidorEmail.ApplicationService
{
    public class ApplicationServiceConsumidor : IConsumer<IChamado>
    {
        readonly IApplicationServiceEmail _applicationServiceEmail;

        public ApplicationServiceConsumidor(IApplicationServiceEmail applicationServiceEmail)
        {
            _applicationServiceEmail = applicationServiceEmail;
        }

        public Task Consume(ConsumeContext<IChamado> context)
        {
            try
            {
                var titulo = context.Message.Titulo;
                var descricao = context.Message.Descricao;

                _applicationServiceEmail.EnviarEmail(titulo, descricao);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
