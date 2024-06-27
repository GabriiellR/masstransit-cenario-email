namespace _2___ConsumidorEmail.Services
{
    public interface IServiceEnvioEmail
    {
        IServiceEnvioEmail Criar();
        IServiceEnvioEmail AdicionarRemetente();
        IServiceEnvioEmail AdicionarDestinatario(string emailDestinatario);
        IServiceEnvioEmail AdicionarAnexo(List<IFormFile> anexos);
        IServiceEnvioEmail AdicionarAssunto(string assunto);
        IServiceEnvioEmail AdicionarCorpo(string corpo);
        IServiceEnvioEmail MontarCorpoEmail();
        bool Enviar();


    }
}
