using System.Text.RegularExpressions;

namespace HomeTask6.Entities
{
    public static class Isbn
    {
        private static readonly Regex isbnFormat = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");

        public static bool IsValid(string isbn) => 
            !string.IsNullOrWhiteSpace(isbn) && isbnFormat.IsMatch(isbn);

        public static string NormalizeISBN(string isbn) => 
            isbn.Replace("-", "");
    }
}
