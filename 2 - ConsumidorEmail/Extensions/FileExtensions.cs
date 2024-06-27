namespace _2___ConsumidorEmail.Extensions
{
    public static class FileExtensions
    {
        public static string MoveTo(this IFormFile? arquivo, string diretorioDestino)
        {
            if (arquivo is null)
                return string.Empty;

            var nomeArquivo = Path.GetFileName(arquivo.FileName);
            var novoArquivo = Path.Combine(diretorioDestino, nomeArquivo);

            using (var fileStream = new FileStream(novoArquivo, FileMode.Create))
            {
                arquivo.CopyTo(fileStream);
            }

            return novoArquivo;
        }

        public static string GetExtension(this IFormFile file)
        {
            if (file is null)
                return string.Empty;

            return Path.GetExtension(file.FileName);
        }
    }
}
