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
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:enviar-email"));

            var arquivosProcessados = ConverterIFormFileParaArrayBytes(chamado.Anexos);
            var extensoesArquivos = GetFilenamesArquivo(chamado.Anexos);

            await endpoint.Send<IChamado>(new
            {
                Titulo = chamadoCriado.Titulo,
                Descricao = chamadoCriado.Descricao,
                EmailDestinatarioNotificacao = chamadoCriado.EmailDestinatarioNotificacao,
                ArquivosProcessados = arquivosProcessados,
                ExtensoesArquivos = extensoesArquivos,
            });

            return chamadoCriado;
        }

        private List<byte[]> ConverterIFormFileParaArrayBytes(List<IFormFile> arquivos)
        {
            if (arquivos is null)
                return new List<byte[]>();

            List<byte[]> arquivosProcessados = new List<byte[]>();

            foreach (IFormFile arquivo in arquivos)
            {
                using (var memoryStream = new MemoryStream())
                {
                    arquivo.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    arquivosProcessados.Add((fileBytes));
                }
            }

            return arquivosProcessados;
        }
        private List<string> GetFilenamesArquivo(List<IFormFile> arquivos)
        {
            if (arquivos is null)
                return new List<string>();

            var filenames = new List<string>();

            foreach (var arquivo in arquivos)
            {
                filenames.Add(arquivo.FileName);
            }

            return filenames;
        }
    }
}
