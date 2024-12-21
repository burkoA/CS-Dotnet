using System.Text.RegularExpressions;

namespace HomeTask7.Utilities
{
    public static class KeyValidator
    {
        private static string isbnPattern = @"^(?:\d{9}[\dX]|\d{13})$";
        private static string linkPattern = @"^[a-zA-Z0-9\-]+$";

        public static bool IsValid(string input)
        {
            if (Regex.IsMatch(input, isbnPattern))
            {
                return true;
            }
            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, linkPattern))
            {
                return true;
            }

            return false;
        }

        public static bool CheckForIsbn(string input) =>
            Regex.IsMatch(input, isbnPattern);

        public static bool CheckForLink(string input) =>
            Regex.IsMatch(input, linkPattern);

    }
}
