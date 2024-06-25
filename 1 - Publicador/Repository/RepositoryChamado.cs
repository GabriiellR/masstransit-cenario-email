using _1___Publicador.Model;

namespace _1___Publicador.Repository
{
    public class RepositoryChamado : IRepositoryChamado
    {
        public Chamado CriarChamado(Chamado chamado)
        {
            return chamado;
            //TODO: SIMULAR BANCO DE DADOS;
        }
    }
}
