using _1___Publicador.Model;
using _1___Publicador.Repository;
using _3_Compartilhado;
using MassTransit;

namespace _1___Publicador.ApplicationService
{
    public class ApplicationServiceChamado : IApplicationServiceChamado
    {
        readonly IRepositoryChamado _repositoryChaamado;
        readonly IPublishEndpoint _publish;
        readonly IBus _bus;

        public ApplicationServiceChamado(IRepositoryChamado repositoryChamado,
                                IPublishEndpoint publish, IBus bus)
        {
            _repositoryChaamado = repositoryChamado;
            _publish = publish;
            _bus = bus;
        }

        public async Task<Chamado> CriarChamado(Chamado chamado)
        {
            var chamadoCriado = _repositoryChaamado.CriarChamado(chamado);
            Uri uri = new Uri("rabbitmq://localhost/enviar-email");
            //var endpoint = await _bus.GetSendEndpoint(new Uri("queue:enviar"));
            var endpoint = await _bus.GetSendEndpoint(uri);

            await endpoint.Send<IChamado>(new
            {
                Titulo = chamadoCriado.Titulo,
                Descricao = chamadoCriado.Descricao

            });
            return chamadoCriado;
        }
    }
}
