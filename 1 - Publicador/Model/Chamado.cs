
using _3_Compartilhado;

namespace _1___Publicador.Model
{
    public class Chamado : IChamado
    {
        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
    }
}
