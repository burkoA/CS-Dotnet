using System.Text.RegularExpressions;

namespace HomeTask5_2.Entities
{
    public static class Isbn
    {
        private static readonly Regex isbnForm = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");

        public static bool IsValidIsbn(string isbn) =>
            !string.IsNullOrWhiteSpace(isbn) && isbnForm.IsMatch(isbn);


        public static string NormalizeISBN(string isbn) =>
            isbn.Replace("-", "");
    }
}
