using HomeTask7.Entities.BookType;
using HomeTask7.Utilities;

namespace HomeTask7.Entities.BookEntities
{
    public class Catalog
    {
        public Dictionary<string, Book> BooksCatalog { get; set; }

        public Catalog()
        {
            BooksCatalog = new Dictionary<string, Book>();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return BooksCatalog.TryGetValue(isbn, out Book book) ? book : null;
        }

        public void AddBook(string isbn, Book book)
        {
            if (book == null)
                throw new Exception("Book cannot be null!");

            if (!KeyValidator.IsValid(isbn))
                return;

            string normalIsbn = Isbn.NormalizeISBN(isbn);

            if (BooksCatalog.ContainsKey(normalIsbn))
                return;

            BooksCatalog[normalIsbn] = book;
        }

        public IEnumerable<string> SetOfBookBySortedAlphabetically() =>
            BooksCatalog.OrderBy(b => b.Value.Title).Select(t => t.Value.Title);


        public IEnumerable<Book> RetriveBookByAuthorAndSorted(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null");


            return BooksCatalog
                .Where(b => b.Value.Authors.Any(a => $"{a.FirstName} {a.LastName}".Contains(author)))
                .Select(b => b.Value)
                .OfType<PaperBook>()
                .OrderBy(p => p.PublicationDate);
        }

        public List<(string, int)> RetriveAuthorAndBook() =>
            BooksCatalog.SelectMany(book => book.Value.Authors)
                .GroupBy(author => $"{author.FirstName} {author.LastName}")
                .Select(g => (g.Key, g.Count()))
                .ToList();
    }
}
