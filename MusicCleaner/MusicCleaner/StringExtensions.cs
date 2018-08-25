using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicCleaner
{
    public static class StringExtensions
    {
        public static string NoeMsg(this string s)
        {
            return "Argument is null or empty.";
        }

        public static string ReplaceWhiteSpaces(this string s, string newValue)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException(s.NoeMsg(), nameof(s));
            }

            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            return Regex.Replace(s, @"\s+", newValue);
        }

        public static string ReplaceWhiteSpaces(this string s, char newChar)
        {
            return ReplaceWhiteSpaces(s, newChar.ToString());
        }

        public static string ToCamel(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException(s.NoeMsg(), nameof(s));
            }

            s = s.ToLower();

            var parts = s.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            foreach (var part in parts)
            {
                sb.Append(FirstCharToUpper(part));
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        private static string FirstCharToUpper(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            if (s.Count() == 1)
            {
                return s.ToUpper();
            }

            return s.First().ToString().ToUpper() + s.Substring(1);
        }
    }
}
