using _2___ConsumidorEmail.Model;
using MassTransit;

namespace _2___ConsumidorEmail.Application
{
    public class ApplicationConsumidor : IConsumer<Chamado>
    {
        public Task Consume(ConsumeContext<Chamado> context)
        {
            var Ttitulo = context.Message.Titutlo;
            var Descricao = context.Message.Descricao;

         

            throw new NotImplementedException();
        }
    }
}
