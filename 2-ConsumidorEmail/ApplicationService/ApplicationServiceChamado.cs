using _2_ConsumidorEmail.Model;
using MassTransit;

namespace _2_ConsumidorEmail.ApplicationService
{
    public class ApplicationServiceChamado : IConsumer<Chamado>
    {
        public Task Consume(ConsumeContext<Chamado> context)
        {
            var Ttitulo = context.Message.Titulo;
            var Descricao = context.Message.Descricao;

            throw new NotImplementedException();
        }
    }
}
