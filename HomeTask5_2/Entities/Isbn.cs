using System.Text.RegularExpressions;

namespace HomeTask5_2.Entities
{
    public class Isbn
    {
        private static Regex isbnForm = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");

        public string ISBN { get; set; }

        public Isbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn) || !isbnForm.IsMatch(isbn))
                throw new ArgumentException("Invalid isbn format!");

            ISBN = isbn;
        }

        public static string NormalizeISBN(string isbn)
        {
            return isbn.Replace("-", "");
        }
    }
}
