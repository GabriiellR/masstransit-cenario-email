
using _3_Compartilhado;

namespace _1___Publicador.Model
{
    public class Chamado : IChamado
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string EmailDestinatarioNotificacao { get; set; }
        public List<IFormFile>? Anexos { get; set; }
        public List<byte[]>? ArquivosProcessados { get;  set; }
        public List<string>? ExtensoesArquivos { get; set; }
    }
}
