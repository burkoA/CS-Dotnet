using HomeTask5_2.Entities;

namespace HomeTask5_2
{
    public class Catalog
    {
        private Dictionary<string, Book> _catalog;

        public Catalog()
        {
            _catalog = new Dictionary<string, Book>();
        }

        public void AddBook(string isbn, Book book)
        {
            if (book == null)
                throw new Exception("Book cannot be null!");

            if (!Isbn.IsValidIsbn(isbn))
                throw new Exception("Valid format isbn!");

            string normalIsbn = Isbn.NormalizeISBN(isbn);

            if (_catalog.ContainsKey(normalIsbn))
                throw new Exception("This ISBN is already in use");

            _catalog[normalIsbn] = book;
        }

        public Book GetBookByISBN(string isbn)
        {
            string normalIsbn = Isbn.NormalizeISBN(isbn);

            return _catalog.TryGetValue(normalIsbn, out Book book) ? book : null;
        }

        public IEnumerable<string> SetOfBookBySortedAlphabetically() =>
            _catalog.OrderBy(b => b.Value.Title).Select(t => t.Value.Title);


        public IEnumerable<Book> RetriveBookByAuthorAndSorted(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null");


            return _catalog.Where(b => b.Value.Authors.Contains(author))
                .Select(b => b.Value)
                .OrderBy(p => p.PublicationDate);
        }

        public List<(string, int)> RetriveAuthorAndBook() =>
            _catalog.SelectMany(book => book.Value.Authors)
                .GroupBy(author => author)
                .Select(g => (g.Key, g.Count()))
                .ToList();
    }
}
