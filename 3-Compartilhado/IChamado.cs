using Microsoft.AspNetCore.Http;

namespace _3_Compartilhado
{
    public interface IChamado
    {
        string Titulo { get; set; }
        string Descricao { get; set; }
        string EmailDestinatarioNotificacao { get; set; }
        List<IFormFile>? Anexos { get; set; }
        List<byte[]>? ArquivosProcessados { get; set; }
        List<string>? ExtensoesArquivos { get; set; }    
    }
}