using System.Text.RegularExpressions;

namespace _2___ConsumidorEmail.Extensions
{
    public static class StringExtensions
    {

        public static bool IsValidEmailAddress(this string? email)
        {
            if (email.IsNull())
                return false;

            var source = email.Split(';', ',');

            source = source.Where(x => x.IsNotNull())
                           .ToArray();

            if (!source.Any())
                return false;

            var regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");

            foreach (var text in source)
            {
                if (!regex.IsMatch(text.Trim()))
                    return false;
            }

            return true;
        }

        public static bool IsNull(this string? value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNull(this string? value)
        {
            return !string.IsNullOrEmpty(value);
        }

    }
}
