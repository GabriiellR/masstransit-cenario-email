using _1___Publicador.Model;

namespace _1___Publicador.ApplicationService
{
    public interface IApplicationServiceChamado
    {
        Task<Chamado> CriarChamado(Chamado chamado);
    }
}
