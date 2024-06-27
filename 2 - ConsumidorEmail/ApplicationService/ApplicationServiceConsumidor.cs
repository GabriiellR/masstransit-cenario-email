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
                var arquivosProcessados = context.Message.ArquivosProcessados;
                var nomeArquivos = context.Message.ExtensoesArquivos;

                var anexos = ConverterArrayByteParaIFormFile(arquivosProcessados, nomeArquivos);

                var titulo = context.Message.Titulo;
                var descricao = context.Message.Descricao;
                var destinatario = context.Message.EmailDestinatarioNotificacao;
                var anexo = anexos;
                var anexoProcessado = context.Message.ArquivosProcessados;


                _applicationServiceEmail.EnviarEmail(titulo, descricao, destinatario, anexo);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consumir mensagem");
            }
        }

        private List<IFormFile> ConverterArrayByteParaIFormFile(List<byte[]> arquivosProcessados, List<string> nomeArquivos)
        {

            List<IFormFile> arquivosConvertidos = new List<IFormFile>();

            for (var i = 0; i < arquivosProcessados.Count; i++)
            {
                var stream = new MemoryStream(arquivosProcessados[i]);
                arquivosConvertidos.Add(new FormFile(stream, 0, arquivosProcessados[i].Length, "arquivo", nomeArquivos[i]));
            }

            return arquivosConvertidos;
        }
    }
}
