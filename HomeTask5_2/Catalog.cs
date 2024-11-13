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

        public void AddBook(Isbn isbn, Book book)
        {
            if (book == null)
                throw new Exception("Book cannot be null!");

            string normalIsbn = Isbn.NormalizeISBN(isbn.ISBN);

            if (_catalog.ContainsKey(normalIsbn))
                throw new Exception("This ISBN is already in use");

            _catalog[normalIsbn] = book;
        }

        public Book GetBookByISBN(string isbn)
        {
            string normalIsbn = Isbn.NormalizeISBN(isbn);

            return _catalog.TryGetValue(normalIsbn, out Book book) ? book : null;
        }

        public List<(string, Book)> SetOfBookBySortedAlphabetically() =>
            _catalog.OrderBy(b => b.Value.Title)
            .Select(b => (b.Key, b.Value))
            .ToList();


        public List<(string, Book)> RetriveBookByAuthorAndSorted(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
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
