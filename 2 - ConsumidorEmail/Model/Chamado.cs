using _3_Compartilhado;

namespace _2___ConsumidorEmail.Model
{
    public class Chamado : IChamado
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
