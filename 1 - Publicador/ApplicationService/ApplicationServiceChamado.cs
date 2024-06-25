using _1___Publicador.Model;
using _1___Publicador.Repository;
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
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:enviar-email"));

            endpoint.Send<Chamado>(new
            {
                Titutlo = chamadoCriado.Titulo,
                Descricao = chamadoCriado.Descricao

            });
            return chamadoCriado;
        }
    }
}
