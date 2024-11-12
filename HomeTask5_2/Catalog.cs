using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HomeTask5_2
{
    public class Catalog
    {
        private Dictionary<string, Book> _catalog;
        private static Regex isbnForm = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");
        public Catalog()
        {
            _catalog = new Dictionary<string, Book>();
        }

        public void AddBook(string isbn, Book book)
        {
            if (book == null)
                throw new Exception("Book cannot be null!");

            if (!isbnForm.IsMatch(isbn) || string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("Invalid format");


            string normalIsbn = NormalizeISBN(isbn);

            if (_catalog.ContainsKey(normalIsbn))
                throw new Exception("This ISBN is already in use");

            _catalog[normalIsbn] = book;
        }

        public Book GetBookByISBN(string isbn)
        {
            string normalIsbn = NormalizeISBN(isbn);

            return _catalog.TryGetValue(normalIsbn, out Book book) ? book : null;
        }

        private string NormalizeISBN(string isbn)
        {
            return isbn.Replace("-", "");
        }

        public List<(string,Book)> SetOfBookBySortedAlphabetically() => 
            _catalog.OrderBy(b => b.Value.Title)
            .Select(b => (b.Key, b.Value))
            .ToList();


        public List<(string, Book)> RetriveBookByAuthorAndSorted(string author)
        {
            if(string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be null");
            }

            var result = _catalog.Where(a => a.Value.Authors.Contains(author)).OrderBy(d => d.Value.PublicationDate).Select(a => (a.Key, a.Value)).ToList();

            return result;
        }

        public List<(string, int)> RetriveAuthorAndBook() =>
            _catalog.SelectMany(book => book.Value.Authors)
                .GroupBy(author => author)
                .Select(g => (g.Key, g.Count()))
                .ToList();
    }
}
